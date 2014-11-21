using System.ServiceModel;

namespace IO.Website.Services.Contracts
{
    [ServiceContract]
    internal interface IWorkWithUsRequest
    {
        [OperationContract]
        void AddWorkWithUsRequest(string firstName, string lastName, string email, string fileName, string fileData, string siteCollectionUrl);
    }
}
