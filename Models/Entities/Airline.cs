using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirApp.Models.Entities
{
    public class Airline
    {
        public int _id;
        public string _tagNumber;
        public string _engineNumber;
        public int _capacity;
        public bool _isAvailable;
        public bool _isDeleted;

        public Airline(int id, string tagNumber, string engineNumber,int capacity,bool isAvailable, bool isDeleted)
        {
            _id = id;
            _tagNumber = tagNumber;
            _engineNumber = engineNumber;
            _capacity = capacity;
            _isAvailable = isAvailable;
            _isDeleted = isDeleted;
        }

        public override string ToString()
        {
            return $"{_id}\t{_tagNumber}\t{_engineNumber}\t{_capacity}\t{_isAvailable}\t{_isDeleted}";
        }

        public static Airline ConvertToAirline(string str)
        {
            var airline = str.Split("\t");
            var id = int.Parse(airline[0]);
            var tagNumber = airline[1];
            var engineNumber = airline[2];
            var capacity = int.Parse(airline[3]);
            var isAvailable = bool.Parse(airline[4]);
            var isDeleted = bool.Parse(airline[5]);
            return new Airline(id, tagNumber, engineNumber, capacity, isAvailable, isDeleted);
        }
    }
}