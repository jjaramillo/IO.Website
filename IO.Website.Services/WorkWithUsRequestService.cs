using IO.Website.Services.Contracts;
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
        public void AddWorkWithUsRequest(string firstName, string lastName, string email, string fileName, byte[] fileData, string siteCollectionUrl)
        {
            throw new NotImplementedException();
        }
    }
}
