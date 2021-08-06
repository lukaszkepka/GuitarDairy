using GuitarDairy.Domain.Extensions;
using GuitarDairy.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuitarDairy.Domain.Entities
{
    public abstract class EntriesSummary : IEntriesSummary
    {
        protected readonly EntriesPerDays _entriesPerEachDay;
        private IEnumerable<Entry> AllEntries => _entriesPerEachDay.SelectMany(x => x.Value);

        public List<ExerciseSummary> ExerciseSummaries => AllEntries.GetPerExerciseSummary().ToList();

        public TimeSpan TotalTimeSpent => AllEntries.TotalTimeSpent();

        public DaysRange DateRange { get; }

        protected EntriesSummary(DaysRange dateRange, IEnumerable<Entry> entries)
        {
            ValidateEntries(dateRange, entries);

            _entriesPerEachDay = EntriesPerDays.For(dateRange, entries);
            DateRange = dateRange;
        }

        private static void ValidateEntries(DaysRange dateRange, IEnumerable<Entry> entries)
        {
            var dates = entries.Select(x => x.Date).Distinct();
            if (entries.Any() && (dates.Min() < dateRange.From || dates.Max() > dateRange.To))
            {
                throw new ArgumentException($"Entry dates should be in range {dateRange}. Actual range <{dates.Min()} - {dates.Max()}>");
            }
        }
    }
}
