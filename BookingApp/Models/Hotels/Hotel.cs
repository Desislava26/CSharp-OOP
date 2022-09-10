using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Models.Hotels
{
    public class Hotel : IHotel
    {
        private RoomRepository rooms;
        private BookingRepository bookings;
        private List<IRoom> roms = new List<IRoom>();
        //private IRepository<IBooking> bookings;
        public Hotel(string fullName, int category)
        {
            FullName = fullName;
            Category = category;
            rooms = new RoomRepository();
            bookings = new BookingRepository();
            //Turnover = turnover;
            
            
        }

        private string fullName;
        public string FullName
        {
            get => fullName;
             set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hotel name cannot be null or empty!");
                }

                fullName = value;
            }
        }

        private int category;   
        public int Category
        {
            get => category;
            set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException("Category should be between 1 and 5 stars!");
                }

                category = value;
            }
        }

        //private double turnover;
        public double Turnover
        {
            get
            {
                return TurnoverSett();
                
            }
        }

        //{
        //    get => turnover;
        //    set
        //    {
        //        //var sum = 0.0;
        //        //foreach (var item in this.Bookings.All())
        //        //{
        //        //    var residence = item.ResidenceDuration;
        //        //    var priceRoom = item.Room.PricePerNight;
        //        //    sum =+ (double)residence * (double)priceRoom;
        //        //}
        //        //value = Math.Round(sum,2);
        //        value = TurnoverSett();
        //        turnover = value;
        //    }
        //}

        public IRepository<IRoom> Rooms// => rooms; 
        {
            get => rooms;
            set => rooms.All().ToList();//throw new NotImplementedException();

        }
        public IRepository<IBooking> Bookings //=> bookings;
        { get => bookings;
            //set => throw new NotImplementedException(); }
            set => bookings.All().ToList();//throw new NotImplementedException();

        }
        public double TurnoverSett()
        {
            decimal sum = 0;
            decimal sum1 = 0;
            foreach (var item in this.Bookings.All().Where(x=>x.Room.PricePerNight >0))
            {
                var residence = item.ResidenceDuration;
                var priceRoom = item.Room.PricePerNight;
                sum =((decimal)residence * (decimal)priceRoom);
                sum1 += sum;
            }
            double sum2 = (double)sum1;
            return Math.Round(sum2, 2);

        }

    }
}
