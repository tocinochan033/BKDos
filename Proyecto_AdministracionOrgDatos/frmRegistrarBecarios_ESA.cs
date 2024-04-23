using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Se agrega libreria dataclient
//Espacio de nombres requerido para interactuar con SQL SERVER
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Proyecto_AdministracionOrgDatos
{
    public partial class frmRegistrarBecarios_ESA : Form
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
        private FuentePersonalizada fontPers;

        //Variable para el calculo de la inactividad
        private Timer temporizadorInactividad;

        // Define un diccionario para almacenar los municipios por estado
        Dictionary<string, List<string>> municipiosPorEstado = new Dictionary<string, List<string>>();

        private Municipios Munic;

        public frmRegistrarBecarios_ESA()
        {
            InitializeComponent();
            LlenarComboBoxEscuelas();

            fontPers = new FuentePersonalizada();
            Munic = new Municipios(cmbEstadoNac, txtMunicipio);


            //Creacion del temporizador y su tiempo
            temporizadorInactividad = new Timer();
            temporizadorInactividad.Interval = 1000;
            //Al llegar al tiempo especificado se accede al metodo
            temporizadorInactividad.Tick += (sender, e) => Verificarlnactividad();
            //Inicializacion del temporizador
            temporizadorInactividad.Start();

            /*
            //Inicializacion de combo box del modelo 
            txtModelo.Items.Add("Semestre");
            txtModelo.Items.Add("Cuatrimestre");
            */



            //Inicializacion de las opciones de modificacion
            cmbFiltroModificar.Items.Add("A.Paterno");
            cmbFiltroModificar.Items.Add("A.Materno");
            cmbFiltroModificar.Items.Add("Nombres");
            cmbFiltroModificar.Items.Add("FechaNac");
            cmbFiltroModificar.Items.Add("Edad");
            cmbFiltroModificar.Items.Add("CURP");
            cmbFiltroModificar.Items.Add("Genero");
            cmbFiltroModificar.Items.Add("Estado Civil");
            cmbFiltroModificar.Items.Add("Domicilio");
            cmbFiltroModificar.Items.Add("Codigo Postal");
            cmbFiltroModificar.Items.Add("Nacionalidad");
            cmbFiltroModificar.Items.Add("EstadoNac");
            cmbFiltroModificar.Items.Add("Municipio");
            cmbFiltroModificar.Items.Add("Correo");
            cmbFiltroModificar.Items.Add("Telefono");
            cmbFiltroModificar.Items.Add("Carrera");
            cmbFiltroModificar.Items.Add("Periodo");
            cmbFiltroModificar.Items.Add("Promedio");
            cmbFiltroModificar.Items.Add("CCT");
            cmbFiltroModificar.Items.Add("Modelo");

            //string aPaterno, aMaterno, nombres, fechanac, edad, curp, genero, estado_civil;
            //string domicilio, codigo_postal, nacionalidad, estado_nacimiento, municipio, correo_electronico, telefono;
            //string carrera, periodo, promedio, cct, modelo;
            //int indicieNuevoRenglon;

            /*
            //Abrimos el archivo de texto en modo lectura
            FileStream becados = new FileStream("Becados.txt", FileMode.OpenOrCreate, FileAccess.Read);

            //Leemos linea por linea y cargamos esta misma en el datagridview
            using (StreamReader lector = new StreamReader(becados))
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
            becados.Close();*/
            LlenarDGV();
        }

        private void btnRegresarMenu_ESA_Click(object sender, EventArgs e)
        {
            //Ese metodo queda obsoleto ya que cuando agrega tambien lo guarda
            //Guardar();
            this.Close();

            DatosInactividad.control = false; //Indicador al cerrar este formulario
        }

        private void Verificarlnactividad()
        {
            //Evaluar tiempo de inactividad
            if (DatosInactividad.GetInputIdleTime().TotalSeconds > 1800)//30min
            {
                //Detener temporizador de la inactividad
                temporizadorInactividad.Stop();

                //Notificacion de inactividad
                MessageBox.Show("Inactividad detectada. Vuelva a iniciar sesion!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                //Cerrar la ventana y regresar al login
                frmMenu_ESA objMenu_ACO = frmMenu_ESA.ventanaUnica();
                this.Close(); objMenu_ACO.Close();
                Program.loginEstatico.Show();

                DatosInactividad.control = false; //Indicador al detectar la inactividad
            }
        }

        private void camposLimpieza()
        {
            txtApaterno.Text = "";
            txtAmaterno.Text = "";
            txtNombres.Text = "";
            txtFechanac.Text = "";
            txtEdad.Text = "";
            CBGenero.Text = "";
            cmbEstCivil.Text = "";
            txtDomicilio.Text = "";
            txtCodigoPostal.Text = "";
            cmbNacionalidad.Text = "";
            cmbEstadoNac.Text = "";
            txtMunicipio.Text = "";
            txtCorreoElectronico.Text = "";
            txtTelefono.Text = "";
            txtCarrera.Text = "";
            txtPeriodo.Text = "";
            txtPromedio.Text = "";
            cmbCCT.Text = "";
            txtModelo.Text = "";
            CBGenero.Text = "";
            cmbEstCivil.Text = "";
            cmbEstadoNac.Text = "";
            txtMunicipio.Text = "";
            cmbNacionalidad.Text = "";
        }

        private void btnAgregar_ESA_Click(object sender, EventArgs e)
        {
            BuscarCamposVacios_AgregarDatos();
        }

        //Metodo para obtener la primer consonante de un nombre
        public string ObtencionDeConsonantes(string palabra)
        {
            //Se adelanta una posicion el contador porque el inicila ya se esta ocupando
            int i = 1;
            //Ciclo que evalua la palabra buscando la primera consonante

            do
            {
                string Letra = String.Concat(palabra[i]);
                switch (Letra)
                {
                    case "B": return "B";
                    case "C": return "C";
                    case "D": return "D";
                    case "F": return "F";
                    case "G": return "G";
                    case "H": return "H";
                    case "J": return "J";
                    case "k": return "k";
                    case "L": return "L";
                    case "M": return "M";
                    case "N": return "N";
                    case "P": return "P";
                    case "Q": return "Q";
                    case "R": return "R";
                    case "S": return "S";
                    case "T": return "T";
                    case "V": return "V";
                    case "W": return "w";
                    case "X": return "X";
                    case "Y": return "Y";
                    case "Z": return "Z";

                }
                i++;
            } while (i != palabra.Length + 1);
            return "X";
        }

        //Metodo para obtener la primer vocal de un nombre
        public string ObtencionDeVocal(string apellido)
        {
            int i = 0;
            //Se utiliza un ciclo para recorrer el string y encontrar la vocal
            try
            {
                do
                {
                    switch (string.Concat(apellido[i]))
                    {
                        case "A":
                            return "A";
                        case "E":
                            return "E";
                        case "I":
                            return "I";
                        case "O":
                            return "O";
                        case "U":
                            return "U";
                    }
                    i++;
                } while (i != apellido.Length + 1);
            }
            //Si no encuentra nada regresa una X
            catch (System.ArgumentOutOfRangeException)
            {
                return "X";
            }
            return "X";
        }
        //Metodo para la generacion de CURP
        public string GeneracionCURP()
        {
            try
            {
                string nombre = txtNombres.Text.ToUpper();
                string ApellidoPaterno = txtApaterno.Text.ToUpper();
                string ApellidoMaterno = txtAmaterno.Text.ToUpper();
                string fechaNacimiento = txtFechanac.Text;
                string Sexo = CBGenero.Text.ToUpper();
                string estado = cmbEstadoNac.Text;
                var random = new Random().Next(0, 99);

                return (ApellidoPaterno[0] + ObtencionDeVocal(ApellidoPaterno) + ApellidoMaterno[0] + nombre[0] + fechaNacimiento.Substring(8, 2) +
                    fechaNacimiento.Substring(3, 2) + fechaNacimiento.Substring(0, 2) + Sexo[0] + ESTADO(estado) + ObtencionDeConsonantes(ApellidoPaterno) +
                    ObtencionDeConsonantes(ApellidoMaterno) + ObtencionDeConsonantes(nombre) + random.ToString());
            }
            catch
            {
                return "XXXXXXXXXXXXXXX";
            }
        }
        public string CURPMODIFICACION()
        {
            try
            {
                int seleccion = dgv_Agregar.CurrentRow.Index;

                // dgv_Agregar.Rows[seleccion].Cells[0].Value;
                //string nombre = txtNombres.Text.ToUpper();
               // string ApellidoPaterno = txtApaterno.Text.ToUpper();
                string nombre = dgv_Agregar.Rows[seleccion].Cells[3].Value.ToString().ToUpper();
                string ApellidoPaterno = dgv_Agregar.Rows[seleccion].Cells[1].Value.ToString().ToUpper();
                string ApellidoMaterno = dgv_Agregar.Rows[seleccion].Cells[2].Value.ToString().ToUpper();
                string fechaNacimiento = dgv_Agregar.Rows[seleccion].Cells[4].Value.ToString();
                string Sexo = dgv_Agregar.Rows[seleccion].Cells[8].Value.ToString().ToUpper();
                string estado = dgv_Agregar.Rows[seleccion].Cells[13].Value.ToString();
                var random = new Random().Next(0, 99);

                return (ApellidoPaterno[0] + ObtencionDeVocal(ApellidoPaterno) + ApellidoMaterno[0] + nombre[0] + fechaNacimiento.Substring(8, 2) +
                    fechaNacimiento.Substring(3, 2) + fechaNacimiento.Substring(0, 2) + Sexo[0] + ESTADO(estado) + ObtencionDeConsonantes(ApellidoPaterno) +
                    ObtencionDeConsonantes(ApellidoMaterno) + ObtencionDeConsonantes(nombre) + random.ToString());
            }
            catch
            {
                return "XXXXXXXXXXXXXXX";
            }
        }

        //Metodo para asignar clave a los estados
        public string ESTADO(string palabra)
        {
            switch (palabra)
            {
                case "Aguascalientes":
                    return "AS";
                case "Baja California":
                    return "BC";
                case "Baja California Sur":
                    return "BS";
                case "Campeche":
                    return "CC";
                case "Coahuila":
                    return "CL";
                case "Colima":
                    return "CM";
                case "Chiapas":
                    return "CS";
                case "Chihuahua":
                    return "CH";
                case "Distrito Federal":
                    return "DF";
                case "Durango":
                    return "DG";
                case "Guanajuato":
                    return "GT";
                case "Guerrero":
                    return "GR";
                case "Hidalgo":
                    return "HG";
                case "Jalisco":
                    return "JC";
                case "Mexico":
                    return "MC";
                case "Michoacan":
                    return "MN";
                case "Morelos":
                    return "MS";
                case "Nayarit":
                    return "NT";
                case "Nuevo Leon":
                    return "NL";
                case "Oaxaca":
                    return "OC";
                case "Puebla":
                    return "PL";
                case "Queretaro":
                    return "QT";
                case "Quintana Roo":
                    return "QR";
                case "San Luis Potosi":
                    return "SP";
                case "Sinaloa":
                    return "SL";
                case "Sonora":
                    return "SR";
                case "Tabasco":
                    return "TC";
                case "Tamaulipas":
                    return "TS";
                case "Tlaxcala":
                    return "TL";
                case "Veracruz":
                    return "VZ";
                case "Yucatan":
                    return "YN";
                case "Zacatecas":
                    return "ZS";
                case "Extranjero":
                    return "NE";
            }
            return "NE";
        }


        private void btnModificar_Click(object sender, EventArgs e)
        {

                Conectar();
                //Verificamos si hay una celda seleccionada
                if (dgv_Agregar.CurrentRow.Index > -1)
                {
                    //Se cargan los datos actuales en los textbox en el datagridview para actualizar sus valores
                    int seleccion = dgv_Agregar.CurrentRow.Index;

                    if (cmbFiltroModificar.Text == "A.Paterno")
                    {
                        Sql = "";
                        Sql = "UPDATE DatosGenerales set ApellidoPaterno = @ApellidoPaterno WHERE Id_Alumno = @Id_Alumno";
                        Comando = new SqlCommand(Sql, Conexion);
                        Comando.Parameters.AddWithValue("@Id_Alumno", dgv_Agregar.Rows[seleccion].Cells[0].Value);
                        Comando.Parameters.AddWithValue("@ApellidoPaterno", txtModificacion.Text);
                        try
                        {
                            //Ejecutamos la instruccion del sql para afectar las filas
                            Comando.ExecuteNonQuery();

                            MessageBox.Show("Registro Actualizado: Apellido Paterno");
                            //  RefresacarDatos();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error tabla general: " + ex.Message);
                        }

                    }
                    else if (cmbFiltroModificar.Text == "A.Materno")
                    {
                        Sql = "";
                        Sql = "UPDATE DatosGenerales set ApellidoMaterno = @ApellidoMaterno WHERE Id_Alumno = @Id_Alumno";
                        Comando = new SqlCommand(Sql, Conexion);
                        Comando.Parameters.AddWithValue("@Id_Alumno", dgv_Agregar.Rows[seleccion].Cells[0].Value);
                        Comando.Parameters.AddWithValue("@ApellidoMaterno", txtModificacion.Text);
                        try
                        {
                            //Ejecutamos la instruccion del sql para afectar las filas
                            Comando.ExecuteNonQuery();

                            MessageBox.Show("Registro Actualizado: Apellido Materno");
                            //  RefresacarDatos();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error tabla general: " + ex.Message);
                        }

                    }
                    else if (cmbFiltroModificar.Text == "Nombres")
                    {

                        Sql = "";
                        Sql = "UPDATE DatosGenerales set Nombres = @Nombres WHERE Id_Alumno = @Id_Alumno";
                        Comando = new SqlCommand(Sql, Conexion);
                        Comando.Parameters.AddWithValue("@Id_Alumno", dgv_Agregar.Rows[seleccion].Cells[0].Value);
                        Comando.Parameters.AddWithValue("@Nombres", txtModificacion.Text);
                        try
                        {
                            //Ejecutamos la instruccion del sql para afectar las filas
                            Comando.ExecuteNonQuery();

                            MessageBox.Show("Registro Actualizado: Nombres");
                            //  RefresacarDatos();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error tabla general: " + ex.Message);
                        }

                    }
                    else if (cmbFiltroModificar.Text == "FechaNac")
                    {
                        Sql = "";
                        Sql = "UPDATE DatosGenerales set FechaNacimiento = @FechaNacimiento WHERE Id_Alumno = @Id_Alumno";
                        Comando = new SqlCommand(Sql, Conexion);
                        // Comando.Parameters.AddWithValue("@Id_DatosContacto", ((DateTime)(dgv_Agregar.Rows[seleccion].Cells[17].Value)).ToString("dd/MM/yyyy"));
                        Comando.Parameters.AddWithValue("@Id_Alumno", dgv_Agregar.Rows[seleccion].Cells[0].Value);
                        Comando.Parameters.AddWithValue("@FechaNacimiento", txtModificacion.Text);
                        try
                        {
                            //Ejecutamos la instruccion del sql para afectar las filas
                            Comando.ExecuteNonQuery();

                            MessageBox.Show("Registro Actualizado: Fecha Nacimiento");
                            //  RefresacarDatos();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error tabla general: " + ex.Message);
                        }


                    }
                    else if (cmbFiltroModificar.Text == "Edad")
                    {
                        Sql = "";
                        Sql = "UPDATE DatosGenerales set Edad = @Edad WHERE Id_Alumno = @Id_Alumno";
                        Comando = new SqlCommand(Sql, Conexion);
                        Comando.Parameters.AddWithValue("@Id_Alumno", dgv_Agregar.Rows[seleccion].Cells[0].Value);
                        Comando.Parameters.AddWithValue("@Edad", txtModificacion.Text);
                        try
                        {
                            //Ejecutamos la instruccion del sql para afectar las filas
                            Comando.ExecuteNonQuery();

                            MessageBox.Show("Registro Actualizado: Edad");
                            //  RefresacarDatos();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error tabla general: " + ex.Message);
                        }


                    }
                    else if (cmbFiltroModificar.Text == "CURP")
                    {
                        txtModificacion.Text = CURPMODIFICACION();
                        Sql = "";
                        Sql = "UPDATE DatosGenerales set CURP = @CURP WHERE Id_Alumno = @Id_Alumno";
                        Comando = new SqlCommand(Sql, Conexion);
                        Comando.Parameters.AddWithValue("@Id_Alumno", dgv_Agregar.Rows[seleccion].Cells[0].Value);

                        Comando.Parameters.AddWithValue("@CURP", txtModificacion.Text);
                        try
                        {
                            //Ejecutamos la instruccion del sql para afectar las filas
                            Comando.ExecuteNonQuery();

                            MessageBox.Show("Registro Actualizado: CURP");
                            //  RefresacarDatos();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error tabla general: " + ex.Message);
                        }

                    }
                    else if (cmbFiltroModificar.Text == "Genero")
                    {

                        Sql = "";
                        Sql = "UPDATE DatosGenerales set Genero = @Genero WHERE Id_Alumno = @Id_Alumno";
                        Comando = new SqlCommand(Sql, Conexion);
                        Comando.Parameters.AddWithValue("@Id_Alumno", dgv_Agregar.Rows[seleccion].Cells[0].Value);
                        Comando.Parameters.AddWithValue("@Genero", txtModificacion.Text);
                        try
                        {
                            //Ejecutamos la instruccion del sql para afectar las filas
                            Comando.ExecuteNonQuery();

                            MessageBox.Show("Registro Actualizado: Genero");
                            //  RefresacarDatos();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error tabla general: " + ex.Message);
                        }

                    }
                    else if (cmbFiltroModificar.Text == "Estado Civil")
                    {

                        Sql = "";
                        Sql = "UPDATE DatosGenerales set EstadoCivil = @EstadoCivil WHERE Id_Alumno = @Id_Alumno";
                        Comando = new SqlCommand(Sql, Conexion);
                        Comando.Parameters.AddWithValue("@Id_Alumno", dgv_Agregar.Rows[seleccion].Cells[0].Value);
                        Comando.Parameters.AddWithValue("@EstadoCivil", txtModificacion.Text);
                        try
                        {
                            //Ejecutamos la instruccion del sql para afectar las filas
                            Comando.ExecuteNonQuery();

                            MessageBox.Show("Registro Actualizado: EstadoCivil");
                            //  RefresacarDatos();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error tabla general: " + ex.Message);
                        }

                    }
                    else if (cmbFiltroModificar.Text == "Domicilio")
                    {

                        Sql = "";
                        Sql = "UPDATE DatosContacto set Domicilio = @Domicilio WHERE Id_DatosContacto = @Id_DatosContacto";
                        Comando = new SqlCommand(Sql, Conexion);
                        Comando.Parameters.AddWithValue("@Id_DatosContacto", dgv_Agregar.Rows[seleccion].Cells[9].Value);
                        Comando.Parameters.AddWithValue("@Domicilio", txtModificacion.Text);
                        try
                        {
                            //Ejecutamos la instruccion del sql para afectar las filas
                            Comando.ExecuteNonQuery();

                            MessageBox.Show("Registro Actualizado: Domicilio");
                            //  RefresacarDatos();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error tabla general: " + ex.Message);
                        }

                    }
                    else if (cmbFiltroModificar.Text == "Codigo Postal")
                    {

                        Sql = "";
                        Sql = "UPDATE DatosContacto set CodigoPostal = @CodigoPostal WHERE Id_DatosContacto = @Id_DatosContacto";
                        Comando = new SqlCommand(Sql, Conexion);
                        Comando.Parameters.AddWithValue("@Id_DatosContacto", dgv_Agregar.Rows[seleccion].Cells[9].Value);
                        Comando.Parameters.AddWithValue("@CodigoPostal", txtModificacion.Text);
                        try
                        {
                            //Ejecutamos la instruccion del sql para afectar las filas
                            Comando.ExecuteNonQuery();

                            MessageBox.Show("Registro Actualizado: Codigo Postal");
                            //  RefresacarDatos();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error tabla general: " + ex.Message);
                        }


                    }
                    else if (cmbFiltroModificar.Text == "Nacionalidad")
                    {

                        Sql = "";
                        Sql = "UPDATE DatosContacto set Nacionalidad = @Nacionalidad WHERE Id_DatosContacto = @Id_DatosContacto";
                        Comando = new SqlCommand(Sql, Conexion);
                        Comando.Parameters.AddWithValue("@Id_DatosContacto", dgv_Agregar.Rows[seleccion].Cells[9].Value);
                        Comando.Parameters.AddWithValue("@Nacionalidad", txtModificacion.Text);
                        try
                        {
                            //Ejecutamos la instruccion del sql para afectar las filas
                            Comando.ExecuteNonQuery();

                            MessageBox.Show("Registro Actualizado: Nacionalidad");
                            //  RefresacarDatos();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error tabla general: " + ex.Message);
                        }

                    }
                    else if (cmbFiltroModificar.Text == "EstadoNac")
                    {

                        Sql = "";
                        Sql = "UPDATE DatosContacto set EstadoNacimiento = @EstadoNacimiento WHERE Id_DatosContacto = @Id_DatosContacto";
                        Comando = new SqlCommand(Sql, Conexion);

                        Comando.Parameters.AddWithValue("@Id_DatosContacto", dgv_Agregar.Rows[seleccion].Cells[9].Value);
                        Comando.Parameters.AddWithValue("@EstadoNacimiento", txtModificacion.Text);
                        try
                        {
                            Comando.ExecuteNonQuery();
                            MessageBox.Show("Registro Actualizado: Estado Nacimiento");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error tabla general: " + ex.Message);
                        }

                    }
                    else if (cmbFiltroModificar.Text == "Municipio")
                    {

                        Sql = "";
                        Sql = "UPDATE DatosContacto set Municipio = @Municipio WHERE Id_DatosContacto = @Id_DatosContacto";
                        Comando = new SqlCommand(Sql, Conexion);
                        Comando.Parameters.AddWithValue("@Id_DatosContacto", dgv_Agregar.Rows[seleccion].Cells[9].Value);
                        Comando.Parameters.AddWithValue("@Municipio", txtModificacion.Text);
                        try
                        {
                            Comando.ExecuteNonQuery();
                            MessageBox.Show("Registro Actualizado: Municipio");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error tabla general: " + ex.Message);
                        }

                    }
                    else if (cmbFiltroModificar.Text == "Correo")
                    {
                        Sql = "";
                        Sql = "UPDATE DatosContacto set Correo = @Correo WHERE Id_DatosContacto = @Id_DatosContacto";
                        Comando = new SqlCommand(Sql, Conexion);
                        Comando.Parameters.AddWithValue("@Id_DatosContacto", dgv_Agregar.Rows[seleccion].Cells[9].Value);
                        Comando.Parameters.AddWithValue("@Correo", txtModificacion.Text);
                        try
                        {
                            Comando.ExecuteNonQuery();
                            MessageBox.Show("Registro Actualizado: Correo Electronico");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error tabla general: " + ex.Message);
                        }

                    }
                    else if (cmbFiltroModificar.Text == "Telefono")
                    {

                        Sql = "";
                        Sql = "UPDATE DatosContacto set Telefono = @Telefono WHERE Id_DatosContacto = @Id_DatosContacto";
                        Comando = new SqlCommand(Sql, Conexion);
                        Comando.Parameters.AddWithValue("@Id_DatosContacto", dgv_Agregar.Rows[seleccion].Cells[9].Value);
                        Comando.Parameters.AddWithValue("@Telefono", txtModificacion.Text);
                        try
                        {
                            Comando.ExecuteNonQuery();
                            MessageBox.Show("Registro Actualizado: Telefono");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error tabla general: " + ex.Message);
                        }

                    }
                    else if (cmbFiltroModificar.Text == "Carrera")
                    {
                        Sql = "";
                        Sql = "UPDATE DatosAcademicos set Carrera = @Carrera WHERE Id_DatosAcademicos = @Id_DatosAcademicos";
                        Comando = new SqlCommand(Sql, Conexion);
                        //MessageBox.Show(dgv_Agregar.Rows[seleccion].Cells[11].Value.ToString());
                        /*MessageBox.Show(txtModificai);*/
                        //Comando.Parameters.AddWithValue("@Id_DatosAcademicos", int.Parse(dgv_Agregar.Rows[seleccion].Cells[11].Value.ToString()));
                        Comando.Parameters.AddWithValue("@Id_DatosAcademicos", dgv_Agregar.Rows[seleccion].Cells[17].Value);
                        Comando.Parameters.AddWithValue("@Carrera", txtModificacion.Text);
                        try
                        {
                            Comando.ExecuteNonQuery();
                            MessageBox.Show("Registro Actualizado: Carrera");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error tabla general: " + ex.Message);
                        }

                    }
                    else if (cmbFiltroModificar.Text == "Periodo")
                    {
                        Sql = "";
                        Sql = "UPDATE DatosAcademicos set Periodo = @Periodo WHERE Id_DatosAcademicos = @Id_DatosAcademicos";
                        Comando = new SqlCommand(Sql, Conexion);

                        Comando.Parameters.AddWithValue("@Id_DatosAcademicos", dgv_Agregar.Rows[seleccion].Cells[17].Value);
                        Comando.Parameters.AddWithValue("@Periodo", txtModificacion.Text);
                        try
                        {
                            Comando.ExecuteNonQuery();
                            MessageBox.Show("Registro Actualizado: Periodo");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error tabla general: " + ex.Message);
                        }
                    }
                    else if (cmbFiltroModificar.Text == "Promedio")
                    {
                        Sql = "";
                        Sql = "UPDATE DatosAcademicos set Promedio = @Promedio WHERE Id_DatosAcademicos = @Id_DatosAcademicos";
                        Comando = new SqlCommand(Sql, Conexion);

                        Comando.Parameters.AddWithValue("@Id_DatosAcademicos", dgv_Agregar.Rows[seleccion].Cells[17].Value);
                        Comando.Parameters.AddWithValue("@Promedio", txtModificacion.Text);
                        try
                        {
                            Comando.ExecuteNonQuery();
                            MessageBox.Show("Registro Actualizado: Promedio");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error tabla general: " + ex.Message);
                        }

                    }
                    else if (cmbFiltroModificar.Text == "CCT")
                    {
                        Sql = "";
                        Sql = "UPDATE DatosAcademicos set CCT = @CCT WHERE Id_DatosAcademicos = @Id_DatosAcademicos";
                        Comando = new SqlCommand(Sql, Conexion);

                        Comando.Parameters.AddWithValue("@Id_DatosAcademicos", dgv_Agregar.Rows[seleccion].Cells[17].Value);
                        Comando.Parameters.AddWithValue("@CCT", txtModificacion.Text);
                        try
                        {
                            Comando.ExecuteNonQuery();
                            MessageBox.Show("Registro Actualizado: CCT");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error tabla general: " + ex.Message);
                        }
                    }
                    else if (cmbFiltroModificar.Text == "Modelo")
                    {
                        Sql = "";
                        Sql = "UPDATE DatosAcademicos set Modelo = @Modelo WHERE Id_DatosAcademicos = @Id_DatosAcademicos";
                        Comando = new SqlCommand(Sql, Conexion);

                        Comando.Parameters.AddWithValue("@Id_DatosAcademicos", dgv_Agregar.Rows[seleccion].Cells[17].Value);
                        Comando.Parameters.AddWithValue("@Modelo", txtModificacion.Text);
                        try
                        {
                            Comando.ExecuteNonQuery();
                            MessageBox.Show("Registro Actualizado: Modelo");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error tabla general: " + ex.Message);
                        }
                    }
                    Conexion.Close();
                    //Se limpian los campos para mayor comodidad del usuario
                    txtModificacion.Text = "";
                    cmbFiltroModificar.Text = "";
                    RefrescarDatos();
                }
                else
                {
                    MessageBox.Show("Favor de seleccionar lo que desea modificar", "Eleccion incompleta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Conectar();
                //Se cargan los datos actuales en los textbox en el datagridview para actualizar sus valores
                int seleccion = dgv_Agregar.CurrentRow.Index;
                // Verificamos si hay una fila seleccionada
                if (dgv_Agregar.CurrentRow != null && dgv_Agregar.CurrentRow.Index > -1)
                {
                    DialogResult confirmacion = MessageBox.Show("¿Está seguro que desea eliminar esta fila permanentemente? Permanentemente es mucho tiempo.",
                        "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    // Usuario confirma eliminación
                    if (confirmacion == DialogResult.Yes)
                    {
                        //dgv_Agregar.Rows.RemoveAt(dgv_Agregar.CurrentRow.Index);
                        Sql = "update DatosGenerales set Estado = @Estado WHERE Id_Alumno = @Id_Alumno";
                        Comando = new SqlCommand(Sql, Conexion);
                        Comando.Parameters.AddWithValue("@Id_Alumno", dgv_Agregar.Rows[seleccion].Cells[0].Value);
                        
                        Comando.Parameters.AddWithValue("@Estado", 2);

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
                    }
                }
                else
                {
                    throw new Exception("Seleccione una fila para eliminar.");
                }
               RefrescarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Guardar()
        {
            ///Se guardan los datos de los becados en el archivo txt
            ///Se tiene que sobreescribir ya que si es que se eliminan datos
            ///los indices estarian mal para las siguientes veces que se desplegara el programa
            FileStream becados = new FileStream("Becados.txt", FileMode.Create, FileAccess.Write);
            using (StreamWriter writer = new StreamWriter(becados))
            {
                //Se recorren todas las filas del datagridview
                foreach (DataGridViewRow row in dgv_Agregar.Rows)
                {
                    writer.WriteLine($"{row.Cells[0].Value},{row.Cells[1].Value},{row.Cells[2].Value},{row.Cells[3].Value}," +
                        $"{row.Cells[4].Value},{row.Cells[5].Value},{row.Cells[6].Value},{row.Cells[7].Value}," +
                        $"{row.Cells[8].Value},{row.Cells[9].Value},{row.Cells[10].Value},{row.Cells[11].Value}," +
                        $"{row.Cells[12].Value},{row.Cells[13].Value},{row.Cells[14].Value},{row.Cells[15].Value}," +
                        $"{row.Cells[16].Value},{row.Cells[17].Value},{row.Cells[18].Value},{row.Cells[19].Value}");

                }
            }
            //Se terminan de guardar los datos y se cierra el archivo
            becados.Close();
        }

        private void frmRegistrarBecarios_ESA_Load(object sender, EventArgs e)
        {
            CargarFuentes();
            this.FormBorderStyle = FormBorderStyle.None;
            
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


        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se admiten letras", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se admiten numeros", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }


        }

        private void txtApaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se admiten letras", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtAmaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se admiten letras", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtEstadoCivil_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se admiten letras", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se admiten numeros", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtCodigoPostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se admiten numeros", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtNacionalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se admiten letras", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtMunicipio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se admiten letras", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtDomicilio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se admiten letras", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtCarrera_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se admiten letras", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtPeriodo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtPromedio_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPromedio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se admiten numeros", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
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
                        return true;
                    //Si hay un control de tipo ComboBox y su valor string esta nulo o vacio, regresara true
                    else if (control is System.Windows.Forms.ComboBox comboBox && comboBox.SelectedIndex == -1)
                        return true;
                }
            }
            return false; //Regresa falso si ningun campo esta vacio
        }

        public void BuscarCamposVacios_AgregarDatos()
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
            else
            {
                //int indiceNuevaFila;
                // Validar que el campo "Correo Electrónico" contenga "@" y termine con ".com"
                string correoElectronico = txtCorreoElectronico.Text;
                if (!correoElectronico.Contains("@") || !correoElectronico.EndsWith(".com") || !correoElectronico.EndsWith(".edu.mx"))
                {
                    MessageBox.Show("Por favor, ingrese una dirección de correo electrónico válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCorreoElectronico.Focus();
                    return;//Detener la ejecucion del metodo si el correo electronico no es valido
                }
                if (txtEdad.Text.Length != 2)//Vaidar rango de edad
                {
                    MessageBox.Show("Por favor, ingrese una edad dentro del rango válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEdad.Focus();
                    return;//Detener la ejecucion del metodo si el correo electronico no es valido
                }

                txtEdad.BorderStyle = BorderStyle.None;

                /*---------------------------------------------Con ARCHIVOS TEXTO--------------------------------------------*/
                //Sirve para adicionar un nuevo renglon y guardar el indice de este mismo
              /*  indiceNuevaFila = dgv_Agregar.Rows.Add();

                //Colocamos la informacion en el DataGridView
                dgv_Agregar.Rows[indiceNuevaFila].Cells[0].Value = txtApaterno.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[1].Value = txtAmaterno.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[2].Value = txtNombres.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[3].Value = txtFechanac.Text;

                dgv_Agregar.Rows[indiceNuevaFila].Cells[4].Value = txtEdad.Text;

                dgv_Agregar.Rows[indiceNuevaFila].Cells[5].Value = GeneracionCURP();
                dgv_Agregar.Rows[indiceNuevaFila].Cells[6].Value = CBGenero.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[7].Value = cmbEstCivil.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[8].Value = txtDomicilio.Text;

                dgv_Agregar.Rows[indiceNuevaFila].Cells[9].Value = txtCodigoPostal.Text;

                dgv_Agregar.Rows[indiceNuevaFila].Cells[10].Value = txtNacionalidad.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[11].Value = cmbEstadoNac.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[12].Value = txtMunicipio.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[13].Value = correoElectronico;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[14].Value = txtTelefono.Text;

                dgv_Agregar.Rows[indiceNuevaFila].Cells[15].Value = txtCarrera.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[16].Value = txtPeriodo.Text;

                dgv_Agregar.Rows[indiceNuevaFila].Cells[17].Value = txtPromedio.Text;

                dgv_Agregar.Rows[indiceNuevaFila].Cells[18].Value = cmbCCT.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[19].Value = txtModelo.Text;*/

                /*-----------------------------------------------------------------------------------------------*/

                int Id_DatosAcademicos;
                int Id_DatosContacto;
                int Id_DatosGenerales;
               
                Conectar();
                /*Seleccionar id de escuela, le asigno una variable para guardar el valor*/
               
              

                /*-----------------------------------Inicio de metodo con base de datos-------------------------------------*/


                /*Insercion de tabla Datos academicos*/
                Sql = "";
                Sql = "insert into DatosAcademicos (Carrera, Periodo, Promedio, Modelo, CCT) values (@Carrera, @Periodo, @Promedio, @Modelo, @CCT)";
                Comando = new SqlCommand(Sql, Conexion);
                /*Tercera tabla*/

                Comando.Parameters.AddWithValue("@Carrera", txtCarrera.Text);
                Comando.Parameters.AddWithValue("@Periodo", txtPeriodo.Text);
                Comando.Parameters.AddWithValue("@Promedio", txtPromedio.Text);
                Comando.Parameters.AddWithValue("@Modelo", txtModelo.Text);
                Comando.Parameters.AddWithValue("@CCT", cmbCCT.Text);
                try
                {

                    Comando.ExecuteNonQuery();

                    MessageBox.Show("Registro Academicos Insertados");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                }


                /*Insercion de tabla Datos Contacto*/
                Sql = "";
                Sql = "insert into DatosContacto (Domicilio, CodigoPostal, Nacionalidad, EstadoNacimiento, Municipio, Correo, Telefono) values (@Domicilio, @CodigoPostal, @Nacionalidad, @EstadoNacimiento, @Municipio, @Correo, @Telefono)";
                Comando = new SqlCommand(Sql, Conexion);
                //Insercion de segunda tabla
                Comando.Parameters.AddWithValue("@Domicilio", txtDomicilio.Text);
                Comando.Parameters.AddWithValue("@CodigoPostal", txtCodigoPostal.Text);
                Comando.Parameters.AddWithValue("@Nacionalidad", cmbNacionalidad.Text);
                Comando.Parameters.AddWithValue("@EstadoNacimiento", cmbEstadoNac.Text);
                Comando.Parameters.AddWithValue("@Municipio", txtMunicipio.Text);
                Comando.Parameters.AddWithValue("@Correo", txtCorreoElectronico.Text);
                Comando.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                try
                {

                    Comando.ExecuteNonQuery();

                    MessageBox.Show("Registro Contacto Insertado");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                }
                /*Insercion de tabla Datos generales*/
                Sql = "";
                Sql = "insert into DatosGenerales(ApellidoPaterno, ApellidoMaterno, Nombres, FechaNacimiento, Edad, Curp, EstadoCivil, Genero, Estado) values (@ApellidoPaterno, @ApellidoMaterno, @Nombres, @FechaNacimiento, @Edad, @Curp, @EstadoCivil, @Genero, @Estado)";
                Comando = new SqlCommand(Sql, Conexion);
                //Insercion de la primera tabla
                Comando.Parameters.AddWithValue("@ApellidoPaterno", txtApaterno.Text);
                Comando.Parameters.AddWithValue("@ApellidoMaterno", txtAmaterno.Text);
                Comando.Parameters.AddWithValue("@Nombres", txtNombres.Text);
                Comando.Parameters.AddWithValue("@FechaNacimiento", txtFechanac.Value);
                Comando.Parameters.AddWithValue("@Edad", txtEdad.Text);
                Comando.Parameters.AddWithValue("@Curp", GeneracionCURP());
                Comando.Parameters.AddWithValue("@EstadoCivil", cmbEstCivil.Text);
                Comando.Parameters.AddWithValue("@Genero", CBGenero.Text);
                Comando.Parameters.AddWithValue("@Estado", 1);
                try
                {

                    Comando.ExecuteNonQuery();

                    MessageBox.Show("Registro General Insertado");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                }



                /*-----------------------------------Fin de metodo con base de datos-------------------------------------*/


                //Se terminan de guardar los datos y se cierra el archivo
                Conexion.Close();

                /*--------------------------------------Insertar los id datos academicos-------------------------------------*/
                Conectar();
                //ID DATOS ACADEMICOS
                Sql = "";
                //Consulta
                Sql = "SELECT MAX(Id_DatosAcademicos) From DatosAcademicos";

                Comando = new SqlCommand(Sql, Conexion);
                Id_DatosAcademicos = Convert.ToInt32(Comando.ExecuteScalar());

                //Seleccion del id mas reciente de Datos generales
                Sql = "";
                
                Sql = "SELECT MAX(Id_Alumno) From DatosGenerales";

                Comando = new SqlCommand(Sql, Conexion);
                Id_DatosGenerales = Convert.ToInt32(Comando.ExecuteScalar());
                //Insercion

                Sql = "update DatosGenerales set Id_DatosAcademicos = @Id_DatosAcademicos WHERE Id_Alumno = @Id_Alumno";
                Comando = new SqlCommand(Sql, Conexion);
                Comando.Parameters.AddWithValue("@Id_Alumno", Id_DatosGenerales);
                Comando.Parameters.AddWithValue("@Id_DatosAcademicos", Id_DatosAcademicos);

                //Comando Try
                try
                {
                    Comando.ExecuteNonQuery();

                    MessageBox.Show("Registro ID academicos");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                }
                Conexion.Close();
                /*Terminacion de insericon de id datos academicos*/

                //ID DATOS CONTACTO
                Conectar();
                Sql = "";
                Sql = "SELECT MAX(Id_DatosContacto) From DatosContacto";

                Comando = new SqlCommand(Sql, Conexion);
                Id_DatosContacto = Convert.ToInt32(Comando.ExecuteScalar());

                //Seleccion del id mas reciente de Datos generales
                Sql = "";

                Sql = "SELECT MAX(Id_Alumno) From DatosGenerales";

                Comando = new SqlCommand(Sql, Conexion);
                Id_DatosGenerales = Convert.ToInt32(Comando.ExecuteScalar());
                //Insercion
                Sql = "update DatosGenerales set Id_DatosContacto = @Id_DatosContacto WHERE Id_Alumno = @Id_Alumno";
                Comando = new SqlCommand(Sql, Conexion);
                Comando.Parameters.AddWithValue("@Id_Alumno", Id_DatosGenerales);
                Comando.Parameters.AddWithValue("@Id_DatosContacto", Id_DatosContacto);

                //Comando Try
                try
                {
                    Comando.ExecuteNonQuery();
                    MessageBox.Show("Registro ID contacto");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                }


                Conexion.Close();
                /*Teminacion de insercion de datos de contacto*/

                /*-----------------------------------------------------------------------------------------------*/

                camposLimpieza();
                RefrescarDatos();
                //Regresar el "cursor" al textbox del nombre
                txtApaterno.Focus();
            }
        }
        public void CargarFuentes()
        {
            // Cargar las fuente desde el archivo TTF
            string nombreFuente = "coolveticaRG.otf";
            fontPers.CargarFuentePersonalizada(nombreFuente);
            // Aplicar la fuente a la etiqueta en lblTitulo_ESA
            fontPers.AplicarFuente(lblTitulo_ESA, 28, FontStyle.Regular);
        }

        public void LlenarDGV()
        {
            Conectar();
            //Query Primera Tabla

            Sql = "SELECT Id_Alumno, ApellidoPaterno, ApellidoMaterno, Nombres, FechaNacimiento, Edad, Curp, EstadoCivil, Genero, DatosContacto.Id_DatosContacto, Domicilio, CodigoPostal, Nacionalidad, EstadoNacimiento, Municipio, Correo, Telefono, DatosAcademicos.Id_DatosAcademicos,Carrera, Periodo, Promedio, Modelo, CCT " +
                "FROM DatosGenerales JOIN DatosContacto ON DatosContacto.Id_DatosContacto = DatosGenerales.Id_DatosContacto " +
                "JOIN DatosAcademicos ON DatosAcademicos.Id_DatosAcademicos = DatosGenerales.Id_DatosAcademicos WHERE Estado = 1 ";
           // Sql = "SELECT * from DatosGenerales, DatosAcademicos, DatosContacto";
            Adaptador = new SqlDataAdapter(Sql, Conexion);
            Adaptador.Fill(Tabla);
            dgv_Agregar.DataSource = Tabla;


            Conexion.Close();
        }
        public void RefrescarDatos()
        {
            Conectar();
            Tabla.Clear();
            dgv_Agregar.ClearSelection();

            // Sql = "SELECT Id_Alumno, ApellidoPaterno, ApellidoMaterno, Nombres, FechaNacimiento, Edad, Curp, EstadoCivil, Genero, Domicilio, CodigoPostal, Nacionalidad, EstadoNacimiento, Municipio, Correo, Telefono, Carrera, Periodo, Promedio, Modelo, CCT FROM DatosGenerales, DatosContacto, DatosAcademicos";
            Sql = "SELECT Id_Alumno, ApellidoPaterno, ApellidoMaterno, Nombres, FechaNacimiento, Edad, Curp, EstadoCivil, Genero, DatosContacto.Id_DatosContacto, Domicilio, CodigoPostal, Nacionalidad, EstadoNacimiento, Municipio, Correo, Telefono, DatosAcademicos.Id_DatosAcademicos,Carrera, Periodo, Promedio, Modelo, CCT " +
              "FROM DatosGenerales JOIN DatosContacto ON DatosContacto.Id_DatosContacto = DatosGenerales.Id_DatosContacto " +
              "JOIN DatosAcademicos ON DatosAcademicos.Id_DatosAcademicos = DatosGenerales.Id_DatosAcademicos WHERE Estado = 1 ";
            Adaptador = new SqlDataAdapter(Sql, Conexion);
            Adaptador.Fill(Tabla);
            dgv_Agregar.DataSource = Tabla;



            Conexion.Close();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void txtCorreoElectronico_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
