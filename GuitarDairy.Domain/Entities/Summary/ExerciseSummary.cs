using GuitarDairy.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuitarDairy.Domain.Entities
{
    public record ExerciseSummary
    {
        public TimeSpan TimeSpent { get; }
        public Exercise Exercise { get; }

        private ExerciseSummary(TimeSpan timeSpent, Exercise exercise)
        {
            TimeSpent = timeSpent;
            Exercise = exercise;
        }

        public static ExerciseSummary FromEntries(IEnumerable<Entry> entries)
        {
            var exercise = entries.Select(x => x.Exercise).Distinct().SingleOrDefault();

            if(exercise is null)
            {
                throw new ArgumentException("Exercise summary can be created only from entries from the same exercise");
            }

            return new ExerciseSummary(entries.TotalTimeSpent(), exercise);
        }
    }
}
