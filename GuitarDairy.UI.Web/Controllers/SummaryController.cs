using GuitarDairy.Application.Services.Interfaces;
using GuitarDairy.Domain.ValueObjects;
using GuitarDairy.UI.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
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
            var viewModel = MonthSummaryViewModel.FromModel(summary);

            return View(viewModel);
        }
    }
}
