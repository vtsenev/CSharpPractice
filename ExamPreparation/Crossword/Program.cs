using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crossword
{
    class Program
    {
        static int N;
        static string[] words;
        static char[,] crossword;
        static char[] currentWord;
        static Dictionary<char, List<string>> letterToWords = new Dictionary<char, List<string>>();
        static Dictionary<char, List<Tuple<int, int>>> letterToCoords = new Dictionary<char, List<Tuple<int, int>>>();
        static List<char[,]> solutions = new List<char[,]>();

        static void Main(string[] args)
        {
            InputAndInit();
            CreateCrossword(0);
            Print();
        }

        static void InputAndInit()
        {
            N = int.Parse(Console.ReadLine());
            words = new string[N * 2];
            for (int i = 0; i < N * 2; i++)
            {
                string word = Console.ReadLine();
                words[i] = word;
                for (int wordIndex = 0; wordIndex < N; wordIndex++)
                {
                    char letter = word[wordIndex];
                    if (letterToWords.ContainsKey(letter))
                    {
                        if (!letterToWords[letter].Contains(word))
                        {
                            letterToWords[letter].Add(word);
                        }
                    }
                    else
                    {
                        letterToWords.Add(letter, new List<string>());
                        letterToWords[letter].Add(word);
                    }
                }
            }
            crossword = new char[N, N];
            currentWord = new char[N];
            
        }

        static void CreateCrossword(int index)
        {
            if (index >= N * 2)
            {
                return;
            }

            string firstWord = String.Empty;
            if (!char.IsLetter(crossword[0, 0]))
            {
                firstWord = words[index];
                for (int i = 0; i < N; i++)
                {
                    crossword[0, i] = firstWord[i];
                    AddLetterCoords(firstWord[i], 0, i);
                }
            }

            bool isSolutionValid = true;
            for (int i = 0; i < N; i++)
            {
                char letter = firstWord[i];
                List<string> verticalWords = letterToWords[letter];
                string verticalWord = string.Empty;
                foreach (string word in verticalWords)
                {
                    if (word[0] == letter && word != firstWord)
                    {
                        verticalWord = word;
                        break;
                    }
                }

                if (verticalWord.Length == N)
                {
                    isSolutionValid = true;
                    for (int j = 1; j < N; j++)
                    {
                        crossword[j, i] = verticalWord[j];
                    }
                }
                else
                {
                    if (firstWord[i] == firstWord[0])
                    {
                        verticalWord = firstWord;
                        isSolutionValid = true;
                        for (int j = 1; j < N; j++)
                        {
                            crossword[j, i] = verticalWord[j];
                        }
                    }
                    else
                    {
                        isSolutionValid = false;
                        break;
                    }
                }
            }
            
            for (int i = 1; i < N; i++)
            {
                char[] word = new char[N];
                for (int j = 0; j < N; j++)
                {
                    word[j] = crossword[i, j];
                }
                if (!words.ToList().Contains(new string(word)))
                {
                    isSolutionValid = false;
                    break;
                }
            }

            if (isSolutionValid)
            {
                solutions.Add(crossword);
            }

            crossword = new char[N, N];

            CreateCrossword(index + 1);
        }

        static void AddLetterCoords(char letter, int x, int y)
        {
            if (letterToCoords.ContainsKey(letter))
            {
                if (!letterToCoords[letter].Contains(new Tuple<int, int>(x, y)))
                {
                    letterToCoords[letter].Add(new Tuple<int, int>(x, y));
                }
            }
            else
            {
                letterToCoords.Add(letter, new List<Tuple<int, int>>());
                letterToCoords[letter].Add(new Tuple<int, int>(x, y));
            }
        }

        static void Print()
        {
            if (solutions.Count == 0)
            {
                Console.WriteLine("NO SOLUTION!");
                return;
            }
            string solution = FindFirstSolution();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(solution[j + (N * i)]);
                }
                Console.WriteLine();
            }
        }

        static string FindFirstSolution()
        {
            List<string> crosswords = new List<string>();
            foreach (var solution in solutions)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        sb.Append(solution[i, j]);
                    }
                }
                crosswords.Add(sb.ToString());
            }
            crosswords.Sort();
            return crosswords[0];
        }
    }
}
