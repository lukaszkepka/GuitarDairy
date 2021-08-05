using GuitarDairy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuitarDairy.UnitTests.DataGeneration
{
    public static class ExerciseDataGenerator
    {
        private static readonly Random _random = new();

        public static Exercise GenerateFromName(string name)
        {
            return new Exercise()
            {
                Id = _random.Next(),
                Name = name,
                Description = ""
            };
        }

        public static IEnumerable<Exercise> GenerateFromNames(params string[] names)
        {
            return names.Select(x => GenerateFromName(x));
        }
    }
}
