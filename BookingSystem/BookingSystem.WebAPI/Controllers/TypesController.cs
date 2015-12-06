using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookingSystem.Service.Contracts;
using BookingSystem.WebAPI.Models;

namespace BookingSystem.WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Type")]
    public class TypesController : ApiController
    {
        private ITypeService _typeService;
        public TypesController(ITypeService typeService)
        {
            _typeService = typeService;
        }

        [Route("GetTypes")]
        public IHttpActionResult GetTypes()
        {
            var types = new List<TypeViewModel>();
            var result = _typeService.GetTypes();
            result.ForEach(c =>
            {
                var item = new TypeViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                };
                types.Add(item);
            });
            return Ok(types);
        }
    }
}