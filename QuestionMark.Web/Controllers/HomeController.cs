using Microsoft.AspNetCore.Mvc;
using QuestionMark.Models;
using System.Diagnostics;
using QuestionMark.Services.Models;
using QuestionMark.Services.Services;
using ViewModel = QuestionMark.Web.Models.ViewModel;

namespace QuestionMark.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DayCalculatorService _dayCalculatorService;

        public HomeController(ILogger<HomeController> logger, DayCalculatorService dayCalculatorService)
        {
            _logger = logger;
            _dayCalculatorService = dayCalculatorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(ViewModel model)
        {
            var outcome = _dayCalculatorService.CalculateDayDifference(new RawDateInput()
            {
                FromDate = model.FromDate,
                ToDate = model.ToDate
            });

            _logger.LogError("Test");

            model.Outcome = outcome?.ToString();
            
            return View("Index", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}