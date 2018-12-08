using CitySourcedClient.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Configuration;
using System.Web.UI;
using System.Xml;
using System.Xml.Serialization;

namespace CitySourcedClient
{
    public partial class _Default : Page
    {
        private string ApiVersion = "2";
        private string ErrorMessage = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            var customerAppKey = WebConfigurationManager.AppSettings["CustomerAppkey"];
            if (!string.IsNullOrWhiteSpace(customerAppKey)) { this.txtCustomerAppKey.Text = customerAppKey; }
            var platformAppKey = WebConfigurationManager.AppSettings["PlatformAppKey"];
            if (!string.IsNullOrWhiteSpace(platformAppKey)) { this.txtPlatformAppKey.Text = platformAppKey; }
            var apiAuthKey = WebConfigurationManager.AppSettings["ApiAuthKey"];
            if (!string.IsNullOrWhiteSpace(apiAuthKey)) { this.txtApiAuthKey.Text = apiAuthKey; }
        }

        protected void btnAgreeToTerms_Click(object sender, EventArgs e)
        {
            this.plcIntoAndLegal.Visible = false;
            this.plcSettings.Visible = true;
        }
        protected void btnSettings_Click(object sender, EventArgs e)
        {
            Session["Environment"] = this.ddlEnvrinment.SelectedValue;
            Session["CustomerAppKey"] = this.txtCustomerAppKey.Text.Trim();
            Session["PlatformAppKey"] = this.txtPlatformAppKey.Text.Trim();
            Session["ApiAuthKey"] = this.txtApiAuthKey.Text.Trim();
            var req = GetRestRequest(true, "2_0/launch", Method.POST);
            var res = MakeApiCall(req);

            // Parse Response...
            var obj = JsonConvert.DeserializeObject<LaunchResult>(res.Content);
            if (!ParseResponse(res, obj)) { return; }

            // All Good...
            Session["ApiToken"] = obj.Results.Token;
            this.txtApiToken.Text = Session["ApiToken"].ToString();
            this.txtResJson.Text = JsonConvert.SerializeObject(obj.Results, Newtonsoft.Json.Formatting.Indented);
            this.plcSettingsError.Visible = false;
            this.plcIntoAndLegal.Visible = false;
            this.plcSettings.Visible = false;
            this.plcWorkbench.Visible = true;
        }
        protected void btnGetSRs_OnClick(object sender, EventArgs e)
        {
            var req = GetRestRequest(false, "2_0/servicerequests");
            req.AddParameter("detail", "");
            var json = this.txtReqJson.Text;
            if (!string.IsNullOrWhiteSpace(json)) { req.AddParameter("json", json); }
            var res = MakeApiCall(req);

            // Parse Response...
            var obj = JsonConvert.DeserializeObject<ServiceRequestResult>(res.Content);
            if (!ParseResponse(res, obj)) { return; }

            // Detail Only?
            if (!this.cbxIncludeChildren.Checked)
            {
                this.txtResJson.Text = JsonConvert.SerializeObject(obj.Results, Newtonsoft.Json.Formatting.Indented);
                return;
            }

            // Get Children...
            foreach (var sr in obj.Results)
            {
                // Report Items...
                var url = string.Format("2_0/servicerequests/{0}/reportitems", sr.Id);
                req = GetRestRequest(false, url);
                res = MakeApiCall(req);
                var resReportItems = JsonConvert.DeserializeObject<ReportItemResult>(res.Content);
                sr.ReportItems = resReportItems.Results;

                // Attachments
                url = string.Format("2_0/servicerequests/{0}/attachments", sr.Id);
                req = GetRestRequest(false, url);
                res = MakeApiCall(req);
                var resAttachments = JsonConvert.DeserializeObject<AttachmentResult>(res.Content);
                sr.Attachments = resAttachments.Results;

                // Comments...
                url = string.Format("2_0/servicerequests/{0}/comments", sr.Id);
                req = GetRestRequest(false, url);
                res = MakeApiCall(req);
                var resComments = JsonConvert.DeserializeObject<CommentResult>(res.Content);
                sr.Comments = resComments.Results;

                // Notes...
                url = string.Format("2_0/servicerequests/{0}/notes", sr.Id);
                req = GetRestRequest(false, url);
                res = MakeApiCall(req);
                var resNotes = JsonConvert.DeserializeObject<NoteResult>(res.Content);
                sr.Notes = resNotes.Results;

                // MetaData...
                url = string.Format("2_0/servicerequests/{0}/keyvaluepairs", sr.Id);
                req = GetRestRequest(false, url);
                res = MakeApiCall(req);
                var resMetaData = JsonConvert.DeserializeObject<MetaDataResult>(res.Content);
                sr.MetaData = resMetaData.Results;
            }

            // JSON?
            if (!this.cbxEportAsXml.Checked)
            {
                this.txtResJson.Text = JsonConvert.SerializeObject(obj.Results, Newtonsoft.Json.Formatting.Indented);
                return;
            }

            // XML...
            var builder = new StringBuilder();
            using (var sw = new StringWriter(builder))
            {
                using (var tw = new XmlTextWriter(sw))
                {
                    tw.Formatting = System.Xml.Formatting.Indented;
                    tw.Indentation = 4;
                    var ser = new XmlSerializer(typeof(List<ServiceRequest>));
                    ser.Serialize(tw, obj.Results);
                }
            }
            this.txtResJson.Text = builder.ToString();
        }

        private void SetErrorMessage(PlatformResponse obj)
        {
            try
            {
                if (obj?.ErrorsCount < 1) { return; }

                var sb = new StringBuilder();
                sb.AppendLine("<p><strong>Sorry!</strong> The following errors were returned by the API</p>");
                sb.AppendLine("<ul>");
                foreach (var error in obj.Errors)
                {
                    sb.AppendLine(string.Format("<li>{0}</li>", error.ErrorText));
                }
                sb.AppendLine("</ul>");
                this.ErrorMessage = sb.ToString();
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
            }
        }
        private RestRequest GetRestRequest(bool isLaunch, string url, Method method = Method.GET)
        {
            var request = new RestRequest(url, method);
            request.AddHeader("X-ApiVersion", this.ApiVersion);
            request.AddHeader("X-CustomerAppKey", Session["CustomerAppKey"].ToString());
            request.AddHeader("X-PlatformAppKey", Session["PlatformAppKey"].ToString());
            request.AddHeader("X-ApiAuthKey", Session["ApiAuthKey"].ToString());
            if (!isLaunch) { request.AddHeader("X-ApiToken", Session["ApiToken"].ToString()); }
            return request;
        }
        private IRestResponse MakeApiCall(RestRequest req)
        {
            this.ErrorMessage = "";
            var client = new RestClient(Session["Environment"].ToString());
            return client.Execute(req);
        }
        private bool ParseResponse(IRestResponse res, PlatformResponse obj)
        {
            if (obj == null)
            {
                this.litSettingsError.Text = "<strong>Sorry!</strong> The response could not be serialized properly.";
                this.plcSettingsError.Visible = true;
                return false;
            }

            if (!res.IsSuccessful)
            {
                SetErrorMessage(obj);
                this.litSettingsError.Text = this.ErrorMessage;
                this.plcSettingsError.Visible = true;
                return false;
            }

            return true;
        }
    }
}