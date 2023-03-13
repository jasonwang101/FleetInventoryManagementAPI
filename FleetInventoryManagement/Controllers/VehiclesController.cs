using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FleetInventoryManagement.Data;
using FleetInventoryManagement.Models;

namespace FleetInventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly FleetInventoryManagementContext _context;

        public VehiclesController(FleetInventoryManagementContext context)
        {
            _context = context;
        }

        // GET: api/Vehicles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicle()
        {
            if (_context.Vehicle == null)
            {
                return NotFound();
            }
            return await _context.Vehicle.ToListAsync();
        }

        // GET: api/Vehicles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> GetVehicle(int id)
        {
            if (_context.Vehicle == null)
            {
                return NotFound();
            }
            var vehicle = await _context.Vehicle.FindAsync(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return vehicle;
        }

        // PUT: api/Vehicles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle(int id, Vehicle vehicle)
        {
            if (id != vehicle.VehicleId)
            {
                return BadRequest();
            }

            _context.Entry(vehicle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Vehicles
        [HttpPost]
        public async Task<ActionResult<Vehicle>> PostVehicle(Vehicle vehicle)
        {
            if (_context.Vehicle == null)
            {
                return Problem("Entity set 'FleetInventoryManagementContext.Vehicle'  is null.");
            }
            _context.Vehicle.Add(vehicle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehicle", new { id = vehicle.VehicleId }, vehicle);
        }

        // DELETE: api/Vehicles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            if (_context.Vehicle == null)
            {
                return NotFound();
            }
            var vehicle = await _context.Vehicle.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            _context.Vehicle.Remove(vehicle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehicleExists(int id)
        {
            return (_context.Vehicle?.Any(e => e.VehicleId == id)).GetValueOrDefault();
        }
    }
}
