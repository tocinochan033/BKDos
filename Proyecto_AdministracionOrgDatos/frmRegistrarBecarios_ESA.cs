﻿using System;
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
        /*llamamiento de clase*/
        ClaseBD ClaseBd = new ClaseBD();

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
        
        public void CargarDatos (int indice)
        {
            
            //Se crea la fila del objeto de la tabla

            //En caso de que la tabla de la base de datos no tenga informacion se utiliza esta condicion
            if (Tabla.Rows.Count >0)
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
                txtPromedio.Text = fila["Promedio"].ToString();
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
       public void RefrescarDatos()
        {
            //Se selecciona la tabl de donde sacar los datos
            Sql = "select * from DatosGenerales ";
            //Pasamos los parametros al adaptador
            Adaptador = new SqlDataAdapter(Sql, Conexion);
            //Se limpia la tabla
            Tabla.Clear();
            //Se vuelve a llenar
            Adaptador.Fill(Tabla);
        }

        /*--------------------------------------------------------------------*/
        public void LlenarDGV()
        {
            Conectar();
            //Se selecciona la tabl de donde sacar los datos
            Sql = "select * from DatosGenerales, DatosAcademicos, DatosContacto, TablaCCT";
            Adaptador = new SqlDataAdapter(Sql, Conexion);
            Adaptador.Fill(Tabla);
            dgv_Agregar.DataSource = Tabla;
            Conexion.Close();
        }

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
           /* Conexion.Open();
            RefrescarDatos();
            CargarDatos(indice);*/
           
            //Este metodo llena el dgv
            LlenarDGV();
           // Conexion.Close();
            
        }

        private void btnRegresarMenu_ESA_Click(object sender, EventArgs e)
        {
            Conectar();
            //Guarda los datos y regresa a la pantalla anterior
            Guardar();

            Conexion.Close();  
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
                dgv_Agregar.Rows[indiceNuevaFila].Cells[1].Value = txtApaterno.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[2].Value = txtAmaterno.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[3].Value = txtNombres.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[4].Value = txtFechanac.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[5].Value = txtEdad.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[6].Value = txtCURP.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[7].Value = CBGenero.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[8].Value = txtEstadoCivil.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[9].Value = txtDomicilio.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[10].Value = txtCodigoPostal.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[11].Value = txtNacionalidad.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[12].Value = txtEstadoNac.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[13].Value = txtMunicipio.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[14].Value = txtCorreoElectronico.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[15].Value = txtTelefono.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[16].Value = txtCarrera.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[17].Value = txtPeriodo.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[18].Value = txtPromedio.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[19].Value = txtModelo.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[20].Value = cmbCCT.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[21].Value = txtEscuela.Text;
                camposLimpieza();

                //Regresar el "cursor" al label del nombre
                txtApaterno.Focus();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
           /* RefrescarDatos();
          

            
           //Verificamos si hay una celda seleccionada
            if (this.dgv_Agregar.SelectedRows.Count == 1)
            {
                //Se cargan los datos actuales en los textbox en el datagridview para actualizar sus valores
                int seleccion = dgv_Agregar.CurrentRow.Index;
                dgv_Agregar.Rows[seleccion].Cells[1].Value = txtApaterno.Text;
                dgv_Agregar.Rows[seleccion].Cells[2].Value = txtAmaterno.Text;
                dgv_Agregar.Rows[seleccion].Cells[3].Value = txtNombres.Text;
                dgv_Agregar.Rows[seleccion].Cells[4].Value = txtFechanac.Text;
                dgv_Agregar.Rows[seleccion].Cells[5].Value = txtEdad.Text;
                dgv_Agregar.Rows[seleccion].Cells[6].Value = txtCURP.Text;
                dgv_Agregar.Rows[seleccion].Cells[7].Value = CBGenero.Text;
                dgv_Agregar.Rows[seleccion].Cells[8].Value = txtEstadoCivil.Text;
                dgv_Agregar.Rows[seleccion].Cells[9].Value = txtDomicilio.Text;
                dgv_Agregar.Rows[seleccion].Cells[10].Value = txtCodigoPostal.Text;
                dgv_Agregar.Rows[seleccion].Cells[11].Value = txtNacionalidad.Text;
                dgv_Agregar.Rows[seleccion].Cells[12].Value = txtEstadoNac.Text;
                dgv_Agregar.Rows[seleccion].Cells[13].Value = txtMunicipio.Text;
                dgv_Agregar.Rows[seleccion].Cells[14].Value = txtCorreoElectronico.Text;
                dgv_Agregar.Rows[seleccion].Cells[15].Value = txtTelefono.Text;
                dgv_Agregar.Rows[seleccion].Cells[16].Value = txtCarrera.Text;
                dgv_Agregar.Rows[seleccion].Cells[17].Value = txtPeriodo.Text;
                dgv_Agregar.Rows[seleccion].Cells[18].Value = txtPromedio.Text;
                dgv_Agregar.Rows[seleccion].Cells[19].Value = txtModelo.Text;
                dgv_Agregar.Rows[seleccion].Cells[20].Value = cmbCCT.Text;
                dgv_Agregar.Rows[seleccion].Cells[21].Value = txtEscuela.Text;
             

                camposLimpieza();
            }*/
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
        
      

        private void Guardar()
        {
            //Conectar();
            /*Seleccionar id de escuela, le asigno una variable para guardar el valor*/
            /*string Nam_Escuela;
            Nam_Escuela = txtEscuela.Text;


            /*Insercion de tercera tabla Datos academicos*/
          /*  Sql = "";
            Sql = "insert into DatosAcademicos (Carrera, Periodo, Promedio, Modelo, Id_cct) values (@Carrera, @Periodo, @Promedio, @Modelo, @Id_cct)";
            Comando = new SqlCommand(Sql, Conexion);*/
            /*Tercera tabla*/
           
           /* Comando.Parameters.AddWithValue("@Carrera", txtCarrera.Text);
            Comando.Parameters.AddWithValue("@Periodo", txtPeriodo.Text);
            Comando.Parameters.AddWithValue("@Promedio", txtPromedio.Text);
            Comando.Parameters.AddWithValue("@Modelo", txtModelo.Text);
            Comando.Parameters.AddWithValue("@Id_cct", selectIDCCT(Nam_Escuela));*/

            /*-----------------------------------Inicio de metodo con base de datos-------------------------------------*/
            /*Insercion de primera tabla Datos generales*/
            Sql = "";
            Sql = "insert into DatosGenerales (ApellidoPaterno, ApellidoMaterno, Nombres, FechaNacimiento, Edad, Curp, EstadoCivil, Genero) values (@ApellidoPaterno, @ApellidoMaterno, @Nombres, @FechaNacimiento, @Edad, @Curp, @EstadoCivil, @Genero)";
            Comando = new SqlCommand(Sql, Conexion);
            //Insercion de la primera tabla
            Comando.Parameters.AddWithValue("@ApellidoPaterno", txtApaterno.Text);
            Comando.Parameters.AddWithValue("@ApellidoMaterno", txtAmaterno.Text);
            Comando.Parameters.AddWithValue("@Nombres", txtNombres.Text);
            Comando.Parameters.AddWithValue("@FechaNacimiento", txtFechanac.Text);
            Comando.Parameters.AddWithValue("@Edad", txtEdad.Text);
            Comando.Parameters.AddWithValue("@Curp", txtCURP.Text);
            Comando.Parameters.AddWithValue("@EstadoCivil", txtEstadoCivil.Text);
            Comando.Parameters.AddWithValue("@Genero", CBGenero.Text);


            /*Insercion de segunda tabla Datos Contacto*/
            Sql = "";
            Sql = "insert into DatosContacto (Domicilio, CodigoPostal, Nacionalidad, EstadoNacimiento, Municipio, Correo, Telefono) values (@Domicilio, @CodigoPostal, @Nacionalidad, @EstadoNacimiento, @Municipio, @Correo, @Telefono)";
            Comando = new SqlCommand(Sql, Conexion);
            //Insercion de segunda tabla
            Comando.Parameters.AddWithValue("@Domicilio", txtDomicilio.Text);
            Comando.Parameters.AddWithValue("@CodigoPostal", txtCodigoPostal.Text);
            Comando.Parameters.AddWithValue("@Nacionalidad", txtNacionalidad.Text);
            Comando.Parameters.AddWithValue("@EstadoNacimiento", txtEstadoNac.Text);
            Comando.Parameters.AddWithValue("@Municipio", txtMunicipio.Text);
            Comando.Parameters.AddWithValue("@Correo", txtCorreoElectronico.Text);
            Comando.Parameters.AddWithValue("@Telefono", txtTelefono.Text);


            /*Insercion de cuarta tabla CCT*/
            Sql = "";
            Sql = "insert into TablaCCT (CCT, NombreEscuela) values (@CCT, @NombreEscuela)";

          
           
            //Añandiendo parametros y campos a agregar
           
           
          
           Comando.Parameters.AddWithValue("@CCT", cmbCCT.Text);
           Comando.Parameters.AddWithValue("@NombreEscuela", txtEscuela.Text);

        
            try
            {
               
                Comando.ExecuteNonQuery();

                MessageBox.Show("Registro insertardo");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }

            /*-----------------------------------Fin de metodo con base de datos-------------------------------------*/

           
            //Se terminan de guardar los datos y se cierra el archiv
          //  Conexion.Close();    
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
                "02DIT0021M Instituto Tecnologico de Tijuana",
                "02PBH0128V Universidad Autónoma de Baja California",
                "U602000 Universidad Nacional Autónoma de México",
                "09PBH0056L Instituto Tecnológico de Monterrey",
                "19USU3353S Universidad Autónoma de Nuevo León",
                "02PBH0022B Universidad Xochicalco"
                // Agrega otros nombres de escuelas según tu necesidad
            };

            return nombresEscuelas;
        }
        public int selectIDCCT(string namEscuela)
        {
            int idEscuela=0;
            namEscuela = txtEscuela.Text;
            switch (namEscuela)
            {

                case "Instituto Tecnologico de Tijuana":
                    idEscuela = 2002;
                    break;

                case "Universidad Autónoma de Baja California":
                    idEscuela = 3002; 
                    break;

                case "Universidad Nacional Autónoma de México":
                    idEscuela = 3003;
                    break;

                case "Instituto Tecnológico de Monterrey":
                    idEscuela = 3005; 
                    break;

                case "Universidad Autónoma de Nuevo León":
                    idEscuela = 3006;
                    break;

                case "Universidad Xochicalco":
                    idEscuela = 3007;
                    break;
            }
            return idEscuela;

        }

        private void cmbCCT_SelectedIndexChanged(object sender, EventArgs e)
        {/*
            Sql = "select  CCT, NombreEscuela FROM [TablaCCT]";
            Comando = new SqlCommand(Sql, Conexion);*/
            // Obtén el nombre de la escuela seleccionada
            string escuelaSeleccionada = cmbCCT.Text;

            // Utiliza la lógica para determinar el modelo según la escuela seleccionada
            if (escuelaSeleccionada == "02DIT0021M Instituto Tecnologico de Tijuana" || escuelaSeleccionada == "02PBH0128V Universidad Autónoma de Baja California" || escuelaSeleccionada == "U602000 Universidad Nacional Autónoma de México" || escuelaSeleccionada == "09PBH0056L Instituto Tecnológico de Monterrey")
                txtModelo.Text = "Semestral";
            else if (escuelaSeleccionada == "19USU3353S Universidad Autónoma de Nuevo León" || escuelaSeleccionada == "02PBH0022B Universidad Xochicalco")
                txtModelo.Text = "Cuatrimestral";

            //Condicion para agregar la escuela automatica
            switch(escuelaSeleccionada)
            {
                case "02DIT0021M Instituto Tecnologico de Tijuana":
                    txtEscuela.Text = "Instituto Tecnologico de Tijuana";
                   
                    break;

                case "02PBH0128V Universidad Autónoma de Baja California":
                    txtEscuela.Text = "Universidad Autónoma de Baja California";
                    break;

                case "U602000 Universidad Nacional Autónoma de México":
                    txtEscuela.Text = "Universidad Nacional Autónoma de México";
                    break;

                case "09PBH0056L Instituto Tecnológico de Monterrey":
                    txtEscuela.Text = "Instituto Tecnológico de Monterrey";
                    break;

                case "19USU3353S Universidad Autónoma de Nuevo León":
                    txtEscuela.Text = "Universidad Autónoma de Nuevo León";
                    break;

                case "02PBH0022B Universidad Xochicalco":
                    txtEscuela.Text = "Universidad Xochicalco";
                    break;
            }
        }

        private void txtModelo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardarMod_Click(object sender, EventArgs e)
        {
            Conectar();
            /*-----------------------------------Inicio de metodo con base de datos-------------------------------------*/


            /*-----------------------------------Inicio de metodo con base de datos-------------------------------------*/
            /*Insercion de primera tabla Datos generales*/
            Sql = "update DatosGenerales set ApellidoPaterno = @ApellidoPaterno, ApellidoMaterno = @ApellidoMaterno, Nombres = @Nombres, FechaNacimiento = @FechaNacimiento, Edad = @Edad, Curp = @Curp, EstadoCivil = @EstadoCivil, Genero = @Genero";
            Comando = new SqlCommand(Sql, Conexion);

            /*Insercion de segunda tabla Datos Contacto*/
            Sql = "update DatosContacto set Domicilio = @Domicilio, CodigoPostal = @CodigoPostal, Nacionalidad = @Nacionalidad, EstadoNacimiento = @EstadoNacimiento, Municipio = @Municipio, Correo = @Correo, Telefono = @Telefono";
            Comando = new SqlCommand(Sql, Conexion);

            /*Insercion de tercera tabla Datos academicos*/
            Sql = "update DatosAcademicos set Carrera = @Carrera, Periodo = @Periodo, Promedio = @Promedio, Modelo = @Modelo, Id_cct = @Id_cct";
            Comando = new SqlCommand(Sql, Conexion);

            /*Insercion de cuarta tabla CCT*/
            Sql = "update TablaCCT CCT = @CCT, NombreEscuela = @NombreEscuela";
            Comando = new SqlCommand(Sql, Conexion);

            /*Seleccionar id de escuela, le asigno una variable para guardar el valor*/
            string Nam_Escuela;
            Nam_Escuela = txtEscuela.Text;
           
            //Añandiendo parametros y campos a agregar
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
            Comando.Parameters.AddWithValue("@Promedio", txtPromedio.Text);
            Comando.Parameters.AddWithValue("@Modelo", txtModelo.Text);
            Comando.Parameters.AddWithValue("@Id_cct", selectIDCCT(Nam_Escuela));
            Comando.Parameters.AddWithValue("@CCT", cmbCCT.Text);
            Comando.Parameters.AddWithValue("@NombreEscuela", txtEscuela.Text);


            try
            {
                //Ejecutamos la instruccion del sql para afectar las filas
                Comando.ExecuteNonQuery();

                MessageBox.Show("Registro insertardo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }

            /*-----------------------------------Fin de metodo con base de datos-------------------------------------*/
            Conexion.Close();
        }

        //Evento para que al seleccionar una celda se refleje en su respectivo text box
        private void dgv_Agregar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtApaterno.Text = dgv_Agregar.SelectedCells[1].Value.ToString();
            txtAmaterno.Text = dgv_Agregar.SelectedCells[2].Value.ToString();
            txtNombres.Text = dgv_Agregar.SelectedCells[3].Value.ToString();
            txtFechanac.Text = dgv_Agregar.SelectedCells[4].Value.ToString();
            txtEdad.Text = dgv_Agregar.SelectedCells[5].Value.ToString();
            txtCURP.Text = dgv_Agregar.SelectedCells[6].Value.ToString();
            txtEstadoCivil.Text = dgv_Agregar.SelectedCells[7].Value.ToString();
            CBGenero.Text = dgv_Agregar.SelectedCells[8].Value.ToString();
            
            txtDomicilio.Text = dgv_Agregar.SelectedCells[9].Value.ToString();
            txtCodigoPostal.Text = dgv_Agregar.SelectedCells[10].Value.ToString();
            txtNacionalidad.Text = dgv_Agregar.SelectedCells[11].Value.ToString();
            txtEstadoNac.Text = dgv_Agregar.SelectedCells[12].Value.ToString();
            txtMunicipio.Text = dgv_Agregar.SelectedCells[13].Value.ToString();
            txtCorreoElectronico.Text = dgv_Agregar.SelectedCells[14].Value.ToString();
            txtTelefono.Text = dgv_Agregar.SelectedCells[15].Value.ToString();
            txtCarrera.Text = dgv_Agregar.SelectedCells[16].Value.ToString();
            txtPeriodo.Text = dgv_Agregar.SelectedCells[17].Value.ToString();
            txtPromedio.Text = dgv_Agregar.SelectedCells[18].Value.ToString();
            txtModelo.Text = dgv_Agregar.SelectedCells[19].Value.ToString();
            cmbCCT.Text = dgv_Agregar.SelectedCells[20].Value.ToString();
            txtEscuela.Text = dgv_Agregar.SelectedCells[21].Value.ToString();
            //Comentado hasta que vea la forma de modificar 3 tablas a la vez


        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Form objMenu_ESA = new frmMenu_ESA();
            objMenu_ESA.Show();
            this.Hide();
        }
    }
}
