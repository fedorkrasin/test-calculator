using System;
using MVP.Core.Interfaces;

namespace MVP.Core.Factory
{
    public interface IUIFactory
    {
        void RegisterView<TView>(IView view) where TView : IView;
        TView CreateView<TView>() where TView : IView;
        void RegisterPresenter<TView>(Func<TView, IPresenter> factory) where TView : IView;
        IPresenter CreatePresenter<TView>(TView view) where TView : IView;
    }
}