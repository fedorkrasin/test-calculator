using System;
using Calculator.Domain.Models.Interfaces;
using MVP.Core.Model;

namespace Calculator.Domain.Models
{
    public class CalculatorService : IModel
    {
        private readonly IExpressionValidator _validator;
        private readonly IExpressionEvaluator _evaluator;

        public CalculatorService(
            IExpressionValidator validator,
            IExpressionEvaluator evaluator)
        {
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
            _evaluator = evaluator ?? throw new ArgumentNullException(nameof(evaluator));
        }

        public ExpressionResult Calculate(Expression expression)
        {
            var evaluationResult = _validator.IsValid(expression)
                ? ExpressionResult.Success(_evaluator.Evaluate(expression))
                : ExpressionResult.Failure();

            return evaluationResult;
        }
    }
}