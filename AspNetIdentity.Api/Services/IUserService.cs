using AspNetIdentity.Api.Models;
using AspNetIdentity.Api.Models.UserManagment;
using AspNetIdentity.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AspNetIdentity.Api.Services
{
    public  interface IUserService
    {
        Task<UserManagerResponse> RegisterUserAsync(RegisterRequest registerRequest);
        Task<UserManagerResponse> LoginUserAsync(LoginRequest loginRequest);
        

    }

   

    public class UserService : IUserService
    {
        private UserManager<ApplicationUser> _userManager;
        private IConfiguration _configuration;

        public UserService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<UserManagerResponse> LoginUserAsync(LoginRequest loginRequest)
        {
            var user = await _userManager.FindByEmailAsync(loginRequest.Email);
            if (user == null)
            {
                return new UserManagerResponse
                {
                    Message = "Usuario incorrecto",
                    IsSucces = false
                };
            }
            var result = await _userManager.CheckPasswordAsync(user, loginRequest.Password);

            if (!result)
            {
                return new UserManagerResponse
                {
                    Message = "Contraseña incorrecta",
                    IsSucces = false
                };
            }

            var claims = new[]
            {
                new Claim("Email",loginRequest.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));


            var token = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key,SecurityAlgorithms.HmacSha256));


            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserManagerResponse
            {
                Message = tokenAsString,
                IsSucces = true,
                ExpireDate = token.ValidTo               
            };


        }

        public async Task<UserManagerResponse> RegisterUserAsync(RegisterRequest request)
        {
            if(request == null)
            {
                throw new NullReferenceException("Register Model is Null");
            }

            if(request.Password != request.ConfirmPassword)
            {
                return new UserManagerResponse
                {
                    Message = "La contraseña de confirmacion no coindice con la actual.",
                    IsSucces = false,                    
                };  
            }

            var applicationUser = new ApplicationUser
            {
                Email = request.Email,
                UserName = request.Email,                
                NombreEmpresa = request.NombreEmpresa,
                PhoneNumber = request.PhoneNumber,
                Name = request.FirstName,
                LastName = request.LastName                
                
            };

            var result =  await _userManager.CreateAsync(applicationUser, request.Password);

            if (result.Succeeded)
            {
                //TODO: Send a confirmation email
                return new UserManagerResponse
                {
                    Message = "El usuario se creo correctamente!",
                    IsSucces = true,
                };
            }

            return new UserManagerResponse
            {
                Message = "No se pudo crear el usuario",
                IsSucces = false,
                Errors = result.Errors.Select(e => e.Description)

            };

        }
    }


}
