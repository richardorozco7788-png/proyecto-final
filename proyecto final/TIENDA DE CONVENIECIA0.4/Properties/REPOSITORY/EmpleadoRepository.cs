using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIENDA_DE_CONVENIECIA0._4.DATOS;

namespace REGISTRO_ESTUDIANTE_0._4.Repositorios
    {
    namespace REGISTRO_ESTUDIANTE_0._4.Repositorios
    {
        public class EmpleadoRepository
        {
            public bool ValidarLogin(string usuario, string contrasena)
            {
                const string sql = @"
                SELECT COUNT(*)
                FROM Empleados
                WHERE Usuario = @Usuario
                AND Contrasena = @Contrasena;";

                using (SqlConnection conexion = ConexionBD.CrearConexion())
                {
                    using (SqlCommand comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.AddWithValue("@Usuario", usuario);
                        comando.Parameters.AddWithValue("@Contrasena", contrasena);

                        conexion.Open();

                        int resultado = Convert.ToInt32(comando.ExecuteScalar());

                        return resultado > 0;
                    }
                }
            }
        }
    }
}


