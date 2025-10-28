using System;
using Calculator.Presentation.Interfaces;
using MVP.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Calculator.UI.Views
{
    public class CalculatorView : View, ICalculatorView
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private TMP_Text _resultLabel;
        [SerializeField] private Button _calculateButton;
        
        public event Action<string> CalculateButtonClicked = delegate { };

        public override void Initialize()
        {
            _calculateButton.onClick.AddListener(OnCalculateButtonClicked);
        }

        public override void Dispose()
        {
            _calculateButton.onClick.RemoveListener(OnCalculateButtonClicked);
        }
        
        public void SetResult(string result)
        {
            _resultLabel.text = result;
        }

        private void OnCalculateButtonClicked()
        {
            var input = _inputField.text;
            CalculateButtonClicked(input);
        }
    }
}