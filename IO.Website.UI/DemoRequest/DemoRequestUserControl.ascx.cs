using System;
using System.Web.UI;

namespace IO.Website.UI.DemoRequest
{
    public partial class DemoRequestUserControl : UserControl
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
                    @"var demoRequestViewModel_{0} = new DemoRequestViewModel(); ko.applyBindings(demoRequestViewModel_{0}, document.getElementById('{0}'));"
                    , demo_request_form_container.ClientID);
            ScriptManager.RegisterStartupScript(this, typeof(DemoRequestUserControl), "DemoRequestViewModel", viewModelJavascript, true);
        }
    }
}
