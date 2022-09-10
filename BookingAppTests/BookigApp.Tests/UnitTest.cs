using FrontDeskApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookigApp.Tests
{
    public class Tests
    {
        //[SetUp]
        //public void Setup()
        //{
        //}


        [TestCase(-50, 5)]
        [TestCase(0, 6)]
        public void TestForNegativeRoomCapacity(int capacity, int price)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Room garage = new Room(capacity, price);
            });
        }
        [TestCase(5, -5)]
        [TestCase(10, -0)]
        public void TestForNegativeRoomPrice(int capacity, int price)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Room garage = new Room(capacity, price);
            });
        }
        [TestCase(7, 20)]
        [TestCase(6, 10)]
        public void TestForConstructorsRoom(int capacity, double price)
        {

            Room room = new Room(capacity, price);
            double expected = room.PricePerNight;
            double actual = price;
            double expectedCapacity = room.BedCapacity;
            double actualCapacity = capacity;
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedCapacity, actualCapacity);


        }
        [Test]
        public void TestForConstructorsRoomBooking()
        {
            int bookingNumber = 123;
            int residenceDuration = 22;
            Room rom = new Room(5, 20);
            Booking book = new Booking(bookingNumber,rom,residenceDuration);

            double expected = book.BookingNumber;
            double actual = bookingNumber;
            var expectedCapacity = book.Room;
            var actualCapacity = rom;

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedCapacity, actualCapacity);

            double expectedRes = book.ResidenceDuration;
            double actualRes = residenceDuration;
           Assert.AreEqual(expectedRes, actualRes);


        }

        [TestCase(null)]
        [TestCase("")]
        public void TestForNullOrEmptyHotelName(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Hotel garage = new Hotel(name, 1);
            });
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(6)]
        public void TestForExceptionHotelStar(int x)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Hotel garage = new Hotel("name", x);
            });
        }

        [Test]
        public void TestForCountListRooms()
        {
            Hotel garage = new Hotel("Desi", 2);
            Room rom = new Room(5, 20);
            Booking book = new Booking(123, rom, 22);
            garage.AddRoom(rom);
           
            List<Room> garage2 = new List<Room>();
            garage2.Add(rom);
            

            int expected = garage.Rooms.Count;
            int actual = garage2.Count;

            Assert.AreEqual(expected, actual);
          

        }
        [Test]
        public void TestForCountListBooking()
        {
            int adult = 2;
            int child = 3;
            int residenceDuration = 10;
            double budget = 1000;
           
            Hotel garage = new Hotel("Desi", 2);
            Room rom = new Room(5, 20);
            Booking book = new Booking(123, rom, 2);
            garage.BookRoom(adult, child, residenceDuration, budget);
            int expBeds = rom.BedCapacity;
            int actual = adult + child;
            
            Assert.That(expBeds >= actual);
            //buget >=
            double check = residenceDuration * rom.PricePerNight;
            
            Assert.That(budget >= check);
            Assert.AreEqual(0,garage.Bookings.Count);
            Assert.AreEqual(0, garage.Turnover);
            //garage.Bookings;
           // Assert.AreEqual(garage.Turnover, check);


        }

        [Test]
        public void TestForCountListBookingInvalid()
        {
            
            Assert.Throws<ArgumentException>(() =>
            {
                int adult = -2;
                int child = -1;
                int residenceDuration = -22;
                double budget = -50;

                Hotel garage = new Hotel("Desi", 2);
                Room rom = new Room(5, 20);
                Booking book = new Booking(123, rom, 2);
                garage.BookRoom(adult, child, residenceDuration, budget);
               
            });

        }
        [Test]
        public void TestForCount()
        {
            Hotel garage = new Hotel("Desi", 2);
            Room rom = new Room(5, 20);
            Booking book = new Booking(123, rom, 2);

            garage.AddRoom(rom);
            List<Room> rooms = new List<Room>();
            rooms.Add(rom);

            int expected = garage.Rooms.Count;
            int actual = rooms.Count;

            Assert.AreEqual(expected, actual);
       

        }
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(6)]
        public void TestForExceptionCategory(int x)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Hotel garage = new Hotel("name", x);
            });
        }
        

        Test




    }
}