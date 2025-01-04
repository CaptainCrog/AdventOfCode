using AdventOfCode2024.Problems;

public static class Menu2024 
{
    public static void Main(string[] args)
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
                            _ = new Day1(@"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\PuzzleInputs\AdventOfCode2024Day1PuzzleInput.txt");
                            break;
                        case 2:
                            _ = new Day2(@"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\PuzzleInputs\AdventOfCode2024Day2PuzzleInput.txt");
                            break;
                        case 3:
                            _ = new Day3(@"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\PuzzleInputs\AdventOfCode2024Day3PuzzleInput.txt");
                            break;
                        case 4:
                            _ = new Day4(@"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\PuzzleInputs\AdventOfCode2024Day4PuzzleInput.txt");
                            break;
                        case 5:
                            _ = new Day5(@"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\PuzzleInputs\AdventOfCode2024Day5PuzzleInput.txt");
                            break;
                        case 6:
                            _ = new Day6(@"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\PuzzleInputs\AdventOfCode2024Day6PuzzleInput.txt");
                            break;
                        case 7:
                            _ = new Day7(@"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\PuzzleInputs\AdventOfCode2024Day7PuzzleInput.txt");
                            break;
                        case 8:
                            _ = new Day8(@"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\PuzzleInputs\AdventOfCode2024Day8PuzzleInput.txt");
                            break;
                        case 9:
                            _ = new Day9(@"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\PuzzleInputs\AdventOfCode2024Day9PuzzleInput.txt");
                            break;
                        case 10:
                            _ = new Day10(@"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\PuzzleInputs\AdventOfCode2024Day10PuzzleInput.txt");
                            break;
                        case 11:
                            _ = new Day11(@"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\PuzzleInputs\AdventOfCode2024Day11PuzzleInput.txt");
                            break;
                        case 12:
                            _ = new Day12(@"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\PuzzleInputs\AdventOfCode2024Day12PuzzleInput.txt");
                            break;
                        case 13:
                            _ = new Day13(@"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\PuzzleInputs\AdventOfCode2024Day13PuzzleInput.txt");
                            break;
                        case 14:
                            _ = new Day14(@"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\PuzzleInputs\AdventOfCode2024Day14PuzzleInput.txt");
                            break;
                        case 15:
                            _ = new Day15(@"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\PuzzleInputs\AdventOfCode2024Day15PuzzleInput.txt");
                            break;
                        case 16:
                            _ = new Day16(@"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\PuzzleInputs\AdventOfCode2024Day16PuzzleInput.txt");
                            break;
                        case 17:
                            _ = new Day17(@"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\PuzzleInputs\AdventOfCode2024Day17PuzzleInput.txt");
                            break;
                        case 18:
                            _ = new Day18(@"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\PuzzleInputs\AdventOfCode2024Day18PuzzleInput.txt");
                            break;
                        case 19:
                            _ = new Day19(@"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\PuzzleInputs\AdventOfCode2024Day19PuzzleInput.txt");
                            break;
                        case 20:
                            _ = new Day20(@"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\PuzzleInputs\AdventOfCode2024Day20PuzzleInput.txt");
                            break;
                        case 21:
                            _ = new Day21(@"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\PuzzleInputs\AdventOfCode2024Day21PuzzleInput.txt");
                            break;
                        case 22:
                            _ = new Day22(@"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\PuzzleInputs\AdventOfCode2024Day22PuzzleInput.txt");
                            break;
                        case 23:
                            _ = new Day23(@"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\PuzzleInputs\AdventOfCode2024Day23PuzzleInput.txt");
                            break;
                        case 24:
                            _ = new Day24(@"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\PuzzleInputs\AdventOfCode2024Day24PuzzleInput.txt");
                            break;
                        case 25:
                            _ = new Day25(@"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\PuzzleInputs\AdventOfCode2024Day25PuzzleInput.txt");
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