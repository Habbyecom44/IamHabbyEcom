using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirApp.Models.Entities;

namespace AirApp.Repositories.Interface
{
    public interface IStaffRepository
    {
        void Create(Staff staff);
        Staff Get(string staffNumber);
        List<Staff> GetAll();
        void Refresh();
        void ReadAllFromFile();
    }
}