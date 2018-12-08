using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitySourcedClient.Model
{
    public class ConfigSettings
    {
        public string AccountAllowsUniqueId { get; set; }
        public string AccountRequiresEmail { get; set; }
        public string AccountRequiresTelephone { get; set; }
        public string AccountRequiresUniqueId { get; set; }
        public string AttachmentMaxFileSizeInMb { get; set; }
        public string AttachmentMaxImageSize { get; set; }
        public string AttachmentMaxQuantity { get; set; }
        public string EmergencyNumberToCall { get; set; }
        public string GeneralSupportNumberToCall { get; set; }
        public string MappingCenterLat { get; set; }
        public string MappingCenterLng { get; set; }
        public string MappingUrlBaseMaps { get; set; }
        public string MappingUrlBaseMaps2 { get; set; }
        public string MenuKbArticleCategoryId { get; set; }
        public string MenuKbArticleEnabledFeatured { get; set; }
        public string MenuKbArticleIncludeModule { get; set; }
        public string MenuKbArticleSortOrder { get; set; }
        public string MenuServiceRequestCategoryId { get; set; }
        public string MenuServiceRequestIncludeModule { get; set; }
        public string MenuServiceRequestSortOrder { get; set; }
        public string MenuTrashServiceCategoryId { get; set; }
        public string MenuTrashServiceIncludeModule { get; set; }
        public string MenuTrashServiceSortOrder { get; set; }
        public string OneSignalAppId { get; set; }
        public string ServiceRequestAllowAnonymous { get; set; }
        public string ServiceRequestAllowComments { get; set; }
        public string ServiceRequestCommentsPrivateByDefault { get; set; }
        public string ServiceRequestShowHtmlPanel { get; set; }
        public string ServiceRequestTypesRequireLocation { get; set; }
        public string UrlBaseDomain { get; set; }
    }
}