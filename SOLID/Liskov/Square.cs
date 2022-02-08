namespace SOLID.Liskov
{
    public class Square: IHasArea
    {
        public Square(int side)
        {
            Side = side;
        }

        private readonly int Side;

        public int Area => Side*Side;
    }
}