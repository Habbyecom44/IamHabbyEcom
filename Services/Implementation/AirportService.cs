using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirApp.Context;
using AirApp.Models.Entities;
using AirApp.Models.Enums;
using AirApp.Repositories.Implementation;
using AirApp.Repositories.Interface;
using AirApp.Services.Interface;

namespace AirApp.Services.Implementation
{
    public class AirportService : IAirportService
    {
        IAirportRepository airportRepository = new AirportRepository();
        //int id, string name, string refNumber, string state,string country, AirportType type, bool isDeleted
        public Airport Create(string name, string state, string country, AirportType type)
        {
            var id = AirContext.AirportDb.Count + 1;
            var refNumber = $"CLH/Port/00{id}";
            var airport = new Airport(id, name, refNumber, state, country, type, false);
            airportRepository.Create(airport);
            return airport;
        }

        public void Delete(string refNumber)
        {
            var airport = Get(refNumber);
            if (airport == null) return;
            airport._isDeleted = true;
        }

        public Airport Get(string refNumber)
        {
            foreach (var item in AirContext.AirportDb)
            {
                if (item._refNumber == refNumber) return item;
            }
            return null;
        }

        public List<Airport> GetAll()
        {
            return AirContext.AirportDb;
        }

        public List<Airport> GetAllButOne(int fromId)
        {
            List<Airport> others = new List<Airport>();
            var all = GetAll();
            foreach (var item in all)
            {
                if(item._id != fromId)
                {
                    others.Add(item);
                }
            }
            return others;
        }

        public Airport Update(string refNumber, AirportType type)
        {
            var airport = Get(refNumber);
            if (airport == null) return null;
            airport._type = type;
            return airport;
        }
    }
}