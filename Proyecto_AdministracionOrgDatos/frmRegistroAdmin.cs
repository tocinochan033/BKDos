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
        public void Conectar()
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


        /*------------------------METODO PARA CARGAR DATOS--------------------*/
        //crea aleatoriamente numeros de 6 digitos para la contraseña
        Random rnd = new Random();
        FuentePersonalizada fontPers = new FuentePersonalizada();

        public frmRegistroAdmin()
        {
            InitializeComponent();
            LlenarDGV();
           
        }

       /* private void cargaDatos() //Carga los datos al datagridview
        {
            //Imprime los datos guardados del archivo al datagridview
            int indiceNuevoRenglon;
            string nombre, correo, numero, rol, contraseña;

            FileStream loginStream = new FileStream("login.txt", FileMode.OpenOrCreate, FileAccess.Read);

            using (StreamReader lector = new StreamReader(loginStream))
            {
                string renglon = lector.ReadLine();
                while (renglon != null)
                {
                    string[] datos = renglon.Split(',');

                    indiceNuevoRenglon = administradoresDataGrid.Rows.Add();

                    nombre = datos[0];
                    correo = datos[1];
                    rol = datos[2];
                    numero = datos[3];
                    contraseña = datos[4];

                    administradoresDataGrid.Rows[indiceNuevoRenglon].Cells[0].Value = nombre;
                    administradoresDataGrid.Rows[indiceNuevoRenglon].Cells[1].Value = correo;
                    administradoresDataGrid.Rows[indiceNuevoRenglon].Cells[2].Value = rol;
                    administradoresDataGrid.Rows[indiceNuevoRenglon].Cells[3].Value = numero;
                    administradoresDataGrid.Rows[indiceNuevoRenglon].Cells[4].Value = contraseña;

                    renglon = lector.ReadLine();
                }
                loginStream.Close();
            }
        }*/

        private void newAdminButton_Click(object sender, EventArgs e)
        {
          
             

                Conectar();
                Sql = "";
                Sql = "INSERT INTO Usuarios (Usuario, Contrasena, Correo, Rol, NumeroTelefonico, Contra_admin, Estado) values (@Usuario, @Contrasena, @Correo,@Rol, @NumeroTelefonico, @Contra_admin, @Estado)";
                Comando = new SqlCommand(Sql, Conexion);
                Comando.Parameters.AddWithValue("@Usuario", nombreTxt.Text);
                Comando.Parameters.AddWithValue("@Contrasena", txtContrasena.Text);
                Comando.Parameters.AddWithValue("@Correo", correoTxt.Text);
                Comando.Parameters.AddWithValue("@Rol", Rol.Text);
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
               
                
                camposLimpieza();
                Conexion.Close();
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
                Conectar();

                SystemSounds.Exclamation.Play();
                string confirmacion = Interaction.InputBox("Favor de confirmar contraseña", "Contraseña"); //messageBox con textbos incluido. Confirma contraseña

                //using (SqlCommand cmd = new SqlCommand("SELECT Usuario, Contrasena FROM Usuarios WHERE Usuario='" + txtUsuario_ESA.Text + "' AND Contrasena='" + txtContraseña_ESA.Text + "'", Conexion))
                if (administradoresDataGrid.CurrentRow.Index > -1)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT Contra_admin FROM Usuarios WHERE Contra_admin='" + confirmacion + "'", Conexion))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            EliminarAdmin();
                            RefrescarDatos();
                        }


                        else
                        {
                            Form login = new FormLogin_ESA();
                            MessageBox.Show("El Usuario y/o Contraseña Administrador INCORRECTOS");
                            login.Show();
                            this.Hide();

                        }
                    }
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
            Conexion.Close();
            Conectar();
            int seleccion = administradoresDataGrid.CurrentRow.Index;
            //dgv_Agregar.Rows.RemoveAt(dgv_Agregar.CurrentRow.Index);
            Sql = "DELETE FROM Usuarios WHERE Id_Usuario = @Id_Usuario";
            Comando = new SqlCommand(Sql, Conexion);
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
            Conexion.Close();
            /*
             
             
             */
        }

        private void confirmarTodoButton_Click(object sender, EventArgs e)
        {
            //Boton Confirmar todo
          //  sobreescribirDatos();
            this.Hide();
        }

       /* private void sobreescribirDatos()
        {
            ///Se guardan los datos de los becados en el archivo txt
            ///Se tiene que sobreescribir ya que si es que se eliminan datos
            ///los indices estarian mal para las siguientes veces que se desplegara el programa
            FileStream login = new FileStream("login.txt", FileMode.Create, FileAccess.Write);
            using (StreamWriter writer = new StreamWriter(login))
            {
                //Se recorren todas las filas del datagridview
                foreach (DataGridViewRow row in administradoresDataGrid.Rows)
                {
                    if (!row.IsNewRow) //borra las lineas vacios del archivo !NO BORRAR!
                    {
                        //nombre,correo,rol,numero
                        writer.WriteLine($"{row.Cells[0].Value},{row.Cells[1].Value},{row.Cells[2].Value},{row.Cells[3].Value}");
                    }
                }
            }
            //Se terminan de guardar los datos y se cierra el archivo
            login.Close();
        }*/

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
            Conectar();
            //Query Primera Tabla

            //Sql = "SELECT Id_Alumno, ApellidoPaterno, ApellidoMaterno, Nombres, FechaNacimiento, Edad, Curp, EstadoCivil, Genero, Domicilio, CodigoPostal, Nacionalidad, EstadoNacimiento, Municipio, Correo, Telefono, Carrera, Periodo, Promedio, Modelo, CCT FROM DatosGenerales, DatosContacto, DatosAcademicos";
            Sql = "SELECT Id_Usuario , Usuario, Contrasena, Correo, Rol, NumeroTelefonico, Contra_admin from Usuarios WHERE Estado = 1";
            Adaptador = new SqlDataAdapter(Sql, Conexion);
            Adaptador.Fill(Tabla);
            administradoresDataGrid.DataSource = Tabla;

         

            Conexion.Close();
        }
        public void RefrescarDatos()
        {
            Conectar();
            Tabla.Clear();
            administradoresDataGrid.ClearSelection();

            // Sql = "SELECT Id_Alumno, ApellidoPaterno, ApellidoMaterno, Nombres, FechaNacimiento, Edad, Curp, EstadoCivil, Genero, Domicilio, CodigoPostal, Nacionalidad, EstadoNacimiento, Municipio, Correo, Telefono, Carrera, Periodo, Promedio, Modelo, CCT FROM DatosGenerales, DatosContacto, DatosAcademicos";
            Sql = "SELECT Id_Usuario, Usuario, Contrasena, Correo, Rol, NumeroTelefonico, Contra_admin from Usuarios WHERE Estado = 1";
            Adaptador = new SqlDataAdapter(Sql, Conexion);
            Adaptador.Fill(Tabla);
            administradoresDataGrid.DataSource = Tabla;



            //Query Segunda tabla
            /*  Sql = "SELECT Domicilio, CodigoPostal, Nacionalidad, EstadoNacimiento, Municipio, Correo, Telefono FROM DatosContacto";
              Adaptador = new SqlDataAdapter(Sql, Conexion);
              Adaptador.Fill(Tabla);
              dgv_Agregar.DataSource = Tabla;

              //Query tercera tabla
              Sql = "SELECT Carrera, Periodo, Promedio, Modelo FROM DatosAcademicos";
              Adaptador = new SqlDataAdapter(Sql, Conexion);
              Adaptador.Fill(Tabla);
              dgv_Agregar.DataSource = Tabla;*/

            Conexion.Close();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form loginForm = new FormLogin_ESA();
            this.Hide(); 
            loginForm.Show();
        }
    }
}
