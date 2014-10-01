<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MailerConfig.aspx.cs" Inherits="IO.Website.UI.Layouts.IO.Website.MailerConfig" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <div role="form">
        <div class="row">
            <div class="col-xs-12 col-md-6 col-sm-12 col-lg-4 form-group">
                <label>Direcci&oacute;n de Correo Saliente:</label>
                <asp:TextBox runat="server" ID="txtbMailFromOut" MaxLength="60" TextMode="Email" class="form-control" />
            </div>
            <div class="col-xs-12 col-md-6 col-sm-12 col-lg-4 form-group">
                <label>Direcci&oacute;n de Correo Entrante:</label>
                <asp:TextBox runat="server" ID="txtbMailFromIn" MaxLength="60" TextMode="Email" class="form-control" />
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12 col-md-6 col-sm-12 col-lg-4">
                <label>Tipo de Env&iacute;o de Correo:</label>

                <asp:RadioButton runat="server" ID="rdbUseSharepointMailer" Text="Usar Mailer de SharePoint" GroupName="MailConfig" Checked="true"
                    AutoPostBack="true" OnCheckedChanged="rdbUseSharepointMailer_CheckedChanged" class="radio" />
                <asp:RadioButton runat="server" ID="rdbUseAspNetMail" Text="Usar Mailer de asp.Net" GroupName="MailConfig" Checked="false"
                    AutoPostBack="true" OnCheckedChanged="rdbUseAspNetMail_CheckedChanged" class="radio" />

            </div>
        </div>
        <div class="row">
            <div class="col-xs-12 col-md-6 col-sm-12 col-lg-4 form-group" runat="server" id="serverAddressContainer" visible="false">
                <label>Direcci&oacute;n del Servidor de Correo:</label>
                <asp:TextBox runat="server" ID="txtbServerAddress" MaxLength="40" class="form-control" />
            </div>
            <div class="col-xs-12 col-md-6 col-sm-12 col-lg-4 form-group" runat="server" id="serverportContainer" visible="false">
                <label>Puerto:</label>
                <asp:TextBox runat="server" ID="txtbPort" MaxLength="5" TextMode="Number" class="form-control" />
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12 col-md-6 col-sm-12 col-lg-4 form-group" runat="server" id="sslSecurityContainer" visible="false">
                <label>Seguridad:</label>
                <asp:CheckBox runat="server" ID="chkUseSSL" Text="Usar SSL" class="checkbox" />
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12 col-md-6 col-sm-12 col-lg-4 form-group" runat="server" id="loginNameContainer" visible="false">
                <label>Nombre de Usuario:</label>
                <asp:TextBox runat="server" ID="txtbLoginName" MaxLength="60" class="form-control" />
            </div>
            <div class="col-xs-6 col-md-3 col-sm-6 col-lg-2 form-group" runat="server" id="passwordContainer" visible="false">
                <label>Contrase&ntilde;a:</label>
                <asp:TextBox runat="server" ID="txtbPassword" MaxLength="20" TextMode="Password" class="form-control" />
            </div>
            <div class="col-xs-6 col-md-3 col-sm-6 col-lg-2 form-group" runat="server" id="passwordConfirmContainer" visible="false">
                <label>Confirme la Contrase&ntilde;a:</label>
                <asp:TextBox runat="server" ID="txtbPasswordConfirm" MaxLength="20" TextMode="Password" class="form-control" />
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12 col-md-6 col-sm-12 col-lg-4">
                <asp:Button runat="server" ID="btnSave" Text="Guardar" OnClick="btnSave_Click" class="btn btn-default" />
                <asp:Button runat="server" ID="btnTest" Text="Probar Env&iacute;o" OnClick="btnTest_Click" class="btn btn-default" />
                <asp:Button runat="server" ID="btnCancel" Text="Cancelar" OnClick="btnCancel_Click" class="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Configuraci&oacute;n de Envios de Correo Electr&oacute;nico
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server">
    Configuraci&oacute;n de Envios de Correo Electr&oacute;nico
</asp:Content>
