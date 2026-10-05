using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TIENDA_DE_CONVENIECIA0._4.REPOSITORY;
using TIENDA_DE_CONVENIECIA0._4.formulario;
using TIENDA_DE_CONVENIECIA0._4.MODELOS;


namespace TIENDA_DE_CONVENIECIA0._4.formulario
{
    public partial class FrmStock : Form
    {
        public FrmStock()
        {
            InitializeComponent();
        }

        private void FrmStock_Load(object sender, EventArgs e)
        {
            CargarStock();
        }

        private void CargarStock()
        {
            ProductoRepository repo =
                new ProductoRepository();
            dgvStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStock.ReadOnly = true;
            dgvStock.AllowUserToAddRows = false;
            dgvStock.AllowUserToDeleteRows = false;
            dgvStock.SelectionMode=DataGridViewSelectionMode.FullRowSelect;
        

            
}

private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            // ==============================
            // VALIDAR NOMBRE
            // ==============================

            string nombre = txtProducto.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                errorProvider1.SetError(
                    txtProducto,
                    "Ingrese el nombre del producto.");

                return;
            }

            // ==============================
            // VALIDAR CANTIDAD
            // ==============================

            if (!int.TryParse(
                    txtCantidad.Text,
                    out int cantidad))
            {
                errorProvider1.SetError(
                    txtCantidad,
                    "Ingrese una cantidad válida.");

                return;
            }

            if (cantidad <= 0)
            {
                errorProvider1.SetError(
                    txtCantidad,
                    "La cantidad debe ser mayor que 0.");

                return;
            }

            // ==============================
            // VALIDAR PRECIO
            // ==============================

            if (!decimal.TryParse(
                    txtPrecio.Text,
                    out decimal precio))
            {
                errorProvider1.SetError(
                    txtPrecio,
                    "Ingrese un precio válido.");

                return;
            }

            if (precio <= 0)
            {
                errorProvider1.SetError(
                    txtPrecio,
                    "El precio debe ser mayor que 0.");

                return;
            }

            // ==============================
            // GUARDAR EN SQL SERVER
            // ==============================

            ProductoRepository repo =
                new ProductoRepository();

            bool resultado =
                repo.AgregarProducto(
                    nombre,
                    cantidad,
                    precio);

            // ==============================
            // RESULTADO
            // ==============================

            if (resultado)
            {
                MessageBox.Show(
                    "Producto guardado correctamente.",
                    "Tienda",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                txtProducto.Clear();
                txtCantidad.Clear();
                txtPrecio.Clear();

                CargarStock();
            }
            else
            {
                MessageBox.Show(
                    "No se pudo guardar el producto.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {

        }
    }
}