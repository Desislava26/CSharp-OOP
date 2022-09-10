using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private HotelRepository hotelRepo;
     
        public Controller()
        {
            hotelRepo = new HotelRepository();
           
  
        }
        public string AddHotel(string hotelName, int category)
        {
            IHotel hotel = null;
           
            foreach (var item in hotelRepo.All())
            {
                if (item.FullName == hotelName)
                {
                    hotel = item;
                }
            }
            if (hotel != null)
            {
                return $"Hotel {hotelName} is already registered in our platform.";
            }
            hotel = new Hotel(hotelName, category);
            hotelRepo.AddNew(hotel);
            return $"{category} stars hotel {hotelName} is registered in our platform and expects room availability to be uploaded.";
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            IBooking book = null;
           IHotel hotel = null;
            IRoom room = null;
            List<Hotel> hotelList = new List<Hotel>();
            int countBook = 0;
            foreach (var item in hotelRepo.All())
            {
                hotelList.Add((Hotel)item);
            }
            foreach (var item in hotelList.OrderBy(x => x.FullName))
            {
                if (item.Category == category) { 
                    List<Room> rooms = new List<Room>();
                    foreach (var rom in item.Rooms.All().Where(x => x.PricePerNight > 0))
                    {
                        rooms.Add((Room)rom);
                    }
                    if(rooms.Count == 0)
                    {
                        continue;
                    }
                    rooms = rooms.OrderBy(x => x.BedCapacity).ToList();
                    room = rooms.First(x => x.BedCapacity >= adults + children);

                    if (room != null)
                    {

                        hotel = item;
                        countBook = hotel.Bookings.All().Count();
                        
                        break;
                    }
                }
                
            }
                    
            
            if(hotel == null)
            {
                return $"{category} star hotel is not available in our platform.";
            }
            if (room == null)
            {
                return $"We cannot offer appropriate room for your request.";
            }
            
            book = new Booking(room, duration, adults, children, hotel.Bookings.All().Count()+1);
          
            hotel.Bookings.AddNew(book);
           
            
           
            return $"Booking number {book.BookingNumber} for {hotel.FullName} hotel is successful!";
        }

        public string HotelReport(string hotelName)
        {
            IHotel hotel = null;
            foreach (var item in hotelRepo.All())
            {
                if (item.FullName == hotelName)
                {
                    hotel = item;
                }
            }
            if(hotel == null)
            {
                return $"Profile {hotelName} doesn’t exist!";
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Hotel name: {hotelName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:F2} $");
            if (hotel.Bookings.All().Count == 0)
            {
                sb.AppendLine($"--Bookings:");
                sb.AppendLine();
                sb.AppendLine($"none");
                return sb.ToString();
            }
            sb.AppendLine($"--Bookings:");
            sb.AppendLine();
        
            foreach (var item in hotel.Bookings.All())
            {
                sb.AppendLine($"{item.BookingSummary()}");
            }
            return sb.ToString();
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            IHotel hotel = null;
            foreach (var item in hotelRepo.All())
            {
                if (item.FullName == hotelName)
                {
                    hotel = item;
                    break;
                }
            }

            IRoom room = null;
            if (hotel == null)
            {
                return $"Profile {hotelName} doesn’t exist!";
            }
            if(roomTypeName != "Studio" && roomTypeName != "Apartment" && roomTypeName != "DoubleBed")
            {
                return $"Incorrect room type!";
            }

            foreach (var item in hotel.Rooms.All())
            {
                if (item.GetType().Name == roomTypeName)
                {
                    room = item;
                    break;
                }
            }
            if (room == null)
            {
                return $"Room type is not created yet!";
            }
            Room room1 = (Room)room;
            if (room1.IsItSetted == false)
            {
                room.SetPrice(price);
                room1.IsItSetted = true;
                return $"Price of {roomTypeName} room type in {hotelName} hotel is set!";
            }
            return "Price is already set!";
            
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
           
            IHotel hotel = null;
            foreach (var item in hotelRepo.All())
            {
                if(item.FullName == hotelName)
                {
                    hotel = item;
                    break;
                }
            }
    
            IRoom room = null;
            if (hotel == null)
            {
                return $"Profile {hotelName} doesn’t exist!";
            }

            foreach (var item in hotel.Rooms.All())
            {
                if (item.GetType().Name == roomTypeName)
                {
                  
                    return $"Room type is already created!";
                 
                }
            }

            
            if(roomTypeName == "Apartment")
            {
                room = new Apartment();
            }
            else if (roomTypeName == "DoubleBed")
            {
                room = new DoubleBed();
            }
            else if (roomTypeName == "Studio")
            {
                room = new Studio();
            }
            else
            {
                throw new ArgumentException("Incorrect room type!");

            }
            hotel.Rooms.AddNew(room);
           
            return $"Successfully added {roomTypeName} room type in {hotelName} hotel!";
        }
    }
}
