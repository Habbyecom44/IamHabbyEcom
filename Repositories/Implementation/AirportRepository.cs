using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirApp.Context;
using AirApp.Models.Entities;
using AirApp.Repositories.Interface;

namespace AirApp.Repositories.Implementation
{
    public class AirportRepository : IAirportRepository
    {
        public void Create(Airport airport)
        {
            AirContext.AirportDb.Add(airport);
        }

        public Airport Get(int id)
        {
            foreach (var item in AirContext.AirportDb)
            {
                if (item._id == id) return item;
            }
            return null;
        }

        public List<Airport> GetAll()
        {
            return AirContext.AirportDb;
        }

        public void ReadAllFromFile()
        {
            var reader = File.ReadAllLines(AirContext.AirlineDbPath);
            foreach (var item in reader)
            {
                AirContext.AirportDb.Add(Airport.ConvertToAirport(item));
            }
        }

        public void Refresh()
        {
            using (StreamWriter sw = new StreamWriter(AirContext.AirlineDbPath, true))
            {
                foreach (var item in AirContext.AirlineDb)
                {
                    sw.WriteLine(item.ToString());
                }
            }
        }
    }
}