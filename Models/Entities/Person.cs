using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirApp.Models.Enums;

namespace AirApp.Models.Entities
{
    public abstract class Person
    {
        public int _id;
        public string _firstName;
        public string _lastName;
        public string _email;
        public string _phone;
        public string _address;
        public Gender _gender;
        public bool _isDeleted;

        public Person(int id, string firstName, string lastName, string email,string phone, string address, Gender gender, bool isDeleted)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _phone = phone;
            _address = address;
            _gender = gender;
            _isDeleted = isDeleted;
        }

    }
}