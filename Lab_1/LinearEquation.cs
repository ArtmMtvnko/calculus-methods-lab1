namespace CalculusMethodsLab1.Lab_1
{
    class LinearEquation
    {
        List<long> _coefficients;
        List<long> _modifiedCoefficients = new List<long>();
        public LinearEquation(List<long> coefficients)
        {
            _coefficients = coefficients;
            _coefficients.Reverse();

            long[] nums = new long[_coefficients.Count];

            _coefficients.CopyTo(nums);

            _modifiedCoefficients = nums.ToList();
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

        public void PrintIntermediatePolinom()
        {
            for (int i = _modifiedCoefficients.Count - 1; i >= 0; i--)
            {
                Console.Write($"{_modifiedCoefficients[i]}x^{i} ");
                if (i > 0) Console.Write("+ ");
            }
            Console.WriteLine("= 0");
        }

        public void Quadrature()
        {
            long b_k = 0;
            long a_k = 0;

            long sum = 0;

            for (int k = 0; k < _coefficients.Count; k++)
            {
                a_k = _coefficients[k];
                sum = 0;

                for (int j = 1; j <= _coefficients.Count - k; j++)
                {
                    if (k - j < 0 || k + j > _coefficients.Count - 1) break;
                    sum += _coefficients[k-j] * _coefficients[k+j] * (int)Math.Pow((-1), j);
                }

                b_k = a_k * a_k + 2 * sum;
                Console.WriteLine(b_k);
                _modifiedCoefficients[k] = b_k;
            }

        }
    }
}
