using System.Collections.Generic;

namespace CitySourcedClient.Model
{
    public class ReportItemResult : PlatformResponse
    {
        public List<ReportItem> Results { get; set; }
    }
}