using Microsoft.EntityFrameworkCore;

namespace DisneyWebAPI.Models
{
    public class DisneyContext : DbContext
    {
        public DisneyContext(DbContextOptions<DisneyContext> options)
            : base(options)
        {
        }

        public DbSet<Character> characters { get; set; }
        public DbSet<Multimedia> multimedias { get; set; }
        public DbSet<Genre> genres { get; set; }
    }
}