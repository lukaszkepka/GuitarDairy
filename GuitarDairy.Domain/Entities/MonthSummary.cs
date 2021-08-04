using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarDairy.Domain.Entities
{
    public class MonthSummary
    {
        public DateTime Month { get; set; }

        public TimeSpan TotalTime { get; }

        public ICollection<DaySummary> Days { get; set; }
    }
}
