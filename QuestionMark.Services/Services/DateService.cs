using Microsoft.Extensions.Logging;
using QuestionMark.Services.Models;
using QuestionMark.Services.Parsers;

namespace QuestionMark.Services.Services
{
    public class DateService
    {
        // would probably want to use third party logging to files?
        private readonly ILogger<DateService> _logger;

        public DateService(ILogger<DateService> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Calculates the difference in days between two date strings
        /// </summary>
        /// <param name="rawInput"></param>
        /// <returns>Integer (days) if successful. Error strings if parsing or date conversion errors.</returns>
        public ResultError<int?> CalculateDayDifference(RawDateInput rawInput)
        {
            var parsedResult = rawInput.Parse();

            if (parsedResult.HasError)
            {
                foreach (var error in parsedResult.Errors)
                {
                    //log warning that input is not correct
                    _logger.LogWarning(error);
                }

                return new ResultError<int?>
                {
                    Errors = parsedResult.Errors
                };
            }

            var from = parsedResult.Result.FromDate;
            var to = parsedResult.Result.ToDate;

            var fromJulian = CalculateJulianDayNumber(from.Day, from.Month, from.Year);
            var toJulian = CalculateJulianDayNumber(to.Day, to.Month, to.Year);

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
        public int CalculateJulianDayNumber(double day, double month, double year)
        {
            // Formula only works if when date used is Jan/Feb, convert to end of previous year
            //. i.e 1st Jan 2000 (2000, 1, 1) => (1999, 13, 1)
            if (month <= 2)
            {
                month += 12;
                year--;
            }

            return (int) (365 * year + (int)Math.Floor(year / 4) - (int)Math.Floor(year / 100) + (int)Math.Floor(year / 400) + (int)Math.Floor((153 * month + 8)/5) + day + 1721025);
        }
    }
}
