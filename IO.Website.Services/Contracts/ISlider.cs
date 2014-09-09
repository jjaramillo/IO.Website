using IO.Website.DAL.Entities;
using System.Collections.Generic;
using System.ServiceModel;

namespace IO.Website.Services.Contracts
{
    [ServiceContract]
    internal interface ISlider
    {
        [OperationContract]
        List<HomeSlide> GetHomeSlides(string siteCollectionUrl);
        [OperationContract]
        List<ProductSlide> GetProductSlides(string siteCollectionUrl);
    }
}
