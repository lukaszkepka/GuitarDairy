using System;

namespace GuitarDairy.Domain.ValueObjects
{
    public record DayDate : MonthDate, IComparable<DayDate>
    {
        public int Day { get; }

        public DayDate(int day, int month, int year) : base(month, year)
        {
            ValidateDay(day, month, year);
            Day = day;
        }

        public DayDate NextDay()
        {
            return ((DateTime)this).AddDays(1);
        }

        private void ValidateDay(int day, int month, int year)
        {
            var validDaysRange = ExclusiveRange<int>.Create(1, DateTime.DaysInMonth(year, month));

            if (validDaysRange.DoesNotContain(day))
            {
                throw new ArgumentOutOfRangeException($"Month should be in range {validDaysRange}");
            }
        }

        public static implicit operator DayDate(DateTime dateTime)
        {
            return new DayDate(dateTime.Day, dateTime.Month, dateTime.Year);
        }

        public static implicit operator DateTime(DayDate dayDate)
        {
            if(dayDate is null)
            {
                return new DateTime();
            }

            return new DateTime(dayDate.Year, dayDate.Month, dayDate.Day);
        }

        public static bool operator >=(DayDate item1, DayDate item2) => (DateTime)item1 >= (DateTime)item2;

        public static bool operator <=(DayDate item1, DayDate item2) => (DateTime)item1 <= (DateTime)item2;

        public static bool operator >(DayDate item1, DayDate item2) => (DateTime)item1 > (DateTime)item2;

        public static bool operator <(DayDate item1, DayDate item2) => (DateTime)item1 < (DateTime)item2;

        public int CompareTo(DayDate other)
        {
            return ((DateTime)this).CompareTo(other);
        }
    }
}
