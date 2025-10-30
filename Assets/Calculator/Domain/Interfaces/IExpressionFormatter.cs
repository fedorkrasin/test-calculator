namespace Calculator.Domain.Models.Interfaces
{
    public interface IExpressionFormatter
    {
        string Format(ExpressionModel expression);
    }
}