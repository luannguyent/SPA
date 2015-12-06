using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = BookingSystem.Entities.Type;
namespace BookingSystem.Service.Contracts
{
    public interface ITypeService
    {
        List<Type> GetTypes();
    }
}
