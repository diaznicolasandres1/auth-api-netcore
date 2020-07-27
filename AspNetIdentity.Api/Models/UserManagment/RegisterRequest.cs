using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetIdentity.Api.Models.UserManagment
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Ingrese un Email valido")]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Debe ingresar un nombre")]
        [StringLength(25)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Debe ingresar un apellido")]
        [StringLength(25)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Debe ingresar una contraseña")]
        [StringLength(50)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Debe confirmar su contraseña")]
        [StringLength(50)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Debe ingresar un nombre de empresa")]
        [StringLength(50)]
        public string NombreEmpresa { get; set; }

        [Required(ErrorMessage ="Debe ingresar un telefono")]
        [StringLength(50)]
        public string PhoneNumber { get; set; }

    }
}
