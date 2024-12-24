using AdventOfCode2024.CommonTypes.Enums;

namespace AdventOfCode2024.CommonTypes.Classes
{
    /// <summary>
    /// Used for Shortest Path Algorithm
    /// </summary>
    public class Node
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Cost { get; set; }
        public Direction Direction { get; set; }
    }
}
