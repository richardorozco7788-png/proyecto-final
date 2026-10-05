using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIENDA_DE_CONVENIECIA0._4.MODELOS
{
    public class DetalleVenta
    {
        public int IdProducto { get; set; }

        public string NombreProducto { get; set; } = string.Empty;

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }

        public decimal Subtotal
        {
            get
            {
                return Cantidad * Precio;
            }
        }
    }
}
