using Microsoft.EntityFrameworkCore;

namespace TrailStatus.Models
{
    public class TrailsContext : DbContext
    {
        public TrailsContext(DbContextOptions<TrailsContext> options)
            : base(options)
        {
        }

        public DbSet<Trail> Trail { get; set; }
    }
}
