using FleetInventoryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace FleetInventoryManagement.Data
{
    public class FleetInventoryManagementContext : DbContext
    {
        public FleetInventoryManagementContext(DbContextOptions<FleetInventoryManagementContext> options)
            : base(options)
        {
        }

        public DbSet<Vehicle> Vehicle { get; set; } = default!;

        public DbSet<Customer> Customer { get; set; } = default!;

        public DbSet<Fleet> Fleet { get; set; } = default!;

        public static async Task CheckAndSeedDatabaseAsync(FleetInventoryManagementContext context)
        {
            if (context.Database.EnsureCreated())
            {
                var customers = Seed.GetCustomers();
                if (context.Customer != null)
                {
                    context.Customer.AddRange(customers);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
