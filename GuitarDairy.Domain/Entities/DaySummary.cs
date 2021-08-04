using GuitarDairy.Domain.ValueObjects;
using System.Collections.Generic;

namespace GuitarDairy.Domain.Entities
{
    public class DaySummary : PeriodSummary
    {
        public DayDate Date { get; }

        private DaySummary(DayDate date, IEnumerable<Entry> entries) 
            : base(ExclusiveRange<DayDate>.Create(date, date), entries)
        {
            Date = date;
        }

        public static DaySummary FromEntries(DayDate date, IEnumerable<Entry> entries)
        {
            return new DaySummary(date, entries);
        }
    }
}
