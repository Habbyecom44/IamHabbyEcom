using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirApp.Models.Entities;

namespace AirApp.Repositories.Interface
{
    public interface IAirlineRepository
    {
        void Create(Airline airline);
        Airline Get(string engineNumber);
        List<Airline> GetAll();
        void RefreshFile();
        void ReadAllFromFile();
    }
}