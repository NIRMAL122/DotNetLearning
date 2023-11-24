using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp
{
    public class BingoGame
    {
        static Random random = new Random();

        static int[,] GenerateBingoCard()
        {
            int[,] card = new int[5, 5];
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    // Ensure each column only contains numbers within a specific range
                    card[row, col] = col * 15 + random.Next(1, 16);
                }
            }
            return card;
        }

        static void PrintBingoCard(int[,] card)
        {
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    Console.Write(card[row, col].ToString().PadLeft(4));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static int GenerateRandomNumber()
        {
            return random.Next(1, 76);
        }

        static void MarkNumberOnCard(int[,] card, int number)
        {
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    if (card[row, col] == number)
                    {
                        card[row, col] = 0; // Mark the number on the card
                        return;
                    }
                }
            }
        }

        static bool CheckBingo(int[,] card)
        {
            // Check rows
            for (int row = 0; row < 5; row++)
            {
                if (AreAllElementsZero(GetRow(card, row)))
                    return true;
            }

            // Check columns
            for (int col = 0; col < 5; col++)
            {
                if (AreAllElementsZero(GetColumn(card, col)))
                    return true;
            }

            // Check diagonals
            if (AreAllElementsZero(GetDiagonal(card, true)) || AreAllElementsZero(GetDiagonal(card, false)))
                return true;

            return false;
        }

        static int[] GetRow(int[,] card, int row)
        {
            int[] result = new int[5];
            for (int col = 0; col < 5; col++)
            {
                result[col] = card[row, col];
            }
            return result;
        }

        static int[] GetColumn(int[,] card, int col)
        {
            int[] result = new int[5];
            for (int row = 0; row < 5; row++)
            {
                result[row] = card[row, col];
            }
            return result;
        }

        static int[] GetDiagonal(int[,] card, bool fromTopLeft)
        {
            int[] result = new int[5];
            int rowIncrement = fromTopLeft ? 1 : -1;
            int col = fromTopLeft ? 0 : 4;

            for (int i = 0; i < 5; i++)
            {
                result[i] = card[i, col];
                col += rowIncrement;
            }
            return result;
        }

        static bool AreAllElementsZero(int[] array)
        {
            foreach (int num in array)
            {
                if (num != 0)
                    return false;
            }
            return true;
        }

        static void PlayBingo()
        {
            int[,] bingoCard = GenerateBingoCard();
            HashSet<int> calledNumbers = new HashSet<int>();

            Console.WriteLine("Welcome to Bingo!");

            while (true)
            {
                Console.WriteLine("Press Enter to call the next number...");
                Console.ReadLine();

                int number = GenerateRandomNumber();

                // Ensure the same number is not called twice
                while (calledNumbers.Contains(number))
                {
                    number = GenerateRandomNumber();
                }

                calledNumbers.Add(number);
                Console.WriteLine($"Calling number: {number}");

                MarkNumberOnCard(bingoCard, number);
                PrintBingoCard(bingoCard);

                if (CheckBingo(bingoCard))
                {
                    Console.WriteLine("Bingo! You've won!");
                    break;
                }
            }
        }

        public void StartGame()
        {
            PlayBingo();
        }
    }

}
