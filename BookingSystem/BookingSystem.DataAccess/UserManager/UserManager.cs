using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.DataAccess.Contracts;
using BookingSystem.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookingSystem.DataAccess.UserManager
{
    public class UserManager : IUserManager
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager; 
        public UserManager(IDataContext dataContext)
        {
            var ctx = dataContext as DbContext;
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(ctx));
            _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(ctx));
        }

        public async Task<IdentityResult> RegisterUser(User userModel)
        {
            var user = new IdentityUser
            {
                UserName = userModel.UserName,
                
            };
            var result = await _userManager.CreateAsync(user, userModel.Password);
            if (result.Succeeded)
            {
                const string roleName = "Administrator";
                if (!_roleManager.RoleExists(roleName))
                {
                    _roleManager.Create(new IdentityRole(roleName));
                }
                _userManager.AddToRole(user.Id, roleName);
            }
            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public bool IsAdministrator(string userName)
        {
            IdentityUser user = _userManager.FindByName(userName);
            return _userManager.IsInRole(user.Id, "Administrator");
        }
    }
}
