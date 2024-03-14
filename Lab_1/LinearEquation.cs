using System.Globalization;
using System.Numerics;
using Singulink.Numerics;

namespace CalculusMethodsLab1.Lab_1
{
    class LinearEquation
    {
        List<double> _coefficients;
        List<double> _intermediateCoefficients = new List<double>();
        List<double> _modifiedCoefficients = new List<double>();

        double[] _roots;

        int quadratureCounter = 0;

        public LinearEquation(List<double> coefficients)
        {
            _coefficients = coefficients;
            _coefficients.Reverse();

            double max = _coefficients.Max();

            for (int i = 0; i < _coefficients.Count; i++)
            {
                _coefficients[i] /= max;
            }

            _roots = new double[_coefficients.Count];

            double[] nums = new double[_coefficients.Count];
            _coefficients.CopyTo(nums);
            _intermediateCoefficients = nums.ToList();
            _modifiedCoefficients = nums.ToList();
        }

        public void PrintPolinom()
        {
            Console.WriteLine("\n=============== Original polynom ===============\n");
            for (int i = _coefficients.Count - 1; i >= 0; i--)
            {
                Console.Write($"{_coefficients[i]}x^{i} ");
                if (i > 0) Console.Write("+ ");
            }
            Console.WriteLine("= 0");
            Console.WriteLine("\n=============== Original polynom END ===============\n");
        }

        public void PrintIntermediatePolinom()
        {
            Console.WriteLine("\n=============== Intermediate polynom ===============\n");
            for (int i = _modifiedCoefficients.Count - 1; i >= 0; i--)
            {
                Console.Write($"{_modifiedCoefficients[i]}x^{i} ");
                if (i > 0) Console.Write("+ ");
            }
            Console.WriteLine("= 0");
            Console.WriteLine("\n=============== Intermediate polynom END ===============\n");
        }

        public void PrintRoots()
        {
            Console.WriteLine("\n=============== Roots ===============\n");
            // First root (cell in array) = 0, because x^0 = 1
            foreach (double root in _roots)
            {
                Console.WriteLine(root);
            }
            Console.WriteLine("\n=============== Roots END ===============\n");
        }

        public void Quadrature()
        {
            double b_k = 0;
            double a_k = 0;
            double sum = 0;
            PullIntermediateCoefficients();

            for (int k = 0; k < _coefficients.Count; k++)
            {
                a_k = _intermediateCoefficients[k];
                sum = 0;

                for (int j = 1; j <= _coefficients.Count - k; j++)
                {
                    if (k - j < 0 || k + j > _coefficients.Count - 1) break;
                    sum += 
                        _intermediateCoefficients[k-j] *
                        _intermediateCoefficients[k+j] * 
                        (int)Math.Pow((-1), j);
                }

                b_k = a_k * a_k + 2 * sum;
                Console.WriteLine(b_k);
                _modifiedCoefficients[k] = b_k;
            }
            quadratureCounter++;
        }

        private void PullIntermediateCoefficients()
        {
            for (int i = 0; i < _coefficients.Count; i++)
            {
                _intermediateCoefficients[i] = _modifiedCoefficients[i];
            }
        }

        public void FindRoots()
        {
            double x_k = 0;

            for (int k = 1; k < _modifiedCoefficients.Count; k++)
            {
                double expression =
                    (
                    _modifiedCoefficients[_modifiedCoefficients.Count - 1 - k] /
                    _modifiedCoefficients[_modifiedCoefficients.Count - 1 - k + 1]
                    );

                x_k = Math.Pow(expression, (1 / Math.Pow(2, quadratureCounter)));

                if (Math.Abs(CheckRoot(x_k)) > Math.Abs(CheckRoot(-x_k)))
                {
                    x_k = -x_k;
                }

                //if (BigDecimalAbs(CheckRoot(x_k)) > BigDecimalAbs(CheckRoot(-x_k)))
                //{
                //    x_k = -x_k;
                //}

                _roots[k] = x_k;
                //Console.WriteLine(x_k);
            }
        }

        private double CheckRoot(double x)
        {
            double sum = 0;

            for (int k = 0; k < _coefficients.Count; k++)
            {
                sum += _coefficients[k] * Math.Pow(x, k);
            }

            return sum;
        }

        public void Solve(double epsilon)
        {
            while (SecondNorma() > epsilon)
            {
                Quadrature();
                FindRoots();
            }

            PrintRoots();
        }

        private double SecondNorma()
        {
            double sum = 0;

            for (int k = 0; k < _modifiedCoefficients.Count; k++)
            {
                sum += 
                    (_modifiedCoefficients[k] - _intermediateCoefficients[k] * _intermediateCoefficients[k]) *
                    (_modifiedCoefficients[k] - _intermediateCoefficients[k] * _intermediateCoefficients[k]);
            }

            sum = Math.Sqrt(sum);

            Console.WriteLine(sum);
            Console.WriteLine(sum < 0.0000001);

            return sum;
        }

        //private BigDecimal BigDecimalAbs (BigDecimal x)
        //{
        //    if (x < 0) return -x;
        //    return x;
        //}
    }
}
