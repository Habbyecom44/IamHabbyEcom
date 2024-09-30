using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirApp.Models.Entities;

namespace AirApp.Repositories.Interface
{
    public interface IFlightRepository
    {
        void Create(Flight flight);
        Flight Get(string refNumber);
        List<Flight> GetAll();
        void Refresh();
        void ReadAllFromFile();
    }
}