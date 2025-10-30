using System.Linq;
using Calculator.Domain.Models;
using Calculator.Domain.Models.Interfaces;

namespace Calculator.ExpressionEvaluation
{
    public class SimpleAdditionEvaluator : IExpressionEvaluator
    {
        public int Evaluate(ExpressionModel expression)
        {
            return expression.Expression
                .Split('+')
                .Select(int.Parse)
                .Sum();
        }
    }
}