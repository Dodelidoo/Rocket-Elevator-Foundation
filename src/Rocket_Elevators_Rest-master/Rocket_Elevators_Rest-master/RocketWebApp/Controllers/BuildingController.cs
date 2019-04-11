using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RocketWebApp.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System.Web.Http.Cors;

namespace RocketWebApp.Controllers
{

    [Route("api/building")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly RocketAppContext _context;

        public BuildingController(RocketAppContext context)
        {
            _context = context;
        }


        // GET: api/building ( All buildings )
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Building>>> GetBuilding()
        {
            return await _context.buildings.OrderBy(s => s.Id).ToListAsync();
        }


        // GET: api/building/id ( Search buildings by ID )
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Building>>> GetBuildingWithId(long id)
        {
            var building = await _context.buildings.FindAsync(id);

            if (building == null)
            {
                return NotFound();
            }

            List<Building> buildingsList = new List<Building>();
            buildingsList.Add(building);

            return buildingsList;
        }


        // GET api/building/inactive ( Only buildings with elevator/column or battery inactive in them)
        [HttpGet("inactive")]
        public IEnumerable<Building> GetInactiveBuilding()
        {
            IQueryable<Building> Building =
               from bu in _context.buildings
               join ba in _context.batteries on bu.Id equals ba.Building_id
               join co in _context.columns on ba.Id equals co.Battery_id
               join el in _context.elevators on co.Id equals el.Column_id
               where ba.Status == "Inactive" || co.Status == "Inactive" || el.Status == "Inactive"
               select bu;
        
            return Building.Distinct();
        }
    }
}