using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace IO.Website.UI.WorkWithUsRequest
{
    public partial class WorkWithUsRequestUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            RegisterViewModel();
        }

        private void RegisterViewModel()
        {
            string viewModelJavascript = string.Format(
                    @"var workWithUsRequestViewModel_{0} = new WorkWithUsRequestViewModel(); ko.applyBindings(workWithUsRequestViewModel_{0}, document.getElementById('{0}'));"
                    , workwithus_request_form_container.ClientID);
            ScriptManager.RegisterStartupScript(this, typeof(WorkWithUsRequestUserControl), "WorkWithUsRequestViewModel", viewModelJavascript, true);
        }
    }
}
