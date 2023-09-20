using Business.Abstract;
using Business.Constants;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]


        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            var token = userToLogin.Data.JwtToken;



            if (userToLogin.Success)
            {

                return Ok(new { userToLogin.Data, Messages.SuccessfulLogin, result.Success });
           
            }

            return BadRequest(userToLogin.Message);

        }


        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {

            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }
            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            if (registerResult.Success)
            {
                var tokenResult = _authService.CreateAccessToken(registerResult.Data);
                if (tokenResult.Success)
                {
                    registerResult.Data.JwtToken = tokenResult.Data.Token;
                    var response = new { registerResult.Data, Messages.UserRegistered, registerResult.Success };
                    return Ok(response);
        
                }
                else
                {
                    return BadRequest(tokenResult.Message);
                }
            }

            return BadRequest(registerResult.Message);
        }


    }
}
