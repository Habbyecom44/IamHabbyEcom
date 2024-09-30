using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirApp.Models.Entities
{
    public class User
    {
        public int _id;
        public string _email;
        public string _password;
        public string _role;
        public bool _isDeleted;

        public User(int id, string email, string password,string role, bool isDeleted)
        {
            _id = id;
            _email = email;
            _password = password;
            _role = role;
            _isDeleted = isDeleted;
        }

        public static string ConvertToString(User user)
        {
            return $"{user._id}\t{user._email}\t{user._password}\t{user._role}\t{user._isDeleted}";
        }

        public override string ToString()
        {
            return $"{_id}\t{_email}\t{_password}\t{_role}\t{_isDeleted}";
        }

        public static User ConvertToUser(string str)
        {
            var model = str.Split('\t');
            
            var id = int.Parse(model[0]);
            var email = model[1];
            var password = model[2];
            var role = model[3];
            var isDeleted = bool.Parse(model[4]);

            return new User(id,email,password,role,isDeleted);
        }
    }
}