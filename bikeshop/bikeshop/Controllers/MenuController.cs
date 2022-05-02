using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using bikeshop.Models;
using bikeshop.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bikeshop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly ILogger<MenuController> _logger;
        private readonly DataContext _context;

        public MenuController(ILogger<MenuController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        //Create a Menu - POST
        [HttpPost]
        public async Task<IActionResult> Post(Menu menu)
        {
     

            try
            {
         
                await _context.AddRangeAsync(menu);
                await _context.SaveChangesAsync();
                return new ContentResult() { StatusCode = 200 };
            }
            catch { return new ContentResult() { StatusCode = 500 }; }
        }

        //Update a Menu - PUT

        //Get all menus -GET

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Menus.ToListAsync());
        }
        //Get one menu -GET
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var menuList = (from m in _context.MenuItems
                            join n in _context.MenuItemLinks
                            on m.Id equals n.MenuID
                            where n.MenuID == id
                            select new
                            {
                                MenuItemID = m.Id,
                                FoodType = m.FoodType,
                                Name = m.Name,
                                Description = m.Description,
                                Price = m.Price
                            }).ToList();

            foreach (var menu in menuList)
            {
                _logger.LogInformation($"{menu.Price}");
            }
            return Ok(menuList);
        }

    }
}

