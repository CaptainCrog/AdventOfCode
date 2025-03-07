using AdventOfCode2017.Problems;
using System.Drawing;

public static class Menu2017
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
                            _ = new Day01(@"..\..\..\..\AdventOfCode2017\Inputs\Puzzles\Day01Puzzle.txt");
                            break;
                        case 2:
                            _ = new Day02(@"..\..\..\..\AdventOfCode2017\Inputs\Puzzles\Day02Puzzle.txt");
                            break;
                        case 3:
                            _ = new Day03(@"..\..\..\..\AdventOfCode2017\Inputs\Puzzles\Day03Puzzle.txt");
                            break;
                        case 4:
                            _ = new Day04(@"..\..\..\..\AdventOfCode2017\Inputs\Puzzles\Day04Puzzle.txt");
                            break;
                        case 5:
                            _ = new Day05(@"..\..\..\..\AdventOfCode2017\Inputs\Puzzles\Day05Puzzle.txt");
                            break;
                        case 6:
                            _ = new Day06(@"..\..\..\..\AdventOfCode2017\Inputs\Puzzles\Day06Puzzle.txt");
                            break;
                        case 7:
                            _ = new Day07(@"..\..\..\..\AdventOfCode2017\Inputs\Puzzles\Day07Puzzle.txt");
                            break;
                        case 8:
                            _ = new Day08(@"..\..\..\..\AdventOfCode2017\Inputs\Puzzles\Day08Puzzle.txt");
                            break;
                        case 9:
                            _ = new Day09(@"..\..\..\..\AdventOfCode2017\Inputs\Puzzles\Day09Puzzle.txt");
                            break;
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