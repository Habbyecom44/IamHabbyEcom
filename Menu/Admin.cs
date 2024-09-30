using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirApp.Models.Entities;
using AirApp.Models.Enums;
using AirApp.Repositories.Implementation;
using AirApp.Repositories.Interface;
using AirApp.Services.Implementation;
using AirApp.Services.Interface;

namespace AirApp.Menu
{
    public class Admin
    {
        IStaffService staffService = new StaffService();
        IFlightService flightService = new FlightService();
        IAirlineService airlineService = new AirlineService();
        IAirportService airportService = new AirportService();

        public void AdminMenu()
        {
            Console.WriteLine("1. Flight Mgt\n2. Staff Mgt\n3. Airline Mgt\n4. Go Back");
            string opt = Console.ReadLine();

            if (opt == "1")
            {
                FlightManagement();
            }
            else if (opt == "2")
            {
                StaffManagement();
            }
            else if (opt == "3")
            {
                AirlineManagement();
            }
            else if (opt == "4")
            {
                Main main = new Main();
                main.MainMenu();
            }
        }
        public void FlightManagement()
        {
            Console.WriteLine("1. Create a new flight\n2. View flight details\n3. View all flights\n4. Go Back");
            string option = Console.ReadLine();

            if (option == "1")
            {
                CreateFlightMenu();
            }
            else if (option == "2")
            {
                FlightDetailsMenu();
            }
            else if (option == "3")
            {
                AllFlightsMenu();
            }
            else if (option == "4")
            {
                Console.WriteLine("Thanks");
                AdminMenu();
            }
        }

        private void FlightDetailsMenu()
        {
            Console.Write("Enter the flight ref number: ");
            string refNumber = Console.ReadLine();
            var flight = flightService.Get(refNumber);
            if (flight == null)
            {
                Console.WriteLine("Flight does not exist");
            }
            else
            {
                Console.WriteLine($"{flight._id}{flight._price}{flight._airLineId}{flight._time}{flight._fromId}{flight._toId}{flight._period}");
            }
        }

        private void AllFlightsMenu()
        {
            var flights = flightService.GetAll();
            foreach (var flight in flights)
            {
                Console.WriteLine($"{flight._id}{flight._price}{flight._airLineId}{flight._time}{flight._fromId}{flight._toId}{flight._period}");
            }
        }

        private void CreateFlightMenu()
        {
            Console.WriteLine("Select Take off: ");
            var airports = airportService.GetAll();
            foreach (var airport in airports)
            {
                Console.WriteLine($"\t{airport._id} for {airport._name}, {airport._state}");
            }
            int from = int.Parse(Console.ReadLine());

            //var others = airportService.GetAllButOne(from);
            Console.WriteLine("Select Destination: ");
            foreach (var airport in airports)
            {
                if (airport._id != from)
                {
                    Console.WriteLine($"\t{airport._id} for {airport._name}, {airport._state}");
                }
            }
            int to = int.Parse(Console.ReadLine());

            Console.WriteLine("Select  Airline: ");
            var airlines = airlineService.GetAll();
            foreach (var item in airlines)
            {
                Console.WriteLine($"\t{item._id} for {item._tagNumber}");
            }
            int airLineTag = int.Parse(Console.ReadLine());
            Console.Write("Enter Time: ");
            DateTime time = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Period: ");
            int period = int.Parse(Console.ReadLine());
            Console.Write("Enter Price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            var flight = flightService.Create(from, to, airLineTag, time, 2, 50000);
            if (flight == null)
            {
                Console.WriteLine("Flight already exist");
            }
            else
            {
                Console.WriteLine("Flight successfully created");
            }
        }

        public void StaffManagement()
        {
            Console.WriteLine("1. Create a new Staff\n2. View staff details\n3. View all staff\n4. Go Back");
            string option = Console.ReadLine();

            if (option == "1")
            {
                CreateStaffMenu();
                StaffManagement();
            }
            else if (option == "2")
            {
                StaffDetailsMenu();
                StaffManagement();
            }
            else if (option == "3")
            {
                AllStaffMenu();
                StaffManagement();
            }
            else if (option == "4")
            {
                AdminMenu();
            }
            else
            {
                Console.WriteLine("Invalid option");
                StaffManagement();
            }
        }

        private void CreateStaffMenu()
        {
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            Console.Write("Enter first name: ");
            string fn = Console.ReadLine();
            Console.Write("Enter last name: ");
            string ln = Console.ReadLine();
            Console.Write("Enter email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Select Level: ");
            Level level = (Level)int.Parse(Console.ReadLine());
            Console.Write("Enter phone number: ");
            string phone = Console.ReadLine();
            Console.Write("Enter address: ");
            string address = Console.ReadLine();
            Console.Write("Select Gender: ");
            Gender gender = (Gender)int.Parse(Console.ReadLine());

            var staff = staffService.Create(password, fn, ln, email, level, phone, address, gender);
            if (staff == null)
            {
                Console.WriteLine("Staff already exists");
            }
            else
            {
                Console.WriteLine("Staff created successfully");
            }
        }

        private void StaffDetailsMenu()
        {
            Console.WriteLine("Enter Staff Number");
            string staffNumber = Console.ReadLine();
            var staff = staffService.Get(staffNumber);
            if (staff == null)
            {
                Console.WriteLine("Staff not found");
            }
            else
            {
                Console.WriteLine($"{staff._firstName}.{staff._lastName}.{staff._email}.{staff._phone}.{staff._address}.{staff._gender}.{staff._level}");
            }
        }

        public void AllStaffMenu()
        {
            var staffs = staffService.GetAll();
            if (staffs == null)
            {
                Console.WriteLine("No staff available");
            }
            else
            {
                foreach (var staff in staffs)
                {
                    Console.WriteLine($"{staff._firstName}.{staff._lastName}.{staff._email}.{staff._phone}.{staff._address}.{staff._gender}.{staff._level}");
                }
            }
        }

        public void AirlineManagement()
        {
            Console.WriteLine("1. Create a new Airline\n2. View Airline details\n3. View all Airlines\n4. Go Back");
            string option = Console.ReadLine();

            if (option == "1")
            {
                CreateAirlineMenu();
                AirlineManagement();
            }
            else if (option == "2")
            {
                AirlineDetailsMenu();
                AirlineManagement();
            }
            else if (option == "3")
            {
                AllAirlineMenu();
                AirlineManagement();
            }
            else
            {
                Console.WriteLine("Invalid option");
            }
        }

        private void CreateAirlineMenu()
        {
            Console.Write("Enter Airline Engine Number");
            string engineNumber = Console.ReadLine();
            Console.Write("Enter Airline Capacity");
            int capacity = int.Parse(Console.ReadLine());

            var airline = airlineService.Create(engineNumber, capacity);
            if (airline == null)
            {
                Console.WriteLine("Airline already exists");
            }
            else
            {
                Console.WriteLine("Airline successfully created");
            }
        }

        private void AirlineDetailsMenu()
        {
            Console.WriteLine("Enter Airline Engine Number");
            string engineNumber = Console.ReadLine();

            var airline = airlineService.Get(engineNumber);
            if (airline == null)
            {
                Console.WriteLine("Airline does not exists");
            }
            else
            {
                Console.WriteLine($"{airline._id}.{airline._engineNumber}.{airline._capacity}");
            }
        }

        private void AllAirlineMenu()
        {
            var airlines = airlineService.GetAll();
            foreach (var airline in airlines)
            {
                Console.WriteLine($"{airline._id}\t{airline._capacity}\t{airline._tagNumber}");
            }
        }
    }
}