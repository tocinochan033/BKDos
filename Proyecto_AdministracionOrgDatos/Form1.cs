using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_AdministracionOrgDatos
{
    public partial class FormLogin_ESA : Form
    {
        /// <summary>
        /// LOGIN EN HIATUS
        /// </summary>
        private string[] usuario = { "manolo", "jose", "felipe" };
        private string[] contraseña = { "12345", "jacobo", "contraseña" };
        FileStream login = new FileStream("login.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

        public FormLogin_ESA()
        {
            InitializeComponent();
            guardado();
        }

        private void btnSalir_ESA_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnInicioSesion_ESA_Click(object sender, EventArgs e)
        {            
            if (archivoAdmin(usuario, contraseña) || txtUsuario_ESA.Text == "1" && txtContraseña_ESA.Text == "1")
            {
                Form objMenu_ACO = new frmMenu_ESA();
                objMenu_ACO.Show();
                this.Hide();
            }
            else
            {
                errorLogin.Visible = true;
                txtUsuario_ESA.Focus();
                SystemSounds.Exclamation.Play();
            }
        }

        public bool archivoAdmin(string[] usuario, string[] contraseña)
        {
            return true;
        }

        private void guardado()
        {
            using (StreamWriter writer = new StreamWriter(login))
            {
                for (int i = 0; i < usuario.Length; i++)
                {
                    writer.WriteLine($"{usuario[i]},{contraseña[i]}");
                }
            }
        }

        //Aqui estan las propiedades para agregar la fecha y la hora al programa
        private void HoraFecha_Tick(object sender, EventArgs e)
        {
            HoraC.Text = DateTime.Now.ToShortTimeString();
            FechaC.Text = DateTime.Now.ToShortDateString();
        }

        private void lblTitulo_ACO_Click(object sender, EventArgs e)
        {

        }

        private void imgLogin_ACO_Click(object sender, EventArgs e)
        {

        }

        private void FormLogin_ESA_Load(object sender, EventArgs e)
        {

        }
    }
}

