using System;
using System.Collections.Generic;
using System.IO;

namespace Task6SortStrings
{
    class Program
    {
        const string INPUT = @"..\..\strings.txt";
        const string OUTPUT = @"..\..\output.txt";

        static void Main(string[] args)
        {
            // Task 6: Write a program that reads a text
            // file containing a list of strings, sorts 
            // them and saves them to another text file.

            List<string> lines = new List<string>();
            using (StreamReader reader = new StreamReader(INPUT))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    lines.Add(line);
                    line = reader.ReadLine();
                }
            }

            string[] strArray = lines.ToArray();
            Array.Sort(strArray);

            using (StreamWriter writer = new StreamWriter(OUTPUT))
            {
                for (int line = 0; line < strArray.Length; line++)
                {
                    writer.WriteLine(strArray[line]);
                }
            }
        }
    }
}
