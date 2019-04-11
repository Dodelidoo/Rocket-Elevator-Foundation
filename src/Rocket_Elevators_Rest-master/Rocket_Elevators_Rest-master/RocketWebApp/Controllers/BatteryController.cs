using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RocketWebApp.Models;
using System.Web.Http.Cors;

namespace RocketWebApp.Controllers
{
   
    [Route("api/battery")]
    [ApiController]
    public class BatteryController : ControllerBase
    {
        private readonly RocketAppContext _context;

        public BatteryController(RocketAppContext context)
        {
            _context = context;
        }


        // GET: api/battery ( All batteries )
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Battery>>> GetBattery()
        {        
            return await _context.batteries.OrderBy(s => s.Id).ToListAsync();
        }


        // GET api/battery/inactive ( Only battery with status Inactive )
        [HttpGet("inactive")]
        public IEnumerable<Battery> GetInactiveBattery()
        {
            IQueryable<Battery> batteries =
              from bat in _context.batteries
              where bat.Status == "Inactive"
              select bat;

            return batteries.ToList();
        }


        // GET: api/battery/id ( Search battery by ID )
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Battery>>> GetBatteryWithId(long id)
        {
            var Batteries = await _context.batteries.FindAsync(id);

            if (Batteries == null)
            {
                return NotFound();
            }

            List<Battery> batteryList = new List<Battery>();
            batteryList.Add(Batteries);

            return batteryList;
        }


        // PUT: api/battery/id ( Update battery status by ID )
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, Battery batteries)
        {
            // If battery with the ID specified doesn't exist
            if (id != batteries.Id)
            {
                return BadRequest();
            }
            var currentBattery = _context.elevators.Find(batteries.Id);
            if (currentBattery == null)
                return NotFound();

            currentBattery.Status = batteries.Status;

            // Restriction on batteries status you can PUT 
            if (batteries.Status == "Intervention" || batteries.Status == "Active" || batteries.Status == "Inactive")
            {
                await _context.SaveChangesAsync();
            }
            else
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}