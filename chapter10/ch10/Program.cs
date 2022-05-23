using System;
using System.Collections.Generic;

namespace ch10
{
    class Program
    {
        static void Main(string[] args)
        {
            GuessingGame mainGame = new GuessingGame();
            // Function sets number of MaxGuesses
            mainGame.AskForDifficulty();
            while (true)
            {
                if (mainGame.MaxGuesses != -1)
                {
                    void recursiveFunction(int i)
                    {
                        if (i == 0)
                        {
                            return;
                        }
                        Console.WriteLine($"\nThis is guess #{mainGame.MaxGuesses-i+1}");
                        mainGame.AskForNumber();
                        if(mainGame.IsCorrectGuess())
                        {
                            return;
                        }
                        recursiveFunction(i-1);
                    }

                    recursiveFunction(mainGame.MaxGuesses);
                    return;
                    // Console.WriteLine($"\nThis is guess number {i + 1}");
                    // i++;
                }
                Console.WriteLine("");
                mainGame.AskForNumber();
                if (mainGame.IsCorrectGuess())
                {
                    break;
                }
            }

            if (mainGame.MaxGuesses == -1)
            {
                Console.WriteLine("\n\n\n\n\nYou dirty cheater . . .\n\n\n\n\n");
            }
        }

    }


    public class GuessingGame
    {
        public int SecretNumber { get; private set; }
        public int ParsedUserNumber { get; private set; }
        public int MaxGuesses { get; private set; }
        public Dictionary<string, int> DifficultySetting = new Dictionary<string, int>{
            {"Easy", 8},
            {"Medium", 6},
            {"Hard", 4},
            {"Cheater", -1}
        };

        public GuessingGame()
        {

            SecretNumber = new Random().Next(1, 101);
            Console.WriteLine($"Secret number is {SecretNumber}\n");
        }

        public void AskForDifficulty()
        {
            string difficultyInput = "";
            do
            {
                Console.WriteLine("Please Select a Difficulty Setting (Easy, Medium, Hard) . . .");
                difficultyInput = Console.ReadLine();
            } while (!DifficultySetting.ContainsKey(difficultyInput));
            MaxGuesses = DifficultySetting[difficultyInput];
        }

        public void AskForNumber()
        {
            int userNumber = new int();
            string userInput = new string("");

            Console.WriteLine("Please guess a valid integer: ");
            bool isEntryValid = false;
            do
            {
                userInput = Console.ReadLine();
                isEntryValid = int.TryParse(userInput, out userNumber);
                if (!isEntryValid)
                {
                    Console.WriteLine("Invlaid entry. Please guess a valid integer: ");
                }
            } while (!isEntryValid);
            ParsedUserNumber = userNumber;
        }

        public bool IsCorrectGuess()
        {
            void GiveHint()
            {
                if (SecretNumber < ParsedUserNumber)
                {
                    Console.WriteLine("Your guess was too high");
                }
                else
                {
                    Console.WriteLine("Your guess was too low");
                }
            }

            if (SecretNumber == ParsedUserNumber)
            {
                Console.WriteLine(@"░░░░░░░░░▄░░░░░░░░░░░░░░▄░░░░
░░░░░░░░▌▒█░░░░░░░░░░░▄▀▒▌░░░
░░░░░░░░▌▒▒█░░░░░░░░▄▀▒▒▒▐░░░
░░░░░░░▐▄▀▒▒▀▀▀▀▄▄▄▀▒▒▒▒▒▐░░░
░░░░░▄▄▀▒░▒▒▒▒▒▒▒▒▒█▒▒▄█▒▐░░░
░░░▄▀▒▒▒░░░▒▒▒░░░▒▒▒▀██▀▒▌░░░ 
░░▐▒▒▒▄▄▒▒▒▒░░░▒▒▒▒▒▒▒▀▄▒▒▌░░
░░▌░░▌█▀▒▒▒▒▒▄▀█▄▒▒▒▒▒▒▒█▒▐░░
░▐░░░▒▒▒▒▒▒▒▒▌██▀▒▒░░░▒▒▒▀▄▌░
░▌░▒▄██▄▒▒▒▒▒▒▒▒▒░░░░░░▒▒▒▒▌░
▐▒▀▐▄█▄█▌▄░▀▒▒░░░░░░░░░░▒▒▒▐░ You guessed it!
▐▒▒▐▀▐▀▒░▄▄▒▄▒▒▒▒▒▒░▒░▒░▒▒▒▒▌
▐▒▒▒▀▀▄▄▒▒▒▄▒▒▒▒▒▒▒▒░▒░▒░▒▒▐░
░▌▒▒▒▒▒▒▀▀▀▒▒▒▒▒▒░▒░▒░▒░▒▒▒▌░
░▐▒▒▒▒▒▒▒▒▒▒▒▒▒▒░▒░▒░▒▒▄▒▒▐░░
░░▀▄▒▒▒▒▒▒▒▒▒▒▒░▒░▒░▒▄▒▒▒▒▌░░
░░░░▀▄▒▒▒▒▒▒▒▒▒▒▄▄▄▀▒▒▒▒▄▀░░░
░░░░░░▀▄▄▄▄▄▄▀▀▀▒▒▒▒▒▄▄▀░░░░░
░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▀▀░░░░░░░░");
                return true;
            }
            else
            {
                Console.WriteLine("This guess is not correct (Sad beep)");
                GiveHint();
                return false;
            }
        }
    }

}
