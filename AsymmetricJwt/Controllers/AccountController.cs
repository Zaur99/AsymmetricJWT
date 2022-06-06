using AsymmetricJwt.Model;
using AsymmetricJwt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Services.WebApi.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsymmetricJwt.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AuthenticationService authenticationService;

        public AccountController(AuthenticationService AuthenticationService)
        {
            authenticationService = AuthenticationService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] UserCredentials userCredentials)
        {
            try
            {
                string token = authenticationService.Authenticate(userCredentials);
                return Ok(token);
            }
            catch (InvalidCredentialsException)
            {
                return Unauthorized();
            }
        }
    }
}
