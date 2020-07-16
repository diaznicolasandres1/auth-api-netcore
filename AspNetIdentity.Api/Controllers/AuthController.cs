using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetIdentity.Api.Models.UserManagment;
using AspNetIdentity.Api.Services;
using AspNetIdentity.Shared;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetIdentity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        // /api/auth/register
        [HttpPost("Register")]
        
        public async Task<IActionResult> RegisterAsync([FromBody]RegisterRequest registerRequest)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterUserAsync(registerRequest);               
                if (result.IsSucces)
                {
                    return Ok(result);
                }
                return BadRequest(result);

            }

            return BadRequest("Algunas propiedades no son validas"); // Code 400 error from client side
        }
        
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginRequest loginRequest)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LoginUserAsync(loginRequest);
                Response.Headers.Add("Access-Control-Allow-Origin", "*");
                if (result.IsSucces)
                {
                    return Ok(result);
                }
                return BadRequest(result);
               
            }
            return BadRequest("Credenciales invalidas");
        }
       
    }
}