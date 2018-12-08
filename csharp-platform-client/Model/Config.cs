namespace CitySourcedClient.Model
{
    public class Config
    {
        public int MobileAppId { get; set; }
        public int VersionNumber { get; set; }
        public bool IgnoresLocation { get; set; }
        public int SubscriptionType { get; set; }
        public string SubscriptionTypeAsReadable { get; set; }
        public string SubscriptionTypeAsString { get; set; }
        public bool RemoveBranding { get; set; }
        public string ProjectName { get; set; }
        public string TopLevelDomain { get; set; }
        public int AnonymousId { get; set; }
        public string UrlBaseApi { get; set; }
        public string UrlBasePortal { get; set; }
        public ConfigSettings Settings { get; set; }
        public ConfigColors Colors { get; set; }
        public ConfigImages Images { get; set; }
        public ConfigText Text { get; set; }

    }
}