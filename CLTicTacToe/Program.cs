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
        static void Main(string[] args)
        {
            string response;
            Console.WriteLine("Welcome to Command Line Tic Tac Toe! Would you like to play a game? (y/n)\n");

            do
            {
                response = Console.ReadLine();
                if (new[] { "Y", "y", "Yes", "yes" }.Contains(response))
                {
                    //Start Play Menu
                    Console.WriteLine("You played a game! (Not Yet Implemented)");
                    Console.WriteLine("Would you like to play another?");
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
    }
}
