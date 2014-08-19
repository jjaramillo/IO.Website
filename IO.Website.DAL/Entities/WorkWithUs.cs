using IO.Website.DAL.Support;
using Microsoft.SharePoint;
using System.Runtime.Serialization;

namespace IO.Website.DAL.Entities
{
    [DataContract]
    public class WorkWithUs : BaseEntity
    {
        private string _FirstName;
        private string _LastName;
        private string _Email;
        private byte[] _FileContents;

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
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        [DataMember]
        public byte[] FileContents
        {
            get { return _FileContents; }
            set { _FileContents = value; }
        }

        public WorkWithUs(SPListItem item)
            : base(item)
        {
            _FirstName = item.GetSiteColumnStringValue(SiteColumns.NAME, string.Empty);
            _LastName = item.GetSiteColumnStringValue(SiteColumns.LAST_NAME, string.Empty);
            _Email = item.GetSiteColumnStringValue(SiteColumns.EMAIL, string.Empty);
        }
    }
}
