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

namespace TIENDA_DE_CONVENIECIA0._4.formulario
{
    public partial class FrmRecibo : Form
    {
        private readonly int idVenta;
        private readonly List<DetalleVenta> detalles;
        private readonly decimal total;

        public FrmRecibo(
            int idVenta,
            List<DetalleVenta> detalles,
            decimal total)
        {
            InitializeComponent();

            this.idVenta = idVenta;
            this.detalles = detalles;
            this.total = total;
        }

        private void FrmRecibo_Load(object sender, EventArgs e)
        {
            lblNumeroVenta.Text = "Venta N.º: " + idVenta;
            lblFecha.Text = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy");
            lblHora.Text = "Hora: " + DateTime.Now.ToString("HH:mm:ss");
            lblTotal.Text = "TOTAL: C$ " + total.ToString("N2");

            dgvRecibo.DataSource = detalles
                .Select(x => new
                {
                    Producto = x.NombreProducto,
                    Cantidad = x.Cantidad,
                    Precio = x.Precio,
                    Subtotal = x.Subtotal
                })
                .ToList();

            dgvRecibo.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvRecibo.ReadOnly = true;
            dgvRecibo.AllowUserToAddRows = false;
            dgvRecibo.AllowUserToDeleteRows = false;
            dgvRecibo.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmRecibo_Load_1(object sender, EventArgs e)
        {

            lblNumeroVenta.Text = "Venta N.º: " + idVenta;
            lblFecha.Text = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy");
            lblHora.Text = "Hora: " + DateTime.Now.ToString("HH:mm:ss");
            lblTotal.Text = "TOTAL: C$ " + total.ToString("N2");

            dgvRecibo.DataSource = detalles
                .Select(x => new
                {
                    Producto = x.NombreProducto,
                    Cantidad = x.Cantidad,
                    Precio = x.Precio,
                    Subtotal = x.Subtotal
                })
                .ToList();

            dgvRecibo.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvRecibo.ReadOnly = true;
            dgvRecibo.AllowUserToAddRows = false;
            dgvRecibo.AllowUserToDeleteRows = false;
            dgvRecibo.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
        }
    }
}
