using System;
//using System.Diagnostics;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture =
                System.Globalization.CultureInfo.InvariantCulture;
            //Stopwatch sw = new Stopwatch(); 
            string input = Console.ReadLine();
            //sw.Start();
            double x = double.Parse(input);
            //sw.Stop();
            input = Console.ReadLine();
            //sw.Start();
            double y = double.Parse(input);
            int result;
            if (x == 0 && y == 0)
            {
                result = 0;
                Console.WriteLine(result);
            }
            else if (x == 0 && y != 0)
            {
                result = 5;
                Console.WriteLine(result);
            }
            else if (x != 0 && y == 0)
            {
                result = 6;
                Console.WriteLine(result);
            }
            else if (x > 0 && y > 0)
            {
                result = 1;
                Console.WriteLine(result);
            }
            else if (x > 0 && y < 0)
            {
                result = 4;
                Console.WriteLine(result);
            }
            else if (x < 0 && y < 0)
            {
                result = 3;
                Console.WriteLine(result);
            }
            else if (x < 0 && y > 0)
            {
                result = 2;
                Console.WriteLine(result);
            }
            //sw.Stop();
            //long memoryUsed = Process.GetCurrentProcess().PeakWorkingSet64;
            //Console.WriteLine("time elapsed = {0}, memory used = {1}" ,sw.Elapsed, memoryUsed);
        }
    }
}