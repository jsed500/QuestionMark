using Microsoft.AspNetCore.Mvc;
using QuestionMark.Models;
using System.Diagnostics;

namespace QuestionMark.Web.Controllers
{
    public class DateCalculatorController : Controller
    {
        private readonly ILogger<DateCalculatorController> _logger;

        public DateCalculatorController(ILogger<DateCalculatorController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CalculateResult()
        {
            return View("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}