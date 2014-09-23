
using Microsoft.SharePoint;
using System.Collections.Generic;
using System.Linq;

namespace IO.Website.DAL.Support
{
    internal class SiteColumns
    {
        internal const string NAME = "IO_Website_Name";
        internal const string LAST_NAME = "IO_Website_LastName";
        internal const string COMPANY = "IO_Website_Company";
        internal const string EMAIL = "IO_Website_Email";
        internal const string PHONE = "IO_Website_Phone";
        internal const string MOBILE = "IO_Website_Mobile";
        internal const string CITY = "IO_Website_City";
        internal const string SUBJECT = "IO_Website_Subject";
        internal const string OTHER_SUBJECT = "IO_Website_OtherSubject";

        internal const string DESCRIPTION = "IO_Website_SliderDescription";
        internal const string LINK = "IO_Website_SliderLink";
        internal const string COLOR = "IO_Website_BackgroundColor";
        internal const string YOUTUBE_LINK = "IO_Website_SliderYoutubeLink";

        internal List<string> ChoiceValues(string siteColumnStaticName, SPWeb web)
        {
            List<string> values = default(List<string>);

            SPFieldChoice field = web.AvailableFields.GetField(siteColumnStaticName) as SPFieldChoice;

            values = (from string choice in field.Choices
                      orderby choice
                      select choice).ToList();

            return values;
        }

        
    }
}
