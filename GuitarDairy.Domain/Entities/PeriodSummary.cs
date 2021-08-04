using GuitarDairy.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuitarDairy.Domain.Entities
{
    public abstract class PeriodSummary
    {
        public ICollection<Entry> Entries { get; }

        public TimeSpan TotalTime => TimeSpan.FromSeconds(Entries.Sum(x => x.Duration.TotalSeconds));

        protected PeriodSummary(ExclusiveRange<DayDate> dateRange, IEnumerable<Entry> entries)
        {
            var dates = entries.Select(x => x.Date).Distinct();
            var minDate = dates.Min();
            var maxDate = dates.Max();

            if (minDate < dateRange.From)
            {
                throw new ArgumentException($"Entry dates should be in range {dateRange}. Was {minDate}");
            }

            if (maxDate > dateRange.To)
            {
                throw new ArgumentException($"Entry dates should be in range {dateRange}. Was {maxDate}");
            }

            Entries = entries.ToList();
        }
    }
}
