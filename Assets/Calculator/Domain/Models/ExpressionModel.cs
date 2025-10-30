using System;

namespace Calculator.Domain.Models
{
    [Serializable]
    public struct ExpressionModel
    {
        public string Expression;
        public ExpressionResult Result;

        public ExpressionModel(string raw)
        {
            Expression = raw.Trim();
            Result = new ExpressionResult();
        }

        public void SetResult(ExpressionResult result)
        {
            Result = result;
        }
    }
}