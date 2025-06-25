using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.UI
{
    public class PopupUIScreen : MonoBehaviour
    {
        [SerializeField] private Button _confirmBtn;
        [SerializeField] private TextMeshProUGUI _message;

        public event Action ConfirmButtonClicked;

        public void DisplayMessage(string message)
        {
            _message.text = message;
            _message.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _message.preferredHeight);
        }

        public void SetVisible(bool isVisible)
            => gameObject.SetActive(isVisible);

        private void OnEnable()
            => _confirmBtn.onClick.AddListener(OnConfirmButtonClicked);

        private void OnConfirmButtonClicked() 
            => ConfirmButtonClicked?.Invoke();

        private void OnDisable()
            => _confirmBtn.onClick.AddListener(OnConfirmButtonClicked);
    }
}
