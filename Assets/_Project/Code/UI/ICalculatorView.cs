using System;

namespace Project.UI
{
    public interface ICalculatorView
    {
        public event Action CalculateButtonClicked;
        public event Action PopupConfirmButtonClicked;

        public void ShowCalculator();
        public void DisplayInput(string input);
        public void DisplayHistory(string[] history);
        public string GetInput();
        public void ShowMessagePopup(string message);
    }
}
