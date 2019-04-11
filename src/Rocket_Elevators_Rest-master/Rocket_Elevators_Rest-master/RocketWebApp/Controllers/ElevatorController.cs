using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RocketWebApp.Models;
using System.Web.Http.Cors;

namespace RocketWebApp.Controllers
{

    [Route("api/elevator")]
    [ApiController]
    public class ElevatorController : ControllerBase
    {
        private readonly RocketAppContext _context;

        public ElevatorController(RocketAppContext context)
        {
            _context = context;
        }

        // GET: api/elevator ( All Elevators )
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Elevator>>> GetElevator()
        {
            return await _context.elevators.OrderBy(s => s.Id).ToListAsync();
        }


        // GET api/elevator/Inactive ( Only elevators with status Inactive )
        [HttpGet("inactive")]
        public IEnumerable<Elevator> GetInactiveElevator()
        {
            IQueryable<Elevator> elevators =
               from elev in _context.elevators
               where elev.Status == "Inactive"
               select elev;

            return elevators.ToList();
        }


        // GET: api/elevator ( Search elevator by ID )
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Elevator>>> GetElevatorWithId(long id)
        {

            var elevators = await _context.elevators
                .FindAsync(id);

            if (elevators == null)
            {
                return NotFound();
            }
            List<Elevator> elevatorsList = new List<Elevator>();
            elevatorsList.Add(elevators);

            return elevatorsList;
        }


        // PUT: api/elevator/id ( Update status of elevators by ID )
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElevator(long id, Elevator elevators)
        {
            // If elevator with the ID specified doesn't exist
            if (id != elevators.Id)
            {
                return BadRequest();
            }
            var currentElevator = _context.elevators.Find(elevators.Id);
            if (currentElevator == null)
                return NotFound();

            currentElevator.Status = elevators.Status;

            // Restriction on elevators status you can PUT 
            if (elevators.Status == "Intervention" || elevators.Status == "Active" || elevators.Status == "Inactive")
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