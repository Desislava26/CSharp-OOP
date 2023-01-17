using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private FormulaOneCarRepository formulaCarRepo;
        private PilotRepository pilotRepo;
        private RaceRepository raceRepo;
        public Controller()
        {
            formulaCarRepo = new FormulaOneCarRepository();
            pilotRepo = new PilotRepository();
            raceRepo = new RaceRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            var pilot = pilotRepo.FindByName(pilotName);
            var car = formulaCarRepo.FindByName(carModel);
            if (pilot == null || pilot.Car != null)
            {
                throw new InvalidOperationException($"Pilot { pilotName } does not exist or has a car.");
            }
            if (car == null)
            {
                throw new NullReferenceException($"Car { car.Model } does not exist.");
            }


            pilot.AddCar(car);
            formulaCarRepo.Remove(car);
            return $"Pilot { pilot.FullName } will drive a {car.GetType().Name} { car.Model } car.";


        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            var pilot = pilotRepo.FindByName(pilotFullName);
            var race = raceRepo.FindByName(raceName);
            if (race == null)
            {
                throw new NullReferenceException($"Race { raceName } does not exist.");
            }
            if (pilot == null || pilot.CanRace == false || race.Pilots.Any(p => p.FullName == pilotFullName))
            {
                throw new InvalidOperationException($"Can not add pilot { pilotFullName } to the race.");
            }

            race.AddPilot(pilot);
            return $"Pilot { pilotFullName } is added to the { raceName } race.";


        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            var car = formulaCarRepo.FindByName(model);
            if (car != null)
            {
                throw new InvalidOperationException($"Formula one car { model } is already created.");
            }
            if (type == "Ferrari")
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else if (type == "Williams")
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }
            formulaCarRepo.Add(car);
            return $"Car { type }, model { model } is created.";
        }

        public string CreatePilot(string fullName)
        {
            if (pilotRepo.FindByName(fullName) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            Pilot pilot = new Pilot(fullName);

            pilotRepo.Add(pilot);
            return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            var race = raceRepo.FindByName(raceName);

            if (race != null)
            {
                throw new InvalidOperationException($"Race { raceName } is already created.");
            }
            Race race1 = new Race(raceName, numberOfLaps);
            raceRepo.Add(race1);
            return $"Race { raceName } is created.";
        }

        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var pilot in pilotRepo.Models.OrderByDescending(x => x.NumberOfWins))
            {
                sb.AppendLine(pilot.ToString());
            }
            return sb.ToString().Trim();
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var race in raceRepo.Models.Where(x => x.TookPlace == true))
            {
                sb.AppendLine(race.RaceInfo());
            }
            return sb.ToString().Trim();
        }

        public string StartRace(string raceName)
        {
            var race = raceRepo.FindByName(raceName);

            if (race == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }

            if (race.TookPlace == true)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            race.TookPlace = true;

            List<IPilot> ordered = race.Pilots.OrderByDescending(r => r.Car.RaceScoreCalculator(race.NumberOfLaps)).Take(3).ToList();

            IPilot winner = ordered[0];
            winner.WinRace();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format(OutputMessages.PilotFirstPlace, winner.FullName, race.RaceName));
            sb.AppendLine(String.Format(OutputMessages.PilotSecondPlace, ordered[1].FullName, race.RaceName));
            sb.AppendLine(String.Format(OutputMessages.PilotThirdPlace, ordered[2].FullName, race.RaceName));
            return sb.ToString();
        }
        public void Exit()
        {
            return;
        }
        //private PilotRepository pilotRepository;
        //private RaceRepository raceRepository;
        //private FormulaOneCarRepository formulaOneCarRepository;
        //public Controller()
        //{
        //    pilotRepository = new PilotRepository();
        //    raceRepository = new RaceRepository();
        //    formulaOneCarRepository = new FormulaOneCarRepository();
        //}
        //public string CreatePilot(string fullName)
        //{

        //    if (pilotRepository.FindByName(fullName) != null)
        //    {
        //        throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
        //    }

        //    Pilot pilot = new Pilot(fullName);

        //    pilotRepository.Add(pilot);
        //    return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        //}

        //public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        //{
        //    IFormulaOneCar car;

        //    if (type == "Ferrari")
        //    {
        //        car = new Ferrari(model, horsepower, engineDisplacement);
        //    }
        //    else if (type == "Williams")
        //    {
        //        car = new Williams(model, horsepower, engineDisplacement);
        //    }
        //    else
        //    {
        //        throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
        //    }

        //    if (formulaOneCarRepository.FindByName(model) != null)
        //    {
        //        throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
        //    }

        //    formulaOneCarRepository.Add(car);
        //    return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        //}

        //public string CreateRace(string raceName, int numberOfLaps)
        //{
        //    if (raceRepository.FindByName(raceName) != null)
        //    {
        //        throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
        //    }

        //    Race race = new Race(raceName, numberOfLaps);
        //    raceRepository.Add(race);

        //    return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        //}

        //public string AddCarToPilot(string pilotName, string carModel)
        //{
        //    IPilot pilot = pilotRepository.FindByName(pilotName);
        //    IFormulaOneCar car = formulaOneCarRepository.FindByName(carModel);

        //    if (pilot == null || pilot.Car != null)
        //    {
        //        throw new InvalidOperationException(
        //            string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
        //    }

        //    if (car == null)
        //    {
        //        throw new NullReferenceException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage,
        //            carModel));
        //    }

        //    pilot.AddCar(car);
        //    formulaOneCarRepository.Remove(car);

        //    return string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel);
        //}

        //public string AddPilotToRace(string raceName, string pilotFullName)
        //{
        //    IRace race = raceRepository.FindByName(raceName);
        //    IPilot pilot = pilotRepository.FindByName(pilotFullName);

        //    if (race == null)
        //    {
        //        throw new NullReferenceException(
        //            string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
        //    }

        //    if (pilot == null || pilot.CanRace == false || race.Pilots.Any(p => p.FullName == pilotFullName))
        //    {
        //        throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistErrorMessage,
        //            pilotFullName));
        //    }

        //    race.Pilots.Add(pilot);
        //    return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        //}

        //public string StartRace(string raceName)
        //{
        //    var race = raceRepository.FindByName(raceName);

        //    if (race == null)
        //    {
        //        throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
        //    }

        //    if (race.Pilots.Count < 3)
        //    {
        //        throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
        //    }

        //    if (race.TookPlace == true)
        //    {
        //        throw new InvalidOperationException(
        //            string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
        //    }

        //    race.TookPlace = true;

        //    List<IPilot> ordered = race.Pilots.OrderByDescending(r => r.Car.RaceScoreCalculator(race.NumberOfLaps)).Take(3).ToList();

        //    IPilot winner = ordered[0];
        //    winner.WinRace();

        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine(String.Format(OutputMessages.PilotFirstPlace, winner.FullName, race.RaceName));
        //    sb.AppendLine(String.Format(OutputMessages.PilotSecondPlace, ordered[1].FullName, race.RaceName));
        //    sb.AppendLine(String.Format(OutputMessages.PilotThirdPlace, ordered[2].FullName, race.RaceName));

        //    return sb.ToString().TrimEnd();
        //}

        //public string RaceReport()
        //{
        //    List<IRace> finishedRaces = raceRepository.Models.Where(r => r.TookPlace == true).ToList();

        //    var sb = new StringBuilder();
        //    foreach (var race in finishedRaces)
        //    {
        //        sb.AppendLine(race.RaceInfo());
        //    }

        //    return sb.ToString().TrimEnd();
        //}

        //public string PilotReport()
        //{
        //    var orderedPilots = pilotRepository.Models.OrderByDescending(p => p.NumberOfWins);

        //    var sb = new StringBuilder();

        //    foreach (var pilot in orderedPilots)
        //    {
        //        sb.AppendLine(pilot.ToString());
        //    }

        //    return sb.ToString().TrimEnd();
        //}
    }
}
