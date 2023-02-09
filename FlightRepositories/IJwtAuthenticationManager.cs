using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightRepositories
{
    public interface IJwtAuthenticationManager
    {
        public string Authenticate(string username, string password);
    }
}
