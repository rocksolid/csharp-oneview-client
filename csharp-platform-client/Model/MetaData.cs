using System;

namespace CitySourcedClient.Model
{
    public class MetaData
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateCreatedUtc { get; set; }
        public string DateCreatedAsAgo { get; set; }
        public string DateCreatedFormatted { get; set; }
        public DateTime DateCreatedSortable { get; set; }
        public string DateCreatedUniversal { get; set; }
        public long ObjectId { get; set; }
        public int ObjectType { get; set; }
        public string ObjectTypeReadable { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}