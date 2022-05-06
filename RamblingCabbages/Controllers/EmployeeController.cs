using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RamblingCabbages.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _emp;
        public EmployeeController(DataContext emp)
        {
            _emp = emp;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAllEmployees()
        {
            return Ok(await _emp.Employees.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult<List<Employee>>> HireEmployee(Employee employee)
        {
            _emp.Employees.Add(employee);
            await _emp.SaveChangesAsync();
            //employees.Add(employee);
            //return Ok(employees);
            return Ok(await _emp.Employees.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Employee>>> FireEmployee(int id)
        {
            var dbEmployee = await _emp.Employees.FindAsync(id);
            if (dbEmployee == null)
                return BadRequest("No employees have that id.");
            _emp.Employees.Remove(dbEmployee);
            await _emp.SaveChangesAsync();
            return Ok(await _emp.Employees.ToListAsync());
        }
    }
}
