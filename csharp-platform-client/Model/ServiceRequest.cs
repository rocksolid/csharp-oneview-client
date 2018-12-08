using System;
using System.Collections.Generic;

namespace CitySourcedClient.Model
{
    // NOTE: We are using the 'Detail' schema as outlined in the API docs: https://api-docs.citysourced.com

    public class ServiceRequest
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateCreatedUtc { get; set; }
        public string DateCreatedAsAgo { get; set; }
        public string DateCreatedFormatted { get; set; }
        public DateTime DateCreatedSortable { get; set; }
        public string DateCreatedUniversal { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime DateUpdatedUtc { get; set; }
        public string DateUpdatedAsAgo { get; set; }
        public string DateUpdatedFormatted { get; set; }
        public string DateUpdatedSortable { get; set; }
        public string DateUpdatedUniversal { get; set; }
        public DateTime? DateClosed { get; set; }
        public DateTime? DateClosedUtc { get; set; }
        public string DateClosedAsAgo { get; set; }
        public string DateClosedFormatted { get; set; }
        public string DateClosedSortable { get; set; }
        public string DateClosedUniversal { get; set; }
        public string RequestType { get; set; }
        public string RequestTypeId { get; set; }
        public string Description { get; set; }
        public string StatusType { get; set; }
        public string StatusTypeReadable { get; set; }
        public bool StatusTypeIsClosed { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string FormattedAddress { get; set; }
        public string InitialBoundaryName { get; set; }
        public string ImageUrl { get; set; }
        public string ImageUrlCdn { get; set; }
        public string PublicUrl { get; set; }
        public bool HasBeenEscalated { get; set; }
        public bool IsEscalated { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsDisabled { get; set; }
        public long AuthorId { get; set; }
        public string AuthorScreenName { get; set; }
        public string AuthorName { get; set; }
        public long? AssignedUserId { get; set; }
        public string AssignedUserName { get; set; }
        public long? IntegrationId { get; set; }
        public string IntegrationName { get; set; }
        public long MobileDeviceId { get; set; }
        public string MobileDeviceTypeAndModel { get; set; }
        public int TotalAttachments { get; set; }
        public int TotalComments { get; set; }
        public int TotalVotes { get; set; }

        public List<ReportItem> ReportItems { get; set; }
        public List<Attachment> Attachments { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Note> Notes { get; set; }
        public List<MetaData> MetaData { get; set; }
    }
}