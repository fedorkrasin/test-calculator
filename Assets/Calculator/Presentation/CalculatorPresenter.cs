using System;
using System.Collections.Generic;
using System.Linq;
using Calculator.Domain.Models;
using Calculator.Domain.Models.Interfaces;
using Calculator.Presentation.Interfaces;
using Calculator.Presentation.Interfaces.Views;
using MVP.Core.Interfaces;

namespace Calculator.Presentation
{
    public class CalculatorPresenter : IPresenter
    {
        private readonly ICalculatorView _view;
        private readonly CalculatorService _model;
        private readonly ICalculatorRepository _repository;
        private readonly IExpressionFormatter _formatter;
        private readonly IUIService _uiService;
        
        public CalculatorPresenter(
            ICalculatorView view,
            CalculatorService model,
            ICalculatorRepository repository,
            IExpressionFormatter formatter,
            IUIService uiService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
            _uiService = uiService ?? throw new ArgumentNullException(nameof(uiService));
        }

        public void Initialize()
        {
            _view.Initialize();
            
            _view.SetHistory(FormatHistory(_repository.GetHistory()));
            _view.SetInput(_repository.GetLastInput());

            _view.CalculateButtonClicked += OnCalculateRequested;
            _view.InputFieldValueChanged += SaveInput;
        }

        public void Dispose()
        {
            _view.InputFieldValueChanged -= SaveInput;
            _view.CalculateButtonClicked -= OnCalculateRequested;
            
            _view.Dispose();
        }

        private void OnCalculateRequested(string input)
        {
            var expression = new ExpressionModel(input);
            var result = _model.Calculate(expression);
            var output = _formatter.Format(result);

            _repository.SaveToHistory(result);
            
            if (!result.Result.IsSuccessful)
            {
                _uiService.OpenView<IInvalidExpressionView>();
                return;
            }
            
            _view.AppendResultToHistory(output);
        }

        private void SaveInput(string value)
        {
            _repository.SaveInput(value);
        }
        
        private string FormatHistory(List<ExpressionModel> expressions)
        {
            return string.Join("\n", expressions
                .AsEnumerable()
                .Reverse()
                .Select(e => _formatter.Format(e))
            );
        }
    }
}