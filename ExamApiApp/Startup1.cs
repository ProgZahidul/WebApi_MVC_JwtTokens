using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Owin;
using System;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(ExamApiApp.Startup1))]

namespace ExamApiApp
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = ConfigurationManager.AppSettings["JwtIssuer"],
                ValidAudience = ConfigurationManager.AppSettings["JwtAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(ConfigurationManager.AppSettings["JwtKey"]))
            };

            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions { AuthenticationMode = AuthenticationMode.Active, TokenValidationParameters = tokenValidationParameters });
        }
    }
}
