using Microsoft.EntityFrameworkCore;
using FleetInventoryManagement.Data;
using FleetInventoryManagement.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FleetInventoryManagement.Endpoints;

public static class CustomerEndpoints
{
    public static void MapCustomerEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Customer").WithTags(nameof(Customer));

        group.MapGet("/", async (FleetInventoryManagementContext db) =>
        {
            return await db.Customer.ToListAsync();
        })
        .WithName("GetAllCustomers")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Customer>, NotFound>> (int customerid, FleetInventoryManagementContext db) =>
        {
            return await db.Customer.AsNoTracking()
                .FirstOrDefaultAsync(model => model.CustomerId == customerid)
                is Customer model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetCustomerById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int customerid, Customer customer, FleetInventoryManagementContext db) =>
        {
            var affected = await db.Customer
                .Where(model => model.CustomerId == customerid)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.CustomerId, customer.CustomerId)
                  .SetProperty(m => m.Name, customer.Name)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateCustomer")
        .WithOpenApi();

        group.MapPost("/", async (Customer customer, FleetInventoryManagementContext db) =>
        {
            db.Customer.Add(customer);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Customer/{customer.CustomerId}", customer);
        })
        .WithName("CreateCustomer")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int customerid, FleetInventoryManagementContext db) =>
        {
            var affected = await db.Customer
                .Where(model => model.CustomerId == customerid)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteCustomer")
        .WithOpenApi();
    }
}
