using System.Collections.Generic;

namespace CitySourcedClient.Model
{
    public class CommentResult : PlatformResponse
    {
        public List<Comment> Results { get; set; }
    }
}