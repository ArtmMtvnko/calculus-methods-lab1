// See https://aka.ms/new-console-template for more information
using System.Numerics;
using CalculusMethodsLab1.Lab_1;

Console.WriteLine("Hello, World!");

//Bisection bisection = new Bisection();
//Console.WriteLine("1) {0}", bisection.FindRoot(-3, -2.5, 0.0000001));
//Console.WriteLine("2) {0}", bisection.FindRoot(-2.5, -2, 0.0000001));
//Console.WriteLine("3) {0}", bisection.FindRoot(-2, -1.5, 0.0000001));
//Console.WriteLine("4) {0}", bisection.FindRoot(-1.5, -1.25, 0.0000001));
//Console.WriteLine("5) {0}", bisection.FindRoot(-1.25, -1, 0.0000001));
//Console.WriteLine("6) {0}", bisection.FindRoot(1.5, 2, 0.0000001));
//Console.WriteLine("7) {0}", bisection.FindRoot(-3, 3, 0.0000001));
//Console.WriteLine("7) {0}", bisection.FindRootCustomFunc(-3, -2.5, 0.0000001, (x) =>
//{
//    return Math.Sinh(x) * Math.Sin(7 * x) - 5 * Math.Exp(x) * Math.Cos(x);
//}));



//SimplifiedNewtonMethod simplifiedNewtonMethod = new SimplifiedNewtonMethod();
//Console.WriteLine(simplifiedNewtonMethod.DoubleDerivativeFunc(2));
//Console.WriteLine("1) {0}", simplifiedNewtonMethod.FindRoot(2, 3, 0.0000001));
//Console.WriteLine("2) {0}", simplifiedNewtonMethod.FindRoot(5.5, 6.2, 0.0000001));
//Console.WriteLine("3) {0}", simplifiedNewtonMethod.FindRoot(7.9, 8.1, 0.0000001));


//SimpleIterationsMethod simpleIterationsMethod = new SimpleIterationsMethod();
//Console.WriteLine(simpleIterationsMethod.dFunc(3));
//Console.WriteLine("1) {0}", simpleIterationsMethod.FindFoot1(2, 3, 0.0000001));
//Console.WriteLine("2) {0}", simpleIterationsMethod.FindFoot2(5.5, 6.5, 0.0000001));
//Console.WriteLine("2) {0}", simpleIterationsMethod.FindFoot3(7.5, 9, 0.0000001));

LinearEquation linearEquation = new LinearEquation(new List<long>()
{
    150, 249, -661, -905, 885, 917, -290, -256
});
linearEquation.PrintPolinom();
linearEquation.Quadrature();
linearEquation.PrintIntermediatePolinom();
linearEquation.FindRoots();
linearEquation.PrintRoots();
