using BookingApp.Models.Rooms.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Rooms
{
    public abstract class Room : IRoom
    {
        protected Room(int bedCapacity)
        {
            BedCapacity = bedCapacity;
            
        }

        private int bedCapacity;
        public int BedCapacity
        {
            get => bedCapacity;
             set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid");
                }

                bedCapacity = value;
            }
        }

        private double priceForNight = 0;
        public double PricePerNight
        {
            get => priceForNight;
             set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative!");
                }
                
                priceForNight = value;
            }
        }
        //private bool isItSetted = false;
        public bool IsItSetted { get; set ; } = false;
        public void SetPrice(double price)
        {
            this.PricePerNight = price;
            
        }
    }
}
