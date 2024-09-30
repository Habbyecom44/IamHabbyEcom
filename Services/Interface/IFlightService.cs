using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirApp.Models.Entities;

namespace AirApp.Services.Interface
{
    public interface IFlightService
    {
        Flight Create(int from,int to, int airLineId, DateTime time, int period, decimal price);
        Flight Get(string refNumber);
        List<Flight> GetAll();
        void Delete(string refNumber);
    }
}