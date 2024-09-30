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
    public class FlightService : IFlightService
    {
        IFlightRepository flightRepository = new FlightRepository();
        public Flight Create(int from, int to, int airLineId, DateTime time, int period, decimal price)
        {
            var id = AirContext.FlightDb.Count + 1;
            var refNumber = $"CLH/AirApp/Flight/00{id}";
            var flight = new Flight(id, refNumber, from, to, airLineId, time, period, price, false);
            flightRepository.Create(flight);
            return flight;
        }

        public void Delete(string refNumber)
        {
            var flight = Get(refNumber);
            if (flight == null) return;
            flight._isDeleted = true;
        }

        public Flight Get(string refNumber)
        {
            foreach (var item in AirContext.FlightDb)
            {
                if (item._refNumber == refNumber) return item;
            }
            return null;
        }

        public List<Flight> GetAll()
        {
            return AirContext.FlightDb;
        }

    }
}