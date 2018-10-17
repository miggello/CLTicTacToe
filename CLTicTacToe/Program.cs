using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLTicTacToe
{
    class Program
    {
        /*Planned Features:
            1. Play Tic-Tac-Toe against the computer.
            2. Draw game as it progresses using a simple command line GUI.
            3. Computer should have multiple difficulty settings (easy - normal - impossible).
            4. Store game data in a basic user profile.
            5. Calculate statistics based on user profile and game data.
        */
        static void Main()
        {
            bool runApp = true;
            Profile myProfile = new Profile("Miggello", "mypassword");

            while (runApp)
            {
                Console.WriteLine("Menu: (U) Reset Username | (E) Exit");
                string arg = Console.ReadLine();

                if (arg == "U")
                {
                    Console.WriteLine("Please enter your desired Username");
                    string user = Console.ReadLine();
                    myProfile.changeUsername(user);

                    Console.WriteLine("Your username is: " + myProfile.Username);
                }
                if (arg == "E")
                {
                    runApp = false;
                }
            }

            /*
            string response;
            Console.WriteLine("Welcome to Command Line Tic Tac Toe! Would you like to play a game? (y/n)\n");

            do
            {
                response = Console.ReadLine();
                if (new[] { "Y", "y", "Yes", "yes" }.Contains(response))
                {
                    //Start Play Menu
                    do
                    {
                        Console.WriteLine("Instructions: (i), Play: (p), Exit: (e)");
                        response = Console.ReadLine();

                        if (response == "i" || response == "I")
                        {
                            writeInstructions();
                        }
                        else if (response == "p" || response == "P")
                        {
                            //play a game
                            Game testgame = new Game();
                            Console.WriteLine("Game was named: " + testgame.Name);
                            Console.WriteLine("Would you like to play another?");
                        }
                        else if (response == "e" || response == "E")
                        {
                            Console.WriteLine("Thank you for playing!");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Entry.");
                        }
                    }
                    while (true);
                }
                else if (new[] { "N", "n", "No", "no" }.Contains(response))
                {
                    //exit application
                    break;
                }
                else
                {
                    //invalid response
                    Console.WriteLine("Invalid Response, please enter 'y' for yes, or 'n' for no.");
                }
            }
            while (true);
            
        }

        private static void writeInstructions()
        {
            Console.WriteLine("When prompted enter the number shown in the cell you would like to place your token (X) in as seen below:\n");
            Console.WriteLine(" 1 | 2 | 3 ");
            Console.WriteLine("___|___|___");
            Console.WriteLine("   |   |   ");
            Console.WriteLine(" 4 | 5 | 6 ");
            Console.WriteLine("___|___|___");
            Console.WriteLine("   |   |   ");
            Console.WriteLine(" 7 | 8 | 9 \n");
        }
        */
        }
    }
}
