using System.Text.RegularExpressions;
using Calculator.Domain.Models;
using Calculator.Domain.Models.Interfaces;

namespace Calculator.ExpressionEvaluation
{
    public class SimpleAdditionValidator : IExpressionValidator
    {
        private static readonly Regex ValidExpressionRegex = new(@"^\d+(\+\d+)*$", RegexOptions.Compiled);

        public bool IsValid(Expression expression) // TODO: 123=123 is not valid
        {
            return ValidExpressionRegex.IsMatch(expression.Raw);
        }
    }
}