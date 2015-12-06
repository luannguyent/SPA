using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.DataAccess.Contracts;
using BookingSystem.Entities;
using BookingSystem.Service.Contracts;

namespace BookingSystem.Service.Implements
{
    public class PropertyService : IPropertyService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PropertyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Property> GetPropertiesByType(int typeId)
        {
            var query = _unitOfWork.Repository<Property>().Gets(c => c.TypeId == typeId);
            return query.ToList();
        } 
    }
}
