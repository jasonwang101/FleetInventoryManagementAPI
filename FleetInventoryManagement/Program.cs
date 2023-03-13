using Microsoft.EntityFrameworkCore;
using FleetInventoryManagement.Data;
using FleetInventoryManagement.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContextFactory<FleetInventoryManagementContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("FleetInventoryManagement") ?? throw new InvalidOperationException("Connection string 'FleetInventoryManagement' not found.")));
builder.Services.AddGraphQLServer().AddQueryType<Query>().AddProjections().AddFiltering().AddSorting();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

await FleetInventoryManagementContext.CheckAndSeedDatabaseAsync(
    app.Services.GetRequiredService<IDbContextFactory<FleetInventoryManagementContext>>()
    .CreateDbContext()
);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapCustomerEndpoints();

app.MapGraphQL("/graphql");

app.MapFleetEndpoints();

app.Run();
