using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using bikeshop.Data;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bikeshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MenuItemsController : Controller
    {

        private readonly DataContext _context;

        public MenuItemsController(DataContext context)
        {
            _context = context;
        }
        // GET: /<controller>/

        [HttpGet]
        public async Task<ActionResult<List<MenuItem>>> Get()
        {
            try
            {
                return Ok(await _context.MenuItems.ToListAsync());

            }
            catch
            {
                return new ContentResult() { StatusCode = 500 };
            }


        }

        [HttpPost]
        public async Task<ContentResult> Post(MenuItem menuItem)
        {
            try
            {
                await _context.AddRangeAsync(menuItem);
                await _context.SaveChangesAsync();
                return new ContentResult() { StatusCode = 200 };
            }
            catch { return new ContentResult() { StatusCode = 500 }; }

        }

        [HttpGet("name")]
        public async Task<ActionResult<MenuItem>> GetName(string Name)
        {
            var menuItem1 = _context.MenuItems
                        .Where(b => b.Name == Name)
                        .FirstOrDefault<MenuItem>();
            if (menuItem1 == null)
                return BadRequest("menuItem not found.");
            return Ok(menuItem1);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItem>> Get(int id)
        {
            var menuItem1 = await _context.MenuItems.FindAsync(id);
            if (menuItem1 == null)
                return BadRequest("Menu item not found.");
            return Ok(menuItem1);
        }


        [HttpDelete("{id}")]
        public async Task<ContentResult> Delete(int id)
        {
            var menuItem1 = await _context.MenuItems.FindAsync(id);
            if (menuItem1 == null)
                return new ContentResult()
                {
                    StatusCode = 400,
                    Content = "Item not found."
                };

            _context.MenuItems.Remove(menuItem1);
            await _context.SaveChangesAsync();
            return new ContentResult()
            {
                StatusCode = 200,
                Content = "Item deleted."
            };
        }

        [HttpGet("foodtype")]
        public async Task<ActionResult<MenuItem>> GetFoodType(string FoodType)
        {

            var menuItem1 = _context.MenuItems
                        .Where(b => b.FoodType == FoodType);

            if (menuItem1 == null)
                return BadRequest("menuItem not found.");
            return Ok(menuItem1.ToList());
        }

        [HttpPut("priceChangeName")]
        public async Task<ContentResult> UpdatePriceByName(MenuItem menuItem)
        {
            var menuItem1 = _context.MenuItems.
                            First(b => b.Name == menuItem.Name);

            menuItem1.Price = menuItem.Price;
            _context.SaveChanges();

            return new ContentResult() { StatusCode = 200 };
        }

        [HttpPut("priceChangeID")]
        public async Task<ContentResult> UpdatePriceByID(MenuItem menuItem)
        {
            var menuItem1 = _context.MenuItems.
                            First(b => b.Id == menuItem.Id);

            menuItem1.Price = menuItem.Price;
            _context.SaveChanges();

            return new ContentResult() { StatusCode = 200 };
        }

    }
}

