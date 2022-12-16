using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Repositories
{
    using BookingApp.Models.Bookings.Contracts;
    using BookingApp.Repositories.Contracts;

    public class BookingRepository : IRepository<IBooking>
    {
        private List<IBooking> bookings;

        public BookingRepository()
        {
            bookings = new List<IBooking>();
        }

        public void AddNew(IBooking booking)
        {
            bookings.Add(booking);
        }

        public IReadOnlyCollection<IBooking> All()
        {
            return bookings.AsReadOnly();
        }

        public IBooking Select(string bookingNumberToString)
        {
            return bookings.Find(x => x.BookingNumber.ToString() == bookingNumberToString);
        }
    }
}
