using System;
using System.Collections.Generic;
using System.Linq;

namespace GuitarDairy.Domain.Entities
{
    public class DaySummary
    {
        public DateTime Date { get; }
        public ICollection<Entry> Entries { get; }

        private DaySummary(DateTime date, IEnumerable<Entry> entries)
        {
            Date = date;
            Entries = entries.ToList();
        }
        
        //public static FromEntries(IEnumerable<Entry> entries)
        //{
        //    var date = entries.Select(x => x.Date.Date).Distinct()
        //    if (date is null)
        //    {
        //        throw new ArgumentException();
        //    }

        //    return new DaySummary()
        //}
    }
}
