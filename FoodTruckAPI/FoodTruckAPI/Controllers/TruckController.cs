using FoodTruckAPI.ClassLibrary.DataAccess;
using FoodTruckAPI.ClassLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace FoodTruckAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruckController : Controller
    {

        private readonly ILogger<TruckController> _logger;
        private readonly FoodTruckContext _ft;

        public TruckController(ILogger<TruckController> logger, FoodTruckContext ft)
        {
            _logger = logger;
            _ft = ft;
        }

        //GET ALL
        [HttpGet("all")]
        public async Task<ActionResult<Truck>> Get()
        {
            return Ok(await _ft.Trucks.ToListAsync());
        }

        //GET by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Truck>> Get(int id)
        {
            var truck1 = await _ft.Trucks.FindAsync(id);
            if (truck1 == null)
            { return BadRequest("Truck not found."); }
            else
            { return Ok(truck1); }
        }

        //POST
        [HttpPost]
        public async Task<ActionResult<Truck>> Post(Truck truck)
        {
            try
            {
                await _ft.AddRangeAsync(truck);
                await _ft.SaveChangesAsync();
                return truck;
            }
            catch { return new ContentResult() { StatusCode = 500 }; }

        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<ContentResult> Delete(int id)
        {
            var truck1 = await _ft.Trucks.FindAsync(id);
            if (truck1 == null)
                return new ContentResult()
                {
                    StatusCode = 400,
                    Content = "Truck not found."
                };

            _ft.Trucks.Remove(truck1);
            await _ft.SaveChangesAsync();
            return new ContentResult()
            {
                StatusCode = 200,
            };
        }

    }
}
