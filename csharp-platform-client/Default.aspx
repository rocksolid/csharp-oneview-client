<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CitySourcedClient._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:PlaceHolder ID="plcIntoAndLegal" runat="server">
        <div class="jumbotron">
            <h1>CitySourced Client</h1>
            <p class="lead">CitySourced is the most widely used enterprise civic engagement platform in the world. Our mobile and web applications streamline interactions between government and the communities they serve. CitySourced is a platform for local and state government to enable a true citizen focused mobile app, that delivers a remarkable experience for governments, businesses, and citizens.</p>
            <p><a href="https://api-docs.citysourced.com/" class="btn btn-primary btn-lg">View the API Docs &raquo;</a></p>
        </div>
        <div class="row">
            <div class="col-md-12">
                <h2>Disclaimer of Warranty and Liability: </h2>
                <p>THIS SOFTWARE IS PROVIDED "AS IS" AND ANY EXPRESSED OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE REGENTS OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.</p>
                <h2>Support Disclaimer: </h2>
                <p>CitySourced, Inc. cannot provide support for these items. If you have a question regarding the use of any of these items, which is not addressed by the documentation (if any) included with the package, you should contact the author as set forth in the appropriate listing.</p>
                <h2>Agreement of Terms</h2>
                <p>By clicking the "I Agree" button below, you have read and agree to the <a href="https://d2p5liwq1c5kwh.cloudfront.net/Developers/CitySourced-Partner-Program-Agreement-Latest.pdf">CitySourced Partner Program Agreement</a>.</p>
            </div>
        </div>
        <div class="row text-center">
            <asp:Button ID="btnAgreeToTerms" CssClass="btn-primary" OnClick="btnAgreeToTerms_Click" Text="I Agree" runat="server" />
        </div>
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="plcSettingsError" Visible="False" runat="server">        
        <div class="row">
            <div class="alert alert-danger">
                <asp:Literal ID="litSettingsError" runat="server" />
            </div>
        </div>
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="plcSettings" Visible="False" runat="server">
        <h3>API Configruation</h3>
        <div class="row form-group">
            <div class="col-lg-12">
                <label for="<%= this.ddlEnvrinment.ClientID %>">Environment: </label>
                <asp:DropDownList ID="ddlEnvrinment" CssClass="form-control" runat="server">
                    <asp:ListItem Value=""></asp:ListItem>
                    <asp:ListItem Value="https://platform.citysourced.com">USA (Commercial)</asp:ListItem>
                    <asp:ListItem Value="https://platform.citysourced.us">USA (GovCloud)</asp:ListItem>
                    <asp:ListItem Value="https://platform.citysourced.ca">CAN (Canada)</asp:ListItem>
                    <asp:ListItem Value="https://platform.citysourced.com.au">AUS (Australia)</asp:ListItem>
                    <asp:ListItem Value="https://platform.citysourced.net">STG (Staging)</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="vldEnvrinment" ControlToValidate="ddlEnvrinment" ForeColor="Red" Display="Dynamic" ErrorMessage="<- Required!" runat="server" />
            </div>
        </div>
        <div class="row form-group">
            <div class="col-lg-12">
                <label for="<%= this.txtCustomerAppKey.ClientID %>">Customer App Key: </label>
                <asp:TextBox ID="txtCustomerAppKey" CssClass="form-control" runat="server" />
                <asp:RequiredFieldValidator ID="vldCustomerAppKey" ControlToValidate="txtCustomerAppKey" ForeColor="Red" Display="Dynamic" ErrorMessage="<- Required!" runat="server" />
            </div>
        </div>
        <div class="row form-group">
            <div class="col-lg-12">
                <label for="<%= this.txtPlatformAppKey.ClientID %>">Platform App Key: </label>
                <asp:TextBox ID="txtPlatformAppKey" CssClass="form-control" runat="server" />
                <asp:RequiredFieldValidator ID="vldPlatformAppKey" ControlToValidate="txtPlatformAppKey" ForeColor="Red" Display="Dynamic" ErrorMessage="<- Required!" runat="server" />
            </div>
        </div>
        <div class="row form-group">
            <div class="col-lg-12">
                <label for="<%= this.txtApiAuthKey.ClientID %>">API Auth Key: </label>
                <asp:TextBox ID="txtApiAuthKey" CssClass="form-control" runat="server" />
                <asp:RequiredFieldValidator ID="vldApiAuthKey" ControlToValidate="txtApiAuthKey" ForeColor="Red" Display="Dynamic" ErrorMessage="<- Required!" runat="server" />
            </div>
        </div>
        <div class="row form-group text-center">
            <div class="col-lg-12">
                <asp:Button ID="btnSettings" CssClass="btn-primary" OnClick="btnSettings_Click" Text="Let's Get Started" runat="server" />
            </div>
        </div>
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="plcWorkbench" Visible="False" runat="server">
        <h3>API Token & Response</h3>
        <div class="row form-group">
            <div class="col-lg-12">
                <label for="<%= this.txtApiToken.ClientID %>">API Token:</label>
                <asp:TextBox ID="txtApiToken" CssClass="form-control" runat="server" />
            </div>
        </div>
        <div class="row form-group">
            <div class="col-lg-12">
                <label for="<%= this.txtResJson.ClientID %>">Response JSON:</label>
                <asp:TextBox ID="txtResJson" CssClass="form-control" TextMode="MultiLine" Height="350px" runat="server" />
            </div>
        </div>
        <hr/>
        <h3>API Workbench</h3>
        <div class="row form-group">
            <div class="col-lg-12">
                <label for="<%= this.txtReqJson.ClientID %>">Request JSON:</label>
                <asp:TextBox ID="txtReqJson" CssClass="form-control" TextMode="MultiLine" Height="100px" runat="server">{"MaxResults":100,"ReportingPeriod":12,"DateCreated":{"DateStart":"2018-01-01","DateEnd":"2018-12-31"}}</asp:TextBox>
            </div>
        </div>
        <div class="row text-center">
            <div class="col-lg-12">
                <asp:CheckBox ID="cbxIncludeChildren" Checked="True" runat="server" />&nbsp; Include Children?&nbsp;&nbsp;
                <asp:CheckBox ID="cbxEportAsXml" runat="server" />&nbsp; Export as XML?&nbsp;&nbsp;
                <asp:Button ID="btnGetSRs" CssClass="btn-primary" OnClick="btnGetSRs_OnClick" Text="GET: Service Requests" runat="server" />
            </div>
        </div>
    </asp:PlaceHolder>
</asp:Content>