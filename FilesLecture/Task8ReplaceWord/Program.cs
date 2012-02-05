using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Task8ReplaceWord
{
    class Program
    {
        const string INPUT = @"..\..\text.txt";

        static void Main(string[] args)
        {
            // Task 8: Modify the solution of the previous
            // problem to replace only whole words (not substrings).

            List<string> lines = new List<string>();
            using (StreamReader reader = new StreamReader(INPUT))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string word = "start";
                    ////string pattern = @"\b(?'word')\b";
                    string replace = "finish";
                    //line = Regex.Replace(line, word, replace, RegexOptions.IgnoreCase);
                    ////line = ReplaceString(line, "start", "finish", StringComparison.OrdinalIgnoreCase);
                    //lines.Add(line);
                    //line = reader.ReadLine();
                    
                }
            }

            using (StreamWriter writer = new StreamWriter(INPUT))
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
    }
}
