using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Entities;

namespace BookingSystem.Service.Contracts
{
    public interface IPropertyService
    {
        List<Property> GetPropertiesByType(int typeId);
    }
}
