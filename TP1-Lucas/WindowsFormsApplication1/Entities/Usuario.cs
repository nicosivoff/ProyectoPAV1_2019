using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico.Entities
{
    public class Usuario
    {
        public string IdUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Email { get; set; }
        public Perfil Perfil { get; set; }
    }
}
