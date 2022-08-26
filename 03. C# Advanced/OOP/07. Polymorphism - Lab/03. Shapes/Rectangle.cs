using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;
        public double Height
        {
            get { return height; }
            private set { height = value; }
        }
        public double Width
        {
            get { return width; }
            private set { width = value; }
        }
        public Rectangle(int height, int width)
        {
            Height = height;
            Width = width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Height + 2 * Width;
        }

        public override double CalculateArea()
        {
            return Height * Width;
        }

        public override string Draw()
        {
            return base.Draw() + "Rectangle";
        }
    }
}
