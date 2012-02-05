using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task7EncodeDecode
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 7: Write a program that encodes and decodes a string using given encryption key (cipher).
            // The key consists of a sequence of characters. The encoding/decoding is done by performing XOR
            // (exclusive or) operation over the first letter of the string with the first of the key, the
            // second – with the second, etc. When the last key character is reached, the next is the first.

            string text = "This text is to be coded.";
            string cypher = "2256";

            string encoded = Encode(text, cypher);
            Console.WriteLine(encoded);
            string decoded = Encode(encoded, cypher);
            Console.WriteLine(decoded);
        }

        static string Encode(string text, string cypher)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(text);

            for (int i = 0; i < text.Length; i++)
            {
                int cypherIndex = text.Length % cypher.Length;
                sb[i] = (char)(text[i] ^ cypher[cypherIndex]);
            }

            return sb.ToString();
        }
    }
}
