using IO.Website.DAL.Support;
using Microsoft.SharePoint;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace IO.Website.UI.ContactRequest
{
    public partial class ContactRequestUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlSubject.DataSource = FieldHelper.GetSubjects(SPContext.Current.Web);
                ddlSubject.DataBind();
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            RegisterViewModel();
        }

        private void RegisterViewModel()
        {
            string viewModelJavascript = string.Format(
                    @"var contactRequestViewModel_{0} = new ContactRequestViewModel(); ko.applyBindings(contactRequestViewModel_{0}, document.getElementById('{0}'));"
                    , contact_request_form_container.ClientID);
            ScriptManager.RegisterStartupScript(this, typeof(ContactRequestUserControl), "ContactRequestViewModel", viewModelJavascript, true);
        }
    }
}
