using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebProject.BO
{
    public class User
    {
        private readonly string _name;
        private readonly string _password;

        public List<String> DataUser { get; set; }

        public User(string name, string password)
        {
            this._name = name;
            this._password = password;
            DataUser = new List<String> { this._name, this._password };
        }
    }
}
