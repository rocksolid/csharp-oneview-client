using System;

namespace CitySourcedClient.Model
{
    public class Attachment
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateCreatedUtc { get; set; }
        public string DateCreatedAsAgo { get; set; }
        public string DateCreatedFormatted { get; set; }
        public DateTime DateCreatedSortable { get; set; }
        public string DateCreatedUniversal { get; set; }
        public string AttachmentType { get; set; }
        public string Filename { get; set; }
        public string Url { get; set; }
        public long AuthorId { get; set; }
    }
}