using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirApp.Context;
using AirApp.Models.Entities;
using AirApp.Repositories.Interface;

namespace AirApp.Repositories.Implementation
{
    public class BookingRepository : IBookingRepository
    {
        public void Create(Booking booking)
        {
            AirContext.BookingDb.Add(booking);
            using (StreamWriter writer = new StreamWriter(AirContext.BookingDbPath, true))
            {
                writer.WriteLine(booking.ToString());
            }
        }

        public Booking Get(string refNumber)
        {
            foreach (var item in AirContext.BookingDb)
            {
                if(item._refNumber == refNumber) return item;
            }
            return null;
        }

        public List<Booking> GetAll()
        {
            return AirContext.BookingDb;
        }

        public void ReadAllFromFile()
        {
            using (var reader = new StreamReader(AirContext.BookingDbPath))
            {
                reader.ReadLine();
            }
        }

        public void Refresh()
        {
            using (StreamWriter writer = new StreamWriter(AirContext.BookingDbPath, true))
            {
                foreach (var item in AirContext.BookingDbPath)
                {
                    writer.WriteLine(item.ToString());
                }
            }
        }
    }
}