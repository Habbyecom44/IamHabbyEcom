using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirApp.Context;
using AirApp.Models.Entities;
using AirApp.Repositories.Interface;

namespace AirApp.Repositories.Implementation
{
    public class AirlineRepository : IAirlineRepository
    {
        public void Create(Airline airline)
        {
            AirContext.AirlineDb.Add(airline);
            using (StreamWriter writer = new StreamWriter(AirContext.AirlineDbPath, true))
            {
                writer.WriteLine(airline.ToString());
            }
        }

        public Airline Get(string engineNumber)
        {
            foreach (var item in AirContext.AirlineDb)
            {
                if(item._engineNumber == engineNumber) return item;
            }
            return null;
        }

        public List<Airline> GetAll()
        {
            return AirContext.AirlineDb;
        }

        public void ReadAllFromFile()
        {
            var reader = File.ReadAllLines(AirContext.AirlineDbPath);
            foreach (var item in reader)
            {
                AirContext.AirlineDb.Add(Airline.ConvertToAirline(item));
            }
        }

        public void RefreshFile()
        {
            using (StreamWriter writer = new StreamWriter(AirContext.AirlineDbPath, true))
            {
                foreach (var item in AirContext.AirlineDbPath)
                {
                    writer.WriteLine(item.ToString());
                }
            }
        }
    }
}