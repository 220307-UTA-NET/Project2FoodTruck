using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RamblingCabbages.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        //private static List<MenuItem> menuItems = new List<MenuItem> { };
        private readonly DataContext _meni;
        public MenuItemController(DataContext meni)
        {
            _meni = meni;
        }
        [HttpGet]
        public async Task<ActionResult<List<MenuItem>>> GetAllMenuItems()
        {
            return Ok(await _meni.MenuItems.ToListAsync());
        }
        [HttpGet("FoodType")]
        public async Task<ActionResult<List<MenuItem>>> GetByFoodType(string foodType)
        {
            var menuItem = await _meni.MenuItems.FindAsync(foodType);  //menuItems.Where(m => m.FoodType == foodType);
            if (menuItem == null)
                return BadRequest("No item found with the food type.");
            return Ok(await _meni.MenuItems.ToListAsync());

        }
        [HttpPost]
        public async Task<ActionResult<List<MenuItem>>> AddNewMenuItem(MenuItem menuItem)
        {
            _meni.MenuItems.Add(menuItem);
            await _meni.SaveChangesAsync();
            //menuItems.Add(menuItem);
            //return Ok(menuItems);
            return Ok(await _meni.MenuItems.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<MenuItem>>> UpdateMenuItem(MenuItem request)
        {
            var dbMenuItem =await _meni.MenuItems.FindAsync(request.FoodType);
            if (dbMenuItem == null)
                return BadRequest("No menu items have that id.");

            dbMenuItem.Id = request.Id;
            dbMenuItem.FoodType = request.FoodType;
            dbMenuItem.Name = request.Name;
            dbMenuItem.Description = request.Description;
            dbMenuItem.Price = request.Price;
            await _meni.SaveChangesAsync();
            return Ok(await _meni.MenuItems.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<MenuItem>>> Discontinue(int id)
        {
            var dbMenuItem = await _meni.MenuItems.FindAsync(id);
            if (dbMenuItem == null)
                return BadRequest("No menu items have that id.");
            _meni.MenuItems.Remove(dbMenuItem);
            await _meni.SaveChangesAsync();
            return Ok(await _meni.MenuItems.ToListAsync());
        }
    }
}
