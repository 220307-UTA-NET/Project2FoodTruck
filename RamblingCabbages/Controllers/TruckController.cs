using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RamblingCabbages.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruckController : ControllerBase
    {
        private readonly DataContext _truck;
        public TruckController(DataContext truck)
        {
            _truck = truck;
        }
        //private static List<Truck> trucks = new List<Truck> { };
        [HttpGet]
        public async Task<ActionResult<List<Truck>>> GetAllTrucks()
        {
            return Ok(await _truck.Trucks.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult<List<Truck>>> AddNewTruck(Truck truck)
        {
            _truck.Trucks.Add(truck);
            await _truck.SaveChangesAsync();
            //trucks.Add(truck);
            //return Ok(trucks);
            return Ok(await _truck.Trucks.ToListAsync());
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Truck>>> UpdateTruck(Truck request)
        {
            var dbTruck = await _truck.Trucks.FindAsync(request.Id);
            if (dbTruck == null)
                return BadRequest("No menus have that id.");

            
            dbTruck.Id = request.Id;
            dbTruck.Day = request.Day;
            dbTruck.MenuId = request.MenuId;
            dbTruck.Employee1 = request.Employee1;
            dbTruck.Employee2 = request.Employee2;
            dbTruck.Location = request.Location;
            await _truck.SaveChangesAsync();
            return Ok(await _truck.Trucks.ToListAsync());
        }
    }
}