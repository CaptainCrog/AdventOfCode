using AdventOfCode2025.Problems;

public static class Menu2025
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Choose which problem to solve (Options between 1 - 12)");
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
                            _ = new Day01(@"..\..\..\..\AdventOfCode2025\Inputs\Puzzles\Day01Puzzle.txt");
                            break;
                        case 2:
                            _ = new Day02(@"..\..\..\..\AdventOfCode2025\Inputs\Puzzles\Day02Puzzle.txt");
                            break;
                        case 3:
                            //_ = new Day03(@"..\..\..\..\AdventOfCode2025\Inputs\Puzzles\Day03Puzzle.txt");
                            break;
                        case 4:
                           // _ = new Day04(@"..\..\..\..\AdventOfCode2025\Inputs\Puzzles\Day04Puzzle.txt");
                            break;
                        case 5:
                            //_ = new Day05(@"..\..\..\..\AdventOfCode2025\Inputs\Puzzles\Day05Puzzle.txt");
                            break;
                        case 6:
                           // _ = new Day06(@"..\..\..\..\AdventOfCode2025\Inputs\Puzzles\Day06Puzzle.txt");
                            break;
                        case 7:
                            //_ = new Day07(@"..\..\..\..\AdventOfCode2025\Inputs\Puzzles\Day07Puzzle.txt");
                            break;
                        case 8:
                           // _ = new Day08(@"..\..\..\..\AdventOfCode2025\Inputs\Puzzles\Day08Puzzle.txt");
                            break;
                        case 9:
                           // _ = new Day09(@"..\..\..\..\AdventOfCode2025\Inputs\Puzzles\Day09Puzzle.txt");
                            break;
                        case 10:
                          //  _ = new Day10(@"..\..\..\..\AdventOfCode2025\Inputs\Puzzles\Day10Puzzle.txt");
                            break;
                        case 11:
                           // _ = new Day11(@"..\..\..\..\AdventOfCode2025\Inputs\Puzzles\Day11Puzzle.txt");
                            break;
                        case 12:
                          //  _ = new Day12(@"..\..\..\..\AdventOfCode2025\Inputs\Puzzles\Day12Puzzle.txt");
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