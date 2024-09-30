using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirApp.Models.Entities;

namespace AirApp.Services.Interface
{
    public interface IAirlineService 
    {
        Airline Create(string engineNumber, int capacity);

        Airline Get(string tagNumber);
        List<Airline> GetAll();
        Airline Update(string tagNumber, int capacity, bool isAvailable);
        void Delete(string tagNumber);
    }
}