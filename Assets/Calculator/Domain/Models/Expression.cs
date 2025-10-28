using System;

namespace Calculator.Domain.Models
{
    public readonly struct Expression
    {
        public string Raw { get; }

        public Expression(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw))
            {
                throw new ArgumentException("The expression cannot be empty", nameof(raw));
            }

            Raw = raw.Trim();
        }
    }
}