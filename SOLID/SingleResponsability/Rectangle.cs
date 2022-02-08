using System;
using System.Drawing;

namespace SOLID.SingleResponsability
{
    public class Rectangle
    {
        public readonly Point topLeft;
        public readonly Point bottomRight;
        public int Perimeter => 2 * (Width + Heigth);

        public int Area => Width * Heigth;

        public int Width => bottomRight.X - topLeft.X;

        public int Heigth => topLeft.Y - bottomRight.Y;

        public Rectangle(Point topLeft, Point bottomRight)
        {
            this.topLeft = topLeft;
            this.bottomRight = bottomRight;
            if (Width <= 0) throw new ArgumentException($"topLeft {topLeft} is not to the left of bottomRight ({bottomRight})");
            if (Heigth <= 0) throw new ArgumentException($"topLeft({topLeft}) is not to the top of bottomRight({bottomRight})");
        }       
    }

    public class DrawRectangle
    {
        private readonly Rectangle _rectangle;

        public DrawRectangle(Rectangle rectangle)
        {
            this._rectangle = rectangle;
        }
        public void Draw(System.Drawing.Graphics graphics)
        {
            //top horizontal line
            graphics.DrawLine(Pens.Black,
                _rectangle.topLeft.X, _rectangle.topLeft.Y,
                _rectangle.bottomRight.X, _rectangle.topLeft.Y
            );
            //bottom horizontal line
            graphics.DrawLine(Pens.Black,
                _rectangle.topLeft.X, _rectangle.bottomRight.Y,
                _rectangle.bottomRight.X, _rectangle.bottomRight.Y
            );
            //left vertical line
            graphics.DrawLine(Pens.Black,
                _rectangle.topLeft.X, _rectangle.topLeft.Y,
                _rectangle.topLeft.X, _rectangle.topLeft.Y - _rectangle.Heigth
            );
            //right vertical line
            graphics.DrawLine(Pens.Black,
                _rectangle.bottomRight.X, _rectangle.bottomRight.Y - _rectangle.Heigth,
                _rectangle.bottomRight.X, _rectangle.bottomRight.Y
            );
        }
    }

}
