using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace IO.Website.UI.Layouts.IO.Website
{
    public partial class ViewVideo : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;
            videoSource.Src =  Request.QueryString.Get("videoUrl");
        }
    }
}
