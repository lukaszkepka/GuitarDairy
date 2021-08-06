using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarDairy.Domain.ValueObjects
{
    public record MonthDate : IComparable<MonthDate>
    {
        public int Month { get; }
        public int Year { get; }

        private static readonly ExclusiveRange<int> ValidYearsRange = ExclusiveRange<int>.Create(1, 9999);
        private static readonly ExclusiveRange<int> ValidMonthsRange = ExclusiveRange<int>.Create(1, 12);

        public MonthDate(int month, int year)
        {
            Month = month;
            Year = year;

            ValidateMonth(month);
            ValidateYear(year);
        }

        public static MonthDate FromDateTime(DateTime dateTime)
        {
            return dateTime;
        }

        public ExclusiveRange<DayDate> ToDayRange()
        {
            var start = new DayDate(1, Month, Year);
            var end = new DayDate(DateTime.DaysInMonth(Year, Month), Month, Year);
            return ExclusiveRange<DayDate>.Create(start, end);
        }

        public IEnumerable<DayDate> Days()
        {
            return Enumerable.Range(1,DateTime.DaysInMonth(Year, Month)).Select(x => new DayDate(x, Month, Year));
        }

        private static void ValidateMonth(int month)
        {
            if (ValidMonthsRange.DoesNotContain(month))
            {
                throw new ArgumentOutOfRangeException($"Month should be in range {ValidMonthsRange}");
            }
        }

        private static void ValidateYear(int year)
        {
            if (ValidYearsRange.DoesNotContain(year))
            {
                throw new ArgumentOutOfRangeException($"Year should be in range {ValidYearsRange}");
            }
        }      

        public static implicit operator DateTime(MonthDate dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        public static implicit operator MonthDate(DateTime dateTime)
        {
            return new MonthDate(dateTime.Month, dateTime.Year);
        }

        public static bool operator >=(MonthDate item1, MonthDate item2) => (DateTime)item1 >= (DateTime)item2;

        public static bool operator <=(MonthDate item1, MonthDate item2) => (DateTime)item1 <= (DateTime)item2;

        public static bool operator >(MonthDate item1, MonthDate item2) => (DateTime)item1 > (DateTime)item2;

        public static bool operator <(MonthDate item1, MonthDate item2) => (DateTime)item1 < (DateTime)item2;

        public int CompareTo(MonthDate other)
        {
            return ((DateTime)this).CompareTo(other);
        }
    }
}
