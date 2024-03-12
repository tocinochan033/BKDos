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


        private FuentePersonalizada fontPers;
        private TextoGuia txtGuia;

        public FormLogin_ESA()
        {
            InitializeComponent();
            guardado();
            
            fontPers = new FuentePersonalizada();  
            txtGuia = new TextoGuia();

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
            for(int i = 0; i < usuario.Length; i++)
            {
                if (usuario[i] == txtUsuario_ESA.Text && contraseña[i] == txtContraseña_ESA.Text)
                    return true;
            }
            return false;
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
    }
}

