using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Repositories
{    
    using BookingApp.Models.Rooms.Contracts;
    using BookingApp.Repositories.Contracts;

    public class RoomRepository : IRepository<IRoom>
    {
        private List<IRoom> rooms;

        public RoomRepository()
        {
            rooms = new List<IRoom>();
        }

        public void AddNew(IRoom room)
        {
            rooms.Add(room);
        }

        public IRoom Select(string roomtypeName)
        {
            return rooms.Find(x => x.GetType().Name == roomtypeName);
        }

        public IReadOnlyCollection<IRoom> All()
        {
            return rooms.AsReadOnly();
        }
    }
}
