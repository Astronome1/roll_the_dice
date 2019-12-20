using System;
using System.Linq;

namespace roll_the_dice
{
    class Program
    {
        static void Main(string[] args)
        {
            //Introduction
            Console.WriteLine("Welcome to Roll The Dice!");
            Console.WriteLine("Roll any number of dice and give us the sum of their outcomes and we will tell you every possible combination that you could have gotten\n");


            //Get and validate the number of dice rolled
            Console.WriteLine("How many dice have you rolled?");

            int no_of_dice;
            bool converted = int.TryParse(Console.ReadLine(), out no_of_dice);

            if (!converted)
            {
                while (!converted)
                {
                    Console.WriteLine("Please input a number\nHow many dice have you rolled?");
                    converted = int.TryParse(Console.ReadLine(), out no_of_dice);
                }
            }


            //Get and validate the total outcome of the dice rolled
            Console.WriteLine("What was the total outcome?");

            int total_outcome;
            converted = int.TryParse(Console.ReadLine(), out total_outcome);

            if (!converted)
            {
                while (!converted)
                {
                    Console.WriteLine("Please input a number\nWhat was the total outcome?");
                    converted = int.TryParse(Console.ReadLine(), out total_outcome);
                }
            }


            //Get the combinations
            Calculator(no_of_dice, total_outcome);

        }

        public static void Calculator(int no_of_dice, int total_outcome)
        {
            int outcomes = 0; //counts the number of outcomes

            int[] dice_outcomes = new int[no_of_dice]; //stores the value of each dice

            //initializing the value of each dice to 1
            for (int i = 0; i < no_of_dice; i++)
            {
                dice_outcomes[i] = 1;
            }


            //hold dice in pairs. Increase the value to the maximum before increasing the value of the adjacent by 1 and reinitilizing the all preceeding
            int x = 0;
            while (true)
            {
                while (dice_outcomes[x + 1] <= 6)
                {
                    while (dice_outcomes[x] <= 6)
                    {
                        int sum = dice_outcomes.Sum();

                        if (sum == total_outcome)
                        {
                            Console.WriteLine($"Outcome {++outcomes}: {String.Join(" + ", dice_outcomes)}");
                        }
                        else if (sum > total_outcome)
                        {
                            break;
                        }

                        dice_outcomes[x]++;
                    }
                    dice_outcomes[x] = 1;
                    dice_outcomes[x + 1]++;

                    if (dice_outcomes.Sum() > total_outcome) break;
                }

                dice_outcomes[x + 1] = 1;
                if (x + 1 < dice_outcomes.Length - 1)
                {
                    dice_outcomes[x + 2] = 2;
                    x++;
                }
                else
                {
                    break;
                }
            }

        }
    }
}
