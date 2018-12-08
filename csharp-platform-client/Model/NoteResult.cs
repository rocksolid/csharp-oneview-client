using System.Collections.Generic;

namespace CitySourcedClient.Model
{
    public class NoteResult : PlatformResponse
    {
        public List<Note> Results { get; set; }
    }
}