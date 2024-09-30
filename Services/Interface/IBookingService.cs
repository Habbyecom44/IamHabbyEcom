using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirApp.Models.Entities;

namespace AirApp.Services.Interface
{
    public interface IBookingService
    {
        Booking Create(string customerEmail,string flightRefNumber);
        Booking Get(string refNumber);
        List<Booking> GetAll();
        Booking Update(string refNumber, string flightRefNumber);
        void Delete(string refNumber);
    }
}