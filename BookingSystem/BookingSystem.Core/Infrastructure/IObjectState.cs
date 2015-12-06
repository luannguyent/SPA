using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.Core.Infrastructure
{
    public interface IObjectState
    {
        [NotMapped]
        ObjectState ObjectState { get; set; }
    }
}
