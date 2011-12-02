using System;

namespace Subset_Sums
{
    class Program
    {
        static int N;
        static long[] numbers;
        static long[] included;
        static long[] notincl;
        static long S;
        static string[] res = new string[65536];

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            S = long.Parse(input);
            input = Console.ReadLine();
            N = int.Parse(input);
            
            numbers = new long[N];
            for (byte i = 0; i < N; i++)
            {
                input = Console.ReadLine();
                numbers[i] = long.Parse(input);
            }

            for (int i = 0; i < 65535; i++)
            {
                res[i] = "";
            }

            included = new long[N];
		    notincl = new long[N];
            Calc(0, 0, "");

            int result = Array.IndexOf(res, "");
            Console.WriteLine(result);
        }

       public static int Calc(int index, long sum, String sb)
        {
            if (sum == S)
            {
                int i = Array.IndexOf(res, "");
                bool exist = false;
                for (int j = 0; j < i; j++)
                {
                    if (res[j] == sb)
                    {
                        exist = true;
                    }
                }
                if (exist == false)
                {
                    res[i] = sb;
                }
            }
            if (index == N)
            {
                return -1;
            }
            Calc(index + 1, sum + numbers[index], sb + " " + numbers[index]);
            Calc(index + 1, sum, sb);
            return 0;
        }
    }
}