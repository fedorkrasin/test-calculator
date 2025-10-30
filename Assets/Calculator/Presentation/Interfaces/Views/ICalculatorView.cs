using System;
using MVP.Core.Interfaces;

namespace Calculator.Presentation.Interfaces.Views
{
    public interface ICalculatorView : IView
    {
        void SetHistory(string history);
        void AppendResultToHistory(string result);
        void SetInput(string getLastInput);
        
        event Action<string> CalculateButtonClicked;
        event Action<string> InputFieldValueChanged;
    }
}