using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TIENDA_DE_CONVENIECIA0._4.formulario
{
    public partial class FrmEmpleado : Form
    {
        public FrmEmpleado()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGestionarStock_Click(object sender, EventArgs e)
        {
            FrmStock stock = new FrmStock();

            stock.ShowDialog();
        }

        private void btnConsultarStock_Click(object sender, EventArgs e)
        {
            FrmConsultaStock frmConsulta = new FrmConsultaStock();
           
        }

        private void btnCerraSesion_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de que desea cerrar sesión?",
                "Cerrar sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                FrmLogin login = new FrmLogin();

                login.Show();

                this.Close();
            }
    }

        private void FrmEmpleado_Load(object sender, EventArgs e)
        {

        }
    }
}