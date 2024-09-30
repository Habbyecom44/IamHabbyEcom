using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirApp.Models.Entities;
using AirApp.Models.Enums;

namespace AirApp.Services.Interface
{
    public interface IStaffService
    {
        Staff Create(string password, string firstName, string lastName, string email, Level level,string phone, string address, Gender gender);
        Staff Get(string staffNumber);
        List<Staff> GetAll();
        Staff Update(string staffNumber, string firstName, string lastName, string phone, string address);   
        void Delete(string staffNumber);
    }
}