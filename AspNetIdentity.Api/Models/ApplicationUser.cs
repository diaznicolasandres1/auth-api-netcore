using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetIdentity.Api.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string NombreEmpresa { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int  IdEmpresa { get; set; }

    }
}
