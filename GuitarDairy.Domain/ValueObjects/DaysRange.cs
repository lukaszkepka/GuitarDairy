using System.Collections.Generic;
using System.Linq;

namespace GuitarDairy.Domain.ValueObjects
{
    public record DaysRange : ExclusiveRange<DayDate>
    {
        protected DaysRange(ExclusiveRange<DayDate> original) : base(original)
        {
        }

        protected DaysRange(DayDate from, DayDate to) : base(from, to)
        {
        }

        public static DaysRange CreateFrom(DayDate from, DayDate to)
        {
            return new DaysRange(from, to);
        }

        public static DaysRange ForSingleDay(DayDate date)
        {
            return new DaysRange(date, date);
        }

        public IEnumerable<DayDate> AsEnumerable()
        {
            var currentDate = From;
            do
            {
                yield return currentDate;
                currentDate = currentDate.NextDay();
            } while (currentDate <= To);
        }

        public override string ToString()
        {
            return $"<{From} - {To}>";
        }
    }
}
