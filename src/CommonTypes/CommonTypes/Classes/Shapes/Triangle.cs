using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTypes.CommonTypes.Classes.Shapes
{
    public class Triangle : PolygonBase
    {
        public readonly int Hypotenuse = 0;
        public readonly int Adjacent = 0;
        public readonly int Opposite = 0;
        public Triangle(int adjacent, int opposite, int hypotenuse) : base(3)
        {
            Adjacent = adjacent;
            Opposite = opposite;
            Hypotenuse = hypotenuse;
        }
    }
}
