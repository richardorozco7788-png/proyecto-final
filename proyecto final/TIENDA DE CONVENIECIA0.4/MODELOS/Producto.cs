using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIENDA_DE_CONVENIECIA0._4.MODELOS
{
    public class Producto
    {
        public int IdProducto { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }
    }
}
