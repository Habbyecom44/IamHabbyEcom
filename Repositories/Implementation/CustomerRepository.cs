using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using AirApp.Context;
using AirApp.Models.Entities;
using AirApp.Repositories.Interface;

namespace AirApp.Repositories.Implementation
{
    public class CustomerRepository : ICustomerRepository
    {
        public void Create(Customer customer)
        {
            AirContext.CustomerDb.Add(customer);
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

        public void ReadAllFromFile()
        {
            var reader = File.ReadAllLines(AirContext.CustomerDbPath);
            foreach (var item in reader)
            {
                AirContext.CustomerDb.Add(Customer.ConvertToCustomer(item.ToString()));
            }
        }

        public void Refresh()
        {
            using (StreamWriter streamWriter = new StreamWriter(AirContext.CustomerDbPath, true))
            {
                foreach (var item in AirContext.CustomerDb)
                {
                    streamWriter.WriteLine(item.ToString());
                }
            }
        }
    }
}