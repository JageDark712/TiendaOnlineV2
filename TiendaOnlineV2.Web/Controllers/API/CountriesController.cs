using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaOnlineV2.Web.Data;

namespace TiendaOnlineV2.Web.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CountriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCountries()
        {
            return Ok(_context.Countries
                .Include(c => c.Departments)
                .ThenInclude(d => d.Cities));
        }
    }
}
