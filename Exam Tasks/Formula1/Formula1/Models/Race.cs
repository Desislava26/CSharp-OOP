﻿using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Race : IRace
    {
        //private string raceName;
        //private int numberOfLaps;
        //private ICollection<IPilot> pilots;
        //private bool tookPlace = false;

        //public Race(string raceName, int numberOfLaps)
        //{
        //    RaceName = raceName;
        //    NumberOfLaps = numberOfLaps;
        //    pilots = new List<IPilot>();
        //}

        //public string RaceName
        //{
        //    get => raceName;
        //    set
        //    {
        //        if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
        //        {
        //            throw new ArgumentException($"Invalid race name: { raceName }.");
        //        }

        //        raceName = value;
        //    }
        //}


        //public int NumberOfLaps
        //{
        //    get => numberOfLaps;
        //    set
        //    {
        //        if (value < 1)
        //        {
        //            throw new ArgumentException($"Invalid lap numbers: { numberOfLaps }.");
        //        }
        //        numberOfLaps = value;
        //    }
        //}
        //public bool TookPlace
        //{
        //    get => tookPlace;
        //    set => tookPlace = value;
        //}

        //public ICollection<IPilot> Pilots
        //{
        //    get => pilots;
        //    set
        //    {
        //        pilots = new List<IPilot>();
        //        pilots = value;
        //    }
        //}

        //public void AddPilot(IPilot pilot)
        //{
        //    pilots.Add(pilot);
        //}

        //public string RaceInfo()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine($"The { RaceName } race has:");
        //    sb.AppendLine($"Participants: { Pilots.Count }");
        //    string yesOrNo = "";
        //    if(TookPlace == false)
        //    {
        //        yesOrNo = "No";
        //    }
        //    else
        //    {
        //        yesOrNo = "Yes";
        //    }
        //    sb.AppendLine($"Number of laps: {NumberOfLaps}");
        //    sb.AppendLine($"Took place: {yesOrNo}");
        //    return sb.ToString();
        //}
        private string raceName;
        private int numberOfLaps;
        private bool tookPlace = false;
        private ICollection<IPilot> pilots;

        public Race(string raceName, int numberOfLaps)
        {
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;
            pilots = new List<IPilot>();
        }

        public string RaceName
        {
            get => raceName;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }
                raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get => numberOfLaps;
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));
                }
                numberOfLaps = value;
            }
        }

        public bool TookPlace
        {
            get => tookPlace;
            set => tookPlace = value;
        }

        public ICollection<IPilot> Pilots => pilots;
        public void AddPilot(IPilot pilot)
        {
            pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            string raceDidHappen = string.Empty;
            raceDidHappen = TookPlace == true ? "Yes" : "No";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The {this.RaceName} race has:");
            sb.AppendLine($"Participants: {Pilots.Count}");
            sb.AppendLine($"Number of laps: {NumberOfLaps}");
            sb.AppendLine($"Took place: {raceDidHappen}");

            return sb.ToString().TrimEnd();
        }
    }
}
