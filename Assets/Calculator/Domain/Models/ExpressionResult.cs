using System;

namespace Calculator.Domain.Models
{
    [Serializable]
    public struct ExpressionResult
    {
        public bool IsSuccessful;
        public int Value;

        public static ExpressionResult Success(int value) => new(true, value);
        public static ExpressionResult Failure() => new(false, 0);

        private ExpressionResult(bool isSuccessful, int value)
        {
            IsSuccessful = isSuccessful;
            Value = isSuccessful ? value : 0;
        }
    }
}