using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task12
{
    class Program
    {

        static double[] pol1;
        static double[] pol2;

        static void Main(string[] args)
        {
            // Task 12: Extend the program to support also subtraction and multiplication of polynomials.

            Init();

            double[] pol3 = SumPolynomials(pol1, pol2);
            PrintSum(pol3);

            Console.WriteLine();

            pol3 = SubtractPolynomials(pol1, pol2);
            PrintSubtr(pol3);

            Console.WriteLine();

            pol3 = MultiplyPolynomials(pol1, pol2);
            PrintProduct(pol3);
        }

        static void Init()
        {
            Console.Write("Enter term count of polynomial 1: ");
            int term1 = int.Parse(Console.ReadLine());
            Console.Write("Enter term count of polynomial 2: ");
            int term2 = int.Parse(Console.ReadLine());

            pol1 = new double[term1];
            pol2 = new double[term2];

            for (int i = 0; i < term1; i++)
            {
                Console.Write("term {0} of polynomial 1 = ", i);
                pol1[i] = double.Parse(Console.ReadLine());
            }

            for (int i = 0; i < term2; i++)
            {
                Console.Write("term {0} of polynomial 2 = ", i);
                pol2[i] = double.Parse(Console.ReadLine());
            }
        }

        static double[] SumPolynomials(double[] pol1, double[] pol2)
        {
            int size = GetMax(pol1.Length, pol2.Length);
            double[] sum = new double[size];

            for (int i = 0; i < size; i++)
            {
                if (i < pol1.Length && i < pol2.Length)
                {
                    sum[i] = pol1[i] + pol2[i];
                }
                else if (i < pol1.Length && i >= pol2.Length)
                {
                    sum[i] = pol1[i];
                }
                else if (i >= pol1.Length && i < pol2.Length)
                {
                    sum[i] = pol2[i];
                }
            }

            return sum;
        }

        static double[] SubtractPolynomials(double[] pol1, double[] pol2)
        {
            int size = GetMax(pol1.Length, pol2.Length);
            double[] subtr = new double[size];

            for (int i = 0; i < size; i++)
            {
                if (i < pol1.Length && i < pol2.Length)
                {
                    subtr[i] = pol1[i] - pol2[i];
                }
                else if (i < pol1.Length && i >= pol2.Length)
                {
                    subtr[i] = pol1[i];
                }
                else if (i >= pol1.Length && i < pol2.Length)
                {
                    subtr[i] = -pol2[i];
                }
            }

            return subtr;
        }

        static double[] MultiplyPolynomials(double[] pol1, double[] pol2)
        {
            int size = pol1.Length + pol2.Length - 1;
            double[] product = new double[size];

            for (int i = 0; i < pol1.Length; i++)
            {
                for (int j = 0; j < pol2.Length; j++)
                {
                    product[j + i] += pol1[i] * pol2[j];
                }
            }

            return product;
        }

        static int GetMax(int a, int b)
        {
            return a > b ? a : b;
        }

        static void Print(double[] pol)
        {
            for (int i = pol.Length - 1; i >= 0; i--)
            {
                if (!(pol[i] == 0))
                {
                    if (i == 0)
                    {
                        Console.Write(pol[0]);
                    }
                    else if (i == 1)
                    {
                        Console.Write("{0}*x + ", pol[i]);
                    }
                    else
                    {
                        Console.Write("{0}*x^{1} + ", pol[i], i);
                    }
                }
            }
            Console.WriteLine();
        }

        static void PrintSum(double[] pol3)
        {
            Print(pol1);
            Console.WriteLine("+");
            Print(pol2);
            Console.WriteLine("-----------");
            Print(pol3);
        }

        private static void PrintSubtr(double[] pol3)
        {
            Print(pol1);
            Console.WriteLine("-");
            Print(pol2);
            Console.WriteLine("-----------");
            Print(pol3);
        }

        private static void PrintProduct(double[] pol3)
        {
            Print(pol1);
            Console.WriteLine("*");
            Print(pol2);
            Console.WriteLine("-----------");
            Print(pol3);
        }
    }
}
