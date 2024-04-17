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
            cargaDatos();
        }

        private void cargaDatos() //Carga los datos al datagridview
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
        }

        private void newAdminButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Añadir nuevo administrador
                SystemSounds.Exclamation.Play();
                string confirmacion = Interaction.InputBox("Favor de confirmar contraseña", "Contraseña"); //messageBox con textbos incluido. Confirma contraseña

                if (int.Parse(confirmacion) == 2) //Cada nuevo administrador requiere confirmacion de contraseña: 2
                {
                    guardarDatos();
                    camposLimpieza();
                }
                else
                {
                    MessageBox.Show("Favor de no olvidar todos los datos en casa.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                //login.Close();
            }
            catch
            {
                Console.WriteLine("hay errores wtf");
            }

        }

        private void guardarDatos() //campo para guarda los datos dentro de una linea nuevo del archivo
        {
            using (FileStream login = new FileStream("login.txt", FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(login))
                {
                    //nombre,correo,numero,rol,contraseña
                    writer.WriteLine($"{nombreTxt.Text.ToLower()},{correoTxt.Text.ToLower()},{numeroTxt.Text},{rolCombo.Text},{rnd.Next(9999999)}");
                }
                login.Close();
            }
        }

        public void camposLimpieza()
        {
            nombreTxt.Text = null;
            correoTxt.Text = null;
            numeroTxt.Text = null;
            rolCombo.Text = null;
        }

        private void eliminarAdminButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Utiliza la misma logica para borrar datos de becarios. A excepcion de pedir contraseña: 2
                if (administradoresDataGrid.CurrentRow.Index > -1)
                {
                    SystemSounds.Exclamation.Play();
                    string confirmacion = Interaction.InputBox("Favor de confirmar contraseña", "Contraseña"); //messageBox con textbos incluido. Confirma contraseña

                    if (int.Parse(confirmacion) == 2)
                    {

                        administradoresDataGrid.Rows.RemoveAt(administradoresDataGrid.CurrentRow.Index);
                    }
                }
            }
            catch
            {

            }
        }

        private void confirmarTodoButton_Click(object sender, EventArgs e)
        {
            //Boton Confirmar todo
            sobreescribirDatos();
            this.Hide();
        }

        private void sobreescribirDatos()
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
    }
}
