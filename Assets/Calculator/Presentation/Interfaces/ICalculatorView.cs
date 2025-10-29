using System;
using MVP.Core.View;

namespace Calculator.Presentation.Interfaces
{
    public interface ICalculatorView : IView
    {
        void SetHistory(string history);
        void AppendResultToHistory(string result);
        
        event Action<string> CalculateButtonClicked;
    }
}