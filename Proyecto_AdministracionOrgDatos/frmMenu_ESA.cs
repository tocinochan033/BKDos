using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_AdministracionOrgDatos
{
    public partial class frmMenu_ESA : Form
    {
        public frmMenu_ESA()
        {
            InitializeComponent();
        }

        private void btnInventario_ACO_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrarUsuarios_ESA_Click(object sender, EventArgs e)
        {
           Form objRegistrarUsuarios_ACO = new frmRegistrarBecarios_ESA();
            objRegistrarUsuarios_ACO.Show();
            this.Hide();
        }

        private void btnCerrarSesion_ESA_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMenu_ESA_Load(object sender, EventArgs e)
        {
            
            
        }

        private void btnDarBaja_ESA_Click(object sender, EventArgs e)
        {
           
            
        }

        private void btnConsultar_ESA_Click(object sender, EventArgs e)
        {
            Form pbjMostrarDatos = new Mostrar_datos();
            pbjMostrarDatos.Show();
            this.Hide();
        }
    }
}
