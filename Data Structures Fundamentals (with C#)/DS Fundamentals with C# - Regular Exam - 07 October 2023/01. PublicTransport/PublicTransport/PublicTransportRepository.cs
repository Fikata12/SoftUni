using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicTransportManagementSystem
{
    public class PublicTransportRepository : IPublicTransportRepository
    {
        public Dictionary<string, Passenger> Passengers = new Dictionary<string, Passenger>();
        public Dictionary<string, Bus> Buses = new Dictionary<string, Bus>();
        public Dictionary<string, string> PassengersBuses = new Dictionary<string, string>();

        public void RegisterPassenger(Passenger passenger)
        {
            Passengers.Add(passenger.Id, passenger);
        }

        public void AddBus(Bus bus)
        {
            Buses.Add(bus.Id, bus);
        }

        public bool Contains(Passenger passenger)
        {
            return Passengers.ContainsKey(passenger.Id);
        }

        public bool Contains(Bus bus)
        {
            return Buses.ContainsKey(bus.Id);
        }

        public IEnumerable<Bus> GetBuses()
        {
            return Buses.Values;
        }

        public void BoardBus(Passenger passenger, Bus bus)
        {
            if (Passengers[passenger.Id] == null || Buses[bus.Id] == null)
            {
                throw new ArgumentException();
            }

            PassengersBuses.Add(passenger.Id, bus.Id);
        }

        public void LeaveBus(Passenger passenger, Bus bus)
        {
            if (Passengers[passenger.Id] == null || Buses[bus.Id] == null || !PassengersBuses.Any(pb => pb.Key == passenger.Id && pb.Value == bus.Id))
            {
                throw new ArgumentException();
            }

            PassengersBuses.Remove(passenger.Id);
        }

        public IEnumerable<Passenger> GetPassengersOnBus(Bus bus)
        {
            return PassengersBuses
                .Where(pb => pb.Value == bus.Id)
                .Select(pb => Passengers[pb.Key])
                .ToList();
        }

        public IEnumerable<Bus> GetBusesOrderedByOccupancy()
        {
            return Buses
                .OrderBy(b => GetPassengersOnBus(b.Value).Count())
                .Select(b => b.Value);
        }

        public IEnumerable<Bus> GetBusesWithCapacity(int capacity)
        {
            return Buses
                .Where(b => b.Value.Capacity >= capacity)
                .Select(b => b.Value)
                .ToList();
        }
    }
}