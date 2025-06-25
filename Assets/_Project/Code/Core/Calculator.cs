using System.Text.RegularExpressions;

namespace Project.Core
{
    public class Calculator : ICalculator
    {
        private static readonly Regex ValidRegex = new (@"^\d+\+\d+$");

        public bool IsValid(string expression)
            =>  ValidRegex.IsMatch(expression);

        public bool TryCalculate(string expression, out float result)
        {
            result = 0;
            if (!IsValid(expression))
                return false;

            var parts = expression.Split('+');
            float left = float.Parse(parts[0]);
            float right = float.Parse(parts[1]);
            
            float sum = left + right;
            if (float.IsInfinity(sum))
                return false;

            result = sum;
            return true;
        }
    }
}
