using Microsoft.SharePoint.WebControls;
using System;

namespace IO.Website.UI.MVP
{
    public class ExtendedLayoutsPage : LayoutsPageBase
    {
        protected void HandleError(Exception ex)
        {
            SPPageStatusSetter setter = new SPPageStatusSetter();
            setter.AddStatus("Error:", ex.Message, SPPageStatusColor.Red);
            this.Controls.Add(setter);
        }

        protected void HandleSuccess(string message) 
        {
            SPPageStatusSetter setter = new SPPageStatusSetter();
            setter.AddStatus("&Eacute;xito:", message, SPPageStatusColor.Green);
            this.Controls.Add(setter);
        }
    }
}
