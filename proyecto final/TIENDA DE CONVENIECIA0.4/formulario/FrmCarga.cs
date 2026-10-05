using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TIENDA_DE_CONVENIECIA0._4.formulario;



namespace TIENDA_DE_CONVENIECIA0._4
{
    public partial class FrmCarga : Form
    {
        public FrmCarga()
        {
            InitializeComponent();

            InitializeComponent();

            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;

            timer1.Interval = 50;
            timer1.Start();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 5;
            }
            else
            {
                timer1.Stop();

                FrmLogin login = new FrmLogin();

                login.Show();

                this.Hide();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 5;
            }
            else
            {
                timer1.Stop();

                FrmLogin login = new FrmLogin();

                login.Show();

                this.Hide();
            }
    }
}
}
