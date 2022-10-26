using System;


namespace Cars
{
    public class Seat : ICar
    {
        public string Model { get; set; }
        public string Color { get; set; }

        public Seat(string model, string color)
        {
            this.Color = color;
            this.Model = model;
        }

        public string Start()
        => "Engine start";


        public string Stop()
        => "Breaaak!";

        public override string ToString()
        => $"{this.Color} Seat {this.Model}" + Environment.NewLine +
            this.Start() + Environment.NewLine +
            this.Stop();
    }
}
