using System.Collections.Generic;
using QuestionMark.Services.Models;
using QuestionMark.Services.Services;
using Xunit;

namespace QuestionMark.Tests.ServiceTests
{
    public class DayCalculatorServiceTests
    {
        private readonly DayCalculatorService _service;

        public DayCalculatorServiceTests()
        {
            _service = new DayCalculatorService();
        }

        [Theory]
        [InlineData("30-04-2022", "30-04-2022", 0, null)]
        [InlineData("20-04-2022", "30-04-2022", 10, null)]
        [InlineData("01-01-2012", "01-01-2013", 366, null)]
        [InlineData("01-01-2010", "01-01-2011", 365, null)]
        [InlineData("29-02-2020", "28-02-2022", 730, null)]
        [InlineData("08-08-1980", "30-11-2002", 8149, null)]
        [InlineData("14-11-1991", "30-04-2022", 11125, null)]
        [InlineData("01-07-1992", "30-04-2022", 10895, null)]
        [InlineData("31-12-1999", "01-01-2000", 1, null)]
        public void DayDifferenceFromStrings(string fromDate, string toDate, int? expectedResult, List<string> expectedErrors)
        {
            var result = _service.CalculateDayDifference(new RawDateInput
            {
                FromDate = fromDate,
                ToDate = toDate
            });

            Assert.Equal(expectedResult, result.Result);
            Assert.Equal(expectedErrors, result.Errors);
        }

        [Theory]
        [InlineData(1, 1, 2000, 2451544)]
        [InlineData(1, 4, 2022, 2459670)]
        [InlineData(30, 4, 2022, 2459699)]
        [InlineData(28, 2, 2022, 2459638)]
        [InlineData(29, 2, 2020, 2458908)]
        public void JulianDayNumber(int day, int month, int year, int expectedDays)
        {
            var result = _service.CalculateJulianDayNumber(day, month, year);

            Assert.Equal(expectedDays, result);
        }
    }
}