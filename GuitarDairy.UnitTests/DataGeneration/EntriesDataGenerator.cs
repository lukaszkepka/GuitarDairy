using GuitarDairy.Domain.Entities;
using System;
using System.Collections.Generic;

namespace GuitarDairy.UnitTests.DataGeneration
{
    public static class EntriesDataGenerator
    {
        public static IEnumerable<Entry> Generate(Exercise exercise, IEnumerable<Tuple<DateTime, int>> items)
        {
            foreach (var item in items)
            {
                for (int i = 0; i < item.Item2; i++)
                {
                    yield return new Entry()
                    {
                        Duration = TimeSpan.FromMinutes(30),
                        Date = item.Item1,
                        Exercise = exercise
                    };
                }
            }
        }
    }
}
