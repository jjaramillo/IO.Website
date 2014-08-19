using System.ServiceModel;

namespace IO.Website.Services.Contracts
{
    [ServiceContract]
    internal interface IDemoRequest
    {
        [OperationContract]
        void AddDemoRequest(string firstName, string lastName, string company, string email, string phone, string mobile, string city, string siteCollectionUrl);
    }
}
