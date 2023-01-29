using Bussines.Abstract;
using Entity.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLogin userForLogin)
        {
            var userToLogin = _authService.Login(userForLogin);
            if(!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }
            var result = _authService.CreateAccessToken(userToLogin.Data);
            if(result.Success)
            {
                return Ok(userToLogin.Data);
            }
            return BadRequest(userToLogin.Message);

        }
         [HttpPost("Register")]
         public ActionResult Register(UserForRegister userForRegister)
        {
            var userExist = _authService.UserExist(userForRegister.Email);
            if(!userExist.Success)
            {
                return BadRequest(userExist.Message);
            }
            var RegisterResult = _authService.Register(userForRegister, userForRegister.Password);
            var token = _authService.CreateAccessToken(RegisterResult.Data);
            if(token.Success)
            {
                return Ok(token.Data);
            }
            return BadRequest(token.Message);
        }
    }
}
