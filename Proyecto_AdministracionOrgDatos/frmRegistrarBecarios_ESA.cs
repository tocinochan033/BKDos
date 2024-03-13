using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_AdministracionOrgDatos
{
    public partial class frmRegistrarBecarios_ESA : Form
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


        /*------------------------METODO PARA CARGAR DATOS--------------------*/
        
        void CargarDatos (int indice)
        {
            //Se crea la fila del objeto de la tabla

            //En caso de que la tabla de la base de datos no tenga informacion se utiliza esta condicion
            if(Tabla.Rows.Count >0)
            {
                //Asignamos los valores correspondientes de cada registro
                //DataRow representa una fila de datos
                DataRow fila = Tabla.Rows[indice];
                /*Primera tabla datos*/
                txtApaterno.Text = fila["ApellidoPaterno"].ToString(); ;
                txtAmaterno.Text = fila["ApellidoMaterno"].ToString();
                txtNombres.Text = fila["Nombres"].ToString();
                txtFechanac.Text = fila["FechaNacimiento"].ToString();
                txtEdad.Text = fila["Edad"].ToString();
                txtCURP.Text = fila["Curp"].ToString();
                txtEstadoCivil.Text = fila["EstadoCivil"].ToString();
                CBGenero.Text = fila["Genero"].ToString();

                //------------------- Segunda tabla de datos contactos -------------------------
                txtDomicilio.Text = fila["Domicilio"].ToString();
                txtCodigoPostal.Text = fila["CodigoPostal"].ToString();
                txtNacionalidad.Text = fila["Nacionalidad"].ToString();
                txtEstadoNac.Text = fila["EstadoNacimiento"].ToString();
                txtMunicipio.Text = fila["Municipio"].ToString();
                txtCorreoElectronico.Text = fila["Correo"].ToString();
                txtTelefono.Text = fila["Telefono"].ToString();
               
                /*---------------------Tercera tabla Datos academicos-------------------------*/
                txtCarrera.Text = fila["Carrera"].ToString();
                txtPeriodo.Text = fila["Periodo"].ToString();
                txtPromedio.Text = fila["Modelo"].ToString();
                cmbCCT.Text = fila["CCT"].ToString();
                txtModelo.Text = fila["NombreEscuela"].ToString();
            }
            else
            {
                MessageBox.Show("No hay registros guardados");
            }
           

        }
       /*----------------------Refrescar datos-----------------------*/
       void RefrescarDatos()
        {
            //Se selecciona la tabl de donde sacar los datos
            Sql = "select * from DatosGenerales";
            //Pasamos los parametros al adaptador
            Adaptador = new SqlDataAdapter(Sql, Conexion);
            //Se limpia la tabla
            Tabla.Clear();
            //Se vuelve a llenar
            Adaptador.Fill(Tabla);
        }

        /*--------------------------------------------------------------------*/

        public frmRegistrarBecarios_ESA()
        {
            InitializeComponent();
            LlenarComboBoxEscuelas();

            /*
            //Inicializacion de combo box del modelo 
            txtModelo.Items.Add("Semestre");
            txtModelo.Items.Add("Cuatrimestre");
            */

            //Inicializacion de los estados de la republica
            txtEstadoNac.Items.Add("Aguascalientes");
            txtEstadoNac.Items.Add("Baja California");
            txtEstadoNac.Items.Add("Baja California Sur");
            txtEstadoNac.Items.Add("Campeche");
            txtEstadoNac.Items.Add("Chiapas");
            txtEstadoNac.Items.Add("Chihuahua");
            txtEstadoNac.Items.Add("Coahuila");
            txtEstadoNac.Items.Add("Colima");
            txtEstadoNac.Items.Add("Durango");
            txtEstadoNac.Items.Add("Estado de México");
            txtEstadoNac.Items.Add("Guanajuato");
            txtEstadoNac.Items.Add("Guerrero");
            txtEstadoNac.Items.Add("Hidalgo");
            txtEstadoNac.Items.Add("Jalisco");
            txtEstadoNac.Items.Add("Michoacán");
            txtEstadoNac.Items.Add("Morelos");
            txtEstadoNac.Items.Add("Nayarit");
            txtEstadoNac.Items.Add("Nuevo León");
            txtEstadoNac.Items.Add("Oaxaca");
            txtEstadoNac.Items.Add("Puebla");
            txtEstadoNac.Items.Add("Querétaro");
            txtEstadoNac.Items.Add("Quintana Roo");
            txtEstadoNac.Items.Add("San Luis Potosí");
            txtEstadoNac.Items.Add("Sinaloa");
            txtEstadoNac.Items.Add("Sonora");
            txtEstadoNac.Items.Add("Tabasco");
            txtEstadoNac.Items.Add("Tamaulipas");
            txtEstadoNac.Items.Add("Tlaxcala");
            txtEstadoNac.Items.Add("Veracruz ");
            txtEstadoNac.Items.Add("Yucatán");
            txtEstadoNac.Items.Add("Zacatecas");
            txtEstadoNac.Items.Add("CDMX");


            string aPaterno, aMaterno, nombres, fechanac, edad, curp, genero, estado_civil;
            string domicilio, codigo_postal, nacionalidad, estado_nacimiento, municipio, correo_electronico, telefono;
            string carrera, periodo, promedio, cct, modelo;
            int indicieNuevoRenglon;

            /*Cargar los datos en el datagridview*/
            RefrescarDatos();
            CargarDatos(indice);
            /*----------------------------------------------ARCHIVOS------------------------------------------*/
             //Abrimos el archivo de texto en modo lectura
             FileStream becados = new FileStream("Becados.txt",FileMode.OpenOrCreate,FileAccess.Read);

            //Leemos linea por linea y cargamos esta misma en el datagridview
            using(StreamReader lector = new StreamReader(becados))
            {
                string renglon = lector.ReadLine();
                while (renglon != null)
                {
                    //Se usa el metodo split para leer los datos de manera individual
                    string[] datos = renglon.Split(',');

                    //Adicionamos nuevo renglon y regresamos su indice
                    indicieNuevoRenglon = dgv_Agregar.Rows.Add();

                    //Asignamos el valor a las variables
                    aPaterno = datos[0];
                    aMaterno = datos[1];
                    nombres = datos[2];
                    fechanac = datos[3];
                    edad = datos[4];
                    curp = datos[5];
                    genero = datos[6];
                    estado_civil = datos[7];
                    domicilio = datos[8];
                    codigo_postal = datos[9];
                    nacionalidad = datos[10];
                    estado_nacimiento = datos[11];
                    municipio = datos[12];
                    correo_electronico = datos[13];
                    telefono = datos[14];
                    carrera = datos[15];
                    periodo = datos[16];
                    promedio = datos[17];
                    cct = datos[18];
                    modelo = datos[19];


                    //Colocamos la informacion en el datagridview
                    dgv_Agregar.Rows[indicieNuevoRenglon].Cells[0].Value = aPaterno;
                    dgv_Agregar.Rows[indicieNuevoRenglon].Cells[1].Value = aMaterno;
                    dgv_Agregar.Rows[indicieNuevoRenglon].Cells[2].Value = nombres;
                    dgv_Agregar.Rows[indicieNuevoRenglon].Cells[3].Value = fechanac;
                    dgv_Agregar.Rows[indicieNuevoRenglon].Cells[4].Value = edad;
                    dgv_Agregar.Rows[indicieNuevoRenglon].Cells[5].Value = curp;
                    dgv_Agregar.Rows[indicieNuevoRenglon].Cells[6].Value = genero;
                    dgv_Agregar.Rows[indicieNuevoRenglon].Cells[7].Value = estado_civil;
                    dgv_Agregar.Rows[indicieNuevoRenglon].Cells[8].Value = domicilio;
                    dgv_Agregar.Rows[indicieNuevoRenglon].Cells[9].Value = codigo_postal;
                    dgv_Agregar.Rows[indicieNuevoRenglon].Cells[10].Value = nacionalidad;
                    dgv_Agregar.Rows[indicieNuevoRenglon].Cells[11].Value = estado_nacimiento;
                    dgv_Agregar.Rows[indicieNuevoRenglon].Cells[12].Value = municipio;
                    dgv_Agregar.Rows[indicieNuevoRenglon].Cells[13].Value = correo_electronico;
                    dgv_Agregar.Rows[indicieNuevoRenglon].Cells[14].Value = telefono;
                    dgv_Agregar.Rows[indicieNuevoRenglon].Cells[15].Value = carrera;
                    dgv_Agregar.Rows[indicieNuevoRenglon].Cells[16].Value = periodo;
                    dgv_Agregar.Rows[indicieNuevoRenglon].Cells[17].Value = promedio;
                    dgv_Agregar.Rows[indicieNuevoRenglon].Cells[18].Value = cct;
                    dgv_Agregar.Rows[indicieNuevoRenglon].Cells[19].Value = modelo;


                    renglon = lector.ReadLine();
                }
            }
            becados.Close();
            /*Archivios recordar tambien cerrar accion de base de datos*/
        }

        private void btnRegresarMenu_ESA_Click(object sender, EventArgs e)
        {
            //Guarda los datos y regresa a la pantalla anterior
            Guardar();
            Form objMenu_ESA = new frmMenu_ESA();
            objMenu_ESA.Show();
            this.Hide();

        }

        private bool camposImcompletos()
        {
            return txtApaterno.Text == "" || txtAmaterno.Text == "" || txtNombres.Text == "" || txtFechanac.Text == ""
               || txtEdad.Text == "" || txtCURP.Text == "" || CBGenero.Text == "" || txtEstadoCivil.Text == "" || txtDomicilio.Text == ""
               || txtCodigoPostal.Text == "" || txtNacionalidad.Text == "" || txtEstadoNac.Text == "" || txtMunicipio.Text == "" || txtCorreoElectronico.Text == ""
               || txtTelefono.Text == "" || txtCarrera.Text == "" || txtPeriodo.Text == "" || txtPromedio.Text == "" || cmbCCT.Text == "" || txtModelo.Text == "";
        }

        private void camposLimpieza()
        {
            txtApaterno.Text = "";
            txtAmaterno.Text = "";
            txtNombres.Text = "";
            txtFechanac.Text = "";
            txtEdad.Text = "";
            txtCURP.Text = "";
            CBGenero.Text = "";
            txtEstadoCivil.Text = "";
            txtDomicilio.Text = "";
            txtCodigoPostal.Text = "";
            txtNacionalidad.Text = "";
            txtEstadoNac.Text = "";
            txtMunicipio.Text = "";
            txtCorreoElectronico.Text = "";
            txtTelefono.Text = "";
            txtCarrera.Text = "";
            txtPeriodo.Text = "";
            txtPromedio.Text = "";
            cmbCCT.Text = "";
            txtModelo.Text = "";
        }

        private void btnAgregar_ESA_Click(object sender, EventArgs e)
        {
            if(camposImcompletos())
            {
                MessageBox.Show("Favor de no olvidar todos los datos en casa.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtApaterno.Focus();
            }
            else
            {
               
                int indiceNuevaFila;

                //Sirve para adicionar un nuevo renglon y guardar el indice de este mismo
                indiceNuevaFila = dgv_Agregar.Rows.Add();

                //Colocamos la informacion en el DataGridView
                dgv_Agregar.Rows[indiceNuevaFila].Cells[0].Value = txtApaterno.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[1].Value = txtAmaterno.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[2].Value = txtNombres.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[3].Value = txtFechanac.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[4].Value = txtEdad.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[5].Value = txtCURP.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[6].Value = CBGenero.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[7].Value = txtEstadoCivil.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[8].Value = txtDomicilio.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[9].Value = txtCodigoPostal.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[10].Value = txtNacionalidad.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[11].Value = txtEstadoNac.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[12].Value = txtMunicipio.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[13].Value = txtCorreoElectronico.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[14].Value = txtTelefono.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[15].Value = txtCarrera.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[16].Value = txtPeriodo.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[17].Value = txtPromedio.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[18].Value = cmbCCT.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[19].Value = txtModelo.Text;

                camposLimpieza();

                //Regresar el "cursor" al label del nombre
                txtApaterno.Focus();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Verificamos si hay una celda seleccionada
            if (this.dgv_Agregar.SelectedRows.Count == 1)
            {
                //Se cargan los datos actuales en los textbox en el datagridview para actualizar sus valores
                int seleccion = dgv_Agregar.CurrentRow.Index;
                dgv_Agregar.Rows[seleccion].Cells[0].Value = txtApaterno.Text;
                dgv_Agregar.Rows[seleccion].Cells[1].Value = txtAmaterno.Text;
                dgv_Agregar.Rows[seleccion].Cells[2].Value = txtNombres.Text;
                dgv_Agregar.Rows[seleccion].Cells[3].Value = txtFechanac.Text;
                dgv_Agregar.Rows[seleccion].Cells[4].Value = txtEdad.Text;
                dgv_Agregar.Rows[seleccion].Cells[5].Value = txtCURP.Text;
                dgv_Agregar.Rows[seleccion].Cells[6].Value = CBGenero.Text;
                dgv_Agregar.Rows[seleccion].Cells[7].Value = txtEstadoCivil.Text;
                dgv_Agregar.Rows[seleccion].Cells[8].Value = txtDomicilio.Text;
                dgv_Agregar.Rows[seleccion].Cells[9].Value = txtCodigoPostal.Text;
                dgv_Agregar.Rows[seleccion].Cells[10].Value = txtNacionalidad.Text;
                dgv_Agregar.Rows[seleccion].Cells[11].Value = txtEstadoNac.Text;
                dgv_Agregar.Rows[seleccion].Cells[12].Value = txtMunicipio.Text;
                dgv_Agregar.Rows[seleccion].Cells[13].Value = txtCorreoElectronico.Text;
                dgv_Agregar.Rows[seleccion].Cells[14].Value = txtTelefono.Text;
                dgv_Agregar.Rows[seleccion].Cells[15].Value = txtCarrera.Text;
                dgv_Agregar.Rows[seleccion].Cells[16].Value = txtPeriodo.Text;
                dgv_Agregar.Rows[seleccion].Cells[17].Value = txtPromedio.Text;
                dgv_Agregar.Rows[seleccion].Cells[18].Value = cmbCCT.Text;
                dgv_Agregar.Rows[seleccion].Cells[19].Value = txtModelo.Text;

                camposLimpieza();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Verificamos si hay una fila seleccionada
            if(dgv_Agregar.CurrentRow.Index > -1)
            {
                DialogResult confirmacion = MessageBox.Show("¿Está seguro que desea eliminar esta fila permanentemente? Permanentemente es mucho tiempo.", 
                    "Confirmar eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                
                //Usuario confirma eliminacion
                if(confirmacion == DialogResult.Yes)
                {
                    dgv_Agregar.Rows.RemoveAt(dgv_Agregar.CurrentRow.Index);
                }
            }
        }

        private void dgv_Agregar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Verificamos si hay una celda seleccionada
            if(this.dgv_Agregar.SelectedRows.Count == 1)
            {
                //Definimos el indice de la fila
                int seleccion = dgv_Agregar.CurrentRow.Index;

                //Cargamos los textbox con los datos de la fila seleccionada en sus celdas correspondientes
                txtApaterno.Text = dgv_Agregar.Rows[seleccion].Cells[0].Value.ToString();
                txtAmaterno.Text = dgv_Agregar.Rows[seleccion].Cells[1].Value.ToString();
                txtNombres.Text = dgv_Agregar.Rows[seleccion].Cells[2].Value.ToString();
                txtFechanac.Text = dgv_Agregar.Rows[seleccion].Cells[3].Value.ToString();
                txtEdad.Text = dgv_Agregar.Rows[seleccion].Cells[4].Value.ToString();
                txtCURP.Text = dgv_Agregar.Rows[seleccion].Cells[5].Value.ToString();
                CBGenero.Text = dgv_Agregar.Rows[seleccion].Cells[6].Value.ToString();
                txtEstadoCivil.Text = dgv_Agregar.Rows[seleccion].Cells[7].Value.ToString();
                txtDomicilio.Text = dgv_Agregar.Rows[seleccion].Cells[8].Value.ToString();
                txtCodigoPostal.Text = dgv_Agregar.Rows[seleccion].Cells[9].Value.ToString();
                txtNacionalidad.Text = dgv_Agregar.Rows[seleccion].Cells[10].Value.ToString();
                txtEstadoNac.Text = dgv_Agregar.Rows[seleccion].Cells[11].Value.ToString();
                txtMunicipio.Text = dgv_Agregar.Rows[seleccion].Cells[12].Value.ToString();
                txtCorreoElectronico.Text = dgv_Agregar.Rows[seleccion].Cells[13].Value.ToString();
                txtTelefono.Text = dgv_Agregar.Rows[seleccion].Cells[14].Value.ToString();
                txtCarrera.Text = dgv_Agregar.Rows[seleccion].Cells[15].Value.ToString();
                txtPeriodo.Text = dgv_Agregar.Rows[seleccion].Cells[16].Value.ToString();
                txtPromedio.Text = dgv_Agregar.Rows[seleccion].Cells[17].Value.ToString();
                cmbCCT.Text = dgv_Agregar.Rows[seleccion].Cells[18].Value.ToString();
                txtModelo.Text = dgv_Agregar.Rows[seleccion].Cells[19].Value.ToString();
            }
        }

        private void Guardar()
        {
            /*
               txtApaterno.Text = fila["ApellidoPaterno"].ToString(); ;
               txtAmaterno.Text = fila["ApellidoMaterno"].ToString();
               txtNombres.Text = fila["Nombres"].ToString();
               txtFechanac.Text = fila["FechaNacimiento"].ToString();
               txtEdad.Text = fila["Edad"].ToString();
               txtCURP.Text = fila["Curp"].ToString();
               txtEstadoCivil.Text = fila["EstadoCivil"].ToString();
               CBGenero.Text = fila["Genero"].ToString();

               //------------------- Segunda tabla de datos contactos -------------------------
               txtDomicilio.Text = fila["Domicilio"].ToString();
               txtCodigoPostal.Text = fila["CodigoPostal"].ToString();
               txtNacionalidad.Text = fila["Nacionalidad"].ToString();
               txtEstadoNac.Text = fila["EstadoNacimiento"].ToString();
               txtMunicipio.Text = fila["Municipio"].ToString();
               txtCorreoElectronico.Text = fila["Correo"].ToString();
               txtTelefono.Text = fila["Telefono"].ToString();


               txtCarrera.Text = fila["Carrera"].ToString();
               txtPeriodo.Text = fila["Periodo"].ToString();
               txtPromedio.Text = fila["Modelo"].ToString();
               cmbCCT.Text = fila["CCT"].ToString();
               txtModelo.Text = fila["NombreEscuela"].ToString();*/
            Sql = "insert into DatosGenerales (ApellidoPaterno, ApellidoMaterno, Nombres, FechaNacimiento, Edad, Curp, EstadoCivil,Genero,Domicilio, CodigoPostal,Nacionalidad,EstadoNacimiento,Municipio,Correo, Telefono, Carrera,Periodo ,Modelo,CCT,NombreEscuela) values (@ApellidoPaterno, @ApellidoMaterno, @Nombres, @FechaNacimiento, @Edad, @Curp, @EstadoCivil, @Genero, @Domicilio, @CodigoPostal, @Nacionalidad, @EstadoNacimiento, @Municipio,@Correo, @Telefono, @Carrera,@Periodo ,@Modelo,@CCT,@NombreEscuela)";
            Comando = new SqlCommand(Sql, Conexion);
            //Añandiendo parametro
            Comando.Parameters.AddWithValue("@ApellidoPaterno", txtApaterno.Text);
            Comando.Parameters.AddWithValue("@ApellidoMaterno", txtAmaterno.Text);
            Comando.Parameters.AddWithValue("@Nombres", txtNombres.Text);
            Comando.Parameters.AddWithValue("@FechaNacimiento", txtFechanac.Text);
            Comando.Parameters.AddWithValue("@Edad", txtEdad.Text);
            Comando.Parameters.AddWithValue("@Curp", txtCURP.Text);
            Comando.Parameters.AddWithValue("@EstadoCivil", txtEstadoCivil.Text);
            Comando.Parameters.AddWithValue("@Genero", CBGenero.Text);
            Comando.Parameters.AddWithValue("@Domicilio", txtDomicilio.Text);
            Comando.Parameters.AddWithValue("@CodigoPostal", txtCodigoPostal.Text);
            Comando.Parameters.AddWithValue("@Nacionalidad", txtNacionalidad.Text);
            Comando.Parameters.AddWithValue("@EstadoNacimiento", txtEstadoNac.Text);
            Comando.Parameters.AddWithValue("@Municipio", txtMunicipio.Text);
            Comando.Parameters.AddWithValue("@Correo", txtCorreoElectronico.Text);
            Comando.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
            Comando.Parameters.AddWithValue("@Carrera", txtCarrera.Text);
            Comando.Parameters.AddWithValue("@Periodo", txtPeriodo.Text);
            Comando.Parameters.AddWithValue("@Modelo", txtPromedio.Text);
            Comando.Parameters.AddWithValue("@CCT", cmbCCT.Text);
            Comando.Parameters.AddWithValue("@NombreEscuela", txtModelo.Text);
        
            //FALTA AGREGAR PROMEDIO EN LA BASE DE DATOS


            ///Se guardan los datos de los becados en el archivo txt
            ///Se tiene que sobreescribir ya que si es que se eliminan datos
            ///los indices estarian mal para las siguientes veces que se desplegara el programa
            FileStream becados = new FileStream("Becados.txt", FileMode.Create, FileAccess.Write);
            using (StreamWriter writer = new StreamWriter(becados))
            {
                //Se recorren todas las filas del datagridview
                foreach(DataGridViewRow row in dgv_Agregar.Rows)
                {
                    writer.WriteLine($"{row.Cells[0].Value},{row.Cells[1].Value},{row.Cells[2].Value},{row.Cells[3].Value}," +
                        $"{row.Cells[4].Value},{row.Cells[5].Value},{row.Cells[6].Value},{row.Cells[7].Value}," +
                        $"{row.Cells[8].Value},{row.Cells[9].Value},{row.Cells[10].Value},{row.Cells[11].Value}," +
                        $"{row.Cells[12].Value},{row.Cells[13].Value},{row.Cells[14].Value},{row.Cells[15].Value}," +
                        $"{row.Cells[16].Value},{row.Cells[17].Value},{row.Cells[18].Value},{row.Cells[19].Value}");

                }
            }
            //Se terminan de guardar los datos y se cierra el archiv
            becados.Close();    
        }

        //Aqui estan las propiedades para agregar la fecha y la hora al programa
        private void FechaHora2_Tick(object sender, EventArgs e)
        {
            HoraC.Text = DateTime.Now.ToShortTimeString();
            FechaC.Text = DateTime.Now.ToShortDateString();
        }

        private void frmRegistrarBecarios_ESA_Load(object sender, EventArgs e)
        {

        }

        private void dgv_Agregar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Txt_Estado_ESA_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        // Cambio en el ComboBox

        private void LlenarComboBoxEscuelas()
        {
            // Puedes obtener los nombres de las escuelas desde tus archivos de texto u otra fuente de datos
            List<string> nombresEscuelas = ObtenerNombresEscuelas();

            // Limpia el ComboBox antes de llenarlo nuevamente
            cmbCCT.Items.Clear();

            // Agrega los nombres de las escuelas al ComboBox
            cmbCCT.Items.AddRange(nombresEscuelas.ToArray());
        }

        private List<string> ObtenerNombresEscuelas()
        {
            // Puedes cargar los nombres de las escuelas desde tus archivos de texto u otra fuente de datos
            List<string> nombresEscuelas = new List<string>
            {
                "02DIT0021M TEC",
                "02PBH0079C UABC",
                "U602000 UNAM",
                "09PBH0056L ITESM",
                "19USU3353S UANL",
                "02PBH0022B ZOCHICALCO"
                // Agrega otros nombres de escuelas según tu necesidad
            };

            return nombresEscuelas;
        }


        private void cmbCCT_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtén el nombre de la escuela seleccionada
            string escuelaSeleccionada = cmbCCT.Text;

            // Utiliza la lógica para determinar el modelo según la escuela seleccionada
            if (escuelaSeleccionada == "02DIT0021M TEC" || escuelaSeleccionada == "02PBH0079C UABC" || escuelaSeleccionada == "U602000 UNAM" || escuelaSeleccionada == "09PBH0056L ITESM")
                txtModelo.Text = "Semestral";
            else if (escuelaSeleccionada == "19USU3353S UANL" || escuelaSeleccionada == "02PBH0022B ZOCHICALCO")
                txtModelo.Text = "Cuatrimestral";
        }

        private void txtModelo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
