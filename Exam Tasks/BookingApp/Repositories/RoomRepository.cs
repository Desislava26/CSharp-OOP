using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private List<IRoom> models;

        public RoomRepository()
        {
            models = new List<IRoom>();
        }
        public void AddNew(IRoom model)
        {
            models.Add(model);
        }

        public IReadOnlyCollection<IRoom> All() => models;
        //{
        //    throw new NotImplementedException();
        //}

        public IRoom Select(string criteria)
        {
            return models.FirstOrDefault(h => h.GetType().Name == criteria);
        }
    }
}
