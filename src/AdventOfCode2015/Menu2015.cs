﻿using AdventOfCode2015.Problems;

public static class Menu2015
{
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
                            _ = new Day01(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day01Puzzle.txt");
                            break;
                        case 2:
                            _ = new Day02(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day02Puzzle.txt");
                            break;
                        case 3:
                            _ = new Day03(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day03Puzzle.txt");
                            break;
                        case 4:
                            _ = new Day04(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day04Puzzle.txt");
                            break;
                        case 5:
                            _ = new Day05(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day05Puzzle.txt");
                            break;
                        case 6:
                            _ = new Day06(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day06Puzzle.txt");
                            break;
                        case 7:
                            _ = new Day07(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day07Puzzle.txt", "a");
                            break;
                        case 8:
                            _ = new Day08(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day08Puzzle.txt");
                            break;
                        case 9:
                            _ = new Day09(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day09Puzzle.txt");
                            break;
                        case 10:
                            _ = new Day10(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day10Puzzle.txt", 40);
                            break;
                        case 11:
                            _ = new Day11(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day11Puzzle.txt");
                            break;
                        case 12:
                            _ = new Day12(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day12Puzzle.txt");
                            break;
                        case 13:
                            _ = new Day13(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day13Puzzle.txt");
                            break;
                        case 14:
                            _ = new Day14(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day14Puzzle.txt", 2503);
                            break;
                        case 15:
                            _ = new Day15(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day15Puzzle.txt");
                            break;
                        case 16:
                            _ = new Day16(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day16Puzzle.txt");
                            break;
                        case 17:
                            _ = new Day17(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day17Puzzle.txt", 150);
                            break;
                        case 18:
                            _ = new Day18(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day18Puzzle.txt", 100);
                            break;
                        case 19:
                            _ = new Day19(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day19Puzzle.txt");
                            break;
                        case 20:
                            _ = new Day20(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day20Puzzle.txt");
                            break;
                        case 21:
                            _ = new Day21(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day21Puzzle.txt");
                            break;
                        case 22:
                            _ = new Day22(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day22Puzzle.txt");
                            break;
                        case 23:
                            _ = new Day23(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day23Puzzle.txt");
                            break;
                        case 24:
                            _ = new Day24(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day24Puzzle.txt");
                            break;
                        case 25:
                            _ = new Day25(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day25Puzzle.txt");
                            break;
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