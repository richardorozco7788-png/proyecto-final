using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIENDA_DE_CONVENIECIA0._4.DATOS;
using TIENDA_DE_CONVENIECIA0._4.MODELOS;

namespace TIENDA_DE_CONVENIECIA0._4.REPOSITORY
{
    public class UsuarioRepository
    {
        
            
        public Usuario IniciarSesion(
            string usuario,
            string contrasena)
            {
                const string sql = @"
                SELECT IdUsuario,
                       Nombre,
                       Usuario,
                       Contrasena,
                       Rol
                FROM Usuarios
                WHERE Usuario = @Usuario
                AND Contrasena = @Contrasena;";

                using (SqlConnection conexion =
                       ConexionBD.CrearConexion())
                {
                    using (SqlCommand comando =
                           new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.AddWithValue(
                            "@Usuario",
                            usuario);

                        comando.Parameters.AddWithValue(
                            "@Contrasena",
                            contrasena);

                        conexion.Open();

                        using (SqlDataReader reader =
                               comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Usuario usuarioEncontrado =
                                    new Usuario();

                                usuarioEncontrado.IdUsuario =
                                    Convert.ToInt32(
                                        reader["IdUsuario"]);

                                usuarioEncontrado.Nombre =
                                    reader["Nombre"].ToString();

                                usuarioEncontrado.UsuarioLogin =
                                    reader["Usuario"].ToString();

                                usuarioEncontrado.Contrasena =
                                    reader["Contrasena"].ToString();

                                usuarioEncontrado.Rol =
                                    reader["Rol"].ToString();

                                return usuarioEncontrado;
                            }
                        }
                    }
                }

                return null;
            }
        }
    }
