using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetIdentity.Api.Services;
using AspNetIdentity.Shared;
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

            return BadRequest("Some properties are not valid"); // Code 400 error from client side
        }
       
    }
}