using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirApp.Models.Entities;

namespace AirApp.Repositories.Interface
{
    public interface ICustomerRepository
    {
     void Create( Customer customer);
     Customer Get(string tagNumber);
     List<Customer> GetAll();
     void Refresh();
     void ReadAllFromFile();   
    }
}