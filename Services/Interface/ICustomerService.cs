using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirApp.Models.Entities;
using AirApp.Models.Enums;

namespace AirApp.Services.Interface
{
    public interface ICustomerService
    {
        Customer Create(string password, string firstName, string lastName, string email,string phone, string address, Gender gender);
        Customer Get(string tagNumber);
        List<Customer> GetAll();
        Customer Update(string tagNumber, string firstName, string lastName, string email, string phone, string address);
        void Delete(string tagNumber);
    }
}