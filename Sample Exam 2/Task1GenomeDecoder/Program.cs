using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Task1GenomeDecoder
{
    class Program
    {
        static int m, n;
        static string genome;
        const string INPUT = @"..\..\input.txt";
        const string OUTPUT = @"..\..\out.txt";
        const string OUT2 = @"..\..\out2.txt";
        static StringBuilder seq = new StringBuilder();

        static void Main(string[] args)
        {
            //CreateTest();
            Input();
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //InputFile();

            Decode();

            Print();
            //PrintFile();
            //sw.Stop();
            //Console.WriteLine(sw.ElapsedMilliseconds);
        }

        static void CreateTest()
        {
            Random r = new Random();

            using (StreamWriter sw = new StreamWriter(OUTPUT))
            {
                for (int i = 0; i < 20000; i++)
                {
                    int num = r.Next(1, 10);
                    int letter = r.Next(0, 3);
                    sw.Write(num + LETTERS[letter].ToString());
                }
            }
        }

        static void PrintFile()
        {
            using (StreamWriter writer = new StreamWriter(OUT2))
            {
                genome = seq.ToString();
                int linesCount = 0;
                if (genome.Length % n == 0)
                {
                    linesCount = genome.Length / n;
                }
                else
                {
                    linesCount = genome.Length / n + 1;
                }

                for (int lineNum = 1; lineNum <= linesCount; lineNum++)
                {
                    int indent = 1;
                    int linesDigits = linesCount;
                    while (linesDigits / 10 > 0)
                    {
                        linesDigits /= 10;
                        indent++;
                    }
                    writer.Write("{0, " + indent + "} ", lineNum);

                    string line = string.Empty;
                    if (lineNum == linesCount && (lineNum - 1) * n + n > genome.Length)
                    {
                        line = genome.Substring((lineNum - 1) * n);
                    }
                    else
                    {
                        line = genome.Substring((lineNum - 1) * n, n);
                    }

                    int subStrLength = 0;
                    if (line.Length % m == 0)
                    {
                        subStrLength = line.Length / m;
                    }
                    else
                    {
                        subStrLength = line.Length / m + 1;
                    }

                    for (int subStrNum = 1; subStrNum <= subStrLength; subStrNum++)
                    {
                        string subString = string.Empty;
                        if (subStrNum == subStrLength && ((subStrNum - 1) * m) + m > line.Length)
                        {
                            subString = line.Substring((subStrNum - 1) * m);
                        }
                        else
                        {
                            subString = line.Substring((subStrNum - 1) * m, m);
                        }

                        writer.Write(subString);
                        if (subStrNum == subStrLength)
                        {
                            writer.WriteLine();
                        }
                        else
                        {
                            writer.Write(" ");
                        }
                    }
                }
            }
        }

        static void Decode()
        {
            StringBuilder number = new StringBuilder();
            for (int i = 0; i < genome.Length; i++)
            {       
                if ((genome[i] > 64) && i - 1 >= 0 && (genome[i - 1] > 64))
                {
                    seq.Append(genome[i]);
                }
                else if ((genome[i] > 64) && i == 0)
                {
                    seq.Append(genome[i]);
                }
                else if (!(genome[i] > 64) && i + 1 < genome.Length && !(genome[i + 1] > 64))
                {
                    number.Append(genome[i]);
                }
                else if (!(genome[i] > 64) && i + 1 < genome.Length && (genome[i + 1] > 64))
                {
                    number.Append(genome[i]);
                    int prefix = int.Parse(number.ToString());
                    seq.Append(new string(genome[i + 1], prefix));
                    number.Clear();
                }
                else if ((genome[i] > 64) && i - 1 >= genome.Length && !(genome[i - 1] > 64))
                {
                    continue;
                }
            }
        }

        static void Print()
        {
            genome = seq.ToString();
            int linesCount = 0;
            if (genome.Length % n == 0)
            {
                linesCount = genome.Length / n;
            }
            else
            {
                linesCount = genome.Length / n + 1;
            }

            for (int lineNum = 1; lineNum <= linesCount; lineNum++)
            {
                int indent = 1;
                int linesDigits = linesCount;
                while (linesDigits / 10 > 0)
                {
                    linesDigits /= 10;
                    indent++;
                }
                Console.Write("{0, " + indent + "} ", lineNum);

                string line = string.Empty;
                if (lineNum == linesCount && (lineNum - 1) * n + n > genome.Length)
                {
                    line = genome.Substring((lineNum - 1) * n);
                }
                else
                {
                    line = genome.Substring((lineNum - 1) * n, n);
                }

                int subStrLength = 0;
                if (line.Length % m == 0)
                {
                    subStrLength = line.Length / m;
                }
                else
                {
                    subStrLength = line.Length / m + 1;
                }

                for (int subStrNum = 1; subStrNum <= subStrLength; subStrNum++)
                {
                    string subString = string.Empty;
                    if (subStrNum == subStrLength && ((subStrNum - 1) * m) + m > line.Length)
                    {
                        subString = line.Substring((subStrNum - 1) * m);
                    }
                    else
                    {
                        subString = line.Substring((subStrNum - 1) * m, m);
                    }

                    Console.Write(subString);
                    if (subStrNum == subStrLength)
                    {
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
            }
        }

        static void Input()
        {
            string input = Console.ReadLine();
            string[] line = input.Split(' ');
            n = int.Parse(line[0]);
            m = int.Parse(line[1]);
            genome = Console.ReadLine();
        }

        static void InputFile()
        {
            using (StreamReader reader = new StreamReader(INPUT))
            {
                string input = reader.ReadLine();
                string[] line = input.Split(' ');
                n = int.Parse(line[0]);
                m = int.Parse(line[1]);
                genome = reader.ReadLine();
            }
        }
    }
}
