using Microsoft.SharePoint;

namespace IO.Website.UI.MVP
{
    public class BasePresenter<T> where T : IView
    {
        protected T _View;
        protected SPWeb _Web;

        public BasePresenter(T view, SPWeb web)
        {
            _View = view;
            _Web = web;
        }
    }
}
