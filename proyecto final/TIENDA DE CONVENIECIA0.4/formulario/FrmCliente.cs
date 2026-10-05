using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TIENDA_DE_CONVENIECIA0._4.MODELOS;
using TIENDA_DE_CONVENIECIA0._4.REPOSITORY;
using TIENDA_DE_CONVENIECIA0._4.DATOS;


namespace TIENDA_DE_CONVENIECIA0._4.formulario
{





















    public partial class FrmCliente : Form
    {
       


















        public FrmCliente()
        {
            InitializeComponent();


        }
        private readonly ProductoRepository productoRepository =
    new ProductoRepository();

        private List<Producto> productos = new List<Producto>();

        private List<DetalleVenta> carrito = new List<DetalleVenta>();
        private readonly VentaRepository ventaRepository =
            new VentaRepository();

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }



        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (carrito.Count == 0)
            {
                MessageBox.Show(
                    "El carrito está vacío.",
                    "Venta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // CALCULAR EL TOTAL
            decimal total = carrito.Sum(x => x.Subtotal);

            try
            {
                // Registrar la venta en SQL Server
                int idVenta = ventaRepository.RegistrarVenta(
                    total,
                    carrito);

                // Copiar el carrito para el recibo
                List<DetalleVenta> detallesRecibo =
                    new List<DetalleVenta>(carrito);

                // Abrir recibo
                FrmRecibo recibo = new FrmRecibo(
                    idVenta,
                    detallesRecibo,
                    total);

                recibo.ShowDialog();

                // Limpiar carrito
                carrito.Clear();

                // Actualizar pantalla
                ActualizarCarrito();
                CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo registrar la venta.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {

        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            CargarProductos();
            ConfigurarCarrito();
        }
        private void CargarProductos()
        {
            productos = productoRepository.Listar();

            cmbProductos.DataSource = productos;

            cmbProductos.DisplayMember = "Nombre";

            cmbProductos.ValueMember = "IdProducto";
        }
        private void ConfigurarCarrito()
        {
            dgvCarrito.AutoGenerateColumns = true;
            dgvCarrito.DataSource = null;
            dgvCarrito.DataSource = carrito;
        }
        private void ActualizarCarrito()
        {
            dgvCarrito.DataSource = null;

            dgvCarrito.DataSource = carrito;

            CalcularTotal();
        }
        private void CalcularTotal()
        {
            decimal total = carrito.Sum(x => x.Subtotal);

            lblTotal.Text =
                $"TOTAL: C$ {total:N2}";
        }

        private void cmbAgregar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (cmbProductos.SelectedItem == null)
            {
                errorProvider1.SetError(
                    cmbProductos,
                    "Seleccione un producto.");

                return;
            }

            Producto producto =
                (Producto)cmbProductos.SelectedItem;

            int cantidad =
                Convert.ToInt32(nudCantidad.Value);

            if (cantidad <= 0)
            {
                errorProvider1.SetError(
                    nudCantidad,
                    "La cantidad debe ser mayor que 0.");

                return;
            }

            if (cantidad > producto.Cantidad)
            {
                MessageBox.Show(
                    "No existe suficiente stock.");

                return;
            }

            DetalleVenta existente =
                carrito.FirstOrDefault(
                    x => x.IdProducto ==
                         producto.IdProducto);

            if (existente != null)
            {
                if (existente.Cantidad + cantidad >
                    producto.Cantidad)
                {
                    MessageBox.Show(
                        "No existe suficiente stock.");

                    return;
                }

                existente.Cantidad += cantidad;
            }
            else
            {
                carrito.Add(
                    new DetalleVenta
                    {
                        IdProducto =
                            producto.IdProducto,

                        NombreProducto =
                            producto.Nombre,

                        Cantidad =
                            cantidad,

                        Precio =
                            producto.Precio
                    });
            }

            ActualizarCarrito();
        }
    }
    }

