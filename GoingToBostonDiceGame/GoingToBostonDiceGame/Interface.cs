using System;
using System.Collections.Generic;
using System.Text;

namespace GoingToBostonDiceGame
{
    class Interface
    {
        private string player1, player2;

        public void MainMenu()
        {
            // this is the main menu where the user is asked if they want to play with 2 players or the computer
            var player_data = new Player();
            

            try
            {
                Console.Clear();
                Console.WriteLine("----------------------------- Going To Boston Game ---------------------------- \n");
                Console.WriteLine("Who Would you like to play against? \n \n 1: Another Player [2 Player] \n 2: The Computer [Single Player] \n 0: Exit. \n \n [Enter 1, 2 or 0]");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("You have selected two player mode.");

                        Console.WriteLine("Please enter the name of the first player.");
                        player1 = player_data.NameCreation();
                        Console.Clear();

                        Console.WriteLine("Please enter the name of the second player.");
                        player2 = player_data.NameCreation();
                        Console.Clear();

                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("You are playing against the computer.");
                        Console.WriteLine();
                        Console.WriteLine("Please enter your name.");
                        player1 = player_data.NameCreation();
                        player2 = "Computer";
                        break;

                    case "0":
                        Environment.Exit(1);
                        break;

                    default:
                        Console.WriteLine("Incorrect Input, [Enter 1, 2 or 0] \n Press enter to try again.");
                        Console.ReadLine();
                        MainMenu();
                        break;
                }

                
                GameMenu();

            }
            catch (Exception e)
            {
                Console.WriteLine("Something wrong has happened in the main menu: {0}", e);
            }

        }

        private void GameMenu()
        {
            bool verif_choice = false; // boolean variable is used for verifying the user's selection in the gamemode menu
            string choice;

            var play_game = new Game(player1,player2);

            Console.Clear();
            try
            {
                Console.WriteLine("What game mode would you like to play? \n Best of Three : 1 \n First to Five : 2 \n Exit to menu : 3 \n Exit to desktop : 0");
                choice = Console.ReadLine(); 
                do
                {

                    switch (choice)   // Gamemode menu
                    {
                        case "1":
                            Console.WriteLine("You have selected Best of Three.");
                            break;

                        case "2":
                            Console.WriteLine("You have selected First to Five.");
                            break;

                        case "3":
                            Console.WriteLine("Exit to menu");
                            break;

                        case "0":
                            Console.WriteLine("You want to exit to desktop?");
                            Environment.Exit(1);
                            break;

                        default:
                            Console.WriteLine("Incorrect input [please enter either 1,2 or 0] \n Press enter to continue ");
                            Console.ReadLine();
                            GameMenu();
                            break;
                            
                    }
                    ConsoleKey input;
                    do    // verification of selection
                    {
                        Console.Write("Are you sure? [y/n]");
                        input = Console.ReadKey(false).Key;
                        if (input != ConsoleKey.Enter)
                            Console.WriteLine();
                    } while (input != ConsoleKey.Y && input != ConsoleKey.N);
                    verif_choice = input == ConsoleKey.Y;
                } while (!verif_choice);
                switch(choice)
                {
                    case "1":
                        play_game.Best_Of_Three();
                        break;

                    case "2":
                        play_game.First_To_Five();
                        break;

                    case "3":
                        Console.WriteLine("Exiting");
                        MainMenu();
                        break;

                    case "0":
                        Console.WriteLine("You want to exit to desktop?");

                        break;

                    default:
                        Console.WriteLine("An error has occurred in the match selection menu...");
                        break;
                }
                Console.Clear();
                GameMenu();
            }
            catch (Exception e)
            {
                Console.WriteLine("Something wrong has happened in Gamemode : {0}", e);
            }
        }

        static void Main(string[] args)
        {
            var menu = new Interface();
            menu.MainMenu();

        }
    }
}
