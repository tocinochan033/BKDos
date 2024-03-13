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
//Se agrega libreria dataclient
//Espacio de nombres requerido para interactuar con SQL SERVER
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_AdministracionOrgDatos
{
    public partial class FormLogin_ESA : Form
    {
        /*-------------------------INSTANCIAS-----------------------------*/
        //Conexion objeto del tipo sqlConnection para conectarnos fisicamente a la base de datos
        SqlConnection Conexion = new SqlConnection(@"server=pc\DESKTOP-JGTCE3J; Initial Catalog = BKDOS; integrated security=true");

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
        String Servidor = @"DESKTOP-JGTCE3J";

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
      /*  private string[] usuario = { "manolo", "jose", "felipe" };
        private string[] contraseña = { "12345", "jacobo", "contraseña" };
        FileStream login = new FileStream("login.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);*/
        

        public FormLogin_ESA()
        {
            InitializeComponent();
           // guardado();
        }

        private void btnSalir_ESA_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        

        private void btnInicioSesion_ESA_Click(object sender, EventArgs e)
        {
            try
            {
                
               
                    Conectar();
                    using (SqlCommand cmd = new SqlCommand("SELECT Usuario, Contrasena FROM Usuarios WHERE Usuario='" + txtUsuario_ESA.Text + "' AND Contrasena='" + txtContraseña_ESA.Text + "'", Conexion))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
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
                            txtContraseña_ESA.Text = "";
                            txtUsuario_ESA.Text = "";
                             Conexion.Close();
                        }
                    }
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

