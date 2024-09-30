using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirApp.Context;
using AirApp.Models.Entities;
using AirApp.Repositories.Interface;

namespace AirApp.Repositories.Implementation
{
    public class FlightRepository : IFlightRepository
    {
        public void Create(Flight flight)
        {
            AirContext.FlightDb.Add(flight);
        }

        public Flight Get(string refNumber)
        {
            foreach (var item in AirContext.FlightDb)
            {
                if(item._refNumber == refNumber) return item;
            }
            return null;
        }

        public List<Flight> GetAll()
        {
            return AirContext.FlightDb;
        }

        public void ReadAllFromFile()
        {
            var reader = File.ReadAllLines(AirContext.FlightDbPath);
            foreach (var item in AirContext.FlightDb)
            {
                AirContext.FlightDb.Add(Flight.ConvertToFlight(item.ToString()));                
            }
        }

        public void Refresh()
        {
            using (StreamWriter stream = new StreamWriter(AirContext.FlightDbPath, true))
            {
                foreach (var item in AirContext.FlightDb)
                {
                    stream.WriteLine(item.ToString());
                }                
            }
        }
    }
}