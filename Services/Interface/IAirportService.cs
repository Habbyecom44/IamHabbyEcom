using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirApp.Models.Entities;
using AirApp.Models.Enums;
using AirApp.Repositories.Implementation;

namespace AirApp.Services.Interface
{
    public interface IAirportService
    {
        Airport Create(string name, string state,string country, AirportType type);
        Airport Get(string refNumber);
        List<Airport> GetAllButOne(int fromId);
        List<Airport> GetAll();
        Airport Update(string refNumber, AirportType type);
        void Delete(string refNumber);
    }
}