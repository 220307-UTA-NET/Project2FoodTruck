using FoodTruckAPI.ClassLibrary.DataAccess;
using FoodTruckAPI.ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodTruckAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TruckController : Controller
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly FoodTruckContext _ft;

        public TruckController(ILogger<EmployeesController> logger, FoodTruckContext ft)
        {
            _logger = logger;
            _ft = ft;
        }

        //GET ALL
        [HttpGet("all")]
        public async Task<ActionResult<List<Truck>>> Get()
        {
            return await _ft.Trucks.OrderByDescending(i=>i.Day).Take(5).ToListAsync();
        }
        
        //GETACTIVE TRUCK
        [HttpGet("{IsActive}")]
        public async Task<ActionResult<List<MenuItem>>> GetActive(bool IsActive)
        {
                             
            var menuItems= await (from a in _ft.Trucks
                            join b in _ft.MenuItemLinks on a.MenuID equals b.MenuID
                            join c in _ft.MenuItems on b.MenuItemID equals c.MenuItemID
                            where a.IsActive==true orderby c.FoodType
                           select new MenuItem()
                            {
                                MenuItemID = c.MenuItemID,
                                FoodType = c.FoodType,
                                Name = c.Name,
                                Description = c.Description,
                                Price = c.Price
                            }).ToListAsync();


            if (menuItems == null)
                return BadRequest("menuItems not found.");
            return menuItems;
        }

        [HttpGet("employees{id}")]
        public async Task<ActionResult<List<Employee>>> GetTruckEmployees(int id)
        {
            var employees = await (from m in _ft.Employees
                             join n in _ft.EmployeeTruckLinks
                             on m.EmployeeID equals n.EmployeeID
                             where n.TruckID == id
                             select new Employee()
                             {
                                 EmployeeID = m.EmployeeID,
                                 Name = m.Name,
                                 PhoneNumber = m.PhoneNumber,
                             }).ToListAsync();

            return employees;
        }

        //POST
        [HttpPost]
        public async Task<ActionResult<Truck>> Post(TruckEmployeeListDTO data)
        {
            List<EmployeeTruckLink> Links = new List<EmployeeTruckLink>();
            foreach (Employee e in data.employees)
            {
                Links.Add(new EmployeeTruckLink()
                {
                    EmployeeID = e.EmployeeID,
                });
            }

            var truck = new Truck()
            {
                Day = data.date,
                MenuID = data.menuID,
                workingEmployees = Links,
                Location = data.location,
                IsActive = false
            };

            try
            {
                await _ft.Trucks.AddRangeAsync(truck);
                await _ft.SaveChangesAsync();
                return truck;
            }
            catch { return new ContentResult() { StatusCode = 500 }; }
        }

        //PUT (CHANGE STATUS OF ISACTIVE
        [HttpPut("{id}")]
        public async Task<ActionResult<Truck>>Put(int id)
        {
            var truckActive = await _ft.Trucks.
                            FirstAsync(b => b.TruckID == id);

            truckActive.IsActive = true;         

            var trucksInactive = await _ft.Trucks.
                            Where(b => b.TruckID != id).ToListAsync();
            foreach (var t in trucksInactive)
            {
                t.IsActive = false;
                
            }
            _ft.SaveChanges();

            //var allTrucks = _ft.Trucks;
           
            //return Ok(allTrucks);
            return new ContentResult() { StatusCode = 200 };
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
