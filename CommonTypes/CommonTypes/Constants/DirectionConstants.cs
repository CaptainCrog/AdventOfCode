using CommonTypes.CommonTypes.Enums;

namespace CommonTypes.CommonTypes.Constants
{
    public static class DirectionConstants
    {
        public static (int dx, int dy, Direction direction)[] GetBasicDirections()
        {
            return new (int, int, Direction)[]
            {
                (0, 1, Direction.East),   // Right
                (1, 0, Direction.South),  // Down
                (0, -1, Direction.West),  // Left
                (-1, 0, Direction.North)  // Up
            };
        }
    }
}
