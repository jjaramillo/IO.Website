<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContactRequestUserControl.ascx.cs" Inherits="IO.Website.UI.ContactRequest.ContactRequestUserControl" %>
<asp:ScriptManagerProxy runat="server" ID="scptmgrpx">
    <Scripts>        
        <asp:ScriptReference Path="/_layouts/15/INC/IO.Website/js/knockout-3.2.0.js" />
        <asp:ScriptReference Path="/_layouts/15/INC/IO.Website/js/knockout.validation.js" />
        <asp:ScriptReference Path="/_layouts/15/INC/IO.Website/js/ContactRequestViewModel.js" />
    </Scripts>
</asp:ScriptManagerProxy>
<div id="contact_request_form_container" runat="server">
    <div data-bind="visible: formvisible">
        <div>
            <label>Nombres:</label>
            <input type="text" maxlength="60" data-bind="value: firstName" />
        </div>
        <div>
            <label>Apellidos:</label>
            <input type="text" maxlength="60" data-bind="value: lastName" />
        </div>
        <div>
            <label>Empresa:</label>
            <input type="text" maxlength="60" data-bind="value: company" />
        </div>
        <div>
            <label>Email:</label>
            <input type="text" maxlength="60" data-bind="value: email" />
        </div>
        <div>
            <label>Tel&eacute;fono:</label>
            <input type="text" maxlength="60" data-bind="value: phone" />
        </div>
        <div>
            <label>Celular:</label>
            <input type="text" maxlength="60" data-bind="value: mobile" />
        </div>
        <div>
            <label>Ciudad:</label>
            <input type="text" maxlength="60" data-bind="value: city" />
        </div>
        <div>
            <label>Asunto:</label>
            <asp:DropDownList runat="server" ID="ddlSubject" data-bind="value: subject, event: { change: subjectChange }" AppendDataBoundItems="true">
                <asp:ListItem Text="[Seleccione]" Value="" />
            </asp:DropDownList>           
        </div>
        <div data-bind="visible: othersubjectvisible">
            <label>Otro Asunto:</label>
             <textarea data-bind="value: otherSubject"></textarea>
        </div>
        <div>
            <button onclick="void(0);" data-bind="click: Save">Enviar</button>
        </div>
    </div>
    <div data-bind="visible: messagevisible">Mensaje de Exito</div>
</div>
