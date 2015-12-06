using System;
using System.Collections.Generic;
using System.Linq;
using BookingSystem.DataAccess.Contracts;
using BookingSystem.Service.Contracts;
using BookingSystem.Entities;
using Type = BookingSystem.Entities.Type;

namespace BookingSystem.Service.Implements
{
    public class TypeService : ITypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<Type> GetTypes()
        {
            var query = _unitOfWork.Repository<Type>().GetAll();
            return query.ToList();
        }
    }
}
