namespace CalculusMethodsLab1.Lab_1
{
    class SimpleIterationsMethod
    {
        public double xk;
        public double xkPlus1;
        public double Func(double x)
        {
            return Math.Exp(Math.Sin(x) + Math.Cos(x) + 1) - 3 * Math.Log(x);
        }

        public double dFunc(double x)
        {
            double sinx = Math.Sin(x);
            double cosx = Math.Cos(x);

            return Math.Exp(sinx + cosx + 1) * (cosx - sinx) - 3 / x;
        }

        public double Fi(double x)
        {
            return x - 0.2058 * -Func(x);
        }

        public double FindFoot1(double low, double high, double epsilon)
        {
            if (Func(low) * Func(high) > 0)
                throw new Exception("Function is not monotone or root does not exist in this range");

            xk = low;
            xkPlus1 = Fi(xk);
            Console.WriteLine("{0}\n{1}", xk, xkPlus1);

            while (Math.Abs(xkPlus1 - xk) > epsilon)
            {
                xk = xkPlus1;
                xkPlus1 = Fi(xk);
                Console.WriteLine(xkPlus1);
            }

            return xkPlus1;
        }

        public double Fi2(double x)
        {
            return x - 0.206932 * Func(x);
        }

        public double FindFoot2(double low, double high, double epsilon)
        {
            if (Func(low) * Func(high) > 0)
                throw new Exception("Function is not monotone or root does not exist in this range");

            xk = low;
            xkPlus1 = Fi2(xk);
            Console.WriteLine("{0}\n{1}", xk, xkPlus1);

            while (Math.Abs(xkPlus1 - xk) > epsilon)
            {
                xk = xkPlus1;
                xkPlus1 = Fi2(xk);
                Console.WriteLine(xkPlus1);
            }

            return xkPlus1;
        }

        public double Fi3(double x)
        {
            return x - 0.22923 * -Func(x);
        }

        public double FindFoot3(double low, double high, double epsilon)
        {
            if (Func(low) * Func(high) > 0)
                throw new Exception("Function is not monotone or root does not exist in this range");

            xk = low;
            xkPlus1 = Fi3(xk);

            while (Math.Abs(xkPlus1 - xk) > epsilon)
            {
                xk = xkPlus1;
                xkPlus1 = Fi3(xk);
            }

            return xkPlus1;
        }
    }
}
