using System;
using Calculator.Presentation.Interfaces;
using Calculator.Presentation.Interfaces.Views;
using MVP.Core.Interfaces;

namespace Calculator.Presentation
{
    public class InvalidExpressionPresenter : IPresenter
    {
        private readonly IInvalidExpressionView _view;
        private readonly IUIService _uiService;

        public InvalidExpressionPresenter(
            IInvalidExpressionView view,
            IUIService uiService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _uiService = uiService ?? throw new ArgumentNullException(nameof(uiService));
        }
        
        public void Initialize()
        {
            _view.Initialize();

            _view.CloseClicked += CloseView;
        }

        public void Dispose()
        {
            _view.CloseClicked -= CloseView;
            
            _view.Dispose();
        }

        private void CloseView()
        {
            _uiService.OpenView<ICalculatorView>();
        }
    }
}