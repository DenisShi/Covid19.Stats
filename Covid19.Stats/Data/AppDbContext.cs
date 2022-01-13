using Microsoft.EntityFrameworkCore;

namespace Covid19.Stats.Data

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<CovidStat> Stats { get; set; }
    }
}
