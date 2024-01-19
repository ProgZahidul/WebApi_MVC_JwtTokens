using ExamApiApp.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web.Http;

namespace ExamApiApp.Controllers
{
    public class AccountController : ApiController
    {
        [Route("~/security")]
        [HttpPost]
        public IHttpActionResult GetToken(UserInfo user)
        {
            UserInfo loginUser = null;

            using (appDb db = new appDb())
            {
                loginUser = db.users.SingleOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
            }

            if (loginUser == null)
            {
                return BadRequest("Invalid credentials");
            }

            
            var key = ConfigurationManager.AppSettings["JwtKey"];
            var issuer = ConfigurationManager.AppSettings["JwtIssuer"];
            var audience = ConfigurationManager.AppSettings["JwtAudience"];

            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var userClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, loginUser.UserName),
                new Claim(ClaimTypes.Role, loginUser.Role.ToString())
            };

            var token = new JwtSecurityToken(issuer, audience, userClaims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: credential);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(jwt);

        }
    }
}
