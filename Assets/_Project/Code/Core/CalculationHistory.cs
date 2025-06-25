using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Project.Core
{
    [JsonObject]
    public class CalculationHistory : ICalculationHistory
    {
        private readonly string _filePath;
        [JsonProperty("History")]
        private List<Calculation> _history = new ();
        [JsonProperty("LastInput")]
        private string _input = string.Empty;

        public CalculationHistory(string filePath)
        {
            _filePath = filePath;
            LoadFromStorage();
        }

        private void LoadFromStorage()
        {
            if (!File.Exists(_filePath))
                return;

            var json = File.ReadAllText(_filePath);
            var data = JsonConvert.DeserializeObject<CalculationHistory>(json);
            if (data != null)
            {
                _history.Clear();
                _history.AddRange(data._history);
                _input = data._input;
            }
        }

        public void Add(Calculation calculation)
        {
            _history.Add(calculation);
            SaveToStorage();
        }

        public void SetInput(string input)
        {
            _input = input;
            SaveToStorage();
        }

        private void SaveToStorage()
        {
            var json = JsonConvert.SerializeObject(this);
            File.WriteAllText(_filePath, json);
        }

        public string GetInput() 
            => _input;

        public IEnumerator<Calculation> GetEnumerator()
            => _history.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            =>  _history.GetEnumerator();
    }
}
