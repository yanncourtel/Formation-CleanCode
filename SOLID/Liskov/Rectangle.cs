namespace SOLID.Liskov
{
    public class Rectangle: IHasArea
    {
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        private int Width { get; set; }
        private int Height { get; set; }

        public int Area => Height * Width;
    }
}