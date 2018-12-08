using System.Collections.Generic;

namespace CitySourcedClient.Model
{
    public class ServiceRequestResult : PlatformResponse
    {
        public List<ServiceRequest> Results { get; set; }
    }
}