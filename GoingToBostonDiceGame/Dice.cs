using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoingToBostonDiceGame
{
    class Dice // class that rolls the dice and returns the highest value.
    {
        private int[] roll_result = new int[] { 0, 0, 0 };    // array that will store the values for each die that is rolled
        private Random roll = new Random();

        private int Roll_Dice()
        {
            Thread.Sleep(500);   // Putting a half second delay for each loading dot to make the play smooth
            Console.Write(".");

            return roll.Next(1, 7);
        }

        public int Display_Rolls(int x) // prints out the results of each roll depending on how many dice is thrown. The argument x is the number of rolls performed (1-3)
        {
            Array.Clear(roll_result,0,3);
            switch (x)
            {
                case 3:
                    Console.WriteLine("Hit enter to roll the dice!");
                    Console.ReadLine();
                    Console.Write("Rolling 3 dice");
                    roll_result[0] = Roll_Dice();
                    roll_result[1] = Roll_Dice();
                    roll_result[2] = Roll_Dice();
                    
                    Console.WriteLine();

                    Console.WriteLine(" The value of dice 1: {0} \n The value of dice 2: {1} \n The value of dice 3: {2}", roll_result[0], roll_result[1], roll_result[2]);
                    break;

                case 2:
                    Console.WriteLine("Hit enter to roll the dice!");
                    Console.ReadLine();
                    Console.Write("Rolling 2 dice");
                    roll_result[0] = Roll_Dice();
                    roll_result[1] = Roll_Dice();

                    Console.WriteLine();
                    Console.WriteLine(" The value of dice 1: {0} \n The value of dice 2: {1}", roll_result[0], roll_result[1]);
                    break;

                case 1:
                    Console.WriteLine("Hit enter to roll the die!");
                    Console.ReadLine();
                    Console.Write("\nRolling die");
                    roll_result[0] = Roll_Dice();
                    Console.WriteLine("\n The value of dice 1: {0}", roll_result[0]);
                    break;

                default:
                    Console.WriteLine("An error has occured.");
                    break;
            }
            Thread.Sleep(2000);
            if (x >1)
            {
                Console.WriteLine("\nThe highest valued die is: {0}", roll_result.Max());
            }

            
            return roll_result.Max(); // returns the highest number from the dice
            
        }
    }
}
