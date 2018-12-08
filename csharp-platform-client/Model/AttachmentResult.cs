using System.Collections.Generic;

namespace CitySourcedClient.Model
{
    public class AttachmentResult : PlatformResponse
    {
        public List<Attachment> Results { get; set; }
    }
}