using System.Collections.Generic;
using Calculator.Data.Models;
using Calculator.Domain.Models;
using Calculator.Domain.Models.Interfaces;
using UnityEngine;

namespace Calculator.Data.Repositories
{
    public class PlayerPrefsCalculatorRepository : ICalculatorRepository
    {
        private const string StateKey = "Calculator_State";

        public void SaveToHistory(ExpressionModel expression)
        {
            var state = LoadState();
            state.History.Add(expression);
            SaveState(state);
        }

        public List<ExpressionModel> GetHistory()
        {
            return LoadState().History;
        }

        public void SaveInput(string input)
        {
            var state = LoadState();
            state.LastInput = input;
            SaveState(state);
        }

        public string GetLastInput()
        {
            return LoadState().LastInput;
        }
        
        private CalculatorState LoadState()
        {
            var json = PlayerPrefs.GetString(StateKey, "");
            return string.IsNullOrEmpty(json) ? new CalculatorState() : JsonUtility.FromJson<CalculatorState>(json);
        }

        private void SaveState(CalculatorState state)
        {
            var json = JsonUtility.ToJson(state);
            PlayerPrefs.SetString(StateKey, json);
            PlayerPrefs.Save();
        }

    }
}