using Calculator.Domain.Models;
using Calculator.Domain.Models.Interfaces;

namespace Calculator.Application.Services
{
    public class ExpressionFormatter : IExpressionFormatter
    {
        private const string SuccessFormat = "{0}={1}";
        private const string ErrorFormat = "{0}=ERROR";

        public string Format(Expression expression, ExpressionResult result)
        {
            return result.IsSuccessful
                ? string.Format(SuccessFormat, expression.Raw, result.Value)
                : string.Format(ErrorFormat, expression.Raw);
        }
    }
}