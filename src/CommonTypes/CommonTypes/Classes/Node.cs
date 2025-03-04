using CommonTypes.CommonTypes.Enums;

namespace CommonTypes.CommonTypes.Classes
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


        public  bool Equals(object obj)
        {
            return obj is Node node && X == node.X && Y == node.Y;
        }

        public  int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}
