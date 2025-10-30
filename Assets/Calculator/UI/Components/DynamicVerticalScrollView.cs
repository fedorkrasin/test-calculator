using UnityEngine;
using UnityEngine.UI;

namespace Calculator.UI.Components
{
    public class DynamicVerticalScrollView : MonoBehaviour
    {
        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField] private LayoutElement _layoutElement;
        [SerializeField] private RectTransform _content;
        [SerializeField] private Scrollbar _scrollbar;
        [SerializeField] private float _maxHeight;

        public void UpdateHeight()
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(_content);
            
            var contentHeight = _content.sizeDelta.y;
            var isScrolling = contentHeight > _maxHeight;
            
            _layoutElement.preferredHeight = Mathf.Min(contentHeight, _maxHeight);
            
            Canvas.ForceUpdateCanvases();
            
            _scrollRect.vertical = isScrolling;
            _scrollbar.gameObject.SetActive(isScrolling);
            _scrollRect.verticalScrollbar = isScrolling ? _scrollbar : null;
        }
    }
}