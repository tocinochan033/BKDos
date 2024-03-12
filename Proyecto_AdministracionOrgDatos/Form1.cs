using Microsoft.VisualBasic;
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
        /// Hize una jaladota que ni yo mismo entiendo. 
        /// 
        /// Dentro del archivo 'login.txt' si no existe informacion alguna copien y peguen
        /// 1,correo@gmail.com,632534,mamaoso,1   -  Es el unico usuario para la visualizacion del boton
        /// Esto es para que puedan entrar sin problemas y aparezca el boton de agregar nuevos administradores.
        /// 
        /// El usuario y contraseña sigue siendo 1.
        /// ----------------------------------------------------------------------------------------------------------------------------------------
        /// 
        /// </summary>


        private FuentePersonalizada fontPers;
        private TextoGuia txtGuia;

        //Abre/crea el archivo cada vez que cargue el formulario 
        private FileStream login;
        public FormLogin_ESA()
        {
            login = new FileStream("login.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            InitializeComponent();
            
            fontPers = new FuentePersonalizada();  
            txtGuia = new TextoGuia();

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

        private bool archivoAdmin()
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


        public void CargarTextoGuia()
        {
            //Cuando se entra, sale o cambia el texto del control, se ejecutara el metodo en txtUsuario_ESA
            txtUsuario_ESA.Enter += (s, v) => txtGuia.CuadroTexto_Enter(txtUsuario_ESA, " Ejemplo: Usuario2134");
            txtUsuario_ESA.Leave += (s, v) => txtGuia.CuadroTexto_Enter(txtUsuario_ESA, " Ejemplo: Usuario2134");
            txtUsuario_ESA.TextChanged += (s, v) => txtGuia.CuadroTexto_TextChanged(txtUsuario_ESA);
            //Cuando se entra, sale o cambia el texto del control, se ejecutara el metodo en txtContrasena_ESA
            txtContraseña_ESA.Enter += (s, v) => txtGuia.CuadroTexto_Enter(txtContraseña_ESA, " Ejemplo: Password2781");
            txtContraseña_ESA.Leave += (s, v) => txtGuia.CuadroTexto_Enter(txtContraseña_ESA, " Ejemplo: Password2781");
            txtContraseña_ESA.TextChanged += (s, v) => txtGuia.CuadroTexto_TextChangedPassword(txtContraseña_ESA);
        }

        public void FormLogin_ESA_Load(object sender, EventArgs e)
        {
            CargarTextoGuia();
    

            // Cargar las fuente desde el archivo TTF
            string nombreFuente = "coolveticaRG.otf";
            fontPers.CargarFuentePersonalizada(nombreFuente);
            // Aplicar la fuente a la etiqueta en lblTitulo_ESA
            fontPers.AplicarFuente(lblTitulo_ESA, 28, FontStyle.Regular);
            
            string nombreFuenteBK2 = "Louis George Cafe Bold.ttf";
            fontPers.CargarFuentePersonalizada(nombreFuenteBK2);
            // Aplicar la fuente a la etiqueta en lbl4
            fontPers.AplicarFuente(label4, 47, FontStyle.Regular);

        }


        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Mostrar el texto claro cuando se está escribiendo
            txtContraseña_ESA.PasswordChar = '\0';  // '\0' representa ningún carácter de contraseña 

        }

        private void errorLogin_Click(object sender, EventArgs e)
        {

        }

        //Boton del registro
        private void button1_Click(object sender, EventArgs e)
        {
            string confirmacion = Interaction.InputBox("Favor de confirmar contraseña", "Contraseña"); //messageBox con textbos incluido. Confirma contraseña

            if (int.Parse(confirmacion) == 2) //Cada nuevo administrador requiere confirmacion de contraseña: 2
            {
                Form adminRegistro = new fmrRegistroAdmin();
                adminRegistro.Show();
            }
        }
    }
}

