using Microsoft.EntityFrameworkCore;
namespace DotnetBakery.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}

        // Bakers is what db table will be called
        // this is _context.Bakers
        // DBSet<Baker> means; data from the db, which is mapped to Baker model 
        public DbSet<Baker> Bakers { get; set; }
    }
}