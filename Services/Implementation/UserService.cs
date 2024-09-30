using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirApp.Context;
using AirApp.Models.Entities;
using AirApp.Repositories.Implementation;
using AirApp.Repositories.Interface;
using AirApp.Services.Interface;

namespace AirApp.Services.Implementation
{
    public class UserService : IUserService
    {
        IUserRepository userRepository = new UserRepository();
        public User Create(string email, string password, string role)
        {
            var id = AirContext.UserDb.Count + 1;
            var user = new User(id, email, password, role, false);
            userRepository.Create(user);
            return user;
        }

        public void Delete(string email)
        {
            var user = Get(email);
            if(user != null)
            user._isDeleted = true;
        }

        public User Get(string email)
        {
            foreach (var item in AirContext.UserDb)
            {
                if (item._email == email) return item;
            }
            return null;
        }

        public List<User> GetAll()
        {
            return AirContext.UserDb;
        }

        public User Login(string email, string password)
        {
            var user = Get(email);
            if(user == null)
            {
                return null;
            }
            if(user._password != password)
            {
                return null;
            }
            return user;
        }
    }
}