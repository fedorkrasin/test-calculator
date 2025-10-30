using System;
using Calculator.Presentation.Interfaces.Views;
using MVP.Unity;
using UnityEngine;
using UnityEngine.UI;

namespace Calculator.UI.Views
{
    public class InvalidExpressionView : View, IInvalidExpressionView
    {
        [SerializeField] private Button _closeButton;

        public event Action CloseClicked = delegate { };

        public override void Initialize()
        {
            _closeButton.onClick.AddListener(OnCloseClicked);
        }

        public override void Dispose()
        {
            _closeButton.onClick.RemoveListener(OnCloseClicked);
            
            base.Dispose();
        }

        private void OnCloseClicked()
        {
            CloseClicked();
        }
    }
}