using GuitarDairy.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarDairy.Domain.Entities
{
    public class MonthSummary : EntriesSummary
    {
        public MonthDate Date { get; }
        public ICollection<DaySummary> PerDaySummaries { get; }

        private MonthSummary(MonthDate monthDate, IEnumerable<Entry> entries)
            : base(monthDate.ToDayRange(), entries)
        {                  
            Date = monthDate;
            PerDaySummaries = EntriesPerMonthDays.For(monthDate, entries)
                .Select(x => DaySummary.FromEntries(x.Key, x.Value))
                .ToList();
        }

        public static MonthSummary FromEntries(MonthDate date, IEnumerable<Entry> entries)
        {
            return new MonthSummary(date, entries);
        }
    }
}
