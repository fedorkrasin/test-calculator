using System;
using Calculator.Presentation.Interfaces.Views;
using Calculator.UI.Components;
using MVP.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Calculator.UI.Views
{
    public class CalculatorView : View, ICalculatorView
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private TMP_Text _historyLabel;
        [SerializeField] private Button _calculateButton;
        [SerializeField] private DynamicVerticalScrollView _scrollView;
        [SerializeField] private RectTransform _buttonSpacer;

        public event Action<string> CalculateButtonClicked = delegate { };
        public event Action<string> InputFieldValueChanged = delegate { };

        public override void Initialize()
        {
            _calculateButton.onClick.AddListener(OnCalculateButtonClicked);
            _inputField.onValueChanged.AddListener(OnInputFieldValueChanged);
        }

        public override void Dispose()
        {
            _inputField.onValueChanged.RemoveListener(OnInputFieldValueChanged);
            _calculateButton.onClick.RemoveListener(OnCalculateButtonClicked);
            
            base.Dispose();
        }

        public void AppendResultToHistory(string result)
        {
            SetHistory(result + "\n" + _historyLabel.text);
        }

        public void SetHistory(string history)
        {
            _historyLabel.text = history;
            _scrollView.UpdateHeight();
            _buttonSpacer.gameObject.SetActive(!string.IsNullOrWhiteSpace(_historyLabel.text));
        }
        
        public void SetInput(string input)
        {
            _inputField.text = input;
        }

        [SerializeField] private RectTransform _modal;

        private void OnCalculateButtonClicked()
        {
            var input = _inputField.text;
            CalculateButtonClicked(input);
        }

        private void OnInputFieldValueChanged(string value)
        {
            InputFieldValueChanged(value);
        }
    }
}