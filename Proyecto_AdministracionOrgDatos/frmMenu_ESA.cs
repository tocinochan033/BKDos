using Microsoft.VisualBasic;
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
        Form loginForm = new FormLogin_ESA();
        private FuentePersonalizada fontPers = new FuentePersonalizada();

        //Variables para las diferentes pantallas
        frmRegistrarBecarios_ESA PantallaRegistro;
        Mostrar_datos PantallaConsulta;

        public frmMenu_ESA()
        {
            InitializeComponent();  
        }

        //Configuracion del boton de Registrar y modificar
        private void btnRegistrarUsuarios_ESA_Click(object sender, EventArgs e)
        {
            PantallaRegistro = new frmRegistrarBecarios_ESA();
            PantallaRegistro.FormClosed += PantallasCerradas;
            PantallaRegistro.MdiParent = this;
            PantallaRegistro.Show();
        }

        private void PantallasCerradas (object sender, FormClosedEventArgs e)
        {
            PantallaRegistro = null;
            PantallaConsulta = null;
        }


        // ----------------------------------------------------------------------

        private void btnCerrarSesion_ESA_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginForm.Show();
        }

        private void frmMenu_ESA_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            CargarFuentes();
        }

        //Configuracion del boton de Consultas
        private void btnConsultar_ESA_Click(object sender, EventArgs e)
        {
            /*
            Form pbjMostrarDatos = new Mostrar_datos();
            pbjMostrarDatos.Show();
            this.Hide();*/

  
                PantallaConsulta = new Mostrar_datos();
                PantallaConsulta.FormClosed += PantallasCerradas;
                PantallaConsulta.MdiParent = this;
                PantallaConsulta.Show();
        }

        public void CargarFuentes()
        {
            // Cargar las fuente desde el archivo TTF
            string nombreFuente = "coolveticaRG.otf";
            fontPers.CargarFuentePersonalizada(nombreFuente);
            // Aplicar la fuente a la etiqueta en lblTitulo_ESA
            fontPers.AplicarFuente(label4, 48, FontStyle.Regular);
        }

    }
}
