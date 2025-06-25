using Project.Core;
using Project.UI;
using UnityEngine;

namespace Project.Runtime
{
    public class Runner : MonoBehaviour
    {
        private const string HISTORY_FILENAME = "history.json";
        [SerializeField] private CalculatorView _calculatorView;
        [SerializeField, Range(30, 144)] private int _targetFramerate = 120;
        private CalculatorPresenter _calculatorPresenter;

        private void Awake()
        {
            CalculationHistory history = new($"{Application.persistentDataPath}/{HISTORY_FILENAME}");
            _calculatorPresenter = new(new Calculator(), history, _calculatorView);

            Application.targetFrameRate = _targetFramerate;
        }

        private void OnDestroy()
        {
            _calculatorPresenter.Dispose();
        }
    }
}
