using System;
using Calculator.Domain.Models;
using Calculator.Domain.Models.Interfaces;
using Calculator.Presentation.Interfaces;
using MVP.Core.Presenter;

namespace Calculator.Presentation
{
    public class CalculatorPresenter : IPresenter
    {
        private readonly ICalculatorView _view;
        private readonly CalculatorService _model;
        private readonly IExpressionFormatter _formatter;
        
        public CalculatorPresenter(
            ICalculatorView view,
            CalculatorService model,
            IExpressionFormatter expressionFormatter)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _formatter = expressionFormatter ?? throw new ArgumentNullException(nameof(expressionFormatter));
        }

        public void Initialize()
        {
            _view.Initialize();

            _view.CalculateButtonClicked += OnCalculateRequested;
        }

        public void Dispose()
        {
            _view.CalculateButtonClicked -= OnCalculateRequested;
            
            _view.Dispose();
        }

        private void OnCalculateRequested(string input)
        {
            var expression = new Expression(input);
            var result = _model.Calculate(expression);

            var output = _formatter.Format(expression, result);
            
            _view.SetResult(output);
        }
    }
}