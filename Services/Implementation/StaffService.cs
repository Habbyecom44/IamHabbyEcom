using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirApp.Context;
using AirApp.Models.Entities;
using AirApp.Models.Enums;
using AirApp.Repositories.Implementation;
using AirApp.Repositories.Interface;
using AirApp.Services.Interface;

namespace AirApp.Services.Implementation
{
    public class StaffService : IStaffService
    {
        IStaffRepository staffRepository = new StaffRepository();
        IUserService userService = new UserService();
        public Staff Create(string firstName, string lastName, string email, string password, Level level, string phone, string address, Gender gender)
        {
            var user = userService.Create(email, password, "app_staff");
            if(user == null)
            {
                return null;
            }
            var id = AirContext.StaffDb.Count + 1;
            var staffNumber = $"CLH/AirApp/Staff/00{id}";
            var staff = new Staff(id, firstName, lastName, staffNumber, email, level, phone, address, gender, false);
            staffRepository.Create(staff);
            return staff;   
        }

        public void Delete(string staffNumber)
        {
            var staff = Get(staffNumber);
            if (staff == null) return;
            staff._isDeleted = true;
        }

        public Staff Get(string staffNumber)
        {
            foreach (var item in AirContext.StaffDb)
            {
                if(item._staffNumber == staffNumber) return item;
            }
            return null;
        }

        public List<Staff> GetAll()
        {
            return AirContext.StaffDb;
        }

        public Staff Update(string staffNumber, string firstName, string lastName, string phone, string address)
        {
            var staff = Get(staffNumber);
            if(staff != null)
            staff._firstName = firstName;
            staff._lastName = lastName;
            staff._phone = phone;
            staff._address = address;
            return staff;
        }
    }
}