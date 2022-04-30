using FoodTruckAPI.ClassLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodTruckAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruckController : ControllerBase
    {
        private readonly FoodTruckContext _foodTruckContext;

        public TruckController(FoodTruckContext foodTruckContext)
        {
            _foodTruckContext = foodTruckContext;
        }

        [HttpGet("see/all/truck")]
        public async Task<ActionResult<List<Truck>>> SeeAllTrucks()
        {
            return Ok(await _foodTruckContext.Trucks.ToListAsync());
        }

        [HttpGet("see/truck{ID}")]
        public async Task<ActionResult<Truck>> SeeTruck(int ID)
        {
            var truck = await _foodTruckContext.MenuItems.FindAsync(ID);
            if (truck == null)
                return BadRequest("Cannot find truck. Please try again.");
            return Ok(truck);
        }

        [HttpPost("create/truck")]
        public async Task<ActionResult<List<Truck>>> CreateTruck(Truck truck)
        {
            _foodTruckContext.Trucks.Add(truck);
            await _foodTruckContext.SaveChangesAsync();
            return Ok(await _foodTruckContext.Trucks.ToListAsync());

        }

        [HttpPut("change/truck{ID}")]
        public async Task<ActionResult<List<Truck>>> ChangeTruck(Truck request)
        {
            var dbTruck = await _foodTruckContext.Trucks.FindAsync(request.ID);
            if (dbTruck == null)
                return BadRequest("Cannot find truck. Please try again.");

            dbTruck.Day = request.Day;
            dbTruck.MenuID = request.MenuID;
            dbTruck.Employee1 = request.Employee1;
            dbTruck.Employee2 = request.Employee2;

            await _foodTruckContext.SaveChangesAsync();

            return Ok(await _foodTruckContext.Trucks.ToListAsync());
        }

        [HttpDelete("delete/truck{ID}")]
        public async Task<ActionResult<List<Truck>>> DeleteTruck(int ID)
        {
            var dbTruck = await _foodTruckContext.Trucks.FindAsync(ID);
            if (dbTruck == null)
                return BadRequest("Cannot find truck. Please try again.");

            _foodTruckContext.Trucks.Remove(dbTruck);
            await _foodTruckContext.SaveChangesAsync();

            return Ok(await _foodTruckContext.Trucks.ToListAsync());
        }
    }
}
