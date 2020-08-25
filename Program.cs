using System;

namespace guessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Secret!------ DO NOT SHARE
            int secret = getSecretNumber();
            // Secret!------ DO NOT SHARE

            Console.WriteLine("HEY!!!!!");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("gUESS MY Secret number!");
            Console.WriteLine();
            int difficulty = getDifficulty();
            if (difficulty == 100)
            {
                Console.WriteLine();
                Console.WriteLine("A cheater eh? I'll allow it.");
                Console.WriteLine();
            }
            Console.WriteLine("Ok ok ok it's between 0-100, now  GUESS GUESS GUESS GUESS GUESS1!!!!!!!!!!!!!!!");
            int guess = getGuess();

            bool success = responseLoop(guess, secret, difficulty);

            if (success)
            {
                Console.WriteLine($"WOWOWOWOW !!!! YOU GOT IT RIGHT!");
            }
            else
            {
                Console.WriteLine("AWWWW!! LOOKS LIKE IT WAS TOO TOO HARD FOR YOU :(");
            }
        }

        static int getGuess()
        {
            string response = Console.ReadLine();
            while (response == "")
            {
                Console.WriteLine("nOpE!! GOTTA GUESS SOMETHING!");
                response = Console.ReadLine();
            }
            bool didItParse = int.TryParse(response, out int convertResponse);
            while (!didItParse)
            {
                Console.WriteLine("Really? Enter a number bro.");
                response = Console.ReadLine();
                didItParse = int.TryParse(response, out convertResponse);
            }
            return convertResponse;
        }

        static bool responseLoop(int guess, int secret, int difficulty)
        {
            int count = 1;
            if (difficulty == 100)
            {
                while (guess != secret)
                {
                    //evaluates correctness
                    if (guess != secret)
                    {
                        Console.WriteLine("WRONG WRONG WRONG WRONG WRONG");

                        //gives user a hint
                        if (guess > secret)
                        {
                            Console.WriteLine("TOO HIGH!!! TOO HIGH!!!");
                        }
                        else if (guess < secret)
                        {
                            Console.WriteLine("LIL' TOO LOW THERE BUD!!!");
                        }
                        guess = getGuess();
                    }
                }
            }
            else
            {
                while (guess != secret)
                {
                    //evaluates correctness
                    if (count < difficulty && guess != secret)
                    {
                        Console.WriteLine("WRONG WRONG WRONG WRONG WRONG");

                        //gives user a hint
                        if (guess > secret)
                        {
                            Console.WriteLine("TOO HIGH!!! TOO HIGH!!!");
                        }
                        else if (guess < secret)
                        {
                            Console.WriteLine("LIL' TOO LOW THERE BUD!!!");
                        }

                        Console.WriteLine($"You hAvE {difficulty - count} GUESSES rEmAiNiNg!");
                        guess = getGuess();
                    }
                    else if (count >= difficulty && guess != secret)
                    {
                        return false;
                    }
                    count++;
                }
            }

            return true;
        }

        static int getSecretNumber()
        {
            Random rnd = new Random();
            int secretNum = rnd.Next(1, 100);
            return secretNum;
        }
        static int getDifficulty()
        {
            Console.WriteLine("BUT FIRST: HOW SMaRT ARE YOU??!?!?!");
            Console.WriteLine("ARE YOU A 'DUMMY'? WE GOT EASY FOR THAT!");
            Console.WriteLine("IF YOU'ER PRETTY DANG SMART' WE GOT MEDIUM");
            Console.WriteLine("iF yOu'Re a gEnUis pIcK hARD!!! (OR ELSE YOU'RE A Cheater!)");
            Console.WriteLine("WHAT'LL IT BE CHAMP?!?!?");
            string difficulty = Console.ReadLine().ToLower();

            while (difficulty != "easy" && difficulty != "medium" && difficulty != "hard" && difficulty != "cheater")
            {
                Console.WriteLine($"Difficulty: {difficulty}");
                Console.WriteLine("I SaID EASY, MEDIUM, OR HARD!!!");
                difficulty = Console.ReadLine().ToLower();
            }

            int guesses = new int();
            switch (difficulty)
            {
                case "easy":
                    guesses = 8;
                    break;
                case "medium":
                    guesses = 6;
                    break;
                case "hard":
                    guesses = 4;
                    break;
                case "cheater":
                    guesses = 100;
                    break;
            }

            return guesses;

        }
    }
}