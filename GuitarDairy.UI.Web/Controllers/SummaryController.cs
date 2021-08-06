using GuitarDairy.Application.Services.Interfaces;
using GuitarDairy.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarDairy.UI.Web.Controllers
{
    public class SummaryController : Controller
    {
        private readonly IMonthSummaryService _summaryService;

        public SummaryController(IMonthSummaryService summaryService)
        {
            _summaryService = summaryService;
        }



        // GET: Summary
        //[Route("Summary/Current")]
        public async Task<IActionResult> Index()
        {
            var currentMonth = MonthDate.FromDateTime(DateTime.Now);
            var summary = await _summaryService.GetSummaryFor(currentMonth);

            return View();
        }
    }

    public record DaySummaryViewModel
    {

    }

    public record MonthSummaryViewModel
    {
        public string Month { get; set; }
        public TimeSpan TotalTimeSpent { get; set; }
        public List<DaySummaryViewModel> DaySummaries { get; set; }
    }
}
