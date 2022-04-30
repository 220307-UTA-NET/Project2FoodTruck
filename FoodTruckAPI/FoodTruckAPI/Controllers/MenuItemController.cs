using FoodTruckAPI.ClassLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodTruckAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly FoodTruckContext _foodTruckContext;

        public MenuItemController(FoodTruckContext foodTruckContext)
        {
            _foodTruckContext = foodTruckContext;
        }

        [HttpGet("see/all/menuItem")]
        public async Task<ActionResult<List<MenuItem>>> SeeAllMenuItems()
        {
            return Ok(await _foodTruckContext.MenuItems.ToListAsync());
        }

        [HttpGet("see/menuItem{ID}")]
        public async Task<ActionResult<MenuItem>> SeeMenuItem(int ID)
        {
            var menuitem = await _foodTruckContext.MenuItems.FindAsync(ID);
            if (menuitem == null)
                return BadRequest("Cannot find item. Please try again.");
            return Ok(menuitem);
        }

        [HttpPost("create/menuItem")]
        public async Task<ActionResult<List<MenuItem>>> CreateMenuItem(MenuItem menuitem)
        {
            _foodTruckContext.MenuItems.Add(menuitem);
            await _foodTruckContext.SaveChangesAsync();
            return Ok(await _foodTruckContext.MenuItems.ToListAsync());

        }

        [HttpPut("update/menuItem{ID}")]
        public async Task<ActionResult<List<MenuItem>>> UpdateMenuItem(MenuItem request)
        {
            var dbMenuItem = await _foodTruckContext.MenuItems.FindAsync(request.ID);
            if (dbMenuItem == null)
                return BadRequest("Cannot find item. Please try again.");

            dbMenuItem.FoodType = request.FoodType;
            dbMenuItem.Name = request.Name;
            dbMenuItem.Description = request.Description;
            dbMenuItem.Price = request.Price;

            await _foodTruckContext.SaveChangesAsync();

            return Ok(await _foodTruckContext.MenuItems.ToListAsync());
        }

        [HttpDelete("delete/menuItem{ID}")]
        public async Task<ActionResult<List<MenuItem>>> DeleteMenuItem(int ID)
        {
            var dbMenuItem = await _foodTruckContext.MenuItems.FindAsync(ID);
            if (dbMenuItem == null)
                return BadRequest("Cannot find employee. Please try again.");

            _foodTruckContext.MenuItems.Remove(dbMenuItem);
            await _foodTruckContext.SaveChangesAsync();

            return Ok(await _foodTruckContext.MenuItems.ToListAsync());
        }

    }
}


