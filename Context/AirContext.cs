using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirApp.Models.Entities;
using AirApp.Models.Enums;

namespace AirApp.Context
{
    public class AirContext
    {
        public static List<Airline> AirlineDb = new List<Airline>()
        {
            new Airline(1,"CLH001","ASD0419",75,true,false),
            new Airline(2,"CLH002","ASD1407",75,true,false),
            new Airline(3,"CLH003","ASD1193",75,true,false),
            new Airline(4,"CLH004","ASD6438",75,true,false),
        };
        public static string AirlineDbPath = @"C:\Users\USER\Documents\Dev\AirApp\Files\Airlines.txt";
        public static List<Airport> AirportDb = new List<Airport>()
        {
            new Airport(1,"MMIA","CLH/Port/001","Lagos","Nigeria",AirportType.International,false),
            new Airport(2,"IAIA","CLH/Port/002","Abuja","Nigeria",AirportType.International,false),
            new Airport(3,"OSLA","CLH/Port/003","Ondo","Nigeria",AirportType.Local,false),
        };
        public static string AirportDbPath = @"C:\Users\USER\Documents\Dev\AirApp\Files\Airports.txt";
        public static List<Booking> BookingDb = new List<Booking>();
        public static string BookingDbPath = @"C:\Users\USER\Documents\Dev\AirApp\Files\Bookings.txt";
        public static List<Customer> CustomerDb = new List<Customer>();
        public static string CustomerDbPath = @"C:\Users\USER\Documents\Dev\AirApp\Files\Customers.txt";
        public static List<Flight> FlightDb = new List<Flight>();
        public static string FlightDbPath = @"C:\Users\USER\Documents\Dev\AirApp\Files\Flights.txt";
        public static List<Staff> StaffDb = new List<Staff>();
        public static string StaffDbPath = @"C:\Users\USER\Documents\Dev\AirApp\Files\Staffs.txt";
        public static List<User> UserDb = new List<User>()
        {
            new User(1,"admin@gmail.com","pass","app_admin",false)
        };
        public static string UserDbPath = @"C:\Users\USER\Documents\Dev\AirApp\Files\Users.txt";
    }
}