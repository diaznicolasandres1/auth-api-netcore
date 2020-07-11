using AspNetIdentity.Shared;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetIdentity.Api.Services
{
    public  interface IUserService
    {
        Task<UserManagerResponse> RegisterUserAsync(RegisterRequest model);
        

    }

   

    public class UserService : IUserService
    {
        private UserManager<IdentityUser> _userManager;

        public UserService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        

        public async Task<UserManagerResponse> RegisterUserAsync(RegisterRequest model)
        {
            if(model == null)
            {
                throw new NullReferenceException("Register Model is Null");
            }

            if(model.Password != model.ConfirmPassword)
            {
                return new UserManagerResponse
                {
                    Message = "Confirm password doesn't math with the password",
                    IsSucces = false,                    
                };  
            }

            var identityUser = new IdentityUser
            {
                Email = model.Email,
                UserName = model.Email,
            };

            var result =  await _userManager.CreateAsync(identityUser, model.Password);

            if (result.Succeeded)
            {
                return new UserManagerResponse
                {
                    Message = "User created succesfully!",
                    IsSucces = true,
                };
            }

            return new UserManagerResponse
            {
                Message = "User didnt create",
                IsSucces = false,
                Errors = result.Errors.Select(e => e.Description)

            };

        }
    }
}
