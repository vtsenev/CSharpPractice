using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Task7ReplaceSubString
{
    class Program
    {
        const string INPUT = @"..\..\text.txt";
        const string TESTFILE = @"..\..\bigfile.txt";

        static void Main(string[] args)
        {
            // Task 7: Write a program that replaces all occurrences
            // of the substring "start" with the substring "finish"
            // in a text file. Ensure it will work with large files (e.g. 100 MB).

            GenerateBigFile();

            List<string> lines = new List<string>();
            using (StreamReader reader = new StreamReader(TESTFILE))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    line = line.Replace("start", "finish");
                    lines.Add(line);
                    line = reader.ReadLine();
                }
            }

            using (StreamWriter writer = new StreamWriter(TESTFILE))
            {
                for (int i = 0; i < lines.Count; i++)
                {
                    writer.WriteLine(lines[i]);
                    if (i % 1000 == 0)
                    {
                        writer.Flush();
                    }
                }
            }
        }

        static void GenerateBigFile()
        {
            string text;
            using (StreamReader reader = new StreamReader(INPUT))
            {
                text = reader.ReadToEnd();
            }

            using (StreamWriter writer = new StreamWriter(TESTFILE))
            {
                for (int i = 0; i < 100000; i++)
                {
                    writer.WriteLine(text);
                    if (i % 1000 == 0)
                    {
                        writer.Flush();
                    }
                }
            }
        }
    }
}
