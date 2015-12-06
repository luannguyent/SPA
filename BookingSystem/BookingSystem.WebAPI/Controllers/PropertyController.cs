using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookingSystem.Entities;
using BookingSystem.Service.Contracts;
using BookingSystem.WebAPI.Models;

namespace BookingSystem.WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Property")]
    public class PropertyController : ApiController
    {
        private readonly IPropertyService _propertyService;
        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [Route("GetPropertiesByType")]
        [HttpGet]
        public IHttpActionResult GetPropertiesByType(int typeId)
        {
            var result = _propertyService.GetPropertiesByType(typeId);
            var properties = new List<PropertyViewModel>();
            result.ForEach(c =>
            {
                var item = new PropertyViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                };
                properties.Add(item);
            });
            return Ok(properties);
        }
    }
}