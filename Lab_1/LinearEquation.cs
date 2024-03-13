namespace CalculusMethodsLab1.Lab_1
{
    class LinearEquation
    {
        List<long> _coefficients;
        public LinearEquation(List<long> coefficients)
        {
            _coefficients = coefficients;
            _coefficients.Reverse();
        }

        public void PrintPolinom()
        {
            for (int i = _coefficients.Count - 1; i >= 0; i--)
            {
                Console.Write($"{_coefficients[i]}x^{i} ");
                if (i > 0) Console.Write("+ ");
            }
            Console.WriteLine("= 0");
        }
    }
}
