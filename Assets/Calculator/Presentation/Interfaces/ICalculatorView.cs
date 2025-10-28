using System;
using MVP.Core.View;

namespace Calculator.Presentation.Interfaces
{
    public interface ICalculatorView : IView
    {
        void SetResult(string result);
        
        event Action<string> CalculateButtonClicked;
    }
}