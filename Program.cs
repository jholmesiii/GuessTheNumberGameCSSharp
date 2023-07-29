using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Guess_the_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to \"Guess The Number!\"\n");

            Random random = new Random();
            String replay = "y";
            bool guessLine = true;

            while (replay == "y")
            {
                int secretNumber = random.Next(1, 101);
                int attempts = 0;
                bool correctGuess = false;

                while (!correctGuess)
                {
                    if(guessLine == true)
                    {
                        Console.WriteLine("\nGuess a number between 1 and 100");
                    }
                    
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out int guess))
                    {
                        if (guess > 0 || guess < 101)
                        {
                            attempts++;

                            if (guess == secretNumber)
                            {
                                guessLine = true;
                                correctGuess = true;
                            }
                            else
                            {
                                guessLine = false;
                                if (guess < secretNumber)
                                {
                                    Console.WriteLine("Try a higher number!");
                                }
                                else
                                {
                                    Console.WriteLine("Try a lower number!");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number between 1 - 100");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number between 1 - 100");
                    }
                }

                Console.WriteLine($"Congratulations! You guessed the number {secretNumber} correctly in {attempts} attempts!");
                Console.WriteLine("Would you like to play again?");

                replay = Console.ReadLine();
                if (replay.ToLower() == "yes" || replay.ToLower() == "y")
                {
                    replay = "y";
                }
                else
                {
                    replay = "n";
                }
            }

            Console.WriteLine("\nThank you for playing!\nPress any key to exit.");

            Console.ReadKey();
        }
    }
}
