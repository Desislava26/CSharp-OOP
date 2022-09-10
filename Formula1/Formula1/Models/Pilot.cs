using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Pilot: IPilot
    {
        //private string fullname;
        //private IFormulaOneCar car;
        //private int numberOfWins;
        //private bool canRace = false;

        //public Pilot(string fullName)
        //{
        //    FullName = fullName;
        //}

        //public string FullName
        //{
        //    get => fullname;
        //    set
        //    {
        //        if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
        //        {
        //            throw new ArgumentException($"Invalid pilot name: { fullname }.");
        //        }

        //        fullname = value;
        //    }
        //}

        //public IFormulaOneCar Car
        //{
        //    get => car;
        //    set
        //    {
        //        if (value == null)
        //        {
        //            throw new ArgumentException("Pilot car can not be null.");
        //        }

        //        car = value;
        //    }
        //}

        //public int NumberOfWins
        //{get;set;}

        //public bool CanRace
        //{
        //    get => canRace;
        //    set => canRace = value;
        //}

        //public void AddCar(IFormulaOneCar car)
        //{
        //    this.Car = car;
        //    this.CanRace = true;

        //}

        //public void WinRace()
        //{
        //    this.NumberOfWins++;
        //}
        //public override string ToString()
        //{
        //    return $"Pilot { FullName } has { NumberOfWins } wins.";
        //}
        private string fullName;
        private bool canRace = false;
        private IFormulaOneCar car;

        public Pilot(string fullName)
        {
            FullName = fullName;
        }

        public string FullName
        {
            get => fullName;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPilot, value));
                }
                fullName = value;
            }
        }

        public IFormulaOneCar Car
        {
            get => car;
            set
            {
                if (value == null)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidCarForPilot));
                }

                car = value;
            }
        }
        public int NumberOfWins { get; set; }

        public bool CanRace
        {
            get => canRace;
            set => canRace = value;
        }

        public void AddCar(IFormulaOneCar car)
        {
            this.Car = car;
            this.CanRace = true;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }

        public override string ToString()
        {
            return $"Pilot {this.FullName} has {this.NumberOfWins} wins.";
        }
    }
}
