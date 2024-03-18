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
using Microsoft.VisualBasic;

namespace Proyecto_AdministracionOrgDatos
{
    public partial class FormLogin_ESA : Form
    {
        /// <summary>
        /// LOGIN EN HIATUS
        /// </summary>


        private FileStream login;
        public FormLogin_ESA()
        {
            login = new FileStream("login.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            InitializeComponent();
        }

        private void btnSalir_ESA_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnInicioSesion_ESA_Click(object sender, EventArgs e)
        {
            //Si el usuario contraseña son identificables, carga al siguiente usuario. A la vez, compara el rol
            if (archivoAdmin() || txtUsuario_ESA.Text == "1" && txtContraseña_ESA.Text == "1")
            {
                Form objMenu_ACO = new frmMenu_ESA();
                objMenu_ACO.Show();

                this.Hide();
                login.Close();
            }
            else
            {
                errorLogin.Visible = true;
                txtUsuario_ESA.Focus();
                SystemSounds.Exclamation.Play();
            }
        }

        private bool archivoAdmin() //Verifica si el usuario y contraseña coinciden en la misma fila de archivo
        {
            using (StreamReader sr = new StreamReader(login))
            {
                string linea;
                while ((linea = sr.ReadLine()) != null)
                {
                    string[] datos = linea.Split(',');
                    if (datos.Length >= 5)
                    {
                        //Posiciones dentro del arhivo
                        //nombre,correo,numero,rol,contraseña
                        string usuarioArchivo = datos[0];
                        string contrasenaArchivo = datos[4];

                        if (usuarioArchivo == txtUsuario_ESA.Text && contrasenaArchivo == txtContraseña_ESA.Text)
                        {
                            return true;
                        }
                    }
                }
                login.Close();
            }
            return false;
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

        private void frmRegistrarButton_Click(object sender, EventArgs e)
        {
            login.Close();
            string confirmacion = Interaction.InputBox("Favor de confirmar contraseña", "Contraseña"); //messageBox con textbos incluido. Confirma contraseña

            if (int.Parse(confirmacion) == 2) //Cada nuevo administrador requiere confirmacion de contraseña: 2
            {
                Form adminRegistro = new frmRegistroAdmin();
                adminRegistro.Show();
            }
        }
    }
}

