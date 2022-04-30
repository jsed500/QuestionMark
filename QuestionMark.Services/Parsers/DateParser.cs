using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using QuestionMark.Services.Models;

namespace QuestionMark.Services.Parsers
{
    public static class DateParser
    {
        //todo make more robust
        public static string DateRegex = "^(0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-](19|20)\\d\\d$";

        public static ResultError<ParsedDateInput> Parse(this RawDateInput input)
        {
            var errors = new List<string>();

            if(!Regex.IsMatch(input.FromDate, DateRegex))
            {
                errors.Add($"{input.FromDate} is not a valid date in the accepted format 'dd-mm-yyyy'");
            }

            if (!Regex.IsMatch(input.ToDate, DateRegex))
            {
                errors.Add($"{input.ToDate} is not a valid date in the accepted format 'dd-mm-yyyy'");
            }

            if (errors.Any())
            {
                return new ResultError<ParsedDateInput>
                {
                    Errors = errors
                };
            }

            var fromDate = new Date();
            var toDate = new Date();

            var splitFrom = input.FromDate.Split("-");

            fromDate.Day = int.Parse(splitFrom[0]); 
            fromDate.Month = int.Parse(splitFrom[1]); 
            fromDate.Year = int.Parse(splitFrom[2]);

            var splitTo = input.ToDate.Split("-");

            toDate.Day = int.Parse(splitTo[0]);
            toDate.Month = int.Parse(splitTo[1]);
            toDate.Year = int.Parse(splitTo[2]);

            return new ResultError<ParsedDateInput>
            {
                Result = new ParsedDateInput(fromDate, toDate)
            };
        }
    }
}
