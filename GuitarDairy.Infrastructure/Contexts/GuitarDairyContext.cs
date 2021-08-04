using GuitarDairy.Domain.Entities;
using GuitarDairy.Infrastructure.EF.DataSeeds;
using GuitarDairy.Infrastructure.EF.Mapping;
using Microsoft.EntityFrameworkCore;


namespace GuitarDairy.Infrastructure
{
    public class GuitarDairyContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Entry> Entries { get; set; }

        public GuitarDairyContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .ApplyConfiguration(new CategoryMap())
                .ApplyConfiguration(new ExerciseMap())
                .ApplyConfiguration(new EntryMap());

            modelBuilder.Seed();
        }
    }
}
