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
                            _ = new Day1(@"..\..\..\..\AdventOfCode2016\Inputs\Puzzles\Day1Puzzle.txt");
                            break;
                        case 2:
                            _ = new Day2(@"..\..\..\..\AdventOfCode2016\Inputs\Puzzles\Day2Puzzle.txt");
                            break;
                        case 3:
                            _ = new Day3(@"..\..\..\..\AdventOfCode2016\Inputs\Puzzles\Day3Puzzle.txt");
                            break;
                        case 4:
                            _ = new Day4(@"..\..\..\..\AdventOfCode2016\Inputs\Puzzles\Day4Puzzle.txt", "northpole");
                            break;
                        case 5:
                            _ = new Day5(@"..\..\..\..\AdventOfCode2016\Inputs\Puzzles\Day5Puzzle.txt");
                            break;
                        case 6:
                            _ = new Day6(@"..\..\..\..\AdventOfCode2016\Inputs\Puzzles\Day6Puzzle.txt");
                            break;
                        case 7:
                            _ = new Day7(@"..\..\..\..\AdventOfCode2016\Inputs\Puzzles\Day7Puzzle.txt");
                            break;
                        case 8:
                            _ = new Day8(@"..\..\..\..\AdventOfCode2016\Inputs\Puzzles\Day8Puzzle.txt", 6, 50);
                            break;
                        case 9:
                            _ = new Day9(@"..\..\..\..\AdventOfCode2016\Inputs\Puzzles\Day9Puzzle.txt");
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
                        case 18:
                        case 19:
                        case 20:
                        case 21:
                        case 22:
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