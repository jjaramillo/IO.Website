using IO.Website.DAL.Support;
using Microsoft.SharePoint;
using System.Runtime.Serialization;

namespace IO.Website.DAL.Entities
{
    [DataContract]
    public class ProductSlide : BaseEntity
    {
        private string _Title;
        private string _Description;
        private string _ImageUrl;
        private string _YoutubeUrl;
        private string _YoutubeVideoTitle;

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
        public string YoutubeUrl
        {
            get { return _YoutubeUrl; }
            set { _YoutubeUrl = value; }
        }

        [DataMember]
        public string YoutubeVideoTitle
        {
            get { return _YoutubeVideoTitle; }
            set { _YoutubeVideoTitle = value; }
        }

        public ProductSlide(SPListItem item)
            : base(item)
        {
            SPFieldUrlValue youtubeLink = item.GetSiteColumnUrlValue(SiteColumns.YOUTUBE_LINK);            
            _Description = item.GetSiteColumnStringValue(SiteColumns.DESCRIPTION, string.Empty);
            _YoutubeUrl = youtubeLink == null ? string.Empty : youtubeLink.Url;
            _YoutubeVideoTitle = youtubeLink == null ? string.Empty : youtubeLink.Description;
            _ImageUrl = item.File.ServerRelativeUrl;
            _Title = item.File.Title;
        }
    }
}
