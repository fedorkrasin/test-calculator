using Calculator.Domain.Models;
using Calculator.Domain.Models.Interfaces;

namespace Calculator.Presentation.Services
{
    public class ExpressionFormatter : IExpressionFormatter
    {
        private const string SuccessFormat = "{0}={1}";
        private const string ErrorFormat = "{0}=ERROR";

        public string Format(ExpressionModel expression)
        {
            return expression.Result.IsSuccessful
                ? string.Format(SuccessFormat, expression.Expression, expression.Result.Value)
                : string.Format(ErrorFormat, expression.Expression);
        }
    }
}