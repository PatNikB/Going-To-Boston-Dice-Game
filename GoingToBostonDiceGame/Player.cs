using System;
using System.Collections.Generic;
using System.Text;

namespace GoingToBostonDiceGame
{
    class Player
    {
        public string NameCreation()
        {
            bool verif_choice; // confirms if the user selects a certain key or not
            string name;
            do
            {
                name = Console.ReadLine();
                Console.WriteLine("You entered the name, {0}.", name);

                ConsoleKey input;
                do
                {
                    Console.Write("Are you sure? [y/n]");
                    input = Console.ReadKey(false).Key;
                    if (input != ConsoleKey.Enter)
                        Console.WriteLine();
                } while (input != ConsoleKey.Y && input != ConsoleKey.N);
                verif_choice = input == ConsoleKey.Y;
            } while (!verif_choice);
            return name;

        }
    }
}
