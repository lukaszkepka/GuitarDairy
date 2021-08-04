using System;

namespace GuitarDairy.Domain.ValueObjects
{
    public class DayDate : MonthDate
    {
        public int Day { get; }

        public DayDate(int day, int month, int year) : base(month, year)
        {
            ValidateDay(day, month, year);
            Day = day;
        }

        private void ValidateDay(int day, int month, int year)
        {
            var daysInMonth = DateTime.DaysInMonth(year, month);
            if (ExclusiveRange<int>.Create(1, daysInMonth).DoesNotContain(day))
            {
                throw new ArgumentOutOfRangeException($"Month should be in range <1-{daysInMonth}>");
            }
        }

        public static implicit operator DayDate(DateTime dateTime)
        {
            return new DayDate(dateTime.Day, dateTime.Month, dateTime.Year);
        }

        public static implicit operator DateTime(DayDate dayDate)
        {
            return new DateTime(dayDate.Year, dayDate.Month, dayDate.Day);
        }
    }
}
