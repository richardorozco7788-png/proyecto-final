using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIENDA_DE_CONVENIECIA0._4.MODELOS
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string UsuarioLogin { get; set; } = string.Empty;

        public string Contrasena { get; set; } = string.Empty;

        public string Rol { get; set; } = string.Empty;
    }
}
