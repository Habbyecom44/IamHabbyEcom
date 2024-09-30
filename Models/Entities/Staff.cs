using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirApp.Models.Enums;

namespace AirApp.Models.Entities
{
    public class Staff : Person
    {
        public string _staffNumber;
        public Level _level;

        public Staff(int id, string firstName, string lastName,string staffNumber, string email, Level level,string phone, string address, Gender gender, bool isDeleted) :base(id,firstName,lastName,email,phone,address, gender,isDeleted)
        {
            _staffNumber = staffNumber;
            _level = level;
        }

        public override string ToString()
        {
            return $"{_id}\t{_firstName}\t{_lastName}\t{_staffNumber}\t{_email}\t{_level}\t{_phone}\t{_address}\t{_gender}\t{_isDeleted}";
        }

        public static Staff ConvertToStaff(string str)
        {
            var model = str.Split("\t");
            var id = int.Parse(model[0]);
            var firstName = model[1];
            var lastName = model[2];
            var staffNumber = model[3];
            var email = model[4];
            var level = (Level)int.Parse(model[5]);
            var phone = model[6];
            var address = model[7];
            var gender = (Gender)int.Parse(model[8]);
            var isDeleted = bool.Parse(model[9]);
            return new Staff(id, firstName, lastName, staffNumber, email, level, phone, address, gender, isDeleted);
        }
    }
}