using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace AsymmetricJwt.JwtRelated
{
    public class SigningAudienceCertificate
    {
        public SigningCredentials GetAudienceSigningKey()
        {
            RSA rsa = RSA.Create();
            string privateXmlKey = File.ReadAllText("./privateKey.xml");
            rsa.FromXmlString(privateXmlKey);
            
            return new SigningCredentials(
                key: new RsaSecurityKey(rsa),
                algorithm: SecurityAlgorithms.RsaSha256);
        }
    }
}
