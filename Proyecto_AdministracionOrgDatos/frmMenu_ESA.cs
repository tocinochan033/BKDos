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
         
        //Aqui estan las propiedades para agregar la fecha y la hora al programa
        private void FechaHora1_Tick(object sender, EventArgs e)
        {
            HoraC.Text = DateTime.Now.ToShortTimeString();
            FechaC.Text = DateTime.Now.ToShortDateString();
        }

        //Aqui esta el codigo de deslizamiento de la barra de menu
        bool sidebarExpand;
        private void SideBarTimer_Tick(object sender, EventArgs e)
        {

            if (sidebarExpand)
            {
                
                sidebar.Width -= 10;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    SideBarTimer.Stop();
                }
            }else
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    SideBarTimer.Stop();
                }
            }
        }

        //Boton del menu
        private void menuButton_Click(object sender, EventArgs e)
        {
            SideBarTimer.Start();
        }
    }
}
