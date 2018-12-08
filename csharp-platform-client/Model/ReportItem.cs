using System;

namespace CitySourcedClient.Model
{
    public class ReportItem
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateCreatedUtc { get; set; }
        public string DateCreatedAsAgo { get; set; }
        public string DateCreatedFormatted { get; set; }
        public DateTime DateCreatedSortable { get; set; }
        public string DateCreatedUniversal { get; set; }
        public long ServiceRequestId { get; set; }
        public long MobileAppItemId { get; set; }
        public int VariableType { get; set; }
        public string VariableTypeReadable { get; set; }
        public string Key { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
        public bool IsPk { get; set; }
    }
}