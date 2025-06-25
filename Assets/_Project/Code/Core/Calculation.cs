namespace Project.Core
{
    public class Calculation
    {
        public string Expression { get; }
        public string Result { get; }

        public Calculation(string expression, string result)
        {
            Expression = expression;
            Result = result;
        }
    }
}
