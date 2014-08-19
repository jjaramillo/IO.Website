using IO.Website.DAL.Support;
using Microsoft.SharePoint;
using System.Runtime.Serialization;

namespace IO.Website.DAL.Entities
{
    [DataContract]
    public class BrochureDownload : BaseEntity
    {
        private string _FirstName;
        private string _LastName;
        private string _Company;
        private string _Email;

        [DataMember]
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        [DataMember]
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        [DataMember]
        public string Company
        {
            get { return _Company; }
            set { _Company = value; }
        }

        [DataMember]
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public BrochureDownload(SPListItem item)
            : base(item)
        {
            _FirstName = item.GetSiteColumnStringValue(SiteColumns.NAME, string.Empty);
            _LastName = item.GetSiteColumnStringValue(SiteColumns.LAST_NAME, string.Empty);
            _Company = item.GetSiteColumnStringValue(SiteColumns.COMPANY, string.Empty);
            _Email = item.GetSiteColumnStringValue(SiteColumns.EMAIL, string.Empty);
        }
    }
}
