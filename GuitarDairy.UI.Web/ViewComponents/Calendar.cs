using GuitarDairy.UI.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarDairy.UI.Web.ViewComponents
{
    public class CalendarItem
    {
        public DateTime? Date { get; set; }
    }

    public class Calendar : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(MonthSummaryViewModel monthViewModel)
        {
            List<CalendarItem> items = new List<CalendarItem>();

            var itemsToAdd = (int)monthViewModel.DaySummaries.First().Date.DayOfWeek - 1;
            itemsToAdd = itemsToAdd < 0 ? 6 : itemsToAdd;

            for (int i = 0; i < itemsToAdd; i++)
            {
                items.Add(new CalendarItem());
            }

            foreach (var item in monthViewModel.DaySummaries)
            {
                items.Add(new CalendarItem() { Date = item.Date });
            }

            itemsToAdd = 7 - (int)monthViewModel.DaySummaries.Last().Date.DayOfWeek;
            itemsToAdd = itemsToAdd == 7 ? 0 : itemsToAdd;

            for (int i = 0; i < itemsToAdd; i++)
            {
                items.Add(new CalendarItem());
            }

            return Task.FromResult<IViewComponentResult>(View(items));
        }
    }
}
