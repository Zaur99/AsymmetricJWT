using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace AsymmetricJwt.JwtRelated
{
    public class SigningIssuerCertificate
    {
      
        public RsaSecurityKey GetIssuerSigningKey()
        {
            RSA rsa = RSA.Create();
            string publicXmlKey = File.ReadAllText("./publicKey.xml");
            rsa.FromXmlString(publicXmlKey);

            return new RsaSecurityKey(rsa);
        }
    }
}
