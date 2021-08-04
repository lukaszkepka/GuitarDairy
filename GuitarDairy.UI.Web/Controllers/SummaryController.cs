using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarDairy.UI.Web.Controllers
{
    public class SummaryController : Controller
    {
        // GET: Summary
        //[Route("Summary/Current")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
