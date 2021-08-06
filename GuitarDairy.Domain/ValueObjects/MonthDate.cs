using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarDairy.Domain.ValueObjects
{
    public readonly struct MonthDate : IComparable<MonthDate>
    {
        private readonly DateTime _internalDateTime;

        public int Month => _internalDateTime.Month;
        public int Year => _internalDateTime.Year;

        public MonthDate(int month, int year)
            : this(new DateTime(year, month, 1))
        {
        }

        private MonthDate(DateTime dateTime)
        {
            _internalDateTime = new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        public static MonthDate FromDateTime(DateTime dateTime)
        {
            return new MonthDate(dateTime);
        }

        public ExclusiveRange<DayDate> ToDayRange()
        {
            var start = new DayDate(1, Month, Year);
            var end = new DayDate(DateTime.DaysInMonth(Year, Month), Month, Year);
            return ExclusiveRange<DayDate>.Create(start, end);
        }

        public IEnumerable<DayDate> Days()
        {
            var dayRange = ToDayRange();
            int month = Month;
            int year = Year;

            return Enumerable.Range(dayRange.From.Day, dayRange.To.Day)
                .Select(x => new DayDate(x, month, year));
        }

        public int CompareTo(MonthDate other)
        {
            return _internalDateTime.CompareTo(other._internalDateTime);
        }

        public static implicit operator DateTime(MonthDate monthDate)
        {
            return monthDate._internalDateTime;
        }

        public static implicit operator MonthDate(DateTime dateTime)
        {
            return new MonthDate(dateTime);
        }

        public static bool operator >=(MonthDate item1, MonthDate item2) => item1._internalDateTime >= item2._internalDateTime;
        public static bool operator <=(MonthDate item1, MonthDate item2) => item1._internalDateTime <= item2._internalDateTime;
        public static bool operator >(MonthDate item1, MonthDate item2) => item1._internalDateTime > item2._internalDateTime;
        public static bool operator <(MonthDate item1, MonthDate item2) => item1._internalDateTime < item2._internalDateTime;
    }
}
