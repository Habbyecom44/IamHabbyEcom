using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirApp.Models.Entities;

namespace AirApp.Repositories.Interface
{
    public interface IUserRepository
    {
        void Create(User user);
        User Get(string email);
        List<User> GetAll();
        void Refresh();
        void ReadAllFromFile();
    }
}