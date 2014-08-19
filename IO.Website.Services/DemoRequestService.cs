using IO.Website.DAL.Entities;
using IO.Website.Services.Contracts;
using IO.Website.Services.Support;
using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace IO.Website.Services
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class DemoRequestService : IDemoRequest
    {
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "Add", BodyStyle = WebMessageBodyStyle.Wrapped)]
        public void AddDemoRequest(string firstName, string lastName, string company, string email, string phone, string mobile, string city, string siteCollectionUrl)
        {
            try
            {
                DemoRequest demoRequest = new DemoRequest(firstName, lastName, company, email, phone, mobile, city);
                demoRequest.Save(siteCollectionUrl, ListUrls.DEMO_REQUESTS_URL);
            }
            catch (Exception) { throw; }
        }
    }
}
