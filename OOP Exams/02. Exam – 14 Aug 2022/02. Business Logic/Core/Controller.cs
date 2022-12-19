using BookingApp.Core.Contracts;
using BookingApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BookingApp.Core
{
    using Models.Hotels.Contacts;
    using Models.Hotels;
    using Utilities.Messages;
    using BookingApp.Models.Rooms.Contracts;
    using BookingApp.Models.Rooms;
    using BookingApp.Models.Bookings.Contracts;
    using BookingApp.Models.Bookings;

    public class Controller : IController
    {
        private HotelRepository hotels;

        public Controller()
        {
            hotels = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            if (hotels.All().Any(x => x.FullName == hotelName))
            {
                return String.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }
            else
            {
                Hotel newHotel = new Hotel(hotelName, category);
                hotels.AddNew(newHotel);
                return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
            }
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            if (!hotels.All().Any(x => x.Category == category))
                return String.Format(OutputMessages.CategoryInvalid, category);
            
            var availableRooms = new Dictionary<IRoom, string>();

            foreach (var hotel in hotels.All().Where(x => x.Category == category).OrderBy(x => x.FullName))
                foreach (var room in hotel.Rooms.All())
                    if (room.PricePerNight > 0)
                        availableRooms.Add(room, hotel.FullName);
                        
            IRoom roomToBook = null;
            string hotelNameToBook = string.Empty;
            int people = adults + children;

            foreach (var room in availableRooms.OrderBy(x => x.Key.BedCapacity))
            {
                if (room.Key.BedCapacity >= people)
                {
                    roomToBook = room.Key;
                    hotelNameToBook = room.Value;
                    break;
                }
            }

            if (roomToBook == null)
                return String.Format(OutputMessages.RoomNotAppropriate);

            IHotel hotelToBook = hotels.Select(hotelNameToBook);
            int newBookingNumber = hotelToBook.Bookings.All().Count + 1;

            Booking newBooking = new Booking(roomToBook, duration, adults, children, newBookingNumber);
            hotelToBook.Bookings.AddNew(newBooking);

            return String.Format(OutputMessages.BookingSuccessful, newBookingNumber, hotelNameToBook);
        }

        public string HotelReport(string hotelName)
        {
            IHotel hotel = hotels.Select(hotelName);
            if (hotel == null)            
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Hotel name: {hotel.FullName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:F2} $");            
            sb.AppendLine($"--Bookings:");
            sb.AppendLine();

            if (hotel.Bookings.All().Count == 0)
            {
                sb.Append("none");
                return sb.ToString();
            }
            foreach (var booking in hotel.Bookings.All())
            {
                sb.AppendLine(booking.BookingSummary());
            }
            return sb.ToString().TrimEnd();
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            if (!hotels.All().Any(x => x.FullName == hotelName))
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);

            if (!new string[] { "Apartment", "DoubleBed", "Studio" }.Contains(roomTypeName))
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);

            IHotel hotel = hotels.All().First(x => x.FullName == hotelName);
            if (!hotel.Rooms.All().Any(x => x.GetType().Name == roomTypeName))
                return OutputMessages.RoomTypeNotCreated;

            IRoom room = hotel.Rooms.All().First(x => x.GetType().Name == roomTypeName);
            if (room.PricePerNight != 0)
                throw new InvalidOperationException(ExceptionMessages.PriceAlreadySet);

            room.SetPrice(price);
            return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            if (!hotels.All().Any(x => x.FullName == hotelName))
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);

            IHotel hotel = hotels.All().First(x => x.FullName == hotelName);
            var rooms = hotel.Rooms.All();
            if (rooms.Any(x => x.GetType().Name == roomTypeName))
                return OutputMessages.RoomTypeAlreadyCreated;

            IRoom roomToAdd;
            switch (roomTypeName)
            {
                case "Apartment": roomToAdd = new Apartment(); break;
                case "DoubleBed": roomToAdd = new DoubleBed(); break;
                case "Studio": roomToAdd = new Studio(); break;
                default: throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }
            hotel.Rooms.AddNew(roomToAdd);
            return String.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
        }
    }
}
