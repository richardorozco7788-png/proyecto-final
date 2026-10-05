using REGISTRO_ESTUDIANTE_0._4.Repositorios.REGISTRO_ESTUDIANTE_0._4.Repositorios;
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
using TIENDA_DE_CONVENIECIA0._4.MODELOS;
using TIENDA_DE_CONVENIECIA0._4.REPOSITORY;
namespace TIENDA_DE_CONVENIECIA0._4.formulario

{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            // Validar usuario
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                errorProvider1.SetError(
                    txtUsuario,
                    "Ingrese el usuario");

                return;
            }

            // Validar contraseña
            if (string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                errorProvider1.SetError(
                    txtContrasena,
                    "Ingrese la contraseña");

                return;
            }

            // Crear repositorio
            UsuarioRepository repo =
                new UsuarioRepository();

            // Intentar iniciar sesión
            Usuario usuario = repo.IniciarSesion(
                txtUsuario.Text.Trim(),
                txtContrasena.Text);

            // Verificar si encontró el usuario
            if (usuario == null)
            {
                MessageBox.Show(
                    "Usuario o contraseña incorrectos.",
                    "Error de inicio de sesión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            // Abrir formulario según el rol
            if (usuario.Rol == "Cliente")
            {
                FrmCliente cliente =
                    new FrmCliente();

                cliente.Show();

                this.Hide();
            }
            else if (usuario.Rol == "Empleado")
            {
                FrmEmpleado empleado =
                    new FrmEmpleado();

                empleado.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show(
                    "El usuario no tiene un rol válido.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }



















        
        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {
            txtContrasena.PasswordChar = '*';
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            txtContrasena.PasswordChar = '*';
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
           
            }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
    }
    

