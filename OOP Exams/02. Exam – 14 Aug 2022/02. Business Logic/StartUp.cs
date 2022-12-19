namespace BookingApp
{
    using BookingApp.Core;
    using BookingApp.Core.Contracts;
    using BookingApp.Models.Bookings;
    using BookingApp.Models.Hotels;
    using BookingApp.Models.Rooms;
    using BookingApp.Models.Rooms.Contracts;
    using BookingApp.Repositories;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            // Don't forget to comment out the commented code lines in the Engine class!
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
