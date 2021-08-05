using GuitarDairy.Domain.ValueObjects;
using System;
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

        public MonthSummary(MonthDate date, IEnumerable<Entry> entries)
            : base(date.ToDayRange(), entries)
        {
            Date = date;
            PerDaySummaries = entries.OrderBy(x => x.Date)
                .GroupBy(x => x.Date)
                .Select(x => DaySummary.FromEntries(x.Key, x))
                .ToList();
        }       
    }
}
