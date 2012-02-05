using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Task1CleanCode
{
    class Program
    {
        const string INPUT = @"..\..\test.009.in.txt";
        static List<string> code = new List<string>();
        static int currentState = 0;
        static Dictionary<String, int>[] rulez = new Dictionary<string, int>[5];
        static int startCol, endCol, startRow, endRow;

        static void Main(string[] args)
        {
            Input();
            //InputFile();
            Init();
            CleanUp();
            RemoveEmptyLines();
        }

        static void Init()
        {
            for (int i = 0; i < 5; i++)
            {
                rulez[i] = new Dictionary<string, int>();
            }
            startCol = 0;
            startRow = 0;
            endCol = 0;
            endRow = 0;

            // state 0 - normal code
            // state 1 - multiline string
            // state 2 - one line comment (// ..)
            // state 3 - normal one line string
            // state 4 - multiline comment (/* ... */)
            string[] alphabet = { "\"", "//", "@\\\"", "/*" };
            rulez[0].Add(alphabet[2], 1);
            rulez[0].Add(alphabet[1], 2);
            rulez[0].Add(alphabet[0], 3);
            rulez[0].Add(alphabet[3], 4);

            rulez[1].Add("\"", 0);

            rulez[2].Add('\n'.ToString(), 0);

            rulez[3].Add("\\\\\"", 0);
            rulez[3].Add("\"", 0); // fix

            rulez[4].Add("*/", 0);
        }

        static void Input()
        {
            int n = int.Parse(Console.ReadLine());
            for (int lineNum = 0; lineNum < n; lineNum++)
            {
                string line = Console.ReadLine();
                code.Add(line);
            }
        }

        static void InputFile()
        {
            using (StreamReader reader = new StreamReader(INPUT))
            {
                int n = int.Parse(reader.ReadLine());
                for (int lineNum = 0; lineNum < n; lineNum++)
                {
                    string line = reader.ReadLine();
                    code.Add(line);
                }
            }
        }

        static void CleanUp()
        {
            string result = string.Empty;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < code.Count; i++)
            {
                string line = code[i];
                for (int j = 0; j < line.Length; j++)
                {
                    string current = line[j].ToString();
                    string next = string.Empty;
                    if (j + 1 < line.Length)
                    {
                        next = line[j + 1].ToString();
                    }
                    next = current + next;

                    if (next == @"@\")
                    {
                        if (j + 2 < line.Length)
                        {
                            next += line[j + 2].ToString();
                        }
                    }

                    if (j == line.Length - 1 && currentState == 2)
                    {
                        int nextState = 0;
                        if (startCol - 1 >= 0)
                        {
                            if (line[startCol - 1] == ' ')
                            {
                                line = line.Remove(startCol - 1);
                            }
                            else
                            {
                                line = line.Remove(startCol);
                            }
                        }
                        else
                        {
                            line = line.Remove(0);
                        }
                        code[i] = line;
                        currentState = nextState;
                        continue;
                    }

                    Dictionary<string, int> regulations = rulez[currentState];

                    if (regulations.ContainsKey(current))
                    {
                        int nextState = rulez[currentState][current];
                        if (currentState == 0 && nextState == 2)
                        {
                            startCol = j;
                        }
                        currentState = nextState;
                    }
                    else if (regulations.ContainsKey(next))
                    {
                        int nextState = rulez[currentState][next];
                        if (currentState == 0 && nextState == 2)
                        {
                            startCol = j;
                        }
                        else if (currentState == 0 && nextState == 4)
                        {
                            startRow = i;
                            startCol = j;
                        }
                        else if (currentState == 4 && nextState == 0)
                        {
                            endCol = j + 2;
                            endRow = i;
                            if (startRow == endRow)
                            {
                                string alteredLine = string.Empty;
                                if (startCol >= 0)
                                {
                                    try
                                    {
                                        alteredLine = code[startRow].Remove(startCol, endCol - startCol);
                                    }
                                    catch (ArgumentOutOfRangeException e)
                                    {
                                        alteredLine = string.Empty;
                                    }
                                }
                                else
                                {
                                    alteredLine = code[startRow].Remove(0, endCol);
                                }
                                code[startRow] = alteredLine;
                            }
                            else
                            {
                                string startLine;
                                if (startCol >= 0)
                                {
                                    startLine = code[startRow].Remove(startCol);
                                }
                                else
                                {
                                    startLine = code[startRow].Remove(0);
                                }
                                string endLine = code[endRow].Remove(0, endCol);
                                startLine += endLine;
                                code[startRow] = startLine;
                                int linesToDelete = endRow - startRow;
                                for (int l = 0; l < linesToDelete; l++)
                                {
                                    code.RemoveAt(startRow + 1);
                                }
                                i -= linesToDelete;
                            }
                        }
                        currentState = nextState;
                    }
                }
            }
        }

        static void RemoveEmptyLines()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string item in code)
            {
                sb.AppendLine(item);
            }
            StringReader sr = new StringReader(sb.ToString());
            string line = null;
            while ((line = sr.ReadLine()) != null)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}
