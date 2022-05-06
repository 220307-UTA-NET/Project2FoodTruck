using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RamblingCabbages.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly DataContext _men;
        public MenuController(DataContext men)
        {
            _men = men;
        }

        //private static List<Menu> menus = new List<Menu> { };

        [HttpGet]
        public async Task<ActionResult<List<Menu>>> GetAllMenus()
        {
            return Ok(await _men.Menus.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult<List<Menu>>> AddNewMenu(Menu menu)
        {
            _men.Menus.Add(menu);
            await _men.SaveChangesAsync();

            //menus.Add(menu);
            //return Ok(menus);
            return Ok(await _men.Menus.ToListAsync());
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Menu>>> UpdateMenu(Menu request)
        {
            var dbMenu = _men.Menus.Find(request.Id);
            if (dbMenu == null)
                return BadRequest("No menus have that id.");

            dbMenu.Id = request.Id;
            dbMenu.M1 = request.M1;
            dbMenu.M2 = request.M2;
            dbMenu.M3 = request.M3;
            dbMenu.D1 = request.D1;
            dbMenu.D2 = request.D2;
            dbMenu.S1 = request.S1;
            dbMenu.S2 = request.S2;
            await _men.SaveChangesAsync();
            return Ok(await _men.Menus.ToListAsync());
        }
    }
}
