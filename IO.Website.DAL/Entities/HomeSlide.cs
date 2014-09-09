using IO.Website.DAL.Support;
using Microsoft.SharePoint;
using System.Runtime.Serialization;

namespace IO.Website.DAL.Entities
{
    [DataContract]
    public class HomeSlide : BaseEntity
    {
        private string _Description;
        private string _ImageUrl;
        private string _LinkUrl;
        private string _LinkTitle;
        private string _Title;

        [DataMember]
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        [DataMember]
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        [DataMember]
        public string ImageUrl
        {
            get { return _ImageUrl; }
            set { _ImageUrl = value; }
        }

        [DataMember]
        public string LinkUrl
        {
            get { return _LinkUrl; }
            set { _LinkUrl = value; }
        }

        [DataMember]
        public string LinkTitle
        {
            get { return _LinkTitle; }
            set { _LinkTitle = value; }
        }

        public HomeSlide(SPListItem item)
            : base(item)
        {            
            SPFieldUrlValue spLink = item.GetSiteColumnUrlValue(SiteColumns.LINK);
            _Title = item.File.Title;
            _Description = item.GetSiteColumnStringValue(SiteColumns.DESCRIPTION, string.Empty);            
            _LinkUrl = spLink == null ? string.Empty : spLink.Url;
            _LinkTitle = spLink == null ? string.Empty : spLink.Description;
            _ImageUrl = item.File.ServerRelativeUrl;
        }
    }
}
