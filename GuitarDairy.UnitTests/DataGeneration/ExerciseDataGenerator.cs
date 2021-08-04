using GuitarDairy.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace GuitarDairy.UnitTests.DataGeneration
{
    public static class ExerciseDataGenerator
    {
        public static Exercise GenerateFromName(string name)
        {
            return new Exercise()
            {
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
