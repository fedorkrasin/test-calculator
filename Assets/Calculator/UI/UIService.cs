using Calculator.Application.Services;
using Calculator.Domain.Models;
using Calculator.ExpressionEvaluation;
using Calculator.Presentation;
using Calculator.UI.Views;
using MVP.Core.Presenter;
using MVP.Unity;
using MVP.Unity.Factory;
using UnityEngine;

namespace Calculator.UI
{
    public class UIService : MonoBehaviour
    {
        [SerializeField] private ViewMap _viewMap;
        [SerializeField] private Transform _canvasTransform;

        private UIFactory _uiFactory;
        private IPresenter _openedPresenter;
        
        private void Awake()
        {
            var validator = new SimpleAdditionValidator();
            var evaluator = new SimpleAdditionEvaluator();

            var formatter = new ExpressionFormatter();
            
            _uiFactory = new UIFactory(_viewMap.ToDictionary(), _canvasTransform);
            
            _uiFactory.RegisterPresenter<CalculatorView>(view =>
            {
                var model = new CalculatorService(validator, evaluator);
                return new CalculatorPresenter(view, model, formatter);
            });
            
            OpenView<CalculatorView>();
        }

        private void OpenView<TView>() where TView : View
        {
            _openedPresenter?.Dispose();
            
            var view = _uiFactory.CreateView<TView>();
            _openedPresenter = _uiFactory.CreatePresenter(view);
            
            _openedPresenter.Initialize();
        }
    }
}