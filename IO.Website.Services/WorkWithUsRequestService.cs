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
    public class WorkWithUsRequestService : IWorkWithUsRequest
    {
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "Add", BodyStyle = WebMessageBodyStyle.Wrapped)]
        public void AddWorkWithUsRequest(string firstName, string lastName, string email, string fileName, string fileData, string siteCollectionUrl)
        {
            try
            {
                WorkWithUs workWithUs = new WorkWithUs(firstName, lastName, email, fileName, fileData);
                workWithUs.Save(siteCollectionUrl, ListUrls.WORK_WITH_US_REQUESTS_URL);
            }
            catch (Exception) { throw; }
        }
    }
}
