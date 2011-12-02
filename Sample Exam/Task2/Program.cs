using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            uint n = uint.Parse(input);
            uint[] catVotes = new uint[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine();
                byte winningCat = byte.Parse(input);
                catVotes[winningCat - 1]++;
            }

            int winner = FindWinner(catVotes);
            Console.WriteLine(winner);
        }

        static int FindWinner(uint[] votes)
        {
            uint mostVotes = votes[0];
            int index = 0;
            for (int i = 0; i < votes.Length; i++)
            {
                if (mostVotes < votes[i])
                {
                    mostVotes = votes[i];
                    index = i;
                }
            }
            return index + 1;
        }
    }
}
