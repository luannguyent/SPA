using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Core.Infrastructure
{
    public interface IAuditableEntity
    {
        DateTime UpdateAt { get; set; }
        DateTime CreateAt { get; set; }
        string CreateBy { get; set; }
        string UpdateBy { get; set; }
    }
}
