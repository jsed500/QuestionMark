namespace QuestionMark.Services.Models
{
    public class RawDateInput
    {
        public RawDateInput(string fromDate, string toDate)
        {
            FromDate = fromDate;
            ToDate = toDate;
        }

        public string FromDate { get; set; }

        public string ToDate { get; set; }
    }
}