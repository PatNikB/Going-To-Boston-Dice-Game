using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GoingToBostonDiceGame
{
    class Game
    {
        Dice play = new Dice();

        private string _Player1, _Player2;
        // class constructor
        public Game(string p1Name, string p2Name)
        {
            _Player1 = p1Name;
            _Player2 = p2Name;

        }
        private int p1Score, p1Dice_Total;
        private int p2Score, p2Dice_Total;

        private void Score_Card()
        {
            Console.WriteLine("\n{0}  {1} : {2}  {3} \n \n ",_Player1, p1Score, p2Score, _Player2);
        }

        private int Play_Dice_Round()  // this method rolls the 3 sets of dice that need to be rolled: 3 dice -> 2 Dice -> 1 Dice
        {
            int dice_sum = 0;
            for (int i = 3; i >= 1; i--)
            {
                dice_sum += play.Display_Rolls(i); //  when i = 3, it rolls 3 dice and finds the highest valued die. when i = 2, it rolls 2 dice and finds the highest valued die and same for when i=1 it only rolls one dice.
                Console.WriteLine();
            }
            return dice_sum;
        }

        private void Play_Round(int a) // This method plays through a round of the game and updates the score of player 1 or player 2 variable whoever wins that point.
        {
            while (p1Score < a && p2Score < a)
            {
                Score_Card();
                Console.WriteLine("{0}'s turn. \n", _Player1);
                p1Dice_Total = Play_Dice_Round();

                Console.WriteLine("The total score for {0} is {1}", _Player1, p1Dice_Total);
                Thread.Sleep(3000);

                Console.Clear();
                Score_Card();

                Console.WriteLine("{0}'s turn. \n", _Player2);
                p2Dice_Total = Play_Dice_Round();

                Thread.Sleep(1000);
                Console.WriteLine("The total score for {0} is: {1} And the total score for {2} is: {3} \n", _Player2, p2Dice_Total, _Player1, p1Dice_Total);
                Thread.Sleep(2000);

                // Displays the winner of the round
                if (p1Dice_Total > p2Dice_Total)
                {
                    Console.WriteLine("{0} wins the round!", _Player1);
                    p1Score++;
                }
                else if (p1Dice_Total == p2Dice_Total)
                {
                    Console.WriteLine("It's a draw! Re-roll!");
                }
                else
                {
                    Console.WriteLine("{0} wins the round!", _Player2);
                    p2Score++;
                }

                Thread.Sleep(2000);
                Console.Clear();
                p1Dice_Total = 0;
                p2Dice_Total = 0;
            }
        }

        public void Best_Of_Three()
        {
            Console.Clear();
            p1Score = 0; p2Score = 0; p1Dice_Total = 0; p2Dice_Total = 0;
            Console.WriteLine("You have chosen the game mode Best of Three.\nIn this game, the player with the highest sum of dice wins a point. \nThe player who gets to 2 points wins.");
            Thread.Sleep(3000);

            Play_Round(2);
            
            Console.Clear();
            Score_Card();

            if (p1Score > p2Score)
            {
                Console.WriteLine("{0} has won the Game!", _Player1);
            }
            else
            {
                Console.WriteLine("{0} has won the Game!", _Player2);
            }

            Thread.Sleep(3000);

            Console.WriteLine("Returning to Game Menu.");

            Thread.Sleep(2000);

        }

        public void First_To_Five()
        {
            Console.Clear();
            p1Score = 0; p2Score = 0; p1Dice_Total = 0; p2Dice_Total = 0;
            Console.WriteLine("You have chosen the game mode First to Five.\nIn this game, the player who wins 5 rounds first wins.");
            Thread.Sleep(3000);

            Play_Round(5);

            Console.Clear();
            Score_Card();

            if (p1Score > p2Score)
            {
                Console.WriteLine("{0} has won the Game!", _Player1);
            }
            else
            {
                Console.WriteLine("{0} has won the Game!", _Player2);
            }

            Thread.Sleep(3000);

            Console.WriteLine("Returning to Game Menu.");

            Thread.Sleep(2000);

        }
    }
}
