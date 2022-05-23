using System;

namespace ch10
{
    class Program
    {
        static void Main(string[] args)
        {
            GuessingGame mainGame = new GuessingGame();
            mainGame.AskForNumber();
            mainGame.CompareNumbers();

        }

    }
    public class GuessingGame
    {
        public int secretNumber { get; private set; }
        public int parsedUserNumber { get; private set; }

        public GuessingGame()
        {
            secretNumber = 42;
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
            Console.WriteLine($"You entered {userNumber}");
            parsedUserNumber = userNumber;
        }

        public void CompareNumbers()
        {
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
            }
            else
            {
                Console.WriteLine("(Sad beep)");
            }
        }
    }

}
