using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private readonly PilotRepository pilotRepository;
        private readonly RaceRepository raceRepository;
        private readonly FormulaOneCarRepository carRepository;
        public Controller()
        {
            this.pilotRepository = new PilotRepository();
            this.raceRepository = new RaceRepository();
            this.carRepository = new FormulaOneCarRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = pilotRepository.FindByName(pilotName);
            IFormulaOneCar car = carRepository.FindByName(carModel);
            if (pilot != null && pilot.CanRace == false)
            {
                if (car != null)
                {
                    pilot.AddCar(car);
                    carRepository.Remove(car);
                    return string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, pilot.Car.GetType().Name, carModel);
                }
                throw new NullReferenceException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }
            throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IPilot pilot = pilotRepository.FindByName(pilotFullName);
            IRace race = raceRepository.FindByName(raceName);
            if (race != null)
            {
                if (pilot != null && pilot.CanRace && !race.Pilots.Any(p => p.FullName == pilotFullName))
                {
                    race.AddPilot(pilot);
                    return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
                }
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }
            throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (carRepository.FindByName(model) == null)
            {
                if (type == "Ferrari")
                {
                    carRepository.Add(new Ferrari(model, horsepower, engineDisplacement));
                    return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
                }
                else if (type == "Williams")
                {
                    carRepository.Add(new Williams(model, horsepower, engineDisplacement));
                    return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
                }
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }
            throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
        }

        public string CreatePilot(string fullName)
        {
            if (pilotRepository.FindByName(fullName) == null)
            {
                pilotRepository.Add(new Pilot(fullName));
                return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
            }
            throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (raceRepository.FindByName(raceName) == null)
            {
                raceRepository.Add(new Race(raceName, numberOfLaps));
                return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
            }
            throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
        }

        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var pilot in pilotRepository.Models.OrderByDescending(p => p.NumberOfWins))
            {
                sb.AppendLine(pilot.ToString());
            }
            return sb.ToString().Trim();
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var race in raceRepository.Models.Where(r => r.TookPlace == true))
            {
                sb.AppendLine(race.RaceInfo());
            }
            return sb.ToString().Trim();
        }

        public string StartRace(string raceName)
        {
            IRace race = raceRepository.FindByName(raceName);
            if (race != null)
            {
                if (race.Pilots.Count >= 3)
                {
                    if (!race.TookPlace)
                    {
                        race.TookPlace = true;
                        StringBuilder sb = new StringBuilder();
                        IPilot[] orderedPilots = race.Pilots.OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps)).ToArray();
                        orderedPilots[0].WinRace();
                        sb.AppendLine(string.Format(OutputMessages.PilotFirstPlace, orderedPilots[0].FullName, raceName));
                        sb.AppendLine(string.Format(OutputMessages.PilotSecondPlace, orderedPilots[1].FullName, raceName));
                        sb.Append(string.Format(OutputMessages.PilotThirdPlace, orderedPilots[2].FullName, raceName));
                        return sb.ToString();
                    }
                    throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
                }
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }
            throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
        }
    }
}
