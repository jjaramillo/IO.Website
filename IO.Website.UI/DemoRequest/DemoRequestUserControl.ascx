<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DemoRequestUserControl.ascx.cs" Inherits="IO.Website.UI.DemoRequest.DemoRequestUserControl" %>
<asp:ScriptManagerProxy runat="server" ID="scptmgrpx">
    <Scripts>        
        <asp:ScriptReference Path="/_layouts/15/INC/IO.Website/js/knockout-3.2.0.js" />
        <asp:ScriptReference Path="/_layouts/15/INC/IO.Website/js/knockout.validation.js" />
        <asp:ScriptReference Path="/_layouts/15/INC/IO.Website/js/DemoRequestViewModel.js" />
    </Scripts>
</asp:ScriptManagerProxy>
<div id="demo_request_form_container" runat="server">
    <div data-bind="visible: formvisible" class="col-xs-12 col-md-12 col-sm-12 col-lg-12 no-padding">
		<div class="col-xs-12 col-md-12 col-sm-12 col-lg-12" >
			<h1 class="demoIO">Solicite su demo </h1>
		</div>
        <div class="col-xs-12 col-md-6 col-sm-12 col-lg-4">
			<label>Nombres:</label>
			<input type="text" maxlength="60" data-bind="value: firstName" />
		</div>
		<div class="col-xs-12 col-md-6 col-sm-12 col-lg-4">
			<label>Apellidos:</label>
			<input type="text" maxlength="60" data-bind="value: lastName"/>
		</div>
		<div class="col-xs-12 col-md-6 col-sm-12 col-lg-4">
			<label>Empresa:</label>
			<input type="text" maxlength="60" data-bind="value: company"/>
		</div>
		<div class="col-xs-12 col-md-6 col-sm-12 col-lg-4">
			<label>Email:</label>
			<input type="text" maxlength="60" data-bind="value: email"/>
		</div>
		<div class="col-xs-12 col-md-6 col-sm-12 col-lg-4">
			<label>Tel&eacute;fono:</label>
			<input type="text" maxlength="60" data-bind="value: phone"/>
		</div>
		<div class="col-xs-12 col-md-6 col-sm-12 col-lg-4">
			<label>Celular:</label>
			<input type="text" maxlength="60" data-bind="value: mobile"/>
		</div>
		<div class="col-xs-12 col-md-6 col-sm-12 col-lg-4">
			<label>Ciudad:</label>
			<input type="text" maxlength="60" data-bind="value: city"/>
		</div>
		<div class="col-xs-12 col-md-6 col-sm-12 col-lg-4 btnArriba">
			<button onclick="void(0);" data-bind="click: Save">Enviar</button>
		</div>
    </div>
    <div data-bind="visible: messagevisible" class="col-xs-12 col-md-12 col-sm-12 col-lg-12">Mensaje de Exito</div>
</div>