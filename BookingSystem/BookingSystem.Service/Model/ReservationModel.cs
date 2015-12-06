using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Service.Model
{
    public class ReservationModel
    {
        public int Id { get; set; }
        public string ReservationNumber { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string PropertyName { get; set; }
        public string TypeName { get; set; }
        public string UserName { get; set; }
    }
}
