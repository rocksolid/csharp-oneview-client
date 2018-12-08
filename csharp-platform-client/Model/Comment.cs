using System;

namespace CitySourcedClient.Model
{
    public class Comment
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateCreatedUtc { get; set; }
        public string DateCreatedAsAgo { get; set; }
        public string DateCreatedFormatted { get; set; }
        public DateTime DateCreatedSortable { get; set; }
        public string DateCreatedUniversal { get; set; }
        public string Text { get; set; }
        public long AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorImageUrl { get; set; }
        public string AuthorThumbUrl { get; set; }
        public bool IsPrivate { get; set; }
    }
}