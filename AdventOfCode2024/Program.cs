﻿using AdventOfCode2024;
using AdventOfCode2024.Problems;

public class Program 
{
    private static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Choose which problem to solve (Options between 1 - 25)");
            Console.WriteLine("Press Q to quit the application");
            var choiceRaw = Console.ReadLine();
            if (choiceRaw != null)
            {
                if (int.TryParse(choiceRaw, out var choiceSanitised))
                {
                    Console.WriteLine($"Running Day {choiceSanitised} Problem");
                    switch (choiceSanitised)
                    {
                        case 1:
                            _ = new Day1();
                            break;
                        case 2:
                            _ = new Day2();
                            break;
                        case 3:
                            _ = new Day3();
                            break;
                        case 4:
                            _ = new Day4();
                            break;
                        case 5:
                            _ = new Day5();
                            break;
                        case 6:
                            _ = new Day6();
                            break;
                        case 7:
                            _ = new Day7();
                            break;
                        case 8:
                            _ = new Day8();
                            break;
                        case 9:
                            _ = new Day9();
                            break;
                        case 10:
                            _ = new Day10();
                            break;
                        case 11:
                            _ = new Day11();
                            break;
                        default:
                            Console.WriteLine("Option is out of bound or unavailable at the moment");
                            break;
                    }
                    Console.WriteLine(string.Empty);
                }
                else if (choiceRaw.ToLower() == "q")
                {
                    Console.WriteLine("Exiting program");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid input, please try again");
                }
            }
            else
            {
                Console.WriteLine("No input detected, please try again");
            }
        }
    }
}