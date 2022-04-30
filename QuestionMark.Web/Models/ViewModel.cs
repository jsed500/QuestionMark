namespace QuestionMark.Web.Models
{
    public class ViewModel
    {
        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public string? Result { get; set; }

        public string FormattedResult => !string.IsNullOrEmpty(Result) ? $" {Result} Days" : string.Empty;

        public IEnumerable<string> Errors { get; set; }
    }
}