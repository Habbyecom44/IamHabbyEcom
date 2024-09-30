using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirApp.Models.Entities;

namespace AirApp.Repositories.Interface
{
    public interface IAirportRepository
    {
        void Create(Airport airport);
        Airport Get(int id);
        List<Airport> GetAll();
        void Refresh();
        void ReadAllFromFile();
    }
}