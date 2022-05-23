using System;
using System.Collections.Generic;

namespace ch10
{
    class Program
    {
        static void Main(string[] args)
        {
            GuessingGame mainGame = new GuessingGame();
            mainGame.AskForDifficulty();
            for (int i = 0; i < mainGame.maxGuesses; i++)
            {
                Console.WriteLine($"\nThis is guess number {i + 1}");
                mainGame.AskForNumber();
                if (mainGame.isCorrectGuess())
                {
                    break;
                }
            }
        }

    }


    public class GuessingGame
    {
        public int secretNumber { get; private set; }
        public int parsedUserNumber { get; private set; }
        public int maxGuesses { get; private set;}
        public Dictionary<string, int> difficultySetting = new Dictionary<string, int>{
            {"Easy", 8},
            {"Medium", 6},
            {"Hard", 4}
        };

        public GuessingGame()
        {

            secretNumber = new Random().Next(1, 101);
            Console.WriteLine($"Secret number is {secretNumber}\n");
        }

        public void AskForDifficulty()
        {
            string difficultyInput = "";
            do
            {
                Console.WriteLine("Please Select a Difficulty Setting (Easy, Medium, Hard) . . .");
                difficultyInput = Console.ReadLine();
            } while (!difficultySetting.ContainsKey(difficultyInput));
            maxGuesses = difficultySetting[difficultyInput];
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
            parsedUserNumber = userNumber;
        }

        public bool isCorrectGuess()
        {
            void GiveHint()
            {
                if (secretNumber < parsedUserNumber)
                {
                    Console.WriteLine("Your guess was too high");
                }
                else
                {
                    Console.WriteLine("Your guess was too low");
                }
            }

            if (secretNumber == parsedUserNumber)
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
