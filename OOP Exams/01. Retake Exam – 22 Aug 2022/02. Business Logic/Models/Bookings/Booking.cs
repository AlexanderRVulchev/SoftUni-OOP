using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Bookings
{
    using BookingApp.Models.Bookings.Contracts;
    using BookingApp.Models.Rooms.Contracts;
    using Utilities.Messages;

    public class Booking : IBooking
    {
        private IRoom room;
        private int residenceDuration;
        private int adultsCount;
        private int childrenCount;
        private int bookingNumber;

        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            this.room = room;
            ResidenceDuration = residenceDuration;
            AdultsCount = adultsCount;
            ChildrenCount = childrenCount;
            this.bookingNumber = bookingNumber;
        }


        public IRoom Room => room;

        public int ResidenceDuration
        {
            get => residenceDuration;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(ExceptionMessages.DurationZeroOrLess);
                residenceDuration = value;
            }
        }

        public int AdultsCount
        {
            get => adultsCount;
            private set
            {
                if (value < 1)
                    throw new ArgumentException(ExceptionMessages.AdultsZeroOrLess);
                adultsCount = value;
            }
        }

        public int ChildrenCount
        {
            get => childrenCount;
            private set
            {
                if (value < 0)
                    throw new ArgumentException(ExceptionMessages.ChildrenNegative);
                childrenCount = value;
            }
        }

        public int BookingNumber => bookingNumber;

        public string BookingSummary()
        => $"Booking number: {BookingNumber}" + Environment.NewLine +
           $"Room type: {room.GetType().Name}" + Environment.NewLine +
           $"Adults: {AdultsCount} Children: {ChildrenCount}" + Environment.NewLine +
           $"Total amount paid: {TotalPaid():f2} $" + Environment.NewLine;

        private double TotalPaid()
        => Math.Round(ResidenceDuration * room.PricePerNight, 2);
    }
}
