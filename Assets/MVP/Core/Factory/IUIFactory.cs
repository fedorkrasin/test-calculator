using MVP.Core.Presenter;
using MVP.Core.View;

namespace MVP.Core.Factory
{
    public interface IUIFactory
    {
        TView CreateView<TView>() where TView : IView;
        IPresenter CreatePresenter<TView>(TView view) where TView : IView;
    }
}