namespace CitySourcedClient.Model
{
    public class Error
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorText { get; set; }
        public string ErrorHtml { get; set; }
    }
}