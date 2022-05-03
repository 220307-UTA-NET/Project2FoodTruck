using FoodTruckAPI.ClassLibrary.DataAccess;
using FoodTruckAPI.ClassLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodTruckAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTruckLinkController : ControllerBase
    {
        private readonly ILogger<EmployeeTruckLinkController> _logger;
        private readonly FoodTruckContext _ft;

        public EmployeeTruckLinkController(ILogger<EmployeeTruckLinkController> logger, FoodTruckContext ft)
        {
            _logger = logger;
            _ft = ft;
        }

        //GET by ID
        [HttpGet("EmployeeTruckLink{id}")]
        public async Task<ActionResult<EmployeeTruckLink>> GetEmployeeTruckLinkID(int id)
        {
            var employeetrucklink1 = await _ft.EmployeeTruckLinks.FindAsync(id);
            if (employeetrucklink1 == null)
            { return BadRequest("Truck Link ID not found."); }
            else
            { return Ok(employeetrucklink1); }
        }

        //GET by ID
        [HttpGet("EmployeeID{id}")]
        public async Task<ActionResult<EmployeeTruckLink>> GetEmployeeID(int id)
        {
            var employeetrucklink1 = await _ft.EmployeeTruckLinks.FindAsync(id);
            if (employeetrucklink1 == null)
            { return BadRequest("Truck Link ID not found."); }
            else
            { return Ok(employeetrucklink1); }
        }

        //GET by ID
        [HttpGet("TruckID{id}")]
        public async Task<ActionResult<EmployeeTruckLink>> GetTruckID(int id)
        {
            var employeetrucklink1 = await _ft.EmployeeTruckLinks.FindAsync(id);
            if (employeetrucklink1 == null)
            { return BadRequest("Truck Link ID not found."); }
            else
            { return Ok(employeetrucklink1); }
        }

    }
}
