using GuitarDairy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace GuitarDairy.UI.Web.ViewModels
{
    public record MonthSummaryViewModel
    {
        public DateTime DateTime { get; private init; }
        public string Month { get; private init; }
        public TimeSpan TotalTimeSpent { get; private init; }
        public List<DaySummaryViewModel> DaySummaries { get; private init; }

        public static MonthSummaryViewModel FromModel(MonthSummary monthSummary)
        {
            return new MonthSummaryViewModel
            {
                DateTime = monthSummary.Date,
                Month = DateTimeFormatInfo.InvariantInfo.MonthNames[monthSummary.Date.Month - 1],
                TotalTimeSpent = monthSummary.TotalTimeSpent,
                DaySummaries = monthSummary.PerDaySummaries.Select(x => DaySummaryViewModel.FromModel(x)).ToList()
            };
        }
    }
}
