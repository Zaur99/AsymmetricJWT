using AsymmetricJwt.JwtRelated;
using AsymmetricJwt.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AsymmetricJwt.Services
{
    public class TokenService
    {
        private readonly SigningAudienceCertificate signingAudienceCertificate;

        public TokenService()
        {
            signingAudienceCertificate = new SigningAudienceCertificate();
        }


        public string GetToken(UserCredentials userCredentials)
        {
            SecurityTokenDescriptor tokenDescriptor = GetTokenDescriptor(userCredentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(securityToken);

            return token;
        }

        private SecurityTokenDescriptor GetTokenDescriptor(UserCredentials userCredentials)
        {
            const int expiringDays = 7;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[] { new Claim(ClaimTypes.Name,userCredentials.Name) }),
                Expires = DateTime.UtcNow.AddDays(expiringDays),
                SigningCredentials = signingAudienceCertificate.GetAudienceSigningKey()
            };

            return tokenDescriptor;
        }
    }
}
