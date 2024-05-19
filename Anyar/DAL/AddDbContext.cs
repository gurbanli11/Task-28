using Anyar.Models;
using Microsoft.EntityFrameworkCore;

namespace Anyar.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Team> Teams { get; set; }

    }
}
