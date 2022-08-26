using System;
using System.Collections.Generic;
using System.Text;

namespace Box
{
    public class Box
    {
        private const int BoxPropMinValue = 0;
        private const string ZeroOrNegativeException = "{0} cannot be zero or negative.";
        private double length;
        private double width;
        private double height;

        public double Length
        {
            get { return length; }
            private set 
            {
                if (value > BoxPropMinValue)
                {
                    length = value;
                }
                else
                {
                    throw new ArgumentException(String.Format(ZeroOrNegativeException, nameof(Length)));
                }
            }
        }
        public double Width
        {
            get { return width; }
            private set
            {
                if (value > BoxPropMinValue)
                {
                    width = value;
                }
                else
                {
                    throw new ArgumentException(String.Format(ZeroOrNegativeException, nameof(Width)));
                }
            }
        }
        public double Height
        {
            get { return height; }
            private set
            {
                if (value > BoxPropMinValue)
                {
                    height = value;
                }
                else
                {
                    throw new ArgumentException(String.Format(ZeroOrNegativeException, nameof(Height)));
                }
            }
        }
        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }
        public double SurfaceArea()
        {
            return 2 * Length * Width + 2 * Length * Height + 2 * Width * Height;
        }
        public double LateralSurfaceArea()
        {
            return 2 * Length * Height + 2 * Width * Height;
        }
        public double Volume()
        {
            return Length * Width * Height;
        }
        public override string ToString()
        {
            return $"Surface Area - {SurfaceArea():f2}" + Environment.NewLine +
                   $"Lateral Surface Area - {LateralSurfaceArea():f2}" + Environment.NewLine +
                   $"Volume - {Volume():f2}";
        }
    }
}
