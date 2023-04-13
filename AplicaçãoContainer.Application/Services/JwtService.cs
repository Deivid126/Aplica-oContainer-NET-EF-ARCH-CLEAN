using AplicaçãoContainer.Core.Interfaces;
using AplicaçãoContainer.Core.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;


namespace AplicaçãoContainer.Application.Services
{
    public class JwtService : IJwtService
    {
        

        public string GenerateToken(Cliente cliente)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("dfaslfjapj3924u394u203u492");
            var tokendescription = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(new[] { new Claim("Id", cliente.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokendescription);

            return tokenHandler.WriteToken(token);
        }

        public Guid? ValidateToken(string token)
        {
            if(token == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes("dfaslfjapj3924u394u203u492");

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwttoken = (JwtSecurityToken)validatedToken;
                var id = Guid.Parse(jwttoken.Claims.First(x => x.Type == "Id").Value);


                return id;

            }catch 
            {

                return null;
            
            }


        }
    }

}

