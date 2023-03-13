namespace FleetInventoryManagement.Models
{
    public class Fleet
    {
        public int FleetId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }

        public virtual int CustomerId { get; set; }
    }
}