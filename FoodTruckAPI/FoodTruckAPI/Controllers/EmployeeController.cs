using FoodTruckDataAccessLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodTruckAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly FoodTruckContext _foodTruckContext;

        public EmployeeController(FoodTruckContext foodTruckContext)
        {
            _foodTruckContext = foodTruckContext;
        }
        
            
        [HttpGet("get/all/employees")]
        public async Task<ActionResult<List<Employee>>> GetAllEmployees()
        {
            return Ok(await _foodTruckContext.Employees.ToListAsync());
        }

        [HttpGet("get/employee{ID}")]
        public async Task<ActionResult<Employee>> GetEmployee(int ID)
        {
            var employee = await _foodTruckContext.Employees.FindAsync(ID);
            if (employee == null)
                return BadRequest("Cannot find employee. Please try again.");
            return Ok(employee);
        }

        [HttpPost("add/employee")]
        public async Task<ActionResult<List<Employee>>> AddEmployee(Employee employee)
        {
            _foodTruckContext.Employees.Add(employee);
            await _foodTruckContext.SaveChangesAsync();
            return Ok(await _foodTruckContext.Employees.ToListAsync());

        }

        [HttpPut("update/employee{ID}")]
        public async Task<ActionResult<List<Employee>>> UpdateEmployee(Employee request)
        {
            var dbEmployee = await _foodTruckContext.Employees.FindAsync(request.ID);
            if (dbEmployee == null)
                return BadRequest("Cannot find employee. Please try again.");

            dbEmployee.FirstName = request.FirstName;
            dbEmployee.LastName = request.LastName;
            dbEmployee.PhoneNumber = request.PhoneNumber;

            await _foodTruckContext.SaveChangesAsync();

            return Ok(await _foodTruckContext.Employees.ToListAsync());

        }

        [HttpDelete("delete/employee{ID}")]
        public async Task<ActionResult<List<Employee>>> DeleteEmployee(int ID)
        {
            var dbEmployee = await _foodTruckContext.Employees.FindAsync(ID);
            if (dbEmployee == null)
                return BadRequest("Cannot find employee. Please try again.");

            _foodTruckContext.Employees.Remove(dbEmployee);
            await _foodTruckContext.SaveChangesAsync();

            return Ok(await _foodTruckContext.Employees.ToListAsync());
        }

    }
}
