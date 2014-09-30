using IO.Website.DAL.Entities;
using IO.Website.Services.Contracts;
using IO.Website.Services.Support;
using Microsoft.SharePoint;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace IO.Website.Services
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class SliderService : ISlider
    {
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "Home?siteCollectionUrl={siteCollectionUrl}", BodyStyle = WebMessageBodyStyle.Wrapped)]
        public List<HomeSlide> GetHomeSlides(string siteCollectionUrl)
        {
            List<HomeSlide> foundElements = new List<HomeSlide>();
            SPSecurity.RunWithElevatedPrivileges(delegate() {
                using (SPSite site = new SPSite(siteCollectionUrl))
                {
                    using (SPWeb web = site.OpenWeb())
                    {
                        SPList targetList = web.GetList(string.Format("{0}/{1}", web.Url, ListUrls.HOME_SLIDES));
                        SPListItemCollection elements = targetList.Items;
                        foundElements = (from SPListItem item in elements
                                         select new HomeSlide(item)).ToList();
                    }
                }
            });
            return foundElements;
        }

        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "Products/Poxta?siteCollectionUrl={siteCollectionUrl}", BodyStyle = WebMessageBodyStyle.Wrapped)]
        public List<ProductSlide> GetPoxtaProductSlides(string siteCollectionUrl)
        {
            List<ProductSlide> foundElements = new List<ProductSlide>();
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = new SPSite(siteCollectionUrl))
                {
                    using (SPWeb web = site.OpenWeb())
                    {
                        SPList targetList = web.GetList(string.Format("{0}/{1}", web.Url, ListUrls.POXTA_PRODUCT_SLIDES));
                        SPListItemCollection elements = targetList.Items;
                        foundElements = (from SPListItem item in elements
                                         select new ProductSlide(item)).ToList();
                    }
                }
            });
            return foundElements;
        }

        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "Products/Memex?siteCollectionUrl={siteCollectionUrl}", BodyStyle = WebMessageBodyStyle.Wrapped)]
        public List<ProductSlide> GetMemexProductSlides(string siteCollectionUrl)
        {
            List<ProductSlide> foundElements = new List<ProductSlide>();
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = new SPSite(siteCollectionUrl))
                {
                    using (SPWeb web = site.OpenWeb())
                    {
                        SPList targetList = web.GetList(string.Format("{0}/{1}", web.Url, ListUrls.MEMEX_PRODUCT_SLIDES));
                        SPListItemCollection elements = targetList.Items;
                        foundElements = (from SPListItem item in elements
                                         select new ProductSlide(item)).ToList();
                    }
                }
            });
            return foundElements;
        }
    }
}
