using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TravelledDistance = 0;
        }
        public void Drive(Car car, double amountOfKm)
        {
            if (car.FuelAmount >= car.FuelConsumptionPerKilometer * amountOfKm)
            {
                car.FuelAmount -= car.FuelConsumptionPerKilometer * amountOfKm;
                car.TravelledDistance += amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}

