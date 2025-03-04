namespace CommonTypes.CommonTypes.Classes.Shapes
{
    public abstract class PolygonBase
    {
        protected readonly int NumberOfSides;
        protected PolygonBase(int numberOfSides)
        {
            NumberOfSides = numberOfSides;
        }
    }
}
