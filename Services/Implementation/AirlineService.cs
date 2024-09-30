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
    public class AirlineService : IAirlineService
    {
        IAirlineRepository airlineRepository = new AirlineRepository();
        public Airline Create(string engineNumber, int capacity)
        {
            var id = AirContext.AirlineDb.Count + 1;
            var tagNumber = $"CLH/AirApp/Line/00{id}";
            var airline = new Airline(id, tagNumber, engineNumber, capacity, true, false);
            airlineRepository.Create(airline);
            return airline;
        }

        public void Delete(string tagNumber)
        {
            var airline = Get(tagNumber);
            if (airline == null) return;
            airline._isDeleted = true;
        }

        public Airline Get(string tagNumber)
        {
            foreach (var item in AirContext.AirlineDb)
            {
                if (item._tagNumber == tagNumber) return item;
            }
            return null;
        }

        public List<Airline> GetAll()
        {
            //return airlineRepository.GetAll();
            return AirContext.AirlineDb;
        }

        public Airline Update(string tagNumber, int capacity, bool isAvailable)
        {
            var airline = Get(tagNumber);
            if(airline == null) return null;
            airline._capacity = capacity;
            airline._isAvailable = true;
            return airline;
        }
    }
}