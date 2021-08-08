using GuitarDairy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuitarDairy.UI.Web.ViewModels
{
    public record DaySummaryViewModel
    {
        public DateTime Date { get; private init; }

        public TimeSpan TotalTimeSpent { get; private init; }

        public List<ExerciseSummaryViewModel> ExerciseSummaries { get; private init; }

        public static DaySummaryViewModel FromModel(DaySummary daySummary)
        {
            return new DaySummaryViewModel
            {
                Date = daySummary.Date,
                TotalTimeSpent = daySummary.TotalTimeSpent,
                ExerciseSummaries = daySummary.ExerciseSummaries
                    .Select(x => ExerciseSummaryViewModel.FromModel(x))
                    .ToList()
            };
        }
    }
}
