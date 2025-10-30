namespace Calculator.Domain.Models.Interfaces
{
    public interface IExpressionEvaluator
    {
        int Evaluate(ExpressionModel expression);
    }
}