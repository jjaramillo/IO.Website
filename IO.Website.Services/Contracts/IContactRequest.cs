using System.ServiceModel;

namespace IO.Website.Services.Contracts
{
    [ServiceContract]
    internal interface IContactRequest
    {
        [OperationContract]
        void AddContactRequest(string firstName, string lastName, string company, string email, string phone, string mobile, string city, string subject, string otherSubject
            , string siteCollectionUrl);
    }
}
