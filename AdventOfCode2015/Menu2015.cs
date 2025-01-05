using AdventOfCode2015.Problems;

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
                            _ = new Day1(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day1Puzzle.txt");
                            break;
                        case 2:
                            _ = new Day2(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day2Puzzle.txt");
                            break;
                        case 3:
                            _ = new Day3(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day3Puzzle.txt");
                            break;
                        case 4:
                            _ = new Day4(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day4Puzzle.txt");
                            break;
                        case 5:
                            _ = new Day5(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day5Puzzle.txt");
                            break;
                        case 6:
                            _ = new Day6(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day6Puzzle.txt");
                            break;
                        case 7:
                            _ = new Day7(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day7Puzzle.txt");
                            break;
                        case 8:
                            _ = new Day8(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day8Puzzle.txt");
                            break;
                        case 9:
                            _ = new Day9(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day9Puzzle.txt");
                            break;
                        case 10:
                            _ = new Day10(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day10Puzzle.txt");
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
                            _ = new Day14(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day14Puzzle.txt");
                            break;
                        case 15:
                            _ = new Day15(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day15Puzzle.txt");
                            break;
                        case 16:
                            _ = new Day16(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day16Puzzle.txt");
                            break;
                        case 17:
                            _ = new Day17(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day17Puzzle.txt");
                            break;
                        case 18:
                            _ = new Day18(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day18Puzzle.txt", 1024);
                            break;
                        case 19:
                            _ = new Day19(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day19Puzzle.txt");
                            break;
                        case 20:
                            _ = new Day20(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day20Puzzle.txt", 100);
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
                            _ = new Day24(@"..\..\..\..\AdventOfCode2015\Inputs\Puzzles\Day24Puzzle.txt", "z45");
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