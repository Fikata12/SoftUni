using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RawData
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; }
        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, 
            string cargoType, double tire1Pressure, int tire1Age, double tire2Pressure, 
            int tire2Age, double tire3Pressure, int tire3Age, double tire4Pressure, int tire4Age)
        {
            Model = model;
            Engine = new Engine(engineSpeed, enginePower);
            Cargo = new Cargo(cargoType, cargoWeight);
            Tires = new Tire[]
            {
                new Tire(tire1Age, tire1Pressure),
                new Tire(tire2Age, tire2Pressure),
                new Tire(tire3Age, tire3Pressure),
                new Tire(tire4Age, tire4Pressure),
            };
        }
    }
}

