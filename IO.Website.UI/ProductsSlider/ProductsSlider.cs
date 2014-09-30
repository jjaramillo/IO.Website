using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace IO.Website.UI.ProductsSlider
{
    public enum ProductSliderType
    {
        Memex,
        Poxta,
        Ninguno
    }

    [ToolboxItemAttribute(false)]
    public class ProductsSlider : WebPart
    {
        // Visual Studio might automatically update this path when you change the Visual Web Part project item.
        private const string _ascxPath = @"~/_CONTROLTEMPLATES/15/IO.Website.UI/ProductsSlider/ProductsSliderUserControl.ascx";
        private ProductSliderType _ProductSliderType;

        protected override void CreateChildControls()
        {
            Control control = Page.LoadControl(_ascxPath);
            (control as ProductsSliderUserControl).ProductSliderType = ProductSliderType;
            Controls.Add(control);
        }        

        [WebBrowsable(true), WebDescription("Indica que Producto se deben cargar en el carrousel"), WebDisplayName("Tipo de Carrousel")
        , Personalizable(PersonalizationScope.Shared), Category("Tipo de Slider")]
        public ProductSliderType ProductSliderType
        {
            get
            {
                return _ProductSliderType;
            }
            set
            {
                _ProductSliderType = value;
            }
        }
    }
}
