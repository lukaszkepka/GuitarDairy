using GuitarDairy.Domain.Entities;
using System;

namespace GuitarDairy.UI.Web.ViewModels
{
    public record ExerciseSummaryViewModel
    {
        public string Name { get; private init; }

        public TimeSpan TotalTimeSpent { get; private init; }

        public static ExerciseSummaryViewModel FromModel(ExerciseSummary summary)
        {
            return new ExerciseSummaryViewModel
            {
                Name = summary.Exercise.Name,
                TotalTimeSpent = summary.TimeSpent,
            };
        }
    }
}
