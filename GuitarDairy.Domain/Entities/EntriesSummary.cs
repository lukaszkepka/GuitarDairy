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

        public IEnumerable<ExerciseSummary> ExerciseSummaries => _entries.GetPerExerciseSummary();

        public TimeSpan TotalTimeSpent => _entries.TotalTimeSpent();

        public ExclusiveRange<DayDate> DateRange { get; }

        protected EntriesSummary(ExclusiveRange<DayDate> dateRange, IEnumerable<Entry> entries)
        {
            var dates = entries.Select(x => x.Date).Distinct();
            var minDate = dates.Min();
            var maxDate = dates.Max();

            if (entries.Any() && (minDate < dateRange.From || maxDate > dateRange.To))
            {
                throw new ArgumentException($"Entry dates should be in range {dateRange}. Was {minDate}");
            }

            _entries = entries.ToList();
            DateRange = dateRange;
        }
    }
}
