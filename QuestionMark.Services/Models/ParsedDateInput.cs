namespace QuestionMark.Services.Models
{
    public class ParsedDateInput
    {
        public ParsedDateInput(Date fromDate, Date toDate)
        {
            FromDate = fromDate;
            ToDate = toDate;
        }

        public Date FromDate { get; set; }

        public Date ToDate { get; set; }
    }
}