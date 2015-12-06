using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookingSystem.WebAPI.Models
{
    public class ReservationViewModel : IValidatableObject
    {
        public int? Id { get; set; }
        public string Comment { get; set; }
        public string ActionType { get; set; }
        [Required]
        public int SelectedType { get; set; }
        [Required]
        public int SelectedProperty { get; set; }

        [Required]
        public DateTime StartDate
        {
            get
            {
                return string.IsNullOrEmpty(StrStartTime) ? DateTime.Now : DateTime.Parse(StrStartTime);
            }
        }

        [Required]
        public DateTime EndDate
        {
            get
            {
                return string.IsNullOrEmpty(StrEndTime) ? DateTime.Now : DateTime.Parse(StrEndTime);
            }
        }

        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string StrStartTime { get; set; }
        public string StrEndTime { get; set; }
        [Required]
        public string Description { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartDate >= EndDate)
            {
                yield return new ValidationResult("The end date must be greater than start date", new[] { "Date" });
            }
        }
    }
}