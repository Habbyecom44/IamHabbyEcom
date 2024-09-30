using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirApp.Models.Entities
{
    public class Flight
    {
        public int _id;
        public string _refNumber;
        public int _fromId;
        public int _toId;
        public int _airLineId;
        public DateTime _time;
        public int _period;
        public decimal _price;
        public bool _isDeleted;

        public Flight(int id, string refNumber, int fromId,int toId, int airLineId, DateTime time,int period, decimal price, bool isDeleted)
        {
            _id = id;
            _refNumber = refNumber;
            _fromId = fromId;
            _toId = toId;
            _airLineId = airLineId;
            _time = time;
            _period = period;
            _price = price;
            _isDeleted = isDeleted;
        }

        public override string ToString()
        {
            return $"{_id}\t{_refNumber}\t{_fromId}\t{_toId}\t{_airLineId}\t{_time}\t{_period}\t{_price}\t{_isDeleted}";
        }

        public static Flight ConvertToFlight(string st)
        {
            var str = st.Split("\t");
            var id = int.Parse(str[0]);
            var refNumber = str[1];
            var from = int.Parse(str[2]);
            var to = int.Parse(str[3]);
            var airLineId = int.Parse(str[4]);
            var time = DateTime.Parse(str[5]);
            var period = int.Parse(str[6]);
            var price = decimal.Parse(str[7]);
            var isDeleted = bool.Parse(str[8]);
            return new Flight(id, refNumber, from, to, airLineId, time, period, price, isDeleted);
        }
    }
}