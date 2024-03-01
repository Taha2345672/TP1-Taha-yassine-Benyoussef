using Microsoft.EntityFrameworkCore;

namespace Projet.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Enfant> Enfants { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Seed();
        }
    }
}
