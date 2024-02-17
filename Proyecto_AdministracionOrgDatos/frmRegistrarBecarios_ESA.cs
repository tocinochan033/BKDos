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
    public partial class frmRegistrarBecarios_ESA : Form
    {
        public frmRegistrarBecarios_ESA()
        {
            InitializeComponent();
        }

        private void btnRegresarMenu_ESA_Click(object sender, EventArgs e)
        {
            Form objMenu_ESA = new frmMenu_ESA();
            objMenu_ESA.Show();
            this.Hide();

        }

        private void btnLimpiar_ESA_Click(object sender, EventArgs e)
        {
            txtNombre_ESA.Text = "";
            txtCorreo_ESA.Text = "";
            txtRegistroClientes_ESA.Text = "";

        }

        private void btnAgregar_ESA_Click(object sender, EventArgs e)
        {
            string Nombre_ESA = txtNombre_ESA.Text;
            string Correo_ESA = txtCorreo_ESA.Text;
            txtRegistroClientes_ESA.AppendText(Nombre_ESA + "\t" + Correo_ESA + "\r\n");
        }
    }
}
