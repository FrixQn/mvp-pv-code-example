using Project.Core;
using Project.UI;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Runtime
{
    public class CalculatorPresenter : IDisposable
    {
        private const string POPUP_ERROR_MESSAGE = "Please check the expression you just entered";
        private const string ERROR_RESULT = "ERROR";

        private readonly ICalculatorView _view;
        private readonly ICalculator _calculator;
        private readonly ICalculationHistory _calculationHistory;

        public CalculatorPresenter(ICalculator calculator, ICalculationHistory history, ICalculatorView view)
        {
            _calculator = calculator;
            _calculationHistory = history;
            _view = view;


            _view.ShowCalculator();
            _view.DisplayInput(_calculationHistory.GetInput());
            DisplayHistory();

            Application.focusChanged += OnFocusChanged;
            _view.CalculateButtonClicked += OnCalculateButtonClicked;
            _view.PopupConfirmButtonClicked += OnPopupConfirmButtonClicked;
        }

        private void OnFocusChanged(bool isFocused)
        {
            if (!isFocused)
                _calculationHistory.SetInput(_view.GetInput());
        }

        private void OnPopupConfirmButtonClicked()
            => _view.ShowCalculator();

        private void OnCalculateButtonClicked()
        {
            string expression = _view.GetInput();
            if (string.IsNullOrEmpty(expression))
                return;

            string stringResult = ERROR_RESULT;
            if (!_calculator.TryCalculate(expression, out float result))
                _view.ShowMessagePopup(POPUP_ERROR_MESSAGE);
            else
                stringResult = result.ToString();

            _calculationHistory.Add(new Calculation(expression, stringResult));
            _view.DisplayInput(string.Empty);
            DisplayHistory();
        }

        private void DisplayHistory()
        {
            List<string> historyStr = new();
            foreach (var line in _calculationHistory)
                historyStr.Insert(0, $"{line.Expression}={line.Result}");

            _view.DisplayHistory(historyStr.ToArray());
        }

        public void Dispose()
        {
            Application.focusChanged -= OnFocusChanged;
            _view.CalculateButtonClicked -= OnCalculateButtonClicked;
            _view.PopupConfirmButtonClicked -= OnPopupConfirmButtonClicked;
        }
    }
}
