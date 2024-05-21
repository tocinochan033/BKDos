using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
//Se agrega libreria dataclient
//Espacio de nombres requerido para interactuar con SQL SERVER
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Proyecto_AdministracionOrgDatos
{
    public partial class FormLogin_ESA : Form
    {
        /// <summary>
        /// Creacion de instancias y metodo conectar
        /// </summary>
        /// 
        
        /**********************************************************************/
        /// <summary>
        /// LOGIN EN HIATUS
        /// </summary>
        private FuentePersonalizada fontPers = new FuentePersonalizada();
        private TextoGuia txtGuia = new TextoGuia();
       // private FileStream login;


        public FormLogin_ESA()
        {
         //   login = new FileStream("login.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            InitializeComponent();

            //Carga de placeholder
            txtUsuario_ESA_Leave(txtUsuario_ESA, EventArgs.Empty);
            txtContraseña_ESA_Leave(txtContraseña_ESA, EventArgs.Empty);
        }

        private void btnSalir_ESA_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnInicioSesion_ESA_Click(object sender, EventArgs e)
        {
            /*using (SqlConnection con = DB_Conexion.GetConnection())
            {*/
                /*Metodo con bd*/
                try
                {
                    string username=txtUsuario_ESA.Text;
                    string password = txtContraseña_ESA.Text;
                    //Invocacion del metodo conectar
                   // Conectar();

                    /*------------------------------Correccion de login--------------------------------*/
                    
                    if(ValidLogin(username,password))
                    {
                        //Se muestra los otros datos
                        Form objMenu_ACO = new frmMenu_ESA();
                        objMenu_ACO.Show();
                        this.Hide();
                    }
                    else
                    {
                        //Cuando no se encontro la informacion
                        errorLogin.Visible = true;
                        txtUsuario_ESA.Focus();
                        SystemSounds.Exclamation.Play();
                        txtContraseña_ESA.Text = "";
                        txtUsuario_ESA.Text = "";
                    }
                    
                    /*---------------------------------------------------------------------------------*/
                    //comando sql para seleccionar los campos de que tablas se obtendran
                   /* using (SqlCommand cmd = new SqlCommand("SELECT Usuario, Contrasena FROM Usuarios WHERE Usuario='" + txtUsuario_ESA.Text + "' AND Contrasena='" + txtContraseña_ESA.Text + "'", Conexion))
                    {
                        //se ejecuta la variable para leer el comando de ejecutar
                        SqlDataReader dr = cmd.ExecuteReader();
                        //si lee los datos corrrectos
                        if (dr.Read())
                        {
                            //Se muestra los otros datos
                            Form objMenu_ACO = new frmMenu_ESA();
                            objMenu_ACO.Show();
                            this.Hide();

                        }
                        else
                        {
                            MessageBox.Show("Error");
                            //Cuando no se encontro la informacion
                            errorLogin.Visible = true;
                            txtUsuario_ESA.Focus();
                            SystemSounds.Exclamation.Play();
                            txtContraseña_ESA.Text = "";
                            txtUsuario_ESA.Text = "";



                        }
                    }
                   Conexion.Close();*/
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
          
              
        }

        //Aqui estan las propiedades para agregar la fecha y la hora al programa
        private void HoraFecha_Tick(object sender, EventArgs e)
        {
            HoraC.Text = DateTime.Now.ToShortTimeString();
            FechaC.Text = DateTime.Now.ToShortDateString();
        }
        
        private bool ValidLogin (string Usuario,string Passw)
        {
            using (SqlConnection con = DB_Conexion.GetConnection())
            {
                //COUNT (1) Que seleccione solo uno
                string query = "SELECT COUNT(1) FROM Usuarios WHERE Usuario=@Usuario AND Contrasena=@Contrasena";

                SqlCommand cmd = new SqlCommand(query,con);
                cmd.Parameters.AddWithValue("Usuario",Usuario);
                cmd.Parameters.AddWithValue("Contrasena", Passw);

                int result = Convert.ToInt32(cmd.ExecuteScalar());

                return result == 1;
            }
        }
        
        private bool ValidAdmin(string users, string confir)
        {
            using (SqlConnection con = DB_Conexion.GetConnection())
            {
                //COUNT (1) Que seleccione solo uno
                string query = "SELECT COUNT(1) FROM Usuarios WHERE Usuario=@Usuario AND Contra_admin=@Contra_admin";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("Usuario", users);
                cmd.Parameters.AddWithValue("Contra_admin", confir);

                int result = Convert.ToInt32(cmd.ExecuteScalar());

                return result == 1;
            }
        }

        private void frmRegistrarButton_Click(object sender, EventArgs e)
        {
            //Se tiene que acceder por medio por contraseña
            try
            {

                /*using (SqlConnection con = DB_Conexion.GetConnection())
                {*/
                // Verificar cuando se equivoca el usuario
                //Invocacion del metodo conectar

                string usuario = Interaction.InputBox("Favor de confirmar usuario", "Usuario");
                string confirmacion = Interaction.InputBox("Favor de confirmar contraseña de administrador", "Contraseña");
                //Invocacion del metodo conectar
                // Conectar();

                /*------------------------------Correccion de login--------------------------------*/

                if (ValidAdmin(usuario, confirmacion))
                {
                    //Se muestra los otros datos
                    Form adminRegistro = new frmRegistroAdmin();
                    adminRegistro.Show();
                    this.Hide();
                }
                else
                {
                    //Cuando no se encontro la informacion
                    Form login = new FormLogin_ESA();
                    MessageBox.Show("El Usuario y/o Contraseña Administrador INCORRECTOS");
                    login.Show();
                    this.Hide();
                }

                /*---------------------------------------------------------------------------------*/

               /* Conectar();
                string usuario = Interaction.InputBox("Favor de confirmar usuario", "Usuario");
                string confirmacion = Interaction.InputBox("Favor de confirmar contraseña de administrador", "Contraseña");
                //using (SqlCommand cmd = new SqlCommand("SELECT Usuario, Contrasena FROM Usuarios WHERE Usuario='" + txtUsuario_ESA.Text + "' AND Contrasena='" + txtContraseña_ESA.Text + "'", Conexion))
                using (SqlCommand cmd = new SqlCommand("SELECT Usuario, Contra_admin FROM Usuarios WHERE Usuario='" + usuario + "' AND Contra_admin='" + confirmacion + "'", Conexion))
                {
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        Form adminRegistro = new frmRegistroAdmin();
                        adminRegistro.Show();
                        this.Hide();
                    }
                    else
                    {
                        Form login = new FormLogin_ESA();
                        MessageBox.Show("El Usuario y/o Contraseña Administrador INCORRECTOS");
                        login.Show();
                        this.Hide();


                    }
                }
               Conexion.Close();*/
            //}
             
               
            }
            catch(Exception es)
            {
                MessageBox.Show(es.ToString());
                Console.WriteLine("No se agrego ninguna contraseña" + es); 
                //Conexion.Close();
            }


        }



        private void lblTitulo_ACO_Click(object sender, EventArgs e)
        {

        }
        private void FormLogin_ESA_Load(object sender, EventArgs e)
        {

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

        //Codigo para lo de ver y no ver la contraseña
        private void VerContra_Click(object sender, EventArgs e)
        {
            NoVerContra.BringToFront();
            txtContraseña_ESA.PasswordChar = '*';
        }

        private void NoVerContra_Click(object sender, EventArgs e)
        {
            VerContra.BringToFront();
            txtContraseña_ESA.PasswordChar = '\0';
        }

       
        //----------------------------------------------
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void errorLogin_Click(object sender, EventArgs e)
        {

        }

        private void txtUsuario_ESA_Enter(object sender, EventArgs e)
        {
            if(txtUsuario_ESA.Text == " Ejemplo: Gerente")
            {
                txtUsuario_ESA.ForeColor = Color.Black;
                txtUsuario_ESA.Text = "";
            }
        }

        private void txtUsuario_ESA_Leave(object sender, EventArgs e)
        {
            if(txtUsuario_ESA.Text == "")
            {
                txtUsuario_ESA.Text = " Ejemplo: Gerente";
            }
        }

        private void txtContraseña_ESA_Enter(object sender, EventArgs e)
        {
            if (txtContraseña_ESA.Text == " Ejemplo: 2024")
            {
                txtContraseña_ESA.ForeColor = Color.Black;
                txtContraseña_ESA.Text = "";
            }
        }

        private void txtContraseña_ESA_Leave(object sender, EventArgs e)
        {
            if(txtContraseña_ESA.Text == "")
            {
                txtContraseña_ESA.Text = " Ejemplo: 2024";
            }
        }

        private void FormLogin_ESA_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void FormLogin_ESA_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}

