using System.Collections.Generic;

namespace IO.Website.DAL.Support
{
    internal static class DictionaryExtensions
    {
        internal static void AddOrUpdateProperty(this Dictionary<string, object> propertyBag, string siteColumnStaticName, object value)
        {
            if (propertyBag.ContainsKey(siteColumnStaticName))
                propertyBag[siteColumnStaticName] = value;
            else
                propertyBag.Add(siteColumnStaticName, value);
        }
    }
}
