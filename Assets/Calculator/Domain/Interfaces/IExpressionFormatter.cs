namespace Calculator.Domain.Models.Interfaces
{
    public interface IExpressionFormatter
    {
        string Format(Expression expression, ExpressionResult result);
    }
}