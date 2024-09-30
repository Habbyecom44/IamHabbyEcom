using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AirApp.Context;
using AirApp.Models.Entities;
using AirApp.Repositories.Interface;

namespace AirApp.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        public void Create(User user)
        {
            AirContext.UserDb.Add(user);
        }

        public User Get(string email)
        {
            foreach (var item in AirContext.UserDb)
            {
                if(item._email == email) return item;
            }
            return null;
        }

        public List<User> GetAll()
        {
            return AirContext.UserDb;
        }

        public void ReadAllFromFile()
        {
            var reader = File.ReadAllLines(AirContext.UserDbPath);
            foreach (var item in reader)
            {
                AirContext.UserDb.Add(User.ConvertToUser(item.ToString()));
            }
        }

        public void Refresh()
        {
            using (StreamWriter writer = new StreamWriter(AirContext.UserDbPath, true))
            {
                foreach (var item in AirContext.UserDbPath)
                {
                    writer.WriteLine(item.ToString());
                }
            }
        }
    }
}