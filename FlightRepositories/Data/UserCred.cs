using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightRepositories.Data
{
    public class UserCred
    {
        public string username = "Admin";
        public string password = "1234";
        public string Username
        {
            set { username = value; }
            get { return username; }
        }

        public string Password
        {
            set { password = value; }
            get { return password; }
        }


    }
}
