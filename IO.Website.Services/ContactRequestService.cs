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
    public class ContactRequestService : IContactRequest
    {
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "Add", BodyStyle = WebMessageBodyStyle.Wrapped)]
        public void AddContactRequest(string firstName, string lastName, string company, string email, string phone, string mobile, string city, string subject
            , string otherSubject, string siteCollectionUrl)
        {
            try
            {
                ContactRequest contactRequest = new ContactRequest(firstName, lastName, company, email, phone, mobile, city, subject, otherSubject);
                contactRequest.Save(siteCollectionUrl, ListUrls.CONTACT_REQUESTS_URL);
            }
            catch (Exception) { throw; }
        }
    }
}
