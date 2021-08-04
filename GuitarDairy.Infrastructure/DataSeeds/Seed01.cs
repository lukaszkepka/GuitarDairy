using GuitarDairy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarDairy.Infrastructure.EF.DataSeeds
{
    public static class Seed01
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var categories = new[]
            {
                new Category { Id = 1, Name = "Warmup" },
                new Category { Id = 2, Name = "Rhythm" },
                new Category { Id = 3, Name = "Soloing" },
                new Category { Id = 4, Name = "Jazz" },
                new Category { Id = 5, Name = "Funk" }
            };

            var exercises = new[]
            {
                new Exercise { Id = 1, CategoryId = 4, Name = "Altered Scale", Description = "" },
                new Exercise { Id = 2, CategoryId = 1, Name = "Eugene's trickbag", Description = "" },
                new Exercise { Id = 3, CategoryId = 3, Name = "Chromatics", Description = "" }
            };

            var entries = new[]
            {
                new Entry { Id = 1, Date = DateTime.Today, Duration = TimeSpan.FromMinutes(30), ExerciseId = 1 },
                new Entry { Id = 2, Date = DateTime.Today, Duration = TimeSpan.FromMinutes(30), ExerciseId = 2 },
                new Entry { Id = 3, Date = DateTime.Today, Duration = TimeSpan.FromMinutes(30), ExerciseId = 3 }
            };

            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Exercise>().HasData(exercises);
            modelBuilder.Entity<Entry>().HasData(entries);
        }
    }
}
