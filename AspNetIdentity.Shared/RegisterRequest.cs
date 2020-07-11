using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AspNetIdentity.Shared
{
    public  class RegisterRequest
    {
        //request from client to server

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength =5)]
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

    }
}
