using Calculator.Domain.Models.Interfaces;
using UnityEngine;

namespace Calculator.Data.Repositories
{
    public class PlayerPrefsCalculatorRepository : ICalculatorRepository
    {
        private const string HistoryKey = "Calculator_History";

        public void Save(string output)
        {
            var currentHistory = PlayerPrefs.GetString(HistoryKey, "");
            var updatedHistory = string.IsNullOrEmpty(currentHistory) ? output : currentHistory + "\n" + output;
            PlayerPrefs.SetString(HistoryKey, updatedHistory);
            PlayerPrefs.Save();
        }

        public string GetHistory()
        {
            return PlayerPrefs.GetString(HistoryKey, "");
        }
    }
}