using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarDairy.Domain.ValueObjects
{

    public class MonthDate
    {
        public int Month { get; }
        public int Year { get; }

        public MonthDate(int month, int year)
        {
            ValidateMonth(month);
            ValidateYear(year);

            Month = month;
            Year = year;
        }

        private void ValidateMonth(int month)
        {
            if (ExclusiveRange<int>.Create(1, 12).DoesNotContain(month))
            {
                throw new ArgumentOutOfRangeException("Month should be in range <1-12>");
            }
        }

        private void ValidateYear(int year)
        {
            if (ExclusiveRange<int>.Create(1, 9999).DoesNotContain(year))
            {
                throw new ArgumentOutOfRangeException("Year should be in range <1-9999>");
            }
        }

        public static implicit operator MonthDate(DateTime dateTime)
        {
            return new MonthDate(dateTime.Month, dateTime.Year);
        }

        public static implicit operator DateTime(MonthDate dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }
    }
}
