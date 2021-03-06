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
        public async Task<ActionResult<Menu>> Post(List<MenuItem> menu, string MenuName)
        {    
            List<MenuItemLink> Links = new List<MenuItemLink>();
            foreach (MenuItem item in menu)
            {
                Links.Add(new MenuItemLink()
                {
                    MenuItemID = item.MenuItemID,
                });
            }

            var menuAdd = new Menu()
            {
                MenuName = MenuName,
                Links = Links
            };

            try
            {
                await _ft.AddRangeAsync(menuAdd);
                await _ft.SaveChangesAsync();
                return menuAdd;                                    
            }
            catch { return new ContentResult() { StatusCode = 500 }; }
        }

        //Update a Menu - PUT
        //[HttpPut]
        //public async Task<IActionResult> Put(List<MenuItem> menu, int id)
        //{
        //    var menuList = (from m in _ft.MenuItems
        //                    join n in _ft.MenuItemLinks
        //                    on m.MenuItemID equals n.MenuItemID
        //                    where n.MenuID == id
        //                    select new
        //                    {
        //                        MenuItemID = m.MenuItemID,
        //                        FoodType = m.FoodType,
        //                        Name = m.Name,
        //                        Description = m.Description,
        //                        Price = m.Price
        //                    }).ToList();

        //    List<MenuItemLink> Links = new List<MenuItemLink>();
        //    foreach (MenuItem item in menu)
        //    {
        //        Links.Add(new MenuItemLink()
        //        {
        //            MenuItemID = item.MenuItemID,
        //        });
        //    }
        //    try
        //    {
        //        await _ft.AddRangeAsync(new Menu()
        //        {
        //           // MenuName = MenuName,
        //            Links = Links
        //        });
        //        await _ft.SaveChangesAsync();
        //        return new ContentResult() { StatusCode = 200 };
        //    }
        //    catch { return new ContentResult() { StatusCode = 500 }; }
        //}

        //Get all menus -GET

        [HttpGet]
        public async Task<ActionResult<List<Menu>>> Get()
        {
            var menus = await _ft.Menus.ToListAsync();
            return menus;
        }
        //Get one menu -GET
        [HttpGet("{id}")]
        public async Task<ActionResult<List<MenuItem>>> Get(int id)
        {
            var menuList = await (from m in _ft.MenuItems
                            join n in _ft.MenuItemLinks
                            on m.MenuItemID equals n.MenuItemID
                            where n.MenuID == id orderby m.FoodType
                            select new MenuItem()
                            {
                                MenuItemID = m.MenuItemID,
                                FoodType = m.FoodType,
                                Name = m.Name,
                                Description = m.Description,
                                Price = m.Price
                            }).ToListAsync();

            return menuList;         
        }
        [HttpDelete("{id}")]
        public async Task<ContentResult> Delete(int id)
        {
            var menu = await _ft.Menus.FindAsync(id);
            if (menu == null)
                return new ContentResult()
                {
                    StatusCode = 400,
                    Content = "Item not found."
                };

            _ft.Menus.Remove(menu);
            await _ft.SaveChangesAsync();
            return new ContentResult()
            {
                StatusCode = 200,
            };
        }

    }
}
