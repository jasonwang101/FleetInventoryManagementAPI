using Microsoft.EntityFrameworkCore;
using FleetInventoryManagement.Data;
using FleetInventoryManagement.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FleetInventoryManagement.Endpoints;

public static class FleetEndpoints
{
    public static void MapFleetEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Fleet").WithTags(nameof(Fleet));

        group.MapGet("/", async (FleetInventoryManagementContext db) =>
        {
            return await db.Fleet.ToListAsync();
        })
        .WithName("GetAllFleets")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Fleet>, NotFound>> (int fleetid, FleetInventoryManagementContext db) =>
        {
            return await db.Fleet.AsNoTracking()
                .FirstOrDefaultAsync(model => model.FleetId == fleetid)
                is Fleet model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetFleetById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int fleetid, Fleet fleet, FleetInventoryManagementContext db) =>
        {
            var affected = await db.Fleet
                .Where(model => model.FleetId == fleetid)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.FleetId, fleet.FleetId)
                  .SetProperty(m => m.Name, fleet.Name)
                  .SetProperty(m => m.Description, fleet.Description)
                  .SetProperty(m => m.CustomerId, fleet.CustomerId)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateFleet")
        .WithOpenApi();

        group.MapPost("/", async (Fleet fleet, FleetInventoryManagementContext db) =>
        {
            db.Fleet.Add(fleet);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Fleet/{fleet.FleetId}", fleet);
        })
        .WithName("CreateFleet")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int fleetid, FleetInventoryManagementContext db) =>
        {
            var affected = await db.Fleet
                .Where(model => model.FleetId == fleetid)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteFleet")
        .WithOpenApi();
    }
}
