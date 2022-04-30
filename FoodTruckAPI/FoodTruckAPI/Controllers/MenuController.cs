using FoodTruckAPI.ClassLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodTruckAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly FoodTruckContext _foodTruckContext;
        private readonly ILogger<MenuController> _logger;

        public MenuController(FoodTruckContext foodTruckContext, ILogger<MenuController> logger)
        {
            _foodTruckContext = foodTruckContext;
            this._logger = logger;
        }

        [HttpGet("get/all/menu")]
        public async Task<ActionResult<List<Menu>>> GetAllMenus()
        {
            return Ok(await _foodTruckContext.Menus.ToListAsync());

        }

        [HttpGet("get/menuItem{ID}")]
        public async Task<ActionResult<Menu>> GetMenuItem(int ID)
        {
            var menu = await _foodTruckContext.MenuItems.FindAsync(ID);
            if (menu == null)
                return BadRequest("Cannot find menu. Please try again.");
            return Ok(menu);
        }

        [HttpPost("add/menu")]
        public async Task<ActionResult<List<Menu>>> AddMenu(Menu menu)
        {
            _foodTruckContext.Menus.Add(menu);
            await _foodTruckContext.SaveChangesAsync();
            return Ok(await _foodTruckContext.Menus.ToListAsync());
        }
        
        [HttpPut("update/menu{ID}")]
        public async Task<ActionResult<List<Menu>>> UpdateMenu(Menu request)
        {
            var dbMenu = await _foodTruckContext.Menus.FindAsync(request.ID);
            if (dbMenu == null)
                return BadRequest("Cannot find menu. Please try again.");

            dbMenu.Main1 = request.Main1;
            dbMenu.Main2 = request.Main2;
            dbMenu.Main3 = request.Main3;
            dbMenu.Drink1 = request.Drink1;
            dbMenu.Drink2 = request.Drink2;
            dbMenu.Side1 = request.Side1;
            dbMenu.Side2 = request.Side2;


            await _foodTruckContext.SaveChangesAsync();

            return Ok(await _foodTruckContext.Menus.ToListAsync());
        }

        [HttpDelete("delete/menu{ID}")]
        public async Task<ActionResult<List<Menu>>> DeleteMenu(int ID)
        {
            var dbMenu = await _foodTruckContext.Menus.FindAsync(ID);
            if (dbMenu == null)
                return BadRequest("Cannot find employee. Please try again.");

            _foodTruckContext.Menus.Remove(dbMenu);
            await _foodTruckContext.SaveChangesAsync();

            return Ok(await _foodTruckContext.Menus.ToListAsync());
        }

    }

}

