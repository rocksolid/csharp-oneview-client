using System.Collections.Generic;

namespace CitySourcedClient.Model
{
    public class PlatformResponse
    {
        public string UniqueId { get; set; }
        public int StatusCode { get; set; }
        public double Took { get; set; }
        public bool HasErrors { get; set; }
        public int ErrorsCount { get; set; }
        public List<Error> Errors { get; set; }
        public string ResultType { get; set; }
        public int ResultsCount { get; set; }
        public object Results { get; set; }
    }
}