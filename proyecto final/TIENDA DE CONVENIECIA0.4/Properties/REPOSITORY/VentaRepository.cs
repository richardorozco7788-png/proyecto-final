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
    public class VentaRepository
    {
        public int RegistrarVenta(
            decimal total,
            List<DetalleVenta> detalles)
        {
            if (detalles == null || detalles.Count == 0)
            {
                throw new Exception(
                    "La venta no contiene productos.");
            }

            using (SqlConnection conexion = ConexionBD.CrearConexion())
            {
                conexion.Open();

                using (SqlTransaction transaccion =
                       conexion.BeginTransaction())
                {
                    try
                    {
                        // =========================================
                        // 1. REGISTRAR LA VENTA
                        // =========================================

                        const string sqlVenta = @"
                            INSERT INTO Ventas
                            (FechaHora, Total)
                            OUTPUT INSERTED.IdVenta
                            VALUES
                            (GETDATE(), @Total);";

                        int idVenta;

                        using (SqlCommand comandoVenta =
                               new SqlCommand(
                                   sqlVenta,
                                   conexion,
                                   transaccion))
                        {
                            comandoVenta.Parameters.Add(
                                "@Total",
                                System.Data.SqlDbType.Decimal);

                            comandoVenta.Parameters["@Total"].Precision = 10;
                            comandoVenta.Parameters["@Total"].Scale = 2;
                            comandoVenta.Parameters["@Total"].Value = total;

                            idVenta = Convert.ToInt32(
                                comandoVenta.ExecuteScalar());
                        }

                        // =========================================
                        // 2. REGISTRAR CADA DETALLE DE LA VENTA
                        // =========================================

                        const string sqlDetalle = @"
                            INSERT INTO DetalleVenta
                            (
                                IdVenta,
                                IdProducto,
                                Cantidad,
                                Precio,
                                Subtotal
                            )
                            VALUES
                            (
                                @IdVenta,
                                @IdProducto,
                                @Cantidad,
                                @Precio,
                                @Subtotal
                            );";

                        // =========================================
                        // 3. DESCONTAR EL STOCK
                        // =========================================

                        const string sqlStock = @"
                            UPDATE Productos
                            SET Cantidad = Cantidad - @Cantidad
                            WHERE IdProducto = @IdProducto
                            AND Cantidad >= @Cantidad;";

                        foreach (DetalleVenta detalle in detalles)
                        {
                            // -----------------------------------------
                            // Insertar detalle
                            // -----------------------------------------

                            using (SqlCommand comandoDetalle =
                                   new SqlCommand(
                                       sqlDetalle,
                                       conexion,
                                       transaccion))
                            {
                                comandoDetalle.Parameters.AddWithValue(
                                    "@IdVenta",
                                    idVenta);

                                comandoDetalle.Parameters.AddWithValue(
                                    "@IdProducto",
                                    detalle.IdProducto);

                                comandoDetalle.Parameters.AddWithValue(
                                    "@Cantidad",
                                    detalle.Cantidad);

                                comandoDetalle.Parameters.Add(
                                    "@Precio",
                                    System.Data.SqlDbType.Decimal);

                                comandoDetalle.Parameters["@Precio"].Precision = 10;
                                comandoDetalle.Parameters["@Precio"].Scale = 2;
                                comandoDetalle.Parameters["@Precio"].Value =
                                    detalle.Precio;

                                comandoDetalle.Parameters.Add(
                                    "@Subtotal",
                                    System.Data.SqlDbType.Decimal);

                                comandoDetalle.Parameters["@Subtotal"].Precision = 10;
                                comandoDetalle.Parameters["@Subtotal"].Scale = 2;
                                comandoDetalle.Parameters["@Subtotal"].Value =
                                    detalle.Subtotal;

                                comandoDetalle.ExecuteNonQuery();
                            }

                            // -----------------------------------------
                            // Descontar stock
                            // -----------------------------------------

                            using (SqlCommand comandoStock =
                                   new SqlCommand(
                                       sqlStock,
                                       conexion,
                                       transaccion))
                            {
                                comandoStock.Parameters.AddWithValue(
                                    "@IdProducto",
                                    detalle.IdProducto);

                                comandoStock.Parameters.AddWithValue(
                                    "@Cantidad",
                                    detalle.Cantidad);

                                int filasAfectadas =
                                    comandoStock.ExecuteNonQuery();

                                if (filasAfectadas == 0)
                                {
                                    throw new Exception(
                                        "No hay suficiente stock para el producto: "
                                        + detalle.NombreProducto);
                                }
                            }
                        }

                        // =========================================
                        // 4. CONFIRMAR LA TRANSACCIÓN
                        // =========================================

                        transaccion.Commit();

                        return idVenta;
                    }
                    catch
                    {
                        // Si ocurre cualquier error,
                        // se deshacen todas las operaciones.
                        transaccion.Rollback();

                        throw;
                    }
                }
            }
        }
    }
}