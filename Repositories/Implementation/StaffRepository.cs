using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirApp.Context;
using AirApp.Models.Entities;
using AirApp.Repositories.Interface;

namespace AirApp.Repositories.Implementation
{
    public class StaffRepository : IStaffRepository
    {
        public void Create(Staff staff)
        {
            AirContext.StaffDb.Add(staff);
        }

        public Staff Get(string staffNumber)
        {
            foreach (var item in AirContext.StaffDb)
            {
                if (item._staffNumber == staffNumber) return item;
            }
            return null;
        }

        public List<Staff> GetAll()
        {
            return AirContext.StaffDb;
        }

        public void ReadAllFromFile()
        {
            var reader = File.ReadAllLines(AirContext.StaffDbPath);
            foreach (var item in AirContext.StaffDb)
            {
                AirContext.StaffDb.Add(Staff.ConvertToStaff(item.ToString()));
            }
        }

        public void Refresh()
        {
            using (StreamWriter sw = new StreamWriter(AirContext.StaffDbPath, true))
            {
                foreach (var item in AirContext.StaffDb)
                {
                    sw.WriteLine(item.ToString());
                }
            }
        }
    }
}