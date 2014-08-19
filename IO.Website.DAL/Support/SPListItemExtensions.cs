using Microsoft.SharePoint;

namespace IO.Website.DAL.Support
{
    internal static class SPListItemExtensions
    {
        internal static string GetSiteColumnStringValue(this SPListItem item, string siteColumnStaticName, string defaulValue)
        {
            return item[siteColumnStaticName] == null ? defaulValue : item[siteColumnStaticName].ToString();
        }
    }
}
