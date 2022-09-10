using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        private List<IBooking> models;

        public BookingRepository()
        {
            models = new List<IBooking>();
        }
        public void AddNew(IBooking model)
        {
            models.Add(model);
        }

        public IReadOnlyCollection<IBooking> All() => models;
        //{
        //    throw new NotImplementedException();
        //}

        public IBooking Select(string criteria)
        {
            return models.FirstOrDefault(h => h.GetType().Name == criteria);
        }
    }
}
