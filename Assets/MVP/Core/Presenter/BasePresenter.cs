using MVP.Core.Model;
using MVP.Core.View;

namespace MVP.Core.Presenter
{
    public abstract class BasePresenter<TView, TModel> : IPresenter where TView : IView where TModel : IModel
    {
        protected readonly TView View;
        protected readonly TModel Model;

        protected BasePresenter(TView view, TModel model)
        {
            View = view;
            Model = model;
        }

        public abstract void Initialize();
        public abstract void Dispose();
    }
}