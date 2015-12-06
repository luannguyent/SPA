using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Core.Infrastructure;

namespace BookingSystem.Entities
{
    public abstract class EntityBase:IObjectState,IAuditableEntity
    {
        public int Id { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime CreateAt { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}
