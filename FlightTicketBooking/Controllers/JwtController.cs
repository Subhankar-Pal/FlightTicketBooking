using FlightRepositories.Data;
using FlightTicketBooking.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HouseServiceApp.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        //public short AuthenticatedId { get; set; }
        private IConfiguration _configuration;
        private readonly FlightTBookingContext _context;

        public TokenController(IConfiguration configuration, FlightTBookingContext context)
        {
            this._configuration = configuration;
            this._context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserCred _userData)
        {
            if (_userData != null && _userData.username != null && _userData.password != null)
            {
                var user = await GetUser(_userData.username, _userData.password);

                if (user != null)
                {
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        
                        new Claim("Username", user.username),
                        new Claim("Type", "admin" )

                    };
                    //AuthenticatedId = user.CustomerId;
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<UserCred> GetUser(string username, string password)
        {
            UserCred u = new UserCred();
            if(u.username == username && u.password == password)
            {
                return u;
            }
            return null;
            //return await UserCred.FirstOrDefaultAsync(u => == email && u.password == password);
        }
    }
}








/*using FlightRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightTicketBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtController : ControllerBase
    {
        private readonly IJwtAuthenticationManager jam;
        public JwtController(IJwtAuthenticationManager jam)
        {
            this.jam = jam;
        }
        [HttpGet]
        public IEnumerable<string > Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] UserCred userCred)
        {
            var token = jam.Authenticate(userCred.Username, userCred.Password);
            if(token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }

    }
}
*/