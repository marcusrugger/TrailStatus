using Microsoft.EntityFrameworkCore;

namespace TrailStatus.Models
{
    public class TrailsContext : DbContext
    {
        public TrailsContext(DbContextOptions<TrailsContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=TrailStatus.db");
        }

        public DbSet<Trail> Trails { get; set; }
    }
}
