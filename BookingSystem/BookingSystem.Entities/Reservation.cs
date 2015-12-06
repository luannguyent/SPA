using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Core.Infrastructure;

namespace BookingSystem.Entities
{
    public class Reservation : EntityBase
    {
        public string ReservationNumber { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PropertyId { get; set; }

        public string Comment { get; set; }
        public virtual Property Property { get; set; }
    }
}
