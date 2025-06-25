using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.UI
{
    public class MainUIScreen : MonoBehaviour
    {
        [SerializeField] private Button _calculate;
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private RectTransform _scrollRect;
        [SerializeField] private TextMeshProUGUI _history;
        [SerializeField, Min(0)] private float _maxScrollRectSize = 200f;

        public string GetInput()
            => _inputField.text;

        public event Action CalculateButtonClicked;

        #region EDITOR
#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_scrollRect == null)
                return;

            if (_scrollRect.TryGetComponent(out ScrollRect scroll))
                return;

            _scrollRect = null;
            Debug.LogError("Scroll rect should contains ScrollRect component.");
        }
#endif
        #endregion

        public void OnEnable()
            => _calculate.onClick.AddListener(OnCalculateButtonClicked);

        private void OnCalculateButtonClicked()
            =>  CalculateButtonClicked?.Invoke();

        public void OnDisable()
            => _calculate.onClick.RemoveAllListeners();

        public void SetVisible(bool isVisible)
            => gameObject.SetActive(isVisible);

        public void DisplayInput(string input)
            => _inputField.text = input;
    
        public void DisplayHistory(string[] history)
        {
            if (_scrollRect == null)
                return;

            bool hasHistory = history != null && history.Length > 0;
            _scrollRect.gameObject.SetActive(hasHistory);
            if (!hasHistory)
                return;

            _history.text = string.Join("\n", history);
            _history.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _history.preferredHeight);
            _history.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _history.preferredWidth);
            _scrollRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _history.preferredHeight < _maxScrollRectSize ? _history.preferredHeight : _maxScrollRectSize);
        }
    }
}
