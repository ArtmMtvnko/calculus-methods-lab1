using System.Xml.Resolvers;

namespace CalculusMethodsLab1.Lab_1
{
    public delegate double Function(double x);
    class Bisection
    {
        private double a = 0;
        private double b = 0;
        private double c = 0;
        private double f_c = 0;

        public double A => a;
        public double B => b;
        public double C => c;
        public double F_c => f_c;

        public int Test { get; set; } = 10;

        public double Func(double x)
        {
            return Math.Sinh(x) * Math.Sin(7 * x) - 5 * Math.Exp(x) * Math.Cos(x);
        }

        public double FindRoot(double low, double high, double epsilon)
        {
            a = low;
            b = high;

            if (Func(low) * Func(high) > 0) 
                throw new Exception("Function is not monotone in this range");

            while (Math.Abs(a - b) > epsilon)
            {
                c = (a + b) / 2;
                Console.WriteLine("Approximate root value: {0}", c);

                f_c = Func(c);

                if (f_c * Func(b) < 0)
                {
                    a = c;
                }
                else if (f_c * Func(a) < 0)
                {
                    b = c;
                }
                else if (f_c == 0)
                {
                    return c;
                }
            }

            return c;
        }

        public double FindRootCustomFunc(double low, double high, double epsilon, Function func)
        {
            a = low;
            b = high;

            if (func(low) * func(high) > 0)
                throw new Exception("Function is not monotone in this range");

            while (Math.Abs(a - b) > epsilon)
            {
                c = (a + b) / 2;
                Console.WriteLine("Approximate root value: {0}", c);

                f_c = func(c);

                if (f_c * func(b) < 0)
                {
                    a = c;
                }
                else if (f_c * func(a) < 0)
                {
                    b = c;
                }
            }

            return c;
        }
    }
}
