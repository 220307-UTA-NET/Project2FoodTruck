using FoodTruckAPI.ClassLibrary.DataAccess;
using FoodTruckAPI.ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodTruckAPI.Controllers
{
    [ApiController]
    [Route ("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly FoodTruckContext _ft;

        public EmployeesController(ILogger<EmployeesController> logger, FoodTruckContext ft)
        {
            _logger = logger;
            _ft = ft;
        }


        //GET ALL
        [HttpGet("all")]
        public async Task<ActionResult<List<Employee>>> Get()
        {
            return await _ft.Employees.ToListAsync();
        }


        //GET by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {          
            var employee = await _ft.Employees.FindAsync(id);
            if (employee == null)
            { return BadRequest("Employeee not found."); }
            else
            { return employee; }
        }

        //POST
        [HttpPost]
        public async Task<ActionResult<Employee>> Post(Employee employee)
        {
            try
            {
                await _ft.AddRangeAsync(employee);
                await _ft.SaveChangesAsync();
                return employee;
            }
            catch { return new ContentResult() { StatusCode = 500 }; }

        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<ContentResult> Delete(int id)
        {
            var employee = await _ft.Employees.FindAsync(id);
            if (employee == null)
                return new ContentResult()
                {
                    StatusCode = 400,
                    Content = "Employee not found."
                };

            _ft.Employees.Remove(employee) ;
            await _ft.SaveChangesAsync();
            return new ContentResult()
            {
                StatusCode = 200,
            };
        }

    }
}
