using AdventOfCode2024;
public class Shell
{
    private static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Choose a year to navigate (Options between 15 - 24)");
            Console.WriteLine("Press Q to quit the application");
            var choiceRaw = Console.ReadLine();
            if (choiceRaw != null)
            {
                if (int.TryParse(choiceRaw, out var choiceSanitised))
                {
                    Console.WriteLine($"Running Day {choiceSanitised} Problem");
                    switch (choiceSanitised)
                    {
                        case 15:
                            break;
                        case 16:
                            Console.WriteLine("Option is out of bound or unavailable at the moment");
                            break;
                        case 17:
                            Console.WriteLine("Option is out of bound or unavailable at the moment");
                            break;
                        case 18:
                            Console.WriteLine("Option is out of bound or unavailable at the moment");
                            break;
                        case 19:
                            Console.WriteLine("Option is out of bound or unavailable at the moment");
                            break;
                        case 20:
                            Console.WriteLine("Option is out of bound or unavailable at the moment");
                            break;
                        case 21:
                            Console.WriteLine("Option is out of bound or unavailable at the moment");
                            break;
                        case 22:
                            Console.WriteLine("Option is out of bound or unavailable at the moment");
                            break;
                        case 23:
                            Console.WriteLine("Option is out of bound or unavailable at the moment");
                            break;
                        case 24:
                            Menu2024.Main([]);
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