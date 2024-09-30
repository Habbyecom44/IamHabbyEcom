using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirApp.Models.Enums;

namespace AirApp.Models.Entities
{
    public class Airport
    {
        public int _id;
        public string _name;
        public string _refNumber;
        public string _state;
        public string _country;
        public AirportType _type;
        public bool _isDeleted;

        public Airport(int id, string name, string refNumber, string state,string country, AirportType type, bool isDeleted)
        {
            _id = id;
            _name = name;
            _refNumber = refNumber;
            _state = state;
            _country = country;
            _type = type;
            _isDeleted = isDeleted;
        }

        public override string ToString()
        {
            return $"{_id}\t{_name}\t{_refNumber}\t{_state}\t{_country}\t{_type}\t{_isDeleted}";
        }

        public static Airport ConvertToAirport(string str)
        {
            var airport = str.Split("\t");
            var id = int.Parse(airport[0]);
            var name = airport[1];
            var refNumber = airport[2];
            var state = airport[3];
            var country = airport[4];
            var type = (AirportType)int.Parse(airport[5]);
            var isDeleted = bool.Parse(airport[6]);
            return new Airport(id, name, refNumber, state, country, type, isDeleted);
        }
    }
}