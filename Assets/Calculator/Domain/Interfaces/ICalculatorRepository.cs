using System.Collections.Generic;

namespace Calculator.Domain.Models.Interfaces
{
    public interface ICalculatorRepository
    {
        void SaveToHistory(ExpressionModel expression);
        List<ExpressionModel> GetHistory();
        
        void SaveInput(string input);
        string GetLastInput();
    }
}