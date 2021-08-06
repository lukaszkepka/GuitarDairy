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
        public virtual IEnumerable<DaySummary> PerDaySummaries => _entriesPerEachDay.Select(x => DaySummary.FromEntries(x.Key, x.Value));

        private MonthSummary(MonthDate monthDate, IEnumerable<Entry> entries)
            : base(monthDate.ToDaysRange(), entries)
        {                  
            Date = monthDate;
        }

        public static MonthSummary FromEntries(MonthDate date, IEnumerable<Entry> entries)
        {
            return new MonthSummary(date, entries);
        }
    }
}
