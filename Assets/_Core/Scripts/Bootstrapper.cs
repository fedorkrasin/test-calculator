using Calculator.Data.Repositories;
using Calculator.Domain.Models;
using Calculator.ExpressionEvaluation;
using Calculator.Presentation;
using Calculator.Presentation.Interfaces;
using Calculator.Presentation.Interfaces.Views;
using Calculator.Presentation.Services;
using Calculator.UI.Views;
using MVP.Core.Factory;
using MVP.Core.Interfaces;
using MVP.Unity.Factory;
using UnityEngine;

public class Bootstrapper : MonoBehaviour, IUIService
{
    [SerializeField] private Transform _canvasTransform;
    
    [SerializeField] private CalculatorView _calculatorView;
    [SerializeField] private InvalidExpressionView _invalidExpressionView;

    private IUIFactory _uiFactory;
    private IPresenter _openedPresenter;
        
    private void Awake()
    {
        _uiFactory = new UIFactory(_canvasTransform);
        RegisterCalculatorPresenter();
        RegisterInvalidExpressionPresenter();

        OpenView<ICalculatorView>();
    }

    public void OpenView<TView>() where TView : IView
    {
        _openedPresenter?.Dispose();
            
        var view = _uiFactory.CreateView<TView>();
        _openedPresenter = _uiFactory.CreatePresenter(view);
            
        _openedPresenter.Initialize();
    }

    private void RegisterCalculatorPresenter()
    {
        var validator = new SimpleAdditionValidator();
        var evaluator = new SimpleAdditionEvaluator();

        var repository = new PlayerPrefsCalculatorRepository();
        var formatter = new ExpressionFormatter();
            
        _uiFactory.RegisterView<ICalculatorView>(_calculatorView);
        _uiFactory.RegisterPresenter<ICalculatorView>(view =>
        {
            var model = new CalculatorService(validator, evaluator);
            return new CalculatorPresenter(view, model, repository, formatter, this);
        });
    }

    private void RegisterInvalidExpressionPresenter()
    {
        _uiFactory.RegisterView<IInvalidExpressionView>(_invalidExpressionView);
        _uiFactory.RegisterPresenter<IInvalidExpressionView>(view => new InvalidExpressionPresenter(view, this));
    }
}
