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
        /*CREACION DE INSTANCIAS*/
        /*-------------------------INSTANCIAS-----------------------------*/
        //Conexion objeto del tipo sqlConnection para conectarnos fisicamente a la base de datos
        SqlConnection Conexion = new SqlConnection(@"server=pc\DESKTOP-1M2HN6J; Initial Catalog = BKDOS; integrated security=true");

        //Comando objeto del tipo SQLcommand para representar las instrucciones SQL
        SqlCommand Comando;

        //Adaptador objeto del tipo sqlDataAdapter para intercambiar datos entre una
        //fuente de datos (en este caso sql server) y un almacen de datos
        SqlDataAdapter Adaptador = null;

        //Tabla objeto del tipo DATATABLE respresenta una coleccion de registros en memoria del cliente
        DataTable Tabla = new DataTable();

        //------------------------------------Variables-----------------------
        //Almacenar instrucciones SQL
        String Sql = "";
        // DESKTOP-LRR3RR8\SQLEXPRESS
        //DESKTOP-JGTCE3J
        //Variable del tipo string para almacenar el nombre de la instancia SQLSERVER
        String Servidor = @"DESKTOP-1M2HN6J";

        //Variable de tipo string para almacenar el nombre de la base de datos
        String Base_Datos = "BKDOS";
        int indice = 0;
        /*--------------------------Metodo Conectar--------------------------*/
        void Conectar()
        {
            try
            {
                Conexion.ConnectionString = "Data Source =" + Servidor + ";" +
                "Initial Catalog =" + Base_Datos + ";" + "Integrated security = true";
                try
                //Bloque try catch para capturar de excepciones en ejecucion
                {
                    Conexion.Open();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error al tratar de establecer la conexión " + ex.Message);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error en la conexión: " + ex.Message);
            }
        }
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
            //Si el usuario contraseña son identificables, carga al siguiente usuario. A la vez, compara el rol
           /* if (archivoAdmin() || txtUsuario_ESA.Text == "1" && txtContraseña_ESA.Text == "1" || txtUsuario_ESA.Text == "admin" && txtContraseña_ESA.Text == "123456")
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
            }*/
            /*Metodo con bd*/
            try
            {

                //Invocacion del metodo conectar
                Conectar();
                //comando sql para seleccionar los campos de que tablas se obtendran
                using (SqlCommand cmd = new SqlCommand("SELECT Usuario, Contrasena FROM Usuarios WHERE Usuario='" + txtUsuario_ESA.Text + "' AND Contrasena='" + txtContraseña_ESA.Text + "'", Conexion))
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
                        //Cuando no se encontro la informacion
                        errorLogin.Visible = true;
                        txtUsuario_ESA.Focus();
                        SystemSounds.Exclamation.Play();
                        txtContraseña_ESA.Text = "";
                        txtUsuario_ESA.Text = "";
                       

                       
                    }
                }
                Conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

       /* private bool archivoAdmin() //Verifica si el usuario y contraseña coinciden en la misma fila de archivo
        {
            try
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
                   // login.Close();
                }


            }
            catch
            {
                errorLogin.Visible = true;
                SystemSounds.Exclamation.Play();
            }
            
            return false;
        }*/

        //Aqui estan las propiedades para agregar la fecha y la hora al programa
        private void HoraFecha_Tick(object sender, EventArgs e)
        {
            HoraC.Text = DateTime.Now.ToShortTimeString();
            FechaC.Text = DateTime.Now.ToShortDateString();
        }


        private void frmRegistrarButton_Click(object sender, EventArgs e)
        {
            //Se tiene que acceder por medio por contraseña
        

            try
            {
                // Verificar cuando se equivoca el usuario
                //Invocacion del metodo conectar
                Conectar();
                string usuario = Interaction.InputBox("Favor de confirmar usuario", "Usuario");
                string confirmacion = Interaction.InputBox("Favor de confirmar contraseña de administrador", "Contraseña");
                //using (SqlCommand cmd = new SqlCommand("SELECT Usuario, Contrasena FROM Usuarios WHERE Usuario='" + txtUsuario_ESA.Text + "' AND Contrasena='" + txtContraseña_ESA.Text + "'", Conexion))
                using (SqlCommand cmd = new SqlCommand("SELECT Usuario, Contra_admin FROM Usuarios WHERE Usuario='" + usuario + "' AND Contra_admin='" + confirmacion + "'", Conexion))
                {
                    SqlDataReader dr = cmd.ExecuteReader();

                    if(dr.Read())
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
                Conexion.Close();
            }
            catch(Exception es)
            {
                Console.WriteLine("No se agrego ninguna contraseña" + es); 
                Conexion.Close();
            }


        }



        private void lblTitulo_ACO_Click(object sender, EventArgs e)
        {

        }
        private void FormLogin_ESA_Load(object sender, EventArgs e)
        {
            //CargarTextoGuia();

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
    }
}

