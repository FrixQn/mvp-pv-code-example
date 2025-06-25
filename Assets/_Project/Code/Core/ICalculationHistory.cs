using System.Collections.Generic;

namespace Project.Core
{
    public interface ICalculationHistory : IEnumerable<Calculation>
    {
        void Add(Calculation calculation);
        void SetInput(string lastInput);
        string GetInput();
    }
}
