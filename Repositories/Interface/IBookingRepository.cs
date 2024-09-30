using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirApp.Models.Entities;

namespace AirApp.Repositories.Interface
{
    public interface IBookingRepository
    {
       void Create(Booking booking);
       Booking Get(string refNumber);
       List<Booking> GetAll();
       void Refresh();
       void ReadAllFromFile(); 
    }
}