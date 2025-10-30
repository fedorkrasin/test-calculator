namespace Calculator.Domain.Models.Interfaces
{
    public interface IExpressionValidator
    {
        bool IsValid(ExpressionModel expression);
    }
}