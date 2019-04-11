using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RocketWebApp.Models;
using System.Web.Http.Cors;

namespace RocketWebApp.Controllers
{

    [Route("api/column")]
    [ApiController]
    public class ColumnController : ControllerBase
    {
        private readonly RocketAppContext _context;

        public ColumnController(RocketAppContext context)
        {
            _context = context;
        }


        // GET: api/column ( All columns )
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Column>>> GetColumn()
        {
            return await _context.columns.OrderBy(s => s.Id).ToListAsync();
        }


        // GET api/column/inactive ( Only columns with status Inactive )
        [HttpGet("inactive")]
        public IEnumerable<Column> GetInactiveColumn()
        {
            IQueryable<Column> columns =
               from elev in _context.columns
               where elev.Status == "Inactive"
               select elev;

            return columns.ToList();
        }



        // GET: api/column/ID ( Search column by ID )
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Column>>> GetColumnWithId(long id)
        {
            var Columns = await _context.columns.FindAsync(id);

            if (Columns == null)
            {
                return NotFound();
            }

            List<Column> columnsList = new List<Column>();
            columnsList.Add(Columns);

            return columnsList;
        }


        // PUT: api/column/id ( Update column status by ID )
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColumnsStatus(long id, Column columns)
        {
            // If column with the ID specified doesn't exist
            if (id != columns.Id)
            {
                return BadRequest();
            }
            var currentColumn = _context.elevators.Find(columns.Id);
            if (currentColumn == null)
                return NotFound();

            currentColumn.Status = columns.Status;

            // Restriction on columns status you can PUT 
            if (columns.Status == "Intervention" || columns.Status == "Active" || columns.Status == "Inactive")
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