using System.Runtime.CompilerServices;
using QuestionMark.Services.Models;
using QuestionMark.Services.Parsers;

namespace QuestionMark.Services.Services
{
    public class DayCalculatorService
    {
        public ResultError<int?> CalculateDayDifference(RawDateInput rawInput)
        {
            var parsedResult = rawInput.Parse();

            if (parsedResult.HasError)
            {
                //todo log warning

                return new ResultError<int?>
                {
                    Errors = parsedResult.Errors
                };
            }

            var fromJulian = CalculateJulianDayNumber(parsedResult.Result.FromDate.Day, parsedResult.Result.FromDate.Month,
                parsedResult.Result.FromDate.Year);

            var toJulian = CalculateJulianDayNumber(parsedResult.Result.ToDate.Day, parsedResult.Result.ToDate.Month,
                parsedResult.Result.ToDate.Year);

            return new ResultError<int?>
            {
                Result = (int)(toJulian - fromJulian)
            };
        }

        /// <summary>
        /// Calculates the JDN (julian day number) for day/month/year
        /// </summary>
        /// <param name="day"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns>Number of days since Jan 1st 4713 BC</returns>
        public double CalculateJulianDayNumber(double day, double month, double year)
        {
            // Formula only works if when date used is Jan/Feb, convert to end of previous year
            //. i.e 1st Jan 2000 (2000, 1, 1) => (1999, 13, 1)
            if (month <= 2)
            {
                month += 12;
                year--;
            }

            return 365 * year +  Math.Floor(year / 4) - Math.Floor(year / 100) + Math.Floor(year / 400) + Math.Floor((153 * month + 8)/5) + day + 1721025;
        }
    }
}
