using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirApp.Context;
using AirApp.Models.Entities;
using AirApp.Repositories.Implementation;

namespace AirApp
{
    public class StartUp
    {
        public void Start()
        {
            CreateSchema();
            CreateFile(AirContext.AirlineDbPath);
            CreateFile(AirContext.AirportDbPath);
            CreateFile(AirContext.BookingDbPath);
            CreateFile(AirContext.CustomerDbPath);
            CreateFile(AirContext.FlightDbPath);
            CreateFile(AirContext.StaffDbPath);
            CreateFile(AirContext.UserDbPath);
            

            WriteAirlineDbToFile();
            WriteAirportDbToFile();
            WriteUserDbToFile();
        }
        private void CreateSchema()
        {
            string schema = @"C:\Users\USER\Documents\Dev\AirApp\Files";
            if(!Directory.Exists(schema)) Directory.CreateDirectory(schema);
        }

        private void CreateFile(string path)
        {
            if(!File.Exists(path)) File.Create(path);
        }

        private void WriteAirlineDbToFile()
        {
            using (StreamWriter sw = new StreamWriter(AirContext.AirlineDbPath, true))
            {
                foreach (var item in AirContext.AirlineDb)
                {
                    sw.WriteLine(item.ToString());
                }
            }
        }

        private void WriteAirportDbToFile()
        {
            using (StreamWriter sw = new StreamWriter(AirContext.AirportDbPath, true))
            {
                foreach (var item in AirContext.AirportDb)
                {
                    sw.WriteLine(item.ToString());
                }

            }
        }

        private void WriteUserDbToFile()
        {
            using (StreamWriter sw = new StreamWriter(AirContext.UserDbPath, true))
            {
                foreach (var item in AirContext.UserDb)
                {
                    sw.WriteLine(item.ToString());
                }
            }
        }
    }
}