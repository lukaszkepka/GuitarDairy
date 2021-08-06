using GuitarDairy.Domain.Extensions;
using GuitarDairy.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuitarDairy.Domain.Entities
{
    public abstract class EntriesSummary
    {
        private readonly List<Entry> _entries;

        public List<ExerciseSummary> ExerciseSummaries => _entries.GetPerExerciseSummary().ToList();

        public TimeSpan TotalTimeSpent => _entries.TotalTimeSpent();

        public ExclusiveRange<DayDate> DateRange { get; }

        protected EntriesSummary(ExclusiveRange<DayDate> dateRange, IEnumerable<Entry> entries)
        {
            var dates = entries.Select(x => x.Date).Distinct();

            if (entries.Any() && (dates.Min() < dateRange.From || dates.Max() > dateRange.To))
            {
                throw new ArgumentException($"Entry dates should be in range {dateRange}. Was {dates.Min()} or {dates.Max()}");
            }

            _entries = entries.ToList();
            DateRange = dateRange;
        }
    }
}
