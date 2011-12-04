using System;

namespace LeastMajorityMultiple
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[5];
            for (int i = 0; i < 5; i++)
            {
                string input = Console.ReadLine();
                numbers[i] = int.Parse(input);
            }

            int lmm = 4;
            while (true)
            {
                int counter = 0;
                for (int i = 0; i < 5; i++)
                {
                    if (lmm % numbers[i] == 0)
                    {
                        counter++;
                    }
                }
                if (counter > 2)
                {
                    break;
                }
                else
                {
                    lmm ++;
                }
            }
            Console.WriteLine(lmm);
        }
    }
}
