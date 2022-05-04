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
        public async Task<ActionResult<Truck>> Get()
        {
            return Ok(await _ft.Trucks.ToListAsync());
        }
        
        //GETACTIVE TRUCK
        [HttpGet("{IsActive}")]
        public async Task<ActionResult<MenuItem>> GetActive(bool IsActive)
        {
                             
            var menuItems=(from a in _ft.Trucks
                            join b in _ft.MenuItemLinks on a.MenuID equals b.MenuID
                            join c in _ft.MenuItems on b.MenuItemID equals c.MenuItemID
                            where a.IsActive==true orderby c.FoodType
                           select new
                            {
                                MenuItemID = c.MenuItemID,
                                FoodType = c.FoodType,
                                Name = c.Name,
                                Description = c.Description,
                                Price = c.Price
                            }).ToList();


            if (menuItems == null)
                return BadRequest("menuItems not found.");
            return Ok(menuItems);
        }

        [HttpGet("employees{id}")]
        public async Task<ActionResult<Employee>> GetTruckEmployees(int id)
        {
            var employees = (from m in _ft.Employees
                             join n in _ft.EmployeeTruckLinks
                             on m.EmployeeID equals n.EmployeeID
                             where n.TruckID == id
                             select new
                             {
                                 EmployeeID = m.EmployeeID,
                                 Name = m.Name,
                                 PhoneNumber = m.PhoneNumber,
                             }).ToList();

            return Ok(employees);
         }
         
        //GET by ID
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Truck>> Get(int id)
        //{
        //    var truck1 = await _ft.Trucks.FindAsync(id);
        //    if (truck1 == null)
        //    { return BadRequest("Truck not found."); }
        //    else
        //    { return Ok(truck1); }
        //}

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
            var truckActive = _ft.Trucks.
                            First(b => b.TruckID == id);

            truckActive.IsActive = true;         

            var trucksInactive = _ft.Trucks.
                            Where(b => b.TruckID != id);
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
