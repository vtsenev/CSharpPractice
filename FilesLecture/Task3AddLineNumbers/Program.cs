using System;
using System.IO;
using System.Collections.Generic;

namespace Task3AddLineNumbers
{
    class Program
    {
        const string INPUTFILE = @"..\..\sample_file.txt";
        const string OUTPUTFILE = @"..\..\output.txt";

        static void Main(string[] args)
        {
            // Task 3: Write a program that reads a text file and
            // inserts line numbers in front of each of its lines.
            // The result should be written to another text file.

            List<string> lines = new List<string>();
            using (StreamReader reader = new StreamReader(INPUTFILE))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    lines.Add(line);
                    line = reader.ReadLine();
                }
            }

            using (StreamWriter writer = new StreamWriter(OUTPUTFILE))
            {
                for (int lineNumber = 0; lineNumber < lines.Count; lineNumber++)
                {
                    string line = (lineNumber + 1).ToString() + " " + lines[lineNumber];
                    writer.WriteLine(line);
                }
                writer.Flush();
            }

        }
    }
}
