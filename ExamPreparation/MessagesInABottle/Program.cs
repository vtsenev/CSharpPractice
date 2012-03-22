using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessagesInABottle
{
    class Program
    {
        private static string secretMessage;
        private static Dictionary<string, char> dict = new Dictionary<string, char>();
        private static char[] currentTranslation = new char[180];
        private static List<string> solutions = new List<string>();

        static void Main(string[] args)
        {
            InputAndInit();
            SolveWithRecursion(0, 0);
            PrintResult();
        }

        static void InputAndInit()
        {
            secretMessage = Console.ReadLine();
            string cypher = Console.ReadLine();

            char letter = cypher[0];
            StringBuilder sb = new StringBuilder();
            for (int cypherIndex = 0; cypherIndex < cypher.Length; cypherIndex++)
            {      
                if (char.IsLetter(cypher[cypherIndex]))
                {
                    if (sb.Length > 0 && char.IsLetter(letter))
                    {
                        dict[sb.ToString()] = letter;
                        sb = new StringBuilder();
                    }
                    letter = cypher[cypherIndex];
                }
                else
                {
                    sb.Append(cypher[cypherIndex]);
                }
            }
            dict[sb.ToString()] = letter;
        }

        static void SolveWithRecursion(int charIndex, int wordIndex)
        {
            if (charIndex == secretMessage.Length)
            {
                AddSolution(currentTranslation);
                return;
            }
            if (charIndex > secretMessage.Length)
            {
                return;
            }
            foreach (var code in dict.Keys)
            {
                if (secretMessage.Length >= charIndex + code.Length && secretMessage.Substring(charIndex, code.Length) == code)
                {
                    currentTranslation[charIndex] = dict[code];
                    SolveWithRecursion(charIndex + code.Length, wordIndex + 1);
                    currentTranslation[charIndex] = '0';
                }
            }
        }

        static void AddSolution(char[] solution)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in solution)
            {
                if (char.IsLetter(c))
                {
                    sb.Append(c);
                }
            }
            solutions.Add(sb.ToString());
        }

        static void PrintResult()
        {
            solutions.Sort();
            Console.WriteLine(solutions.Count);
            foreach (string solution in solutions)
            {
                Console.WriteLine(solution);
            }
        }
    }
}
