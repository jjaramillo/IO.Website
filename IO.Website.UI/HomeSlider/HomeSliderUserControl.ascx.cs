using System;
using System.Web.UI;

namespace IO.Website.UI.HomeSlider
{
    public partial class HomeSliderUserControl : UserControl
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
                    @"var homeSliderViewModel_{0} = new HomeSliderViewModel(); ko.applyBindings(homeSliderViewModel_{0}, document.getElementById('{0}'));"
                    , home_slider_container.ClientID);
            ScriptManager.RegisterStartupScript(this, typeof(HomeSliderUserControl), "HomeSliderViewModel", viewModelJavascript, true);
        }
    }
}
