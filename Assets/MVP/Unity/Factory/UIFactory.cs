using System;
using System.Collections.Generic;
using MVP.Core.Factory;
using MVP.Core.Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MVP.Unity.Factory
{
    public class UIFactory : IUIFactory
    {
        private readonly Dictionary<Type, View> _viewPrefabs;
        private readonly Transform _uiRoot;
        private readonly Dictionary<Type, Func<IView, IPresenter>> _presenterFactories;
        
        public UIFactory(Transform uiRoot)
        {
            _uiRoot = uiRoot ?? throw new ArgumentNullException(nameof(uiRoot));
            _viewPrefabs = new Dictionary<Type, View>();
            _presenterFactories = new Dictionary<Type, Func<IView, IPresenter>>();
        }

        public void RegisterView<TView>(IView view) where TView : IView
        {
            if (view is TView)
            {
                _viewPrefabs[typeof(TView)] = (View)view;
            }
        }

        public TView CreateView<TView>() where TView : IView
        {
            if (!_viewPrefabs.TryGetValue(typeof(TView), out var prefab))
            {
                throw new Exception($"No prefab registered for view type {typeof(TView).Name}");
            }

            var view = Object.Instantiate(prefab, _uiRoot);
            return view.GetComponent<TView>();
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