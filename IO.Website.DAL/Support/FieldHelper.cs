using Microsoft.SharePoint;
using System.Collections.Generic;

namespace IO.Website.DAL.Support
{
    public class FieldHelper
    {
        public static List<string> GetSubjects(SPWeb web)
        {
            SiteColumns sc = new SiteColumns();
            return sc.ChoiceValues(SiteColumns.SUBJECT, web);
        }
    }
}
