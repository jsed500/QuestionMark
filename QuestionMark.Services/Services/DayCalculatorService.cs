using QuestionMark.Services.Models;
using QuestionMark.Services.Parsers;

namespace QuestionMark.Services.Services
{
    public class DayCalculatorService
    {
        public int? CalculateDayDifference(RawDateInput rawInput)
        {
            var parsedData = rawInput.Parse();

            if (parsedData == null)
            {
                return null;
            }

            return 10;
        }
    }
}
