using System;
using UnityEngine;

namespace Project.UI
{
    public class CalculatorView : MonoBehaviour, ICalculatorView
    {
        [SerializeField] private MainUIScreen _mainScreen;
        [SerializeField] private PopupUIScreen _popup;

        public event Action CalculateButtonClicked;
        public event Action PopupConfirmButtonClicked;

        public void ShowCalculator()
        {
            _mainScreen.SetVisible(true);
            _popup.SetVisible(false);
        }

        public void DisplayInput(string input)
            => _mainScreen.DisplayInput(input);

        public void DisplayHistory(string[] history)
            =>  _mainScreen.DisplayHistory(history);

        public string GetInput()
            => _mainScreen.GetInput();

        public void ShowMessagePopup(string message)
        {
            _mainScreen.SetVisible(false);
            _popup.SetVisible(true);
            _popup.DisplayMessage(message);
        }

        private void OnEnable()
        {
            _popup.ConfirmButtonClicked += OnPopupConfirmed;
            _mainScreen.CalculateButtonClicked += OnCalculateButtonClicked;
        }

        private void OnCalculateButtonClicked()
            => CalculateButtonClicked?.Invoke();

        private void OnPopupConfirmed()
        { 
             _popup.SetVisible(false);
            PopupConfirmButtonClicked?.Invoke();
        }

        private void OnDisable()
        {
            _popup.ConfirmButtonClicked -= OnPopupConfirmed;
            _mainScreen.CalculateButtonClicked -= OnCalculateButtonClicked;
        }
    }
}
