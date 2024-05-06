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
using Microsoft.VisualBasic;

namespace Proyecto_AdministracionOrgDatos
{
    public partial class frmRegistroAdmin : Form
    {
        /*llamamiento de clase*/
        //  ClaseBD ClaseBd = new ClaseBD();

        /*-------------------------INSTANCIAS-----------------------------*/
        
        //SqlConnection Conexion = new SqlConnection(@"server=pc\DESKTOP-EOG5OVI; Initial Catalog = BKDOS; integrated security=true");


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
        
        //String Servidor = @"DESKTOP-EOG5OVI";

        //Variable de tipo string para almacenar el nombre de la base de datos
        String Base_Datos = "BKDOS";
        int indice = 0;

        Form loginForm = new FormLogin_ESA();



        /*------------------------METODO PARA CARGAR DATOS--------------------*/
        //crea aleatoriamente numeros de 6 digitos para la contraseña
        Random rnd = new Random();
        FuentePersonalizada fontPers = new FuentePersonalizada();

        public frmRegistroAdmin()
        {
            InitializeComponent();
            LlenarDGV();
           
        }        

        private void newAdminButton_Click(object sender, EventArgs e)
        {
            if (HayCamposVacios())
            {
                MessageBox.Show("Favor de no olvidar todos los datos en casa.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
                for (int i = 0; i < tabControl1.TabPages.Count; i++)
                {
                    foreach (Control control in tabControl1.TabPages[i].Controls)
                    {
                        if (control is System.Windows.Forms.TextBox textBox && string.IsNullOrEmpty(textBox.Text))
                        {
                            tabControl1.SelectTab(i);
                            textBox.Focus();
                            return; // Terminamos la búsqueda después de moverse a la pestaña adecuada
                        }
                        else if (control is System.Windows.Forms.ComboBox comboBox && comboBox.SelectedIndex == -1)
                        {
                            tabControl1.SelectTab(i);
                            comboBox.Focus();
                            return; // Terminamos la búsqueda después de moverse a la pestaña adecuada
                        }
                    }
                }
            }

            string correoElectronico = correoTxt.Text;
            if (!correoElectronico.Contains("@") || !correoElectronico.EndsWith(".com"))
            {
                MessageBox.Show("Por favor, ingrese una dirección de correo electrónico válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;//Detener la ejecucion del metodo si el correo electronico no es valido
            }

          //  Conectar();
            string correo = correoTxt.Text;

            if (valiCorreo(correo)==true)
            {
                MessageBox.Show("Dirección de correo electrónico válidada.");
                //return;
            }
            else
            {
                MessageBox.Show("Por favor, ingrese una dirección de correo electrónico válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using(SqlConnection con = DB_Conexion.GetConnection())
            {
               
                Sql = "";
                Sql = "INSERT INTO Usuarios (Usuario, Contrasena, Correo, Rol, NumeroTelefonico, Contra_admin, Estado) values (@Usuario, @Contrasena, @Correo,@Rol, @NumeroTelefonico, @Contra_admin, @Estado)";
                Comando = new SqlCommand(Sql, con);
                Comando.Parameters.AddWithValue("@Usuario", nombreTxt.Text);
                Comando.Parameters.AddWithValue("@Contrasena", txtContrasena.Text);
                Comando.Parameters.AddWithValue("@Correo", correoTxt.Text);
                Comando.Parameters.AddWithValue("@Rol", rolCombo.Text);
                Comando.Parameters.AddWithValue("@NumeroTelefonico", numeroTxt.Text);
                Comando.Parameters.AddWithValue("@Contra_admin", txtAdminContra.Text);
                Comando.Parameters.AddWithValue("@Estado", 1);

                try
                {

                    Comando.ExecuteNonQuery();

                    MessageBox.Show("Registro Administrador Insertado");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                }

            }


                camposLimpieza();
               
                RefrescarDatos();



        }

       

        public void camposLimpieza()
        {
            nombreTxt.Text = null;
            correoTxt.Text = null;
            numeroTxt.Text = null;
            rolCombo.Text = null;
            txtAdminContra.Text = null;
            txtContrasena.Text = null;
        }

        private void eliminarAdminButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar cuando se equivoca el usuario
                //Invocacion del metodo conectar
               

                SystemSounds.Exclamation.Play();
                string confirmacion = Interaction.InputBox("Favor de confirmar contraseña", "Contraseña"); //messageBox con textbos incluido. Confirma contraseña

                //using (SqlCommand cmd = new SqlCommand("SELECT Usuario, Contrasena FROM Usuarios WHERE Usuario='" + txtUsuario_ESA.Text + "' AND Contrasena='" + txtContraseña_ESA.Text + "'", Conexion))
                if (administradoresDataGrid.CurrentRow.Index > -1)
                {
                    using(SqlConnection con = DB_Conexion.GetConnection())
                    {
                        EliminarAdmin();
                    }
                    RefrescarDatos();
                    /*   using (SqlCommand cmd = new SqlCommand("SELECT Contra_admin FROM Usuarios WHERE Contra_admin='" + confirmacion + "'", Conexion))
                       {
                           SqlDataReader dr = cmd.ExecuteReader();

                           if (dr.Read())
                           {

                               RefrescarDatos();
                           }


                           else
                           {
                               Form login = new FormLogin_ESA();
                               MessageBox.Show("El Usuario y/o Contraseña Administrador INCORRECTOS");
                               login.Show();
                               this.Hide();

                           }
                       }*/
                    //  Conexion.Close();
                }
                else

                {
                    MessageBox.Show("Seleccione una FILA DE DATOS");
                }
           
                //Utiliza la misma logica para borrar datos de becarios. A excepcion de pedir contraseña: 2

            }


            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }
        public void EliminarAdmin()
        {

            int seleccion = administradoresDataGrid.CurrentRow.Index;
            //dgv_Agregar.Rows.RemoveAt(dgv_Agregar.CurrentRow.Index);

            using(SqlConnection con = DB_Conexion.GetConnection())
            {
                Sql = "DELETE FROM Usuarios WHERE Id_Usuario = @Id_Usuario";
                Comando = new SqlCommand(Sql, con);
                Comando.Parameters.AddWithValue("@Id_Usuario", administradoresDataGrid.Rows[seleccion].Cells[0].Value);



                //Comando Try
                try
                {
                    Comando.ExecuteNonQuery();

                    MessageBox.Show("Registro Eliminado");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                }
            }
           
           
        }     

        public void CargarFuentes()
        {
            // Cargar las fuente desde el archivo TTF
            string nombreFuente = "coolveticaRG.otf";
            fontPers.CargarFuentePersonalizada(nombreFuente);
            // Aplicar la fuente a la etiqueta en lblTitulo_ESA
            fontPers.AplicarFuente(label1, 28, FontStyle.Regular);

            // Cargar las fuente desde el archivo TTF
            string nombreFuente2 = "coolveticaRG.otf";
            fontPers.CargarFuentePersonalizada(nombreFuente);
            // Aplicar la fuente a la etiqueta en lblTitulo_ESA
            fontPers.AplicarFuente(label2, 28, FontStyle.Regular);
        }

        private void frmRegistroAdmin_Load(object sender, EventArgs e)
        {
            CargarFuentes();
        }

        public void LlenarDGV()
        {
            //Query Primera Tabla
            using(SqlConnection con = DB_Conexion.GetConnection())
            {
                //Sql = "SELECT Id_Alumno, ApellidoPaterno, ApellidoMaterno, Nombres, FechaNacimiento, Edad, Curp, EstadoCivil, Genero, Domicilio, CodigoPostal, Nacionalidad, EstadoNacimiento, Municipio, Correo, Telefono, Carrera, Periodo, Promedio, Modelo, CCT FROM DatosGenerales, DatosContacto, DatosAcademicos";
                Sql = "SELECT Id_Usuario , Usuario, Contrasena, Correo, Rol, NumeroTelefonico, Contra_admin from Usuarios WHERE Estado = 1";
                Adaptador = new SqlDataAdapter(Sql, con);
                Adaptador.Fill(Tabla);
                administradoresDataGrid.DataSource = Tabla;
            }
 
          
        }
        public void RefrescarDatos()
        {
            Tabla.Clear();
            administradoresDataGrid.ClearSelection();
            using (SqlConnection con = DB_Conexion.GetConnection())
            {
                // Sql = "SELECT Id_Alumno, ApellidoPaterno, ApellidoMaterno, Nombres, FechaNacimiento, Edad, Curp, EstadoCivil, Genero, Domicilio, CodigoPostal, Nacionalidad, EstadoNacimiento, Municipio, Correo, Telefono, Carrera, Periodo, Promedio, Modelo, CCT FROM DatosGenerales, DatosContacto, DatosAcademicos";
                Sql = "SELECT Id_Usuario, Usuario, Contrasena, Correo, Rol, NumeroTelefonico, Contra_admin from Usuarios WHERE Estado = 1";
                Adaptador = new SqlDataAdapter(Sql, con);
                Adaptador.Fill(Tabla);
                administradoresDataGrid.DataSource = Tabla;
            }
           

        }

        private bool HayCamposVacios()
        {
            // Suponiendo que los controles están directamente en los TabPage
            // foreach (tipo elemento in colección) .TabPages(Toma todas las paginas del TabControl
            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                // foreach (tipo elemento in colección) .Controls(Obtiene todos los controles dentro del tabPage)
                foreach (Control control in tabPage.Controls)
                {
                    //Si hay un control de tipo Textbox y su valor string esta nulo o vacio, regresara true
                    if (control is System.Windows.Forms.TextBox textBox && string.IsNullOrEmpty(textBox.Text))
                    {
                        return true;

                    }
                    //Si hay un control de tipo ComboBox y su valor string esta nulo o vacio, regresara true
                    else if (control is System.Windows.Forms.ComboBox comboBox && comboBox.SelectedIndex == -1)
                        return true;
                }
            }
            return false; //Regresa falso si ningun campo esta vacio
        }

        public bool valiCorreo(string email)
        {
            if (email.Contains("@") && email.EndsWith(".com"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void frmRegistroAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                SystemSounds.Exclamation.Play();
                // El usuario ha hecho clic en la "X" para cerrar la ventana
                // Puedes poner aquí el código que deseas ejecutar antes de que se cierre la ventana
                DialogResult result = MessageBox.Show("¿Está seguro de que desea cerrar la ventana?", "Confirmar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Verificar la respuesta del usuario
                if (result == DialogResult.No)
                {
                    // Cancelar el cierre de la ventana si el usuario selecciona "No"
                    e.Cancel = true;
                }
                else
                {
                    loginForm.Show();
                }
            }
        }
    }
}
