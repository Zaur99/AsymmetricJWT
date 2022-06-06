using AsymmetricJwt.Model;
using Microsoft.VisualStudio.Services.WebApi.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsymmetricJwt.Services
{
    public class UserService
    {
        private readonly IEnumerable<UserCredentials> users;

        public UserService()
        {
            users = new List<UserCredentials>
                {
                    new UserCredentials
                    {
                        Name = "Zaur",
                        Password = "test123"
                    }
                };
        }

        public void ValidateCredentials(UserCredentials userCredentials)
        {
            bool isValid =
                users.Any(u =>
                    u.Name == userCredentials.Name &&
                    u.Password == userCredentials.Password);

            if (!isValid)
            {
                throw new InvalidCredentialsException("Invalid Credentials");
            }
        }
    }
}
