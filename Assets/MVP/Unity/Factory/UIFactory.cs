using System;
using System.Collections.Generic;
using MVP.Core.Factory;
using MVP.Core.Presenter;
using MVP.Core.View;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MVP.Unity.Factory
{
    public class UIFactory : IUIFactory
    {
        private readonly Dictionary<Type, View> _viewPrefabs;
        private readonly Transform _uiRoot;
        private readonly Dictionary<Type, Func<IView, IPresenter>> _presenterFactories;
        
        public UIFactory(Dictionary<Type, View> viewPrefabs, Transform uiRoot)
        {
            _viewPrefabs = viewPrefabs ?? throw new ArgumentNullException(nameof(viewPrefabs));
            _uiRoot = uiRoot ?? throw new ArgumentNullException(nameof(uiRoot));
            _presenterFactories = new Dictionary<Type, Func<IView, IPresenter>>();
        }

        public TView CreateView<TView>() where TView : IView
        {
            if (!_viewPrefabs.TryGetValue(typeof(TView), out var prefab))
            {
                throw new Exception($"No prefab registered for view type {typeof(TView).Name}");
            }

            var view = Object.Instantiate(prefab, _uiRoot);
            return view.GetComponent<TView>(); // TODO: mb refactor
        }
        
        public void RegisterPresenter<TView>(Func<TView, IPresenter> factory) where TView : IView
        {
            _presenterFactories[typeof(TView)] = view => factory((TView)view);
        }

        public IPresenter CreatePresenter<TView>(TView view) where TView : IView
        {
            var viewType = typeof(TView);
            if (!_presenterFactories.TryGetValue(viewType, out var factory))
            {
                throw new Exception($"No presenter registered for view type {viewType.Name}");
            }

            return factory(view);
        }
    }
}