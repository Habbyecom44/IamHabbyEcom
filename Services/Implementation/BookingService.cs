using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirApp.Context;
using AirApp.Models.Entities;
using AirApp.Repositories.Implementation;
using AirApp.Repositories.Interface;
using AirApp.Services.Interface;

namespace AirApp.Services.Implementation
{
    public class BookingService : IBookingService
    {
        IBookingRepository bookingRepository = new BookingRepository();
        public Booking Create(string customerEmail, string flightRefNumber)
        {
            var id = AirContext.BookingDb.Count + 1;
            var refNumber = $"CLH/AirApp/Booking/00{id}";
            var booking = new Booking(id, refNumber, customerEmail, flightRefNumber, false);
            bookingRepository.Create(booking);
            return booking;
        }

        public void Delete(string refNumber)
        {
            var booking = Get(refNumber);
            if (booking == null) return;
            booking._isDeleted = true;
        }

        public Booking Get(string refNumber)
        {
            foreach (var item in AirContext.BookingDb)
            {
                if (item._refNumber == refNumber) return item;
            }
            return null;
        }

        public List<Booking> GetAll()
        {
            return AirContext.BookingDb;
        }

        public Booking Update(string refNumber, string flightRefNumber)
        {
            var booking = Get(refNumber);
            if (booking == null) return null;
            booking._flightRefNumber = flightRefNumber;
            return booking;
        }
    }
}