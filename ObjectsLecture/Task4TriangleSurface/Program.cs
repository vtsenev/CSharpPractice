using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task4TriangleSurface
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 4: Write methods that calculate the surface of a triangle by given:
            // Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math.

            Console.WriteLine("To calculate the surface of a triangle press:");
            Console.WriteLine("1 - By side and altitude");
            Console.WriteLine("2 - By three sides");
            Console.WriteLine("3 - By two sides and an angle between them");

            double surface = 0;
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.D1: Console.WriteLine(); surface = CalculateSurfaceBySideAltitude(); break;
                case ConsoleKey.D2: Console.WriteLine(); surface = CalculateSurfaceByThreeSides(); break;
                case ConsoleKey.D3: Console.WriteLine(); surface = CalculateSurfaceBySidesAngle(); break;
                default: Console.WriteLine("Wrong option."); break;
            }

            Console.WriteLine("The surface is {0:0.00}.", surface);
        }

        static double CalculateSurfaceBySideAltitude()
        {
            Console.Write("side = ");
            double side = double.Parse(Console.ReadLine());

            Console.Write("altitude = ");
            double altitude = double.Parse(Console.ReadLine());

            double surface = (side * altitude) / 2.0;
            return surface;
        }

        static double CalculateSurfaceBySidesAngle()
        {
            Console.Write("side 1 = ");
            double side1 = double.Parse(Console.ReadLine());
            Console.Write("side 2 = ");
            double side2 = double.Parse(Console.ReadLine());
            Console.Write("angle between = ");
            double angle = double.Parse(Console.ReadLine());

            double surface = (side1 * side2 * Math.Sin(angle)) / 2.0;
            return surface;
        }

        static double CalculateSurfaceByThreeSides()
        {
            Console.Write("side 1 = ");
            double side1 = double.Parse(Console.ReadLine());
            Console.Write("side 2 = ");
            double side2 = double.Parse(Console.ReadLine());
            Console.Write("side 3 = ");
            double side3 = double.Parse(Console.ReadLine());

            double semiPerimeter = (side1 + side2 + side3) / 2.0;

            double surface = Math.Sqrt((semiPerimeter - side1) * (semiPerimeter - side2) * (semiPerimeter - side3));
            return surface;
        }
    }
}
