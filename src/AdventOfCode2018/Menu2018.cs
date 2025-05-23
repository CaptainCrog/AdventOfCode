﻿using AdventOfCode2018.Problems;

public static class Menu2018
{
    static readonly string _basePath = @"..\..\..\..\AdventOfCode2018\Inputs\Puzzles";
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Choose which problem to solve (Options between 1 - 25)");
            Console.WriteLine("Press Q to return to the main menu");
            var choiceRaw = Console.ReadLine();
            if (choiceRaw != null)
            {
                if (int.TryParse(choiceRaw, out var choiceSanitised))
                {
                    Console.WriteLine($"Running Day {choiceSanitised} Problem");
                    switch (choiceSanitised)
                    {
                        case 1:
                            _ = new Day01(@$"{_basePath}\Day01Puzzle.txt");
                            break;
                        case 2:
                            _ = new Day02(@$"{_basePath}\Day02Puzzle.txt");
                            break;
                        case 3:
                            _ = new Day03(@$"{_basePath}\Day03Puzzle.txt");
                            break;
                        case 4:
                            _ = new Day04(@$"{_basePath}\Day04Puzzle.txt");
                            break;
                        case 5:
                            _ = new Day05(@$"{_basePath}\Day05Puzzle.txt");
                            break;
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                        case 15:
                        case 16:
                        case 17:
                        case 18:
                        case 19:
                        case 20:
                        case 21:
                        case 22:
                        case 24:
                        case 25:
                        default:
                            Console.WriteLine("Option is out of bound or unavailable at the moment");
                            break;
                    }
                    Console.WriteLine(string.Empty);
                }
                else if (choiceRaw.ToLower() == "q")
                {
                    Console.WriteLine("Returning to main menu");
                    return;
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