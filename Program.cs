using System.Net.Mime;
using System.Windows.Input;

namespace BloodBowlGeneratorV4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*  
            *   Blood Bowl action generator that generates a random sequence of actions you can take for your player.
            *
            *   This version adds formatting to the output as well as adding the the half and turn number for the user.
            *   
            *
            */

            Welcome();
            StartGame();

        }

        static void StartGame()
        {
            //variable declarations and initialize
            bool play = true;
            int half = 0;
            int turnNum = 1;
            string action;
            string? teamName = "";
            Random rng = new Random();

            Console.WriteLine("Enter Team One name: ");
            string? teamOne = Console.ReadLine();
            Console.WriteLine("Enter Team Two name: ");
            string? teamTwo = Console.ReadLine();

            Thread.Sleep(1000);
            Console.Clear();

            while (play)
            {

                //Create a list to store the actions in
                List<string> actions = new List<string>();
                //a while loop that continues to adds the actions to the list until it is full
                while (actions.Count() != 4 && turnNum <= 16)
                {
                    //This is to keep track of the half and turn number that will be printed to the console for the user.
                    if (turnNum <= 8)
                    {
                        half = 1;
                    }
                    else if (turnNum >= 9)
                    {
                        half = 2;
                    }

                    if (turnNum % 2 == 0)
                    {
                        teamName = teamTwo;
                    }
                    else
                    {
                        teamName = teamOne;
                    }

                    //Random number generator
                    int num = rng.Next(1, 5);


                    //Switch case that assigns the random number to an item that is stored in the List.
                    switch (num)
                    {
                        case 1:
                            action = "Move Player";
                            if (!actions.Contains(action))
                            {
                                actions.Add(action);
                            }
                            break;
                        case 2:
                            action = "Pass / Throw Team Mate";
                            if (!actions.Contains(action))
                            {
                                actions.Add(action);
                            }
                            break;
                        case 3:
                            action = "Block";
                            if (!actions.Contains(action))
                            {
                                actions.Add(action);
                            }
                            break;
                        case 4:
                            action = "Blitz / Get Up";
                            if (!actions.Contains(action))
                            {
                                actions.Add(action);
                            }
                            break;
                    }

                }

                //We will print out the list to the console, using an index variable to to print the order of the items
                int index = 0;
                Console.WriteLine("");
                Console.WriteLine("{0}'s turn.", teamName);
                System.Console.WriteLine("-- Half {0} -- Turn {1}", half, turnNum);
                foreach (var item in actions)
                {
                    //increment the index variable after every iteration
                    index++;
                    Console.WriteLine("{0}. {1}", index, item);

                }
                turnNum++;
                System.Console.WriteLine("-------------------");

                if (Console.ReadKey(true).Key != ConsoleKey.Enter)
                {
                }

                //Here we check to see if the game is over.
                if (turnNum > 16)
                {
                    ExitGame();
                }
            }
        }

        static void Welcome()
        {
            Console.WriteLine(" ************************************************************\n");

            Console.WriteLine("   Welcome to the Blood Bowl Action Generator Version 4.0.0.");

            Console.WriteLine("\n ************************************************************");

            System.Console.WriteLine("Press 'Enter' to continue");


            //Check to make sure the user is pressing the enter key.
            Console.ReadKey();
            System.Console.Clear();

        }

        static void ExitGame()
        {
            Console.WriteLine(" ************************************************************\n");

            System.Console.WriteLine("     Aaaaaand that's the game!");
            System.Console.WriteLine("     Thank you for using the Blood Bowl Generator!");
            System.Console.WriteLine("     We hope to see if you at the next match.");

            Console.WriteLine("\n ************************************************************");
            Console.ReadKey();
            Environment.Exit(0);
        }

    }
}