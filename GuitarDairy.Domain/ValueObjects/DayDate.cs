using System;

namespace GuitarDairy.Domain.ValueObjects
{
    public readonly struct DayDate : IComparable<DayDate>
    {
        private readonly DateTime _internalDateTime;

        public int Day => _internalDateTime.Day;
        public int Month => _internalDateTime.Month;
        public int Year => _internalDateTime.Year;

        public DayDate(int day, int month, int year)
            : this(new DateTime(year, month, day))
        {
        }

        private DayDate(DateTime dateTime)
        {
            _internalDateTime = dateTime.Date;
        }

        public DayDate NextDay()
        {
            return new DayDate(_internalDateTime.AddDays(1));
        }

        public DayDate PreviousDay()
        {
            return new DayDate(_internalDateTime.AddDays(-1));
        }

        public MonthDate ToMonthDate()
        {
            return new MonthDate(Month, Year);
        }

        public int CompareTo(DayDate other)
        {
            return _internalDateTime.CompareTo(other);
        }

        public static implicit operator DayDate(DateTime dateTime) => new(dateTime);

        public static implicit operator DateTime(DayDate dayDate) => dayDate._internalDateTime;
        public static bool operator >=(DayDate item1, DayDate item2) => item1._internalDateTime >= item2._internalDateTime;
        public static bool operator <=(DayDate item1, DayDate item2) => item1._internalDateTime <= item2._internalDateTime;
        public static bool operator >(DayDate item1, DayDate item2) => item1._internalDateTime > item2._internalDateTime;
        public static bool operator <(DayDate item1, DayDate item2) => item1._internalDateTime < item2._internalDateTime;
    }
}
