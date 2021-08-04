using GuitarDairy.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarDairy.Domain.Entities
{
    public class MonthSummary
    {
        public MonthDate Month { get; set; }

        public TimeSpan TotalTime { get; }

        public ICollection<DaySummary> Days { get; set; }
    }
}
