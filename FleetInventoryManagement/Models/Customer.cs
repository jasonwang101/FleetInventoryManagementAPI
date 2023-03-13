namespace FleetInventoryManagement.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Fleet> Fleets { get; set; }
    }
}
