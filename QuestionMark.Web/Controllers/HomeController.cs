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
        private readonly DateService _dateService;

        public HomeController(DateService dateService)
        {
            _dateService = dateService;
        }

        public IActionResult Index(ViewModel model)
        {
            return View(model);
        }

        [HttpPost]
        public IActionResult Submit(ViewModel model)
        {
            var dayDiff = _dateService.CalculateDayDifference(new RawDateInput(model.FromDate, model.ToDate));
            
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