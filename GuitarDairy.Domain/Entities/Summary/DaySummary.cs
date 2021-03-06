using GuitarDairy.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace GuitarDairy.Domain.Entities
{
    public class DaySummary : EntriesSummary
    {
        public DayDate Date { get; }

        private DaySummary(DayDate date, IEnumerable<Entry> entries) 
            : base(DaysRange.ForSingleDay(date), entries)
        {
            Date = date;
        }

        public static DaySummary FromEntries(DayDate date, IEnumerable<Entry> entries)
        {
            return new DaySummary(date, entries);
        }
    }
}
