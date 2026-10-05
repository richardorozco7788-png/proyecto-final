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
    public class ProductoRepository
    {
 
            // ==========================================
            // LISTAR PRODUCTOS
            // ==========================================

            public List<Producto> Listar()
            {
                List<Producto> lista = new List<Producto>();

                const string sql = @"
                SELECT
                    IdProducto,
                    Nombre,
                    Cantidad,
                    Precio
                FROM Productos
                ORDER BY Nombre;";

                using (SqlConnection conexion =
                       ConexionBD.CrearConexion())
                {
                    conexion.Open();

                    using (SqlCommand comando =
                           new SqlCommand(sql, conexion))
                    {
                        using (SqlDataReader reader =
                               comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new Producto
                                {
                                    IdProducto = Convert.ToInt32(
                                        reader["IdProducto"]),

                                    Nombre = reader["Nombre"].ToString(),

                                    Cantidad = Convert.ToInt32(
                                        reader["Cantidad"]),

                                    Precio = Convert.ToDecimal(
                                        reader["Precio"])
                                });
                            }
                        }
                    }
                }

                return lista;
            }


            // ==========================================
            // AGREGAR PRODUCTO
            // ==========================================

            public bool AgregarProducto(
                string nombre,
                int cantidad,
                decimal precio)
            {
                const string sql = @"
                INSERT INTO Productos
                (
                    Nombre,
                    Cantidad,
                    Precio
                )
                VALUES
                (
                    @Nombre,
                    @Cantidad,
                    @Precio
                );";

                using (SqlConnection conexion =
                       ConexionBD.CrearConexion())
                {
                    conexion.Open();

                    using (SqlCommand comando =
                           new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.AddWithValue(
                            "@Nombre",
                            nombre);

                        comando.Parameters.AddWithValue(
                            "@Cantidad",
                            cantidad);

                        comando.Parameters.AddWithValue(
                            "@Precio",
                            precio);

                        int filas =
                            comando.ExecuteNonQuery();

                        return filas > 0;
                    }
                }
            }


            // ==========================================
            // ACTUALIZAR PRODUCTO
            // ==========================================

            public bool ActualizarProducto(
                int idProducto,
                string nombre,
                int cantidad,
                decimal precio)
            {
                const string sql = @"
                UPDATE Productos
                SET
                    Nombre = @Nombre,
                    Cantidad = @Cantidad,
                    Precio = @Precio
                WHERE IdProducto = @IdProducto;";

                using (SqlConnection conexion =
                       ConexionBD.CrearConexion())
                {
                    conexion.Open();

                    using (SqlCommand comando =
                           new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.AddWithValue(
                            "@IdProducto",
                            idProducto);

                        comando.Parameters.AddWithValue(
                            "@Nombre",
                            nombre);

                        comando.Parameters.AddWithValue(
                            "@Cantidad",
                            cantidad);

                        comando.Parameters.AddWithValue(
                            "@Precio",
                            precio);

                        int filas =
                            comando.ExecuteNonQuery();

                        return filas > 0;
                    }
                }
            }
        }
    }
