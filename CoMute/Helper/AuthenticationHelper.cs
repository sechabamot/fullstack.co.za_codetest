using CoMute.Models;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CoMute.Helpers
{
    /// <summary>
    /// Class with methods for manipulating the application user object.
    /// </summary>
    public static class AuthenticationHelper
    {

        /// <summary>
        /// Grante the user a token that allows them access to the protected endpoints of the application.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="secret"></param>
        /// <returns></returns>
        public static AuthenticationResult Authenticate(string email, string secret)
        {

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(secret);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, email)
                }),

                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new AuthenticationResult(email, tokenHandler.WriteToken(token));

        }

    }
}
