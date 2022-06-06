using AsymmetricJwt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsymmetricJwt.Services
{
    public class AuthenticationService
    {
        private readonly UserService _userService;
        private readonly TokenService _tokenService;


        public AuthenticationService(UserService userService,TokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }
        public string Authenticate(UserCredentials userCredentials)
        {
            _userService.ValidateCredentials(userCredentials);
            string securityToken = _tokenService.GetToken(userCredentials);

            return securityToken;
        }
    }
}
