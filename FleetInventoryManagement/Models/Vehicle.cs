namespace FleetInventoryManagement.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public string? Color { get; set; }

        public virtual int FleetId { get; set; }
    }
}
