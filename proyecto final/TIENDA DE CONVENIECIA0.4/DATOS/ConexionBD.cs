using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIENDA_DE_CONVENIECIA0._4.DATOS

{
    internal class ConexionBD
    {
        private static string cadenaConexion =
            @"Server=RICHARD-ROSTRAN;
              Database=TiendaConveniencia;
              Trusted_Connection=True;
              TrustServerCertificate=True;";

        public static SqlConnection CrearConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}