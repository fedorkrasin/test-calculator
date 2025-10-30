using MVP.Core.Interfaces;

namespace Calculator.Presentation.Interfaces
{
    public interface IUIService
    {
        void OpenView<TView>() where TView : IView;
    }
}