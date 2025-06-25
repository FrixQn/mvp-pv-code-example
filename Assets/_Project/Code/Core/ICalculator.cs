namespace Project.Core
{
    public interface ICalculator
    {
        bool IsValid(string expression);
        public bool TryCalculate(string expression, out float result);
    }
}
