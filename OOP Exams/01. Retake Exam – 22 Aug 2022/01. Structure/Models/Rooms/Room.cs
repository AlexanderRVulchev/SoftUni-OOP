using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Rooms
{
    using BookingApp.Models.Rooms.Contracts;
    using BookingApp.Utilities.Messages;

    public abstract class Room : IRoom
    {
        private readonly int bedCapacity;
        private double pricePerNight;

        public Room(int bedCapacity)
        {
            bedCapacity = 0;
            pricePerNight = 0;
        }

        public int BedCapacity => bedCapacity;

        public double PricePerNight
        {
            get => pricePerNight;
            private set
            {
                if (value < 0)
                    throw new ArgumentException(ExceptionMessages.PricePerNightNegative);
                pricePerNight = value;
            }
        }

        public void SetPrice(double price)
        {
            PricePerNight = price;
        }
    }
}
