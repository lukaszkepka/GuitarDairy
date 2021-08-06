using GuitarDairy.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace GuitarDairy.Domain.Entities
{
    public interface IEntriesSummary
    {
        List<ExerciseSummary> ExerciseSummaries { get; }
        TimeSpan TotalTimeSpent { get; }
        DaysRange DateRange { get; }
    }
}
