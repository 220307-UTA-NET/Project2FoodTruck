using FoodTruckAPI.ClassLibrary.DataAccess;
using FoodTruckAPI.ClassLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodTruckAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenusController : ControllerBase
    {

        private readonly ILogger<MenuItemController> _logger;
        private readonly FoodTruckContext _ft;

        public MenusController(ILogger<MenuItemController> logger, FoodTruckContext ft)
        {
            _logger = logger;
            _ft = ft;
        }

        //Create a Menu - POST
        [HttpPost]
        public async Task<IActionResult> Post(Menu menu)
        {
            //List<MenuItem> menu = new List<MenuItem>();
            //for (int i = 0; i < menuAdds.Length; i++)
            //{
            //    int menuAdd = menuAdds[i];
            //    menu.Add(await _ft.MenuItems.FindAsync(menuAdd));
            //}
            
            try
            {
                //await _ft.AddRangeAsync(new Menu()
                //{
                //    Main1 = menu[0],
                //    Main2 = menu[1],
                //    Main3 = menu[2],
                //    Drink1 = menu[3],
                //    Drink2 = menu[4],
                //    Side1 = menu[5],
                //    Side2 = menu[6],

                //});
                await _ft.AddRangeAsync(menu);
                await _ft.SaveChangesAsync();
                return new ContentResult() { StatusCode = 200 };
            }
            catch { return new ContentResult() { StatusCode = 500 }; }
        }

        //Update a Menu - PUT

        //Get all menus -GET

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _ft.Menus.ToListAsync());
        }
        //Get one menu -GET
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var menuList = (from m in _ft.MenuItems
                            join n in _ft.MenuItemLinks
                            on m.MenuItemID equals n.MenuItemID
                            where n.MenuID == id
                            select new
                            {
                                MenuItemID = m.MenuItemID,
                                FoodType = m.FoodType,
                                Name = m.Name,
                                Description = m.Description,
                                Price = m.Price
                            }).ToList();

            foreach(var menu in menuList)
            {
                _logger.LogInformation($"{menu.Price}");
            }
            return Ok(menuList);         
        }

    }
}
