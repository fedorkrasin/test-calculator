using System;
using MVP.Core.Interfaces;

namespace Calculator.Presentation.Interfaces.Views
{
    public interface IInvalidExpressionView : IView
    {
        event Action CloseClicked;
    }
}