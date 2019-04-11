
using Microsoft.EntityFrameworkCore;

namespace RocketWebApp.Models
{
    public class RocketAppContext : DbContext
    {
        public RocketAppContext(DbContextOptions<RocketAppContext> options)
            : base(options)
        {           
        }

        public DbSet<Elevator> elevators { get; set; }
        public DbSet<ElevatorBasic> elevatorsBasic { get; set; }
        public DbSet<Column> columns { get; set; }
        public DbSet<Battery> batteries { get; set; }
        public DbSet<Building> buildings { get; set; }
        public DbSet<Lead> leads { get; set; }
    }
}
