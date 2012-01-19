using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task11
{
    class Program
    {

        static double[] pol1;
        static double[] pol2;

        static void Main(string[] args)
        {
            // Task 11: Write a method that adds two polynomials.
            // Represent them as arrays of their coefficients as
            // in the example below:
		    // x^2 + 5 = 1*x^2 + 0*x + 5 -> 5 0 1

            Init();

            double[] pol3 = SumPolynomial(pol1, pol2);

            Print(pol1);
            Console.WriteLine("+");
            Print(pol2);
            Console.WriteLine("-----------");
            Print(pol3);
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

        static double[] SumPolynomial(double[] pol1, double[] pol2)
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
                    else
                    {
                        Console.Write("{0}*x^{1} + ", pol[i], i);
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
