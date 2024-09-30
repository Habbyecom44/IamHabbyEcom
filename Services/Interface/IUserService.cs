using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirApp.Models.Entities;

namespace AirApp.Services.Interface
{
    public interface IUserService
    {
        User Create(string email, string password, string role);
        User Get(string email);
        List<User> GetAll();
        void Delete(string email);
        User Login(string email, string password);
    }
}