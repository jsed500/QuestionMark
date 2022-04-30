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
        private readonly DayCalculatorService _dayCalculatorService;

        public HomeController(DayCalculatorService dayCalculatorService)
        {
            _dayCalculatorService = dayCalculatorService;
        }

        public IActionResult Index(ViewModel model)
        {
            return View(model);
        }

        [HttpPost]
        public IActionResult Submit(ViewModel model)
        {
            var dayDiff = _dayCalculatorService.CalculateDayDifference(new RawDateInput()
            {
                FromDate = model.FromDate,
                ToDate = model.ToDate
            });
            
            model.Result = dayDiff.Result?.ToString();
            model.Errors = dayDiff.Errors;

            return RedirectToAction("Index", "Home", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}