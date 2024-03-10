namespace CalculusMethodsLab1.Lab_1
{
    class SimplifiedNewtonMethod
    {
        public double Func(double x)
        {
            return Math.Exp(Math.Sin(x) + Math.Cos(x) + 1) - 3 * Math.Log(x);
        }

        public double DerivativeFunc(double x)
        {
            double sin = Math.Sin(x);
            double cos = Math.Cos(x);

            return Math.Exp(sin + cos + 1) * (cos - sin) - 3 / x;
        }

        public double DoubleDerivativeFunc(double x)
        {
            double exp = Math.Exp(Math.Sin(x) + Math.Cos(x) + 1);
            double sin = Math.Sin(x);
            double cos = Math.Cos(x);

            return exp * (cos - sin) * (cos - sin) + exp * (-sin - cos) + 3 / (x * x);
        }

        public double FindRoot(double low, double high, double epsilon)
        {
            if (Func(low) * Func(high) > 0)
                throw new Exception("Function is not monotone in this range");

            double a = low;
            double b = high;

            double x0;

            while (true)
            {
                bool fourierA = Func(a) * DoubleDerivativeFunc(a) > 0;
                bool fourierB = Func(b) * DoubleDerivativeFunc(b) > 0;

                if (fourierA)
                {
                    x0 = a;
                    break;
                }
                else if (fourierB)
                {
                    x0 = b;
                    break;
                }
                else
                {
                    throw new Exception("Range does not match to Fourier condition, specify range around root");
                }
            }

            double dF_x0 = DerivativeFunc(x0);

            double xk = x0 - Func(x0) / dF_x0;
            double xkPlus1 = xk - Func(xk) / dF_x0;
            
            while (Math.Abs(Func(xkPlus1)) > epsilon)
            {
                xk = xkPlus1;
                xkPlus1 = xk - Func(xk) / dF_x0;
            }

            return xkPlus1;
        }
    }
}
