namespace BookingSystem.Entities
{
    public class Property : EntityBase
    {
        public string Name { get; set; }

        public int TypeId { get; set; }

        public virtual Type Type { get; set; }

    }
}
