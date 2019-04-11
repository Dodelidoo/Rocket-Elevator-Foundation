using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RocketWebApp.Models;
using System;
using System.Web.Http.Cors;

namespace RocketWebApp.Controllers
{

    [Route("api/lead")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private readonly RocketAppContext _context;

        // Declaring context
        public LeadsController(RocketAppContext context)
        {
            _context = context;
        }


        // GET: api/lead (All Leads)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lead>>> GetLeads()
        {
            return await _context.leads.OrderBy(s => s.Id).ToListAsync();
        }


        // GET api/lead/recent ( Only recent leads without being customer )    
        [HttpGet("recent")]
        public List<Lead> GetRecentLeads()
        {
            List<Lead> recentList = new List<Lead>();

            // Query leads with null customer_id 
            IQueryable<Lead> LeadsNotCustomer =
            from l in _context.leads
            where l.Customer_id == null
            select l;

            // Looping on LeadsNotCustomer and find recent ones (last 30 days)
            foreach (Lead lead in LeadsNotCustomer)
            {
                var leadDate = lead.Created_at;
                var tooAncientDate = DateTime.Now.AddDays(-30);

                // Filter date older than 30 days
                if (leadDate >= tooAncientDate)
                {
                    recentList.Add(lead);
                }
            }
            return recentList;
        }


        // GET: api/lead/id ( Search leads by ID )
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Lead>>> GetBatteryWithId(long id)
        {
            var Leads = await _context.leads.FindAsync(id);

            if (Leads == null)
            {
                return NotFound();
            }

            List<Lead> leadsList = new List<Lead>();
            leadsList.Add(Leads);
            
            return leadsList;
        }
    }
}