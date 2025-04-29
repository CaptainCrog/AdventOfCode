using AdventOfCode2017.Problems;
using System.Drawing;

public static class Menu2017
{
    static readonly string _basePath = @"..\..\..\..\AdventOfCode2017\Inputs\Puzzles";
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
                            _ = new Day06(@$"{_basePath}\Day06Puzzle.txt");
                            break;
                        case 7:
                            _ = new Day07(@$"{_basePath}\Day07Puzzle.txt");
                            break;
                        case 8:
                            _ = new Day08(@$"{_basePath}\Day08Puzzle.txt");
                            break;
                        case 9:
                            _ = new Day09(@$"{_basePath}\Day09Puzzle.txt");
                            break;
                        case 10:
                            _ = new Day10(@$"{_basePath}\Day10Puzzle.txt", 256);
                            break;
                        case 11:
                            _ = new Day11(@$"{_basePath}\Day11Puzzle.txt");
                            break;
                        case 12:
                            _ = new Day12(@$"{_basePath}\Day12Puzzle.txt");
                            break;
                        case 13:
                            _ = new Day13(@$"{_basePath}\Day13Puzzle.txt");
                            break;
                        case 14:
                            _ = new Day14(@$"{_basePath}\Day14Puzzle.txt");
                            break;
                        case 15:
                            _ = new Day15(@$"{_basePath}\Day15Puzzle.txt");
                            break;
                        case 16:
                            _ = new Day16(@$"{_basePath}\Day16Puzzle.txt", ['a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p']);
                            break;
                        case 17:
                            _ = new Day17(@$"{_basePath}\Day17Puzzle.txt");
                            break;
                        case 18:
                            _ = new Day18(@$"{_basePath}\Day18Puzzle.txt");
                            break;
                        case 19:
                            _ = new Day19(@$"{_basePath}\Day19Puzzle.txt");
                            break;
                        case 20:
                            _ = new Day20(@$"{_basePath}\Day20Puzzle.txt");
                            break;
                        case 21:
                            _ = new Day21(@$"{_basePath}\Day21Puzzle.txt", 5);
                            break;
                        case 22:
                            _ = new Day22(@$"{_basePath}\Day22Puzzle.txt", 10000);
                            break;
                        case 23:
                            _ = new Day23(@$"{_basePath}\Day23Puzzle.txt");
                            break;
                        case 24:
                            _ = new Day24(@$"{_basePath}\Day24Puzzle.txt");
                            break;
                        case 25:
                            _ = new Day25(@$"{_basePath}\Day25Puzzle.txt");
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