using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task8ExtractSentencesByWord
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 8: Write a program that extracts from a given text all sentences containing given word.

            string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
            string word = "in";

            List<string> sentences = ExtractSentencesByWord(text, word);

            foreach (string sentence in sentences)
            {
                Console.WriteLine(sentence);
            }
        }

        static List<string> ExtractSentencesByWord(string text, string word)
        {
            string[] allSentences = text.Split('.');
            List<string> goodSentences = new List<string>();

            for (int i = 0; i < allSentences.Length; i++)
            {
                allSentences[i] = allSentences[i].TrimStart(' ');
                allSentences[i] = allSentences[i] + ".";
                if (allSentences[i].Contains(" " + word + " "))
                {
                    goodSentences.Add(allSentences[i]);
                }
            }
            return goodSentences;
        }
    }
}
