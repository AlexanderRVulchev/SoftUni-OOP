using System;


namespace _01._Class_Box_Data
{
    public class Box
    {
        // Fields
        private double length;
        private double width;
        private double height;

        // Properties        
        public double Length
        {
            get { return length; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Length cannot be zero or negative.");
                length = value;
            }
        }

        public double Width
        {
            get { return width; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Width cannot be zero or negative.");
                width = value;
            }
        }

        public double Height
        {
            get { return height; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Height cannot be zero or negative.");
                height = value;
            }
        }

        // Constructors
        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        // Methods
        public double SurfaceArea()
        => 2 * (length * height + width * height + width * length);

        public double LateralSurfaceArea()
        => 2 * (width * height + height * length);

        public double Volume()
        => length * width * height;

        public override string ToString()
        => $"Surface Area - {SurfaceArea():f2}" + Environment.NewLine +
           $"Lateral Surface Area - {LateralSurfaceArea():f2}" + Environment.NewLine +
           $"Volume - {Volume():f2}";
    }
}

