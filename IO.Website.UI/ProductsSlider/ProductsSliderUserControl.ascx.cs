using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace IO.Website.UI.ProductsSlider
{
    public partial class ProductsSliderUserControl : UserControl
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
                    @"var productSliderViewModel_{0} = new ProductSliderViewModel(); ko.applyBindings(productSliderViewModel_{0}, document.getElementById('{0}'));"
                    , products_container.ClientID);
            ScriptManager.RegisterStartupScript(this, typeof(ProductsSliderUserControl), "ProductSliderViewModel", viewModelJavascript, true);
        }
    }
}
