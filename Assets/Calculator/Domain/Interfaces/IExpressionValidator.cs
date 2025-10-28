namespace Calculator.Domain.Models.Interfaces
{
    public interface IExpressionValidator
    {
        bool IsValid(Expression expression);
    }
}