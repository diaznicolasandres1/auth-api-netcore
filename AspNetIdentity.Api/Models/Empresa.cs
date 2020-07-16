using System;
using System.Collections.Generic;

namespace AspNetIdentity.Api.Model
{
    public partial class Empresa
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdUsuario { get; set; }
    }
}
