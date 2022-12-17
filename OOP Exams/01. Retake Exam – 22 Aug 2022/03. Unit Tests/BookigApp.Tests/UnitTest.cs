using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        Room room;        
        Hotel hotel;

        [SetUp]
        public void Setup()
        {
            room = new Room(2, 25.0);            
            hotel = new Hotel("HotelName", 3);
        }

        // Testing class Room

        [Test]
        public void Room_Constructor_AssignsValuesProperly()
        {
            int bedCapacity = 2;
            double pricePerNight = 24.5;
            room = new Room(bedCapacity, pricePerNight);
            Assert.IsTrue(room.BedCapacity == bedCapacity && room.PricePerNight == pricePerNight);
        }


        [TestCase(-50)]
        [TestCase(0)]
        public void Room_PropertyBedCapacity_CantBeNegativeOrZero(int bedCapacity)
        {
            Assert.Throws<ArgumentException>(() => room = new Room(bedCapacity, 35.0));
        }

        [TestCase(-5.5)]
        [TestCase(0.0)]
        public void Room_PropertyPricePerNight_CantBeNegativeOrZero(double pricePerNight)
        {
            Assert.Throws<ArgumentException>(() => room = new Room(2, pricePerNight));
        }

        // Testing class Booking

        [Test]
        public void Booking_Constructor_AssignsValuesProperly()
        {
            const int BOOKING_NUMBER = 10;
            const int RESIDENCE_DURATION = 4;
            Booking booking = new Booking(BOOKING_NUMBER, room, RESIDENCE_DURATION);
            Assert.True(booking.BookingNumber == BOOKING_NUMBER &&
                        booking.ResidenceDuration == RESIDENCE_DURATION &&
                        booking.Room.Equals(room));
        }

        // Testing class Hotel

        [Test]
        public void Hotel_Constructor_AssignsValuesProperly()
        {
            const string HOTEL_NAME = "HotelName";
            const int HOTEL_CATEGORY = 4;
            hotel = new Hotel(HOTEL_NAME, HOTEL_CATEGORY);
            Assert.IsTrue(hotel.FullName == HOTEL_NAME &&
                          hotel.Category == HOTEL_CATEGORY &&
                          hotel.Rooms != null &&
                          hotel.Bookings != null);
        }

        [TestCase(null)]
        [TestCase(" ")]
        public void Hotel_PropertyFullName_CantBeNullOrWhiteSpace(string name)
        {            
            Assert.Throws<ArgumentNullException>(() => hotel = new Hotel(name, 4));
        }

        [TestCase(0)]
        [TestCase(6)]
        public void Hotel_PropertyCategory_MustBeBetween1And5(int category)
        {
            Assert.Throws<ArgumentException>(() => hotel = new Hotel("TestName", category));
        }

        [Test]
        public void Hotel_AddRoom_IncreasesCountOfTheCollection()
        {
            hotel.AddRoom(room);
            Assert.AreEqual(hotel.Rooms.Count, 1);
        }

        [TestCase(-4)]
        [TestCase(0)]
        public void Hotel_BookRoom_AdultsCantBeNegativeOrZero(int adults)
        {
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(adults, 2, 4, 500.0));
        }

        [TestCase(-1)]
        public void Hotel_BookRoom_ChildrenCantBeNegative(int children)
        {
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(2, children, 4, 500.0));
        }

        [TestCase(0)]
        public void Hotel_BookRoom_ResidenceDurationCantBeLessThan1(int residenceDuration)
        {
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(2, 3, residenceDuration, 500.0));
        }

        [Test]
        public void Hotel_BookRoom_AddsABookingToTheCollection()
        {
            hotel.AddRoom(room);
            hotel.BookRoom(1, 1, 4, 200.0);
            Assert.AreEqual(hotel.Bookings.Count, 1);
        }

        [Test]
        public void Hotel_BookRoom_DoesntBookIfBedCapacityIsLowerThanBedsNeeded()
        {
            hotel.AddRoom(room);
            hotel.BookRoom(2, 1, 4, 200.0);
            Assert.AreEqual(hotel.Bookings.Count, 0);
        }

        [Test]
        public void Hotel_BookRoom_ProperlyGeneratesTurnover()
        {
            int residenceDuration = 4;
            double pricePerNight = room.PricePerNight;
            double expectedTurnover = residenceDuration * pricePerNight;

            hotel.AddRoom(room);
            hotel.BookRoom(1, 1, residenceDuration, 200.0);
            Assert.AreEqual(expectedTurnover, hotel.Turnover);
        }
    }
}