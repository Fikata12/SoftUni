using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }
        public Car()
        {
            Weight = 0;
            Color = "n/a";
        }

        public Car(string model, Engine engine) : this()
        {
            Model = model;
            Engine = engine;
        }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"{Model}:");
            output.AppendLine($"  {Engine.Model}:");
            output.AppendLine($"    Power: {Engine.Power}");
            if (Engine.Displacement != 0)
            {
                output.AppendLine($"    Displacement: {Engine.Displacement}");
            }
            else
            {
                output.AppendLine($"    Displacement: n/a");
            }
            output.AppendLine($"    Efficiency: {Engine.Efficiency}");
            if (Weight != 0)
            {
                output.AppendLine($"  Weight: {Weight}");
            }
            else
            {
                output.AppendLine($"  Weight: n/a");
            }
            output.Append($"  Color: {Color}");
            return output.ToString();
        }

    }
}

