using System.Collections.Generic;

namespace CitySourcedClient.Model
{
    public class MetaDataResult : PlatformResponse
    {
        public List<MetaData> Results { get; set; }
    }
}