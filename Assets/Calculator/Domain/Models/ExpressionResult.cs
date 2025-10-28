namespace Calculator.Domain.Models
{
    public readonly struct ExpressionResult
    {
        public bool IsSuccessful { get; }
        public int? Value { get; }

        public static ExpressionResult Success(int value) => new(true, value);
        public static ExpressionResult Failure() => new(false, null);

        private ExpressionResult(bool isSuccessful, int? value)
        {
            IsSuccessful = isSuccessful;
            Value = isSuccessful ? value : null;
        }
    }
}