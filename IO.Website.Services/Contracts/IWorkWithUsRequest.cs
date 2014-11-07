using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IO.Website.Services.Contracts
{
    [ServiceContract]
    internal interface IWorkWithUsRequest
    {
        [OperationContract]
        void AddWorkWithUsRequest(string firstName, string lastName, string email, string fileName, byte[] fileData, string siteCollectionUrl);
    }
}
