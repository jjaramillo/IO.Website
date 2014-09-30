<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductsSliderUserControl.ascx.cs" Inherits="IO.Website.UI.ProductsSlider.ProductsSliderUserControl" %>
<asp:ScriptManagerProxy runat="server" ID="smProxyJS">
    <Scripts>
        <asp:ScriptReference Path="/_layouts/15/INC/IO.Website/js/knockout-3.2.0.js" />
        <asp:ScriptReference Path="/_layouts/15/INC/IO.Website/js/ProductsSliderViewModel.js" />
    </Scripts>
</asp:ScriptManagerProxy>
<div class="caractProductos carrusel" id="products_container" data-ride="carousel" runat="server">
    <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
        <!-- Indicators -->
        <ol class="carousel-indicators" data-bind="foreach: Products">
        <li data-target='#<%= products_container.ClientID %>' data-bind="attr: { 'data-slide-to': Index }, css: IndicatorClass"></li>
    </ol>
        <!-- Wrapper for slides -->
        <div class="container">
            <div class="carousel-inner" data-bind="foreach: Products">
                <div data-bind="css: Class, foreach: Childs">
                    <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4 itemProducto">
                        <div class="imagenCaract hidden-xs hidden-sm">
                            <img style="border: 0px solid;" data-bind="attr: { src: ImageUrl, alt: Title, title: Title }" />
                        </div>
                        <div class="tituloCarruselPr">
                            <p><span class="ms-rteStyle-H2" data-bind="text: Title"></span></p>
                        </div>
                        <div class="textCaract hidden-xs hidden-sm" data-bind="html: Description"></div>
                        <div class="linkCarruselPr">
                            <p><a data-bind="click: OpenVideo">Más info</a></p>
                        </div>
                    </div>
                </div>                
            </div>
        </div>
        <!-- Controls -->
        <a class="left carousel-control hidden-xs hidden-sm" href='#<%= products_container.ClientID %>' role="button" data-slide="prev">
            <span class="glyphicon glyphicon-chevron-left"></span>
        </a>
        <a class="right carousel-control hidden-xs hidden-sm" href='#<%= products_container.ClientID %>' role="button" data-slide="next">
            <span class="glyphicon glyphicon-chevron-right"></span>
        </a>
    </div>
</div>

