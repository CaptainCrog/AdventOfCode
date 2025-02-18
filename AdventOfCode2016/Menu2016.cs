using AdventOfCode2016.Problems;
using System.Drawing;

public static class Menu2016
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
                            _ = new Day01(@"..\..\..\..\AdventOfCode2016\Inputs\Puzzles\Day01Puzzle.txt");
                            break;
                        case 2:
                            _ = new Day02(@"..\..\..\..\AdventOfCode2016\Inputs\Puzzles\Day02Puzzle.txt");
                            break;
                        case 3:
                            _ = new Day03(@"..\..\..\..\AdventOfCode2016\Inputs\Puzzles\Day03Puzzle.txt");
                            break;
                        case 4:
                            _ = new Day04(@"..\..\..\..\AdventOfCode2016\Inputs\Puzzles\Day04Puzzle.txt", "northpole");
                            break;
                        case 5:
                            _ = new Day05(@"..\..\..\..\AdventOfCode2016\Inputs\Puzzles\Day05Puzzle.txt");
                            break;
                        case 6:
                            _ = new Day06(@"..\..\..\..\AdventOfCode2016\Inputs\Puzzles\Day06Puzzle.txt");
                            break;
                        case 7:
                            _ = new Day07(@"..\..\..\..\AdventOfCode2016\Inputs\Puzzles\Day07Puzzle.txt");
                            break;
                        case 8:
                            _ = new Day08(@"..\..\..\..\AdventOfCode2016\Inputs\Puzzles\Day08Puzzle.txt", 6, 50);
                            break;
                        case 9:
                            _ = new Day09(@"..\..\..\..\AdventOfCode2016\Inputs\Puzzles\Day09Puzzle.txt");
                            break;
                        case 10:
                            _ = new Day10(@"..\..\..\..\AdventOfCode2016\Inputs\Puzzles\Day10Puzzle.txt", (61, 17));
                            break;
                        case 11:
                            _ = new Day11(@"..\..\..\..\AdventOfCode2016\Inputs\Puzzles\Day11Puzzle.txt");
                            break;
                        case 12:
                            _ = new Day12(@"..\..\..\..\AdventOfCode2016\Inputs\Puzzles\Day12Puzzle.txt");
                            break;
                        case 13:
                            _ = new Day13(@"..\..\..\..\AdventOfCode2016\Inputs\Puzzles\Day13Puzzle.txt", new Point() { X = 31, Y = 39 });
                            break;
                        case 14:
                            _ = new Day14(@"..\..\..\..\AdventOfCode2016\Inputs\Puzzles\Day14Puzzle.txt");
                            break;
                        case 15:
                            _ = new Day15(@"..\..\..\..\AdventOfCode2016\Inputs\Puzzles\Day15Puzzle.txt");
                            break;
                        case 16:
                            _ = new Day16(@"..\..\..\..\AdventOfCode2016\Inputs\Puzzles\Day16Puzzle.txt", 272);
                            break;
                        case 17:
                            _ = new Day17(@"..\..\..\..\AdventOfCode2016\Inputs\Puzzles\Day17Puzzle.txt");
                            break;
                        case 18:
                            _ = new Day18(@"..\..\..\..\AdventOfCode2016\Inputs\Puzzles\Day18Puzzle.txt", 40);
                            break;
                        case 19:
                            _ = new Day19(@"..\..\..\..\AdventOfCode2016\Inputs\Puzzles\Day19Puzzle.txt");
                            break;
                        case 20:
                            _ = new Day20(@"..\..\..\..\AdventOfCode2016\Inputs\Puzzles\Day20Puzzle.txt", uint.MaxValue);
                            break;
                        case 21:
                            _ = new Day21(@"..\..\..\..\AdventOfCode2016\Inputs\Puzzles\Day21Puzzle.txt", "abcdefgh", "fbgdceah");
                            break;
                        case 22:
                            _ = new Day22(@"..\..\..\..\AdventOfCode2016\Inputs\Puzzles\Day22Puzzle.txt");
                            break;
                        case 23:
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