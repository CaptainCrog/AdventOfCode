namespace CommonTypes.CommonTypes.Classes
{
    public class ThreeDimensionalObject
    {
        int _length = 0;
        int _width = 0;
        int _height = 0;

        public int Length
        {
            get => _length;
            set
            {
                if (_length != value)
                {
                    _length = value;
                }
            }
        }

        public int Width
        {
            get => _width;
            set
            {
                if (_width != value)
                {
                    _width = value;
                }
            }
        }
        public int Height
        {
            get => _height;
            set
            {
                if (_height != value)
                {
                    _height = value;
                }
            }
        }
        public ThreeDimensionalObject(int length, int width, int height) 
        {
            _length = length;
            _width = width;
            _height = height;
        }
    }
}
