﻿using System;
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
        [StringLength(25)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string ConfirmPassword { get; set; }

        [Required]
        public string NombreEmpresa { get; set; }

    }
}
