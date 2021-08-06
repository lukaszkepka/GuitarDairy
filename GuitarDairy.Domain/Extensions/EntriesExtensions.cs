using GuitarDairy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarDairy.Domain.Extensions
{
    public static class EntriesExtensions
    {
        public static TimeSpan TotalTimeSpent(this IEnumerable<Entry> entries)
        {
            return TimeSpan.FromSeconds(entries.Sum(x => x.Duration.TotalSeconds));
        }

        public static IEnumerable<ExerciseSummary> GetPerExerciseSummary(this IEnumerable<Entry> entries)
        {
            return entries.GroupBy(x => x.ExerciseId).Select(x => ExerciseSummary.FromEntries(x));
        }
    }
}
