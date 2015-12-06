using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Core.Infrastructure;

namespace BookingSystem.Entities
{
    public class Type : EntityBase
    {
        public string Name { get; set; }

        public virtual ICollection<Property> Properties { get; set; }

    }
}
