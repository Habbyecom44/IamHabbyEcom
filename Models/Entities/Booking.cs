using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirApp.Models.Entities
{
    public class Booking
    {
        public int _id;
        public string _refNumber;
        public string _customerEmail;
        public string _flightRefNumber;
        public bool _isDeleted;

        public Booking(int id, string refNumber, string customerEmail,string flightRefNumber, bool isDeleted)
        {
            _id = id;
            _refNumber = refNumber;
            _customerEmail = customerEmail;
            _flightRefNumber = flightRefNumber;
            _isDeleted = isDeleted;
        }

        public override string ToString()
        {
            return $"{_id}\t{_refNumber}\t{_customerEmail}\t{_flightRefNumber}\t{_isDeleted}";
        }

        public static Booking ConvertToBooking(string str)
        {
            var booking = str.Split("\t");
            var id = int.Parse(booking[0]);
            var refNumber = booking[1];
            var customerEmail = booking[2];
            var flightRefNumber = booking[3];
            var isDeleted = bool.Parse(booking[4]);
            return new Booking(id, refNumber, customerEmail, flightRefNumber, isDeleted);
        }
    }
}