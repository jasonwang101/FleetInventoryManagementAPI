using FleetInventoryManagement.Models;

namespace FleetInventoryManagement.Data
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Customer> GetCustomers([Service] FleetInventoryManagementContext context) =>
            context.Customer;

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Fleet> GetFleets([Service] FleetInventoryManagementContext context) =>
            context.Fleet;

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Vehicle> GetVehicle([Service] FleetInventoryManagementContext context) =>
            context.Vehicle;
    }
}
