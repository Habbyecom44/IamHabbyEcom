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
    public class CustomerService : ICustomerService
    {
        IUserService userService = new UserService();
        ICustomerRepository customerRepository = new CustomerRepository();
        public Customer Create(string firstName, string lastName, string email, string password, string phone, string address, Gender gender)
        {
            var user = userService.Create(email, password, "app_customer");
            if(user == null)
            {
                return null;
            }
            var id = AirContext.CustomerDb.Count + 1;
            var tagNumber = $"CLH/AirApp/Customer/00{id}";
            var customer = new Customer(id, firstName, lastName, tagNumber, email, phone, address, gender,false);
            customerRepository.Create(customer);
            return customer;
        }

        public void Delete(string tagNumber)
        {

        }

        public Customer Get(string tagNumber)
        {
            foreach (var item in AirContext.CustomerDb)
            {
                if (item._tagNumber == tagNumber) return item;
            }
            return null;
        }

        public List<Customer> GetAll()
        {
            return AirContext.CustomerDb;
        }

        public Customer Update(string tagNumber, string firstName, string lastName, string email, string phone, string address)
        {
            var customer = Get(tagNumber);
            if(customer == null) return null;
            customer._firstName = firstName;
            customer._lastName = lastName;
            customer._phone = phone;
            customer._address = address;
            return customer;
        }
    }
}