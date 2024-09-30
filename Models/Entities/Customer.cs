using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirApp.Models.Enums;

namespace AirApp.Models.Entities
{
    public class Customer : Person
    {
        public string _tagNumber;

        public Customer(int id, string firstName, string lastName,string tagNumber, string email,string phone, string address, Gender gender, bool isDeleted) :base(id,firstName,lastName,email,phone,address,gender,isDeleted)
        {
            _tagNumber = tagNumber;
        }

        public  override string ToString()
        {
            return $"{_id}\t{_firstName}\t{_lastName}\t{_tagNumber}\t{_email}\t{_phone}\t{_address}\t{_gender}\t{_isDeleted}";
        }

        public static Customer ConvertToCustomer(string str)
        {
            var model = str.Split("\t");
            var id = int.Parse(model[0]);
            var firstName = model[1];
            var lastName = model[2];
            var tagNumber = model[3];
            var email = model[4];
            var phone = model[5];
            var address = model[6];
            var gender = (Gender)int.Parse(model[7]);
            var isDeleted = bool.Parse(model[8]);
            return new Customer(id, firstName, lastName, tagNumber, email, phone, address, gender, isDeleted);
        }
    }
}