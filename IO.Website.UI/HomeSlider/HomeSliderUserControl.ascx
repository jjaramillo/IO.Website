<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HomeSliderUserControl.ascx.cs" Inherits="IO.Website.UI.HomeSlider.HomeSliderUserControl" %>
<asp:ScriptManagerProxy runat="server" ID="smProxyJS">
    <Scripts>
        <asp:ScriptReference Path="/_layouts/15/INC/IO.Website/js/knockout-3.2.0.js" />
        <asp:ScriptReference Path="/_layouts/15/INC/IO.Website/js/HomeSliderViewModel.js" />
    </Scripts>
</asp:ScriptManagerProxy>
<div id="home_slider_container" class="carousel slide" data-ride="carousel" runat="server">
    <!-- Indicators -->
    <ol class="carousel-indicators" data-bind="foreach: Pictures">
        <li data-target='#<%= home_slider_container.ClientID %>' data-bind="attr: { 'data-slide-to': Index }"></li>
    </ol>
    <!-- Wrapper for slides -->
    <div class="carousel-inner" data-bind="foreach: Pictures">
        <div data-bind="style: { 'background': Color }, css: Class">
            <div class="container">
                <div class="carousel-caption">
                    <div class="col-xs-12 col-md-12 col-sm-6 col-lg-6 imagenSlider">
                        <img data-bind="attr: { 'src': ImageUrl, 'alt': LinkTitle, 'title': LinkTitle }"/>
                    </div>
                    <div class="col-xs-12 col-md-12 col-sm-6 col-lg-6">
                        <span class="descripcion">
                            <h1 data-bind="text: Title"></h1>
                            <span class="hidden-xs" data-bind="html: Description"></span><br />
                            <a data-bind="attr: { 'href': LinkUrl }">Más</a></span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Controls -->
    <a class="left carousel-control" href='#<%= home_slider_container.ClientID %>' role="button" data-slide="prev">
        <span class="glyphicon glyphicon-chevron-left"></span>
    </a>
    <a class="right carousel-control" href='#<%= home_slider_container.ClientID %>' role="button" data-slide="next">
        <span class="glyphicon glyphicon-chevron-right"></span>
    </a>
</div>

