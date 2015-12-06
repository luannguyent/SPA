using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookingSystem.DataAccess.UserManager
{
    public interface IUserManager
    {
        Task<IdentityResult> RegisterUser(User userModel);
        Task<IdentityUser> FindUser(string userName, string password);
        bool IsAdministrator(string userName);
    }
}
