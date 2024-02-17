using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_AdministracionOrgDatos
{
    public partial class FormLogin_ESA : Form
    {
        public FormLogin_ESA()
        {
            InitializeComponent();
        }

        private void lblTitulo_ACO_Click(object sender, EventArgs e)
        {

        }

        private void imgLogin_ACO_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_ESA_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnInicioSesion_ESA_Click(object sender, EventArgs e)
        {
            if (txtUsuario_ESA.Text == "HijosTrueno" && txtContraseña_ESA.Text == "rode2024")
            {
                Form objMenu_ACO = new frmMenu_ESA();
                objMenu_ACO.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Datos Invalidos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsuario_ESA.Text = "";
                txtContraseña_ESA.Text = "";
                txtUsuario_ESA.Focus();
            }
        }
    }
}

