using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Repositories
{
    public class HotelRepository : IRepository<IHotel>
    {
        private List<IHotel> hotels;

        public HotelRepository()
        {
            hotels = new List<IHotel>();
        }

        public void AddNew(IHotel hotel)
        {
            hotels.Add(hotel);
        }

        public IReadOnlyCollection<IHotel> All()
        {
            return hotels.AsReadOnly();
        }

        public IHotel Select(string hotelName)
        {
            return hotels.Find(x => x.FullName == hotelName);
        }
    }
}
