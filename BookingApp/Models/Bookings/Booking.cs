using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Bookings
{
    public class Booking : IBooking
    {
        public Booking(IRoom room, int duration, int adults, int children, int bookingNumber)
        {
            Room = room;
            ResidenceDuration = duration;
            AdultsCount = adults;
            ChildrenCount = children;
            BookingNumber = bookingNumber;
        }

        private IRoom room;
        public IRoom Room
        {
            get => room;
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Room cannot be null.");
                }

                room = value;
            }
        }

        private int residenceDuration;
        public int ResidenceDuration
        {
            get => residenceDuration;
             set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Duration cannot be negative or zero!");
                }

                residenceDuration = value;
            }
        }

        private int adultsCount;
        public int AdultsCount
        {
            get => adultsCount;
             set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Adults count cannot be negative or zero!");
                }

                adultsCount = value;
            }
        }

        private int childrenCount;
        public int ChildrenCount
        {
            get => childrenCount;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Children count cannot be negative!");
                }

                childrenCount = value;
            }
        }

        private int bookingNumber;
        public int BookingNumber { get => bookingNumber; set => bookingNumber = value; } 

        public string BookingSummary()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Booking number: {this.BookingNumber}");
            sb.AppendLine($"Room type: {this.Room.GetType().Name}");
           // sb.AppendLine($"Room type: {this.Room.GetType().Name}");
            sb.AppendLine($"Adults: { this.AdultsCount} Children: { this.ChildrenCount}");
            var totalPaid = Math.Round(ResidenceDuration * this.Room.PricePerNight, 2);
            sb.AppendLine($"Total amount paid: { totalPaid:F2}$");
            return sb.ToString();
        }
        //public double TotalPaid()
        //{
        //    var totalPaid = Math.Round(ResidenceDuration * this.Room.PricePerNight, 2);
        //    return totalPaid;
        //}

    }
}
