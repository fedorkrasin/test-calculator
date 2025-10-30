using System;
using System.Collections.Generic;
using Calculator.Domain.Models;

namespace Calculator.Data.Models
{
    [Serializable]
    public class CalculatorState
    {
        public List<ExpressionModel> History = new();
        public string LastInput = "";
    }
}