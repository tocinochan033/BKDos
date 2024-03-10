using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_AdministracionOrgDatos
{
    public partial class frmRegistrarBecarios_ESA : Form
    {
        //Variable para el calculo de la inactividad
        private Timer temporizadorInactividad;

        // Define un diccionario para almacenar los municipios por estado
        Dictionary<string, List<string>> municipiosPorEstado = new Dictionary<string, List<string>>();

        public frmRegistrarBecarios_ESA()
        {
            InitializeComponent();
            LlenarComboBoxEscuelas();
            LlenarComboBoxEstados();


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

            string aPaterno, aMaterno, nombres, fechanac, edad, curp, genero, estado_civil;
            string domicilio, codigo_postal, nacionalidad, estado_nacimiento, municipio, correo_electronico, telefono;
            string carrera, periodo, promedio, cct, modelo;
            int indicieNuevoRenglon;


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

        private void btnRegresarMenu_ESA_Click(object sender, EventArgs e)
        {
            //Guarda los datos y regresa a la pantalla anterior
            Guardar();
            this.Close();

            DatosInactividad.control = false; //Indicador al cerrar este formulario
        }

        private bool camposImcompletos()
        {
            return txtApaterno.Text == "" || txtAmaterno.Text == "" || txtNombres.Text == "" || txtFechanac.Text == ""
               || txtEdad.Text == "" || txtCURP.Text == "" || CBGenero.Text == "" || txtEstadoCivil.Text == "" || txtDomicilio.Text == ""
               || txtCodigoPostal.Text == "" || txtNacionalidad.Text == "" || cmbEstadoNac.Text == "" || txtMunicipio.Text == "" || txtCorreoElectronico.Text == ""
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
            cmbEstadoNac.Text = "";
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
                dgv_Agregar.Rows[indiceNuevaFila].Cells[5].Value = GeneracionCURP();
                dgv_Agregar.Rows[indiceNuevaFila].Cells[6].Value = CBGenero.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[7].Value = txtEstadoCivil.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[8].Value = txtDomicilio.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[9].Value = txtCodigoPostal.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[10].Value = txtNacionalidad.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[11].Value = cmbEstadoNac.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[12].Value = txtMunicipio.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[13].Value = txtCorreoElectronico.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[14].Value = txtTelefono.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[15].Value = txtCarrera.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[16].Value = txtPeriodo.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[17].Value = txtPromedio.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[18].Value = cmbCCT.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[19].Value = txtModelo.Text;


                
                camposLimpieza();

                //Regresar el "cursor" al textbox del nombre
                txtApaterno.Focus();
            }
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
            //Verificamos si hay una celda seleccionada
            if (this.dgv_Agregar.SelectedRows.Count == 1)
            {
                //Se cargan los datos actuales en los textbox en el datagridview para actualizar sus valores
                int seleccion = dgv_Agregar.CurrentRow.Index;
        
                if (cmbFiltroModificar.Text == "A.Paterno")
                {
                    dgv_Agregar.Rows[seleccion].Cells[0].Value = txtModificacion.Text;
                }
                else if (cmbFiltroModificar.Text == "A.Materno")
                {
                    dgv_Agregar.Rows[seleccion].Cells[1].Value = txtModificacion.Text;
                }
                else if (cmbFiltroModificar.Text == "Nombres")
                {
                    dgv_Agregar.Rows[seleccion].Cells[2].Value = txtModificacion.Text;
                }
                else if (cmbFiltroModificar.Text == "FechaNac")
                {
                    dgv_Agregar.Rows[seleccion].Cells[3].Value = txtModificacion.Text;
                }
                else if (cmbFiltroModificar.Text == "Edad")
                {
                    dgv_Agregar.Rows[seleccion].Cells[4].Value = txtModificacion.Text;
                }
                else if (cmbFiltroModificar.Text == "CURP")
                {
                    dgv_Agregar.Rows[seleccion].Cells[5].Value = txtModificacion.Text;
                }
                else if (cmbFiltroModificar.Text == "Genero")
                {
                    dgv_Agregar.Rows[seleccion].Cells[6].Value = txtModificacion.Text;
                }
                else if (cmbFiltroModificar.Text == "Estado Civil")
                {
                    dgv_Agregar.Rows[seleccion].Cells[7].Value = txtModificacion.Text;
                }
                else if (cmbFiltroModificar.Text == "Domicilio")
                {
                    dgv_Agregar.Rows[seleccion].Cells[8].Value = txtModificacion.Text;
                }
                else if (cmbFiltroModificar.Text == "Codigo Postal")
                {
                    dgv_Agregar.Rows[seleccion].Cells[9].Value = txtModificacion.Text;
                }
                else if (cmbFiltroModificar.Text == "Nacionalidad")
                {
                    dgv_Agregar.Rows[seleccion].Cells[10].Value = txtNacionalidad.Text;
                }
                else if (cmbFiltroModificar.Text == "EstadoNac")
                {
                    dgv_Agregar.Rows[seleccion].Cells[11].Value = txtModificacion.Text;
                }
                else if (cmbFiltroModificar.Text == "Municipio")
                {
                    dgv_Agregar.Rows[seleccion].Cells[12].Value = txtModificacion.Text;
                }
                else if (cmbFiltroModificar.Text == "Correo")
                {
                    dgv_Agregar.Rows[seleccion].Cells[13].Value = txtModificacion.Text;
                }
                else if (cmbFiltroModificar.Text == "Telefono")
                {
                    dgv_Agregar.Rows[seleccion].Cells[14].Value = txtModificacion.Text;
                }
                else if (cmbFiltroModificar.Text == "Carrera")
                {
                    dgv_Agregar.Rows[seleccion].Cells[15].Value = txtModificacion.Text;
                }
                else if (cmbFiltroModificar.Text == "Periodo")
                {
                    dgv_Agregar.Rows[seleccion].Cells[16].Value = txtModificacion.Text;
                }
                else if (cmbFiltroModificar.Text == "Promedio")
                {
                    dgv_Agregar.Rows[seleccion].Cells[17].Value = txtModificacion.Text;
                }
                else if (cmbFiltroModificar.Text == "CCT")
                {
                    dgv_Agregar.Rows[seleccion].Cells[18].Value = txtModificacion.Text;
                }
                else if (cmbFiltroModificar.Text == "Modelo")
                {
                    dgv_Agregar.Rows[seleccion].Cells[19].Value = txtModificacion.Text;
                }

                //Se limpian los campos para mayor comodidad del usuario
                txtModificacion.Text = "";
                cmbFiltroModificar.Text = "";
            }
            else
            {
                MessageBox.Show("Favor de seleccionar lo que desea modificar", "Eleccion incompleta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                cmbEstadoNac.Text = dgv_Agregar.Rows[seleccion].Cells[11].Value.ToString();
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
            //Se terminan de guardar los datos y se cierra el archivo
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
            this.FormBorderStyle = FormBorderStyle.None;
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

        private void cmbFiltroModificar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtModificacion_TextChanged(object sender, EventArgs e)
        {

        }

        // Método para llenar el ComboBox de estados
        private void LlenarComboBoxEstados()
        {
            // Agrega los estados a ComboBox de estados
            cmbEstadoNac.Items.AddRange(new string[] {
                "Aguascalientes", "Baja California", "Baja California Sur", "Campeche", "Coahuila",
                "Colima", "Chiapas", "Chihuahua", "Distrito Federal", "Durango", "Guanajuato", "Guerrero",
                "Hidalgo", "Jalisco", "Mexico", "Michoacan", "Morelos", "Nayarit", "Nuevo Leon", "Oaxaca",
                "Puebla", "Queretaro", "Quintana Roo", "San Luis Potosi", "Sinaloa", "Sonora", "Tabasco",
                "Tamaulipas", "Tlaxcala", "Veracruz", "Yucatan", "Zacatecas", "Extranjero"
                });

            // Agrega los municipios correspondientes a cada estado al diccionario
            municipiosPorEstado.Add("Aguascalientes", new List<string> { "Aguascalientes", "Asientos", "Calvillo", "Cosío", "Jesús María", "Pabellón de Arteaga", "Rincón de Romos", 
            "San José de Gracia", "Tepezalá", "El Llano", "San Francisco de los Romo" });
            municipiosPorEstado.Add("Baja California", new List<string> { "Ensenada", "Mexicali", "Tecate", "Tijuana", "Playas de Rosarito" });
            municipiosPorEstado.Add("Baja California Sur", new List<string> {
    "Comondú", "Mulegé", "La Paz", "Los Cabos", "Loreto"
});

            municipiosPorEstado.Add("Campeche", new List<string> {
    "Calkiní", "Campeche", "Carmen", "Champotón", "Hecelchakán", "Hopelchén", "Palizada", "Tenabo", "Escárcega"
});

            municipiosPorEstado.Add("Coahuila", new List<string> {
    "Abasolo", "Acuña", "Allende", "Arteaga", "Candela", "Castaños", "Cuatro Ciénegas", "Escobedo", "Francisco I. Madero", "Frontera",
    "General Cepeda", "Guerrero", "Hidalgo", "Jiménez", "Juárez", "Lamadrid", "Matamoros", "Monclova", "Morelos", "Múzquiz", "Nadadores",
    "Nava", "Ocampo", "Parras", "Piedras Negras", "Progreso", "Ramos Arizpe", "Sabinas", "Sacramento", "Saltillo", "San Buenaventura",
    "San Juan de Sabinas", "San Pedro", "Sierra Mojada", "Torreón", "Viesca", "Villa Unión", "Zaragoza"
});

            municipiosPorEstado.Add("Colima", new List<string> {
    "Armería", "Colima", "Comala", "Coquimatlán", "Cuauhtémoc", "Ixtlahuacán", "Manzanillo", "Minatitlán", "Tecomán", "Villa de Álvarez"
});

            municipiosPorEstado.Add("Chiapas", new List<string> {
    "Acacoyagua", "Acala", "Acapetahua", "Altamirano", "Amatán", "Amatenango de la Frontera", "Amatenango del Valle", "Angel Albino Corzo",
    "Arriaga", "Bejucal de Ocampo", "Bella Vista", "Berriozábal", "Bochil", "El Bosque", "Cacahoatán", "Catazajá", "Cintalapa", "Coapilla",
    "Comitán de Domínguez", "La Concordia", "Copainalá", "Chalchihuitán", "Chamula", "Chanal", "Chapultenango", "Chenalhó", "Chiapa de Corzo",
    "Chiapilla", "Chicoasén", "Chicomuselo", "Chilón", "Escuintla", "Francisco León", "Frontera Comalapa", "Frontera Hidalgo", "La Grandeza",
    "Huehuetán", "Huixtán", "Huitiupán", "Huixtla", "La Independencia", "Ixhuatán", "Ixtacomitán", "Ixtapa", "Ixtapangajoya", "Jiquipilas",
    "Jitotol", "Juárez", "Larráinzar", "La Libertad", "Mapastepec", "Las Margaritas", "Mazapa de Madero", "Mazatán", "Metapa", "Mitontic",
    "Motozintla", "Nicolás Ruíz", "Ocosingo", "Ocotepec", "Ocozocoautla de Espinosa", "Ostuacán", "Osumacinta", "Oxchuc", "Palenque",
    "Pantelhó", "Pantepec", "Pichucalco", "Pijijiapan", "El Porvenir", "Villa Comaltitlán", "Pueblo Nuevo Solistahuacán", "Rayón", "Reforma",
    "Las Rosas", "Sabanilla", "Salto de Agua", "San Cristóbal de las Casas", "San Fernando", "Siltepec", "Simojovel", "Sitalá", "Socoltenango",
    "Solosuchiapa", "Soyaló", "Suchiapa", "Suchiate", "Sunuapa", "Tapachula", "Tapalapa", "Tapilula", "Tecpatán", "Tenejapa", "Teopisca",
    "Tila", "Tonalá", "Totolapa", "La Trinitaria", "Tumbalá", "Tuxtla Gutiérrez", "Tuxtla Chico", "Tuzantán", "Tzimol", "Unión Juárez",
    "Venustiano Carranza", "Villa Corzo", "Villaflores", "Yajalón", "San Lucas", "Zinacantán", "San Juan Cancuc", "Aldama"
});

            municipiosPorEstado.Add("Chihuahua", new List<string> {
    "Ahumada", "Aldama", "Allende", "Aquiles Serdán", "Ascensión", "Bachíniva", "Balleza", "Batopilas", "Bocoyna", "Buenaventura", "Camargo",
    "Carichí", "Casas Grandes", "Coronado", "Coyame del Sotol", "La Cruz", "Cuauhtémoc", "Cusihuiriachi", "Chihuahua", "Chínipas", "Delicias",
    "Dr. Belisario Domínguez", "Galeana", "Santa Isabel", "Gómez Farías", "Gran Morelos", "Guachochi", "Guadalupe", "Guadalupe y Calvo",
    "Guazapares", "Guerrero", "Hidalgo del Parral", "Huejotitán", "Ign"
});

            municipiosPorEstado.Add("Distrito Federal", new List<string> {
    "Alvaro Obregón", "Azcapotzalco", "Benito Juarez", "Coyoacán", "Cuajimalpa de Morelos", "Cuauhtémoc", "Gustavo A. Madero",
    "Iztacalco", "Iztapalapa", "Magdalena Contreras", "Miguel Hidalgo", "Milpa Alta", "Tláhuac", "Tlalpan", "Venustiano Carranza",
    "Xochimilco"
});

            municipiosPorEstado.Add("Durango", new List<string> {
    "Canatlán", "Canelas", "Coneto de Comonfort", "Cuencamé", "Durango", "General Simón Bolívar", "Gómez Palacio", "Guadalupe Victoria",
    "Guanaceví", "Hidalgo", "Indé", "Lerdo", "Mapimí", "Mezquital", "Nazas", "Nombre de Dios", "Nuevo Ideal", "Ocampo", "Otáez", "Pánuco de Coronado",
    "Peñón Blanco", "Poanas", "Pueblo Nuevo", "Rodeo", "San Bernardo", "San Dimas", "San Juan de Guadalupe", "San Juan del Río", "San Luis del Cordero",
    "San Pedro del Gallo", "Santa Clara", "Santiago Papasquiaro", "Súchil", "Tamazula", "Tepehuanes", "Tlahualilo", "Topia", "Vicente Guerrero",
    "Nuevo Ideal"
});

            municipiosPorEstado.Add("Guanajuato", new List<string> {
    "Abasolo", "Acámbaro", "San Miguel de Allende", "Apaseo el Alto", "Apaseo el Grande", "Atarjea", "Celaya", "Manuel Doblado",
    "Comonfort", "Coroneo", "Cortazar", "Cuerámaro", "Doctor Mora", "Dolores Hidalgo Cuna de la Independencia Nacional", "Guanajuato",
    "Huanímaro", "Irapuato", "Jaral del Progreso", "Jerécuaro", "León", "Moroleón", "Ocampo", "Pénjamo", "Pueblo Nuevo", "Purísima del Rincón",
    "Romita", "Salamanca", "Salvatierra", "San Diego de la Unión", "San Felipe", "San Francisco del Rincón", "San José Iturbide",
    "San Luis de la Paz", "Santa Catarina", "Santa Cruz de Juventino Rosas", "Santiago Maravatío", "Silao", "Tarandacuao",
    "Tarimoro", "Tierra Blanca", "Uriangato", "Valle de Santiago", "Victoria", "Villagrán", "Xichú", "Yuriria"
});

            municipiosPorEstado.Add("Guerrero", new List<string> {
    "Acapulco de Juárez", "Ahuacuotzingo", "Ajuchitlán del Progreso", "Alcozauca de Guerrero", "Alpoyeca", "Apaxtla", "Arcelia", "Atenango del Río",
    "Atlamajalcingo del Monte", "Atlixtac", "Atoyac de Álvarez", "Ayutla de los Libres", "Azoyú", "Benito Juárez", "Buenavista de Cuéllar",
    "Coahuayutla de José María Izazaga", "Cocula", "Copala", "Copalillo", "Copanatoyac", "Coyuca de Benítez", "Coyuca de Catalán", "Cuajinicuilapa",
    "Cualác", "Cuautepec", "Cuetzala del Progreso", "Cutzamala de Pinzón", "Chilapa de Álvarez", "Chilpancingo de los Bravo", "Florencio Villarreal",
    "General Canuto A. Neri", "General Heliodoro Castillo", "Huamuxtitlán", "Huitzuco de los Figueroa", "Iguala de la Independencia", "Igualapa",
    "Ixcateopan de Cuauhtémoc", "Zihuatanejo de Azueta", "Juan R. Escudero", "Leonardo Bravo", "Malinaltepec", "Mártir de Cuilapan", "Metlatónoc",
    "Mochitlán", "Olinalá", "Ometepec", "Pedro Ascencio Alquisiras", "Petatlán", "Pilcaya", "Pungarabato", "Quechultenango", "San Luis Acatlán",
    "San Marcos", "San Miguel Totolapan", "Taxco de Alarcón", "Tecoanapa", "Técpan de Galeana", "Teloloapan", "Tepecoacuilco de Trujano",
    "Tetipac", "Tixtla de Guerrero", "Tlacoachistlahuaca", "Tlacoapa", "Tlalchapa", "Tlalixtaquilla de Maldonado", "Tlapa de Comonfort",
    "Tlapehuala", "La Unión de Isidoro Montes de Oca", "Xalpatláhuac", "Xochihuehuetlán", "Xochistlahuaca", "Zapotitlán Tablas", "Zirándaro",
    "Zitlala", "Eduardo Neri", "Acatepec", "Marquelia", "Cochoapa el Grande", "José Joaquín de Herrera", "Juchitán", "Iliatenco",
    "La Unión Tejalapan", "Xochapa", "Pilcaya"
});

            municipiosPorEstado.Add("Hidalgo", new List<string> {
    "Acatlán", "Acaxochitlán", "Actopan", "Agua Blanca de Iturbide", "Ajacuba", "Alfajayucan", "Almoloya", "Apan", "El Arenal", "Atitalaquia",
    "Atlapexco", "Atotonilco el Grande", "Atotonilco de Tula", "Calnali", "Cardonal", "Cuautepec de Hinojosa", "Chapantongo", "Chapulhuacán",
    "Chilcuautla", "Eloxochitlán", "Emiliano Zapata", "Epazoyucan", "Francisco I. Madero", "Huasca de Ocampo", "Huautla", "Huazalingo",
    "Huehuetla", "Huejutla de Reyes", "Huichapan", "Ixmiquilpan", "Jacala de Ledezma", "Jaltocán", "Juárez Hidalgo", "Lolotla", "Metepec",
    "San Agustín Metzquititlán", "Metztitlán", "Mineral del Chico", "Mineral del Monte", "La Misión", "Mixquiahuala de Juárez", "Molango de Escamilla",
    "Nicolás Flores", "Nopala de Villagrán", "Omitlán de Juárez", "San Felipe Orizatlán", "Pacula", "Pachuca de Soto", "Pisaflores", "Progreso de Obregón",
    "Mineral de la Reforma", "San Agustín Tlaxiaca", "San Bartolo Tutotepec", "San Salvador", "Santiago de Anaya", "Santiago Tulantepec de Lugo Guerrero",
    "Singuilucan", "Tasquillo", "Tecozautla", "Tenango de Doria", "Tepeapulco", "Tepehuacán de Guerrero", "Tepeji del Río de Ocampo", "Tepetitlán",
    "Tetepango", "Villa de Tezontepec", "Tezontepec de Aldama", "Tianguistengo", "Tizayuca", "Tlahuelilpan", "Tlahuiltepa", "Tlanalapa",
    "Tlanchinol", "Tlaxcoapan", "Tolcayuca", "Tula de Allende", "Tulancingo de Bravo", "Xochiatipan", "Xochicoatlán", "Yahualica", "Zacualtipán de Ángeles",
    "Zapotlán de Juárez", "Zempoala", "Zimapán"
});

            municipiosPorEstado.Add("Jalisco", new List<string> {
    "Acatic", "Acatlán de Juárez", "Ahualulco de Mercado", "Amacueca", "Amatitán", "Ameca", "San Juanito de Escobedo", "Arandas", "El Arenal",
    "Atemajac de Brizuela", "Atengo", "Atenguillo", "Atotonilco el Alto", "Atoyac", "Autlán de Navarro", "Ayotlán", "Ayutla", "La Barca",
    "Bolaños", "Cabo Corrientes", "Casimiro Castillo", "Cihuatlán", "Zapotlán el Grande", "Cocula", "Colotlán", "Concepción de Buenos Aires",
    "Cuautitlán de García Barragán", "Cuautla", "Cuquío", "Chapala", "Chimaltitán", "Chiquilistlán", "Degollado", "Ejutla", "Encarnación de Díaz",
    "Etzatlán", "El Grullo", "Guachinango", "Guadalajara", "Hostotipaquillo", "Huejúcar", "Huejuquilla el Alto", "La Huerta", "Ixtlahuacán de los Membrillos",
    "Ixtlahuacán del Río", "Jalostotitlán", "Jamay", "Jesús María", "Jilotlán de los Dolores", "Jocotepec", "Juanacatlán", "Juchitlán", "Lagos de Moreno",
    "El Limón", "Magdalena", "Santa María del Oro", "La Manzanilla de la Paz", "Mascota", "Mazamitla", "Mexticacán", "Mezquitic", "Mixtlán", "Ocotlán",
    "Ojuelos de Jalisco", "Pihuamo", "Poncitlán", "Puerto Vallarta", "Villa Purificación", "Quitupan", "El Salto", "San Cristóbal de la Barranca",
    "San Diego de Alejandría", "San Juan de los Lagos", "San Julián", "San Marcos", "San Martín de Bolaños", "San Martín Hidalgo", "San Miguel el Alto",
    "Gómez Farías", "San Sebastián del Oeste", "Santa María de los Ángeles", "Sayula", "Tala", "Talpa de Allende", "Tamazula de Gordiano",
    "Tapalpa", "Tecalitlán", "Tecolotlán", "Techaluta de Montenegro", "Tenamaxtlán", "Teocaltiche", "Teocuitatlán de Corona", "Tepatitlán de Morelos",
    "Tequila", "Teuchitlán", "Tizapán el Alto", "Tlajomulco de Zúñiga", "San Pedro Tlaquepaque", "Tolimán", "Tomatlán", "Tonalá", "Tonaya", "Tonila",
    "Totatiche", "Tototlán", "Tuxcacuesco", "Tuxcueca", "Tuxpan", "Unión de San Antonio", "Unión de Tula", "Valle de Guadalupe", "Valle de Juárez",
    "San Gabriel", "Villa Corona", "Villa Guerrero", "Villa Hidalgo", "Cañadas de Obregón", "Yahualica de González Gallo", "Zacoalco de Torres",
    "Zapopan", "Zapotiltic", "Zapotitlán de Vadillo", "Zapotlán del Rey", "Zapotlanejo"
});

            municipiosPorEstado.Add("Mexico", new List<string> {
    "Acambay de Ruíz Castañeda", "Acolman", "Aculco", "Almoloya de Alquisiras", "Almoloya de Juárez", "Almoloya del Río", "Amanalco",
    "Amatepec", "Amecameca", "Apaxco", "Atenco", "Atizapán", "Atizapán de Zaragoza", "Atlacomulco", "Atlautla", "Axapusco", "Ayapango",
    "Calimaya", "Capulhuac", "Coacalco de Berriozábal", "Coatepec Harinas", "Cocotitlán", "Coyotepec", "Cuautitlán", "Chalco", "Chapa de Mota",
    "Chapultepec", "Chiautla", "Chicoloapan", "Chiconcuac", "Chimalhuacán", "Donato Guerra", "Ecatepec de Morelos", "Ecatzingo", "Huehuetoca",
    "Hueypoxtla", "Huixquilucan", "Isidro Fabela", "Ixtapaluca", "Ixtapan de la Sal", "Ixtapan del Oro", "Ixtlahuaca", "Xalatlaco", "Jaltenco",
    "Jilotepec", "Jilotzingo", "Jiquipilco", "Jocotitlán", "Joquicingo", "Juchitepec", "Lerma", "Malinalco", "Melchor Ocampo", "Metepec",
    "Mexicaltzingo", "Morelos", "Naucalpan de Juárez", "Nezahualcóyotl", "Nextlalpan", "Nicolás Romero", "Nopaltepec", "Ocoyoacac", "Ocuilan",
    "El Oro", "Otumba", "Otzoloapan", "Otzolotepec", "Ozumba", "Papalotla", "La Paz", "Polotitlán", "Rayón", "San Antonio la Isla",
    "San Felipe del Progreso", "San Martín de las Pirámides", "San Mateo Atenco", "San Simón de Guerrero", "Santo Tomás", "Soyaniquilpan de Juárez",
    "Sultepec", "Tecámac", "Tejupilco", "Temamatla", "Temascalapa", "Temascalcingo", "Temascaltepec", "Temoaya", "Tenancingo", "Tenango del Aire",
    "Tenango del Valle", "Teoloyucan", "Teotihuacán", "Tepetlaoxtoc", "Tepetlixpa", "Tepotzotlán", "Tequixquiac", "Texcaltitlán", "Texcalyacac",
    "Texcoco", "Tezoyuca", "Tianguistenco", "Timilpan", "Tlalmanalco", "Tlalnepantla de Baz", "Tlatlaya", "Toluca", "Tonatico", "Tultepec",
    "Tultitlán", "Valle de Bravo", "Villa de Allende", "Villa del Carbón", "Villa Guerrero", "Villa Victoria", "Xonacatlán", "Zacazonapan",
    "Zacualpan", "Zinacantepec", "Zumpahuacán", "Zumpango"
});

            municipiosPorEstado.Add("Michoacan", new List<string> {
    "Acuitzio", "Aguililla", "Álvaro Obregón", "Angamacutiro", "Angangueo", "Apatzingán", "Aporo", "Aquila", "Ario", "Arteaga", "Briseñas",
    "Buenavista", "Carácuaro", "Coahuayana", "Coalcomán de Vázquez Pallares", "Coeneo", "Contepec", "Copándaro", "Cotija", "Cuitzeo",
    "Charapan", "Charo", "Chavinda", "Cherán", "Chilchota", "Chinicuila", "Chucándiro", "Churintzio", "Churumuco", "Ecuandureo", "Epitacio Huerta",
    "Erongarícuaro", "Gabriel Zamora", "Hidalgo", "La Huacana", "Huandacareo", "Huaniqueo", "Huetamo", "Huiramba", "Indaparapeo", "Irimbo",
    "Ixtlán", "Jacona", "Jiménez", "Jiquilpan", "Juárez", "Jungapeo", "Lagunillas", "Madero", "Maravatío", "Marcos Castellanos", "Lázaro Cárdenas",
    "Morelia", "Morelos", "Múgica", "Nahuatzen", "Nocupétaro", "Nuevo Parangaricutiro", "Nuevo Urecho", "Numarán", "Ocampo", "Pajacuarán",
    "Panindícuaro", "Parácuaro", "Paracho", "Pátzcuaro", "Penjamillo", "Peribán", "La Piedad", "Purépero", "Puruándiro", "Queréndaro",
    "Quiroga", "Cojumatlán de Régules", "Los Reyes", "Sahuayo", "San Lucas", "Santa Ana Maya", "Salvador Escalante", "Senguio", "Susupuato",
    "Tacámbaro", "Tancítaro", "Tangamandapio", "Tangancícuaro", "Tanhuato", "Taretan", "Tarímbaro", "Tepalcatepec", "Tingambato", "Tingüindín",
    "Tiquicheo de Nicolás Romero", "Tlalpujahua", "Tlazazalca", "Tocumbo", "Tumbiscatío", "Turicato", "Tuxpan", "Tuzantla", "Tzintzuntzan",
    "Tzitzio", "Uruapan", "Venustiano Carranza", "Villamar", "Vista Hermosa", "Yurécuaro", "Zacapu", "Zamora", "Zináparo", "Zinapécuaro",
    "Ziracuaretiro", "Zitácuaro", "José Sixto Verduzco"
});

            municipiosPorEstado.Add("Morelos", new List<string> {
    "Amacuzac", "Atlatlahucan", "Axochiapan", "Ayala", "Coatlán del Río", "Cuautla", "Cuernavaca", "Emiliano Zapata", "Huitzilac",
    "Jantetelco", "Jiutepec", "Jojutla", "Jonacatepec", "Mazatepec", "Miacatlán", "Ocuituco", "Puente de Ixtla", "Temixco",
    "Tepalcingo", "Tepoztlán", "Tetecala", "Tetela del Volcán", "Tlalnepantla", "Tlaltizapán de Zapata", "Tlaquiltenango",
    "Tlayacapan", "Totolapan", "Xochitepec", "Yautepec", "Yecapixtla", "Zacatepec de Hidalgo", "Zacualpan de Amilpas",
    "Temoac"
});

            municipiosPorEstado.Add("Nayarit", new List<string> {
    "Acaponeta", "Ahuacatlán", "Amatlán de Cañas", "Compostela", "Huajicori", "Ixtlán del Río", "Jala", "Xalisco", "Del Nayar",
    "Rosamorada", "Ruíz", "San Blas", "San Pedro Lagunillas", "Santa María del Oro", "Santiago Ixcuintla", "Tecuala", "Tepic",
    "Tuxpan", "La Yesca", "Bahía de Banderas"
});

            municipiosPorEstado.Add("Nuevo Leon", new List<string> {
    "Abasolo", "Agualeguas", "Los Aldamas", "Allende", "Anáhuac", "Apodaca", "Aramberri", "Bustamante", "Cadereyta Jiménez",
    "El Carmen", "Cerralvo", "Ciénega de Flores", "China", "Doctor Arroyo", "Doctor Coss", "Doctor González", "Galeana",
    "García", "San Pedro Garza García", "General Bravo", "General Escobedo", "General Terán", "General Treviño", "General Zaragoza", 
    "General Zuazua", "Guadalupe", "Los Herreras", "Higueras", "Hualahuises", "Iturbide", "Juárez", "Lampazos de Naranjo", "Linares", 
    "Marín", "Melchor Ocampo", "Mier y Noriega", "Mina", "Montemorelos", "Monterrey", "Parás", 
    "Pesquería", "Los Ramones", "Rayones", "Sabinas Hidalgo", "Salinas Victoria", "San Nicolás de los Garza", "Hidalgo",
    "Santa Catarina", "Santiago", "Vallecillo", "Villaldama"
});

            municipiosPorEstado.Add("Oaxaca", new List<string> {
    "Abejones", "Acatlán de Pérez Figueroa", "Asunción Cacalotepec", "Asunción Cuyotepeji", "Asunción Ixtaltepec",
    "Asunción Nochixtlán", "Asunción Ocotlán", "Asunción Tlacolulita", "Ayotzintepec", "El Barrio de la Soledad",
    "Calihualá", "Candelaria Loxicha", "Ciénega de Zimatlán", "Ciudad Ixtepec", "Coatecas Altas", "Coicoyán de las Flores",
    "La Compañía", "Concepción Buenavista", "Concepción Pápalo", "Constancia del Rosario", "Cosolapa", "Cosoltepec",
    "Cuilápam de Guerrero", "Cuyamecalco Villa de Zaragoza", "Chahuites", "Chalcatongo de Hidalgo", "Chiquihuitlán de Benito Juárez",
    "Heroica Ciudad de Ejutla de Crespo", "Eloxochitlán de Flores Magón", "El Espinal", "Tamazulápam del Espíritu Santo",
    "Fresnillo de Trujano", "Guadalupe Etla", "Guadalupe de Ramírez", "Guelatao de Juárez", "Guevea de Humboldt", "Mesones Hidalgo",
    "Villa Hidalgo", "Heroica Ciudad de Huajuapan de León", "Huautepec", "Huautla de Jiménez", "Ixtlán de Juárez", "Heroica Ciudad de Juchitán de Zaragoza",
    "Loma Bonita", "Magdalena Apasco", "Magdalena Jaltepec", "Santa Magdalena Jicotlán", "Magdalena Mixtepec", "Magdalena Ocotlán",
    "Magdalena Peñasco", "Magdalena Teitipac", "Magdalena Tequisistlán", "Magdalena Tlacotepec", "Magdalena Zahuatlán", "Mariscala de Juárez",
    "Mártires de Tacubaya", "Matías Romero Avendaño", "Mazatlán Villa de Flores", "Miahuatlán de Porfirio Díaz", "Mixistlán de la Reforma",
    "Monjas", "Natividad", "Nazareno Etla", "Nejapa de Madero", "Ixpantepec Nieves", "Santiago Niltepec", "Oaxaca de Juárez",
    "Ocotlán de Morelos", "La Pe", "Pinotepa de Don Luis", "Pluma Hidalgo", "San José del Progreso", "Putla Villa de Guerrero",
    "Santa Catarina Quioquitani", "Reforma de Pineda", "La Reforma", "Reyes Etla", "Rojas de Cuauhtémoc", "Salina Cruz",
    "San Agustín Amatengo", "San Agustín Atenango", "San Agustín Chayuco", "San Agustín de las Juntas", "San Agustín Etla",
    "San Agustín Loxicha", "San Agustín Tlacotepec", "San Agustín Yatareni", "San Andrés Cabecera Nueva", "San Andrés Dinicuiti",
    "San Andrés Huaxpaltepec", "San Andrés Huayápam", "San Andrés Ixtlahuaca", "San Andrés Lagunas", "San Andrés Nuxiño",
    "San Andrés Paxtlán", "San Andrés Sinaxtla", "San Andrés Solaga", "San Andrés Teotilálpam", "San Andrés Tepetlapa",
    "San Andrés Yaá", "San Andrés Zabache", "San Andrés Zautla", "San Antonino Castillo Velasco", "San Antonino el Alto",
    "San Antonino Monte Verde", "San Antonio Acutla", "San Antonio de la Cal", "San Antonio Huitepec", "San Antonio Nanahuatípam",
    "San Antonio Sinicahua", "San Antonio Tepetlapa", "San Baltazar Chichicápam", "San Baltazar Loxicha", "San Baltazar Yatzachi el Bajo",
    "San Bartolo Coyotepec", "San Bartolomé Ayautla", "San Bartolomé Loxicha", "San Bartolomé Quialana", "San Bartolomé Yucuañe",
    "San Bartolomé Zoogocho", "San Bartolo Soyaltepec", "San Bartolo Yautepec", "San Bernardo Mixtepec", "San Blas Atempa",
    "San Carlos Yautepec", "San Cristóbal Amatlán", "San Cristóbal Amoltepec", "San Cristóbal Lachirioag", "San Cristóbal Suchixtlahuaca",
    "San Dionisio del Mar", "San Dionisio Ocotepec", "San Dionisio Ocotlán", "San Esteban Atatlahuca", "San Felipe Jalapa de Díaz",
    "San Felipe Tejalápam", "San Felipe Usila", "San Francisco Cahuacuá", "San Francisco Cajonos", "San Francisco Chapulapa",
    "San Francisco Chindúa", "San Francisco del Mar", "San Francisco Huehuetlán", "San Francisco Ixhuatán", "San Francisco Jaltepetongo",
    "San Francisco Lachigoló", "San Francisco Logueche", "San Francisco Nuxaño", "San Francisco Ozolotepec", "San Francisco Sola",
    "San Francisco Telixtlahuaca", "San Francisco Teopan", "San Francisco Tlapancingo", "San Gabriel Mixtepec", "San Ildefonso Amatlán",
    "San Ildefonso Sola", "San Ildefonso Villa Alta", "San Jacinto Amilpas", "San Jacinto Tlacotepec", "San Jerónimo Coatlán",
    "San Jerónimo Silacayoapilla", "San Jerónimo Sosola", "San Jerónimo Taviche", "San Jerónimo Tecóatl", "San Jorge Nuchita",
    "San José Ayuquila", "San José Chiltepec", "San José del Peñasco", "San José Estancia Grande", "San José Independencia",
    "San José Lachiguiri", "San José Tenango", "San Juan Achiutla", "San Juan Atepec", "Ánimas Trujano", "San Juan Bautista Atatlahuca",
    "San Juan Bautista Coixtlahuaca", "San Juan Bautista Cuicatlán", "San Juan Bautista Guelache", "San Juan Bautista Jayacatlán",
    "San Juan Bautista Lo de Soto", "San Juan Bautista Suchitepec", "San Juan Bautista Tlacoatzintepec", "San Juan Bautista Tlachichilco",
    "San Juan Bautista Tuxtepec", "San Juan Cacahuatepec", "San Juan Cieneguilla", "San Juan Coatzóspam", "San Juan Colorado",
    "San Juan Comaltepec", "San Juan Cotzocón", "San Juan Chicomezúchil", "San Juan Chilateca", "San Juan del Estado", "San Juan del Río",
    "San Juan Diuxi", "San Juan Evangelista Analco", "San Juan Guelavía", "San Juan Guichicovi", "San Juan Ihualtepec",
    "San Juan Juquila Mixes", "San Juan Juquila Vijanos", "San Juan Lachao", "San Juan Lachigalla", "San Juan Lajarcia",
    "San Juan Lalana", "San Juan de los Cués", "San Juan Mazatlán", "San Juan Mixtepec", "San Juan Mixtepec", "San Juan Ñumí",
    "San Juan Ozolotepec", "San Juan Petlapa", "San Juan Quiahije", "San Juan Quiotepec", "San Juan Sayultepec",
    "San Juan Tabaá", "San Juan Tamazola", "San Juan Teita", "San Juan Teitipac", "San Juan Tepeuxila", "San Juan Teposcolula",
    "San Juan Yaeé", "San Juan Yatzona", "San Juan Yucuita", "San Lorenzo", "San Lorenzo Albarradas", "San Lorenzo Cacaotepec",
    "San Lorenzo Cuaunecuiltitla", "San Lorenzo Texmelúcan", "San Lorenzo Victoria", "San Lucas Camotlán", "San Lucas Ojitlán",
    "San Lucas Quiaviní", "San Lucas Zoquiápam", "San Luis Amatlán", "San Marcial Ozolotepec", "San Marcos Arteaga",
    "San Martín de los Cansecos", "San Martín Huamelúlpam", "San Martín Itunyoso", "San Martín Lachilá", "San Martín Peras",
    "San Martín Tilcajete", "San Martín Toxpalan", "San Martín Zacatepec", "San Mateo Cajonos", "Capulálpam de Méndez",
    "San Mateo del Mar", "San Mateo Yoloxochitlán", "San Mateo Etlatongo", "San Mateo Nejápam", "San Mateo Peñasco",
    "San Mateo Piñas", "San Mateo Río Hondo", "San Mateo Sindihui", "San Mateo Tlapiltepec", "San Melchor Betaza",
    "San Miguel Achiutla", "San Miguel Ahuehuetitlán", "San Miguel Aloápam", "San Miguel Amatitlán", "San Miguel Amatlán",
    "San Miguel Coatlán", "San Miguel Chicahua", "San Miguel Chimalapa", "San Miguel del Puerto", "San Miguel del Río",
    "San Miguel Ejutla", "San Miguel el Grande", "San Miguel Huautla", "San Miguel Mixtepec", "San Miguel Panixtlahuaca",
    "San Miguel Peras", "San Miguel Piedras", "San Miguel Quetzaltepec", "San Miguel Santa Flor", "Villa Sola de Vega",
    "San Miguel Soyaltepec", "San Miguel Suchixtepec", "Villa Talea de Castro", "San Miguel Tecomatlán", "San Miguel Tenango",
    "San Miguel Tequixtepec", "San Miguel Tilquiápam", "San Miguel Tlacamama", "San Miguel Tlacotepec", "San Miguel Tulancingo",
    "San Miguel Yotao", "San Nicolás", "San Nicolás Hidalgo", "San Pablo Coatlán", "San Pablo Cuatro Venados",
    "San Pablo Etla", "San Pablo Huitzo", "San Pablo Huixtepec", "San Pablo Macuiltianguis", "San Pablo Tijaltepec",
    "San Pablo Villa de Mitla", "San Pablo Yaganiza", "San Pedro Amuzgos", "San Pedro Apóstol", "San Pedro Atoyac",
    "San Pedro Cajonos", "San Pedro Coxcaltepec Cántaros", "San Pedro Comitancillo", "San Pedro el Alto", "San Pedro Huamelula",
    "San Pedro Huilotepec", "San Pedro Ixcatlán", "San Pedro Ixtlahuaca", "San Pedro Jaltepetongo", "San Pedro Jicayán",
    "San Pedro Jocotipac", "San Pedro Juchatengo", "San Pedro Mártir", "San Pedro Mártir Quiechapa", "San Pedro Mártir Yucuxaco",
    "San Pedro Mixtepec", "San Pedro Mixtepec", "San Pedro Molinos", "San Pedro Nopala", "San Pedro Ocopetatillo",
    "San Pedro Ocotepec", "San Pedro Pochutla", "San Pedro Quiatoni", "San Pedro Sochiápam", "San Pedro Tapanatepec",
    "San Pedro Taviche", "San Pedro Teozacoalco", "San Pedro Teutila", "San Pedro Tidaá", "San Pedro Topiltepec",
    "San Pedro Totolápam", "Villa de Tututepec de Melchor Ocampo", "San Pedro Yaneri", "San Pedro Yólox", "San Pedro y San Pablo Ayutla",
    "Villa de Etla", "San Pedro y San Pablo Teposcolula", "San Pedro y San Pablo Tequixtepec", "San Pedro Yucunama", "San Raymundo Jalpan",
    "San Sebastián Abasolo", "San Sebastián Coatlán", "San Sebastián Ixcapa", "San Sebastián Nicananduta", "San Sebastián Río Hondo",
    "San Sebastián Tecomaxtlahuaca", "San Sebastián Teitipac", "San Sebastián Tutla", "San Simón Almolongas", "San Simón Zahuatlán",
    "Santa Ana", "Santa Ana Ateixtlahuaca", "Santa Ana Cuauhtémoc", "Santa Ana del Valle", "Santa Ana Tavela", "Santa Ana Tlapacoyan",
    "Santa Ana Yareni", "Santa Ana Zegache", "Santa Catalina Quierí", "Santa Catarina Cuixtla", "Santa Catarina Ixtepeji",
    "Santa Catarina Juquila", "Santa Catarina Lachatao", "Santa Catarina Loxicha", "Santa Catarina Mechoacán",
    "Santa Catarina Minas", "Santa Catarina Quiané", "Santa Catarina Tayata", "Santa Catarina Ticuá", "Santa Catarina Yosonotú",
    "Santa Catarina Zapoquila", "Santa Cruz Acatepec", "Santa Cruz Amilpas", "Santa Cruz de Bravo", "Santa Cruz Itundujia",
    "Santa Cruz Mixtepec", "Santa Cruz Nundaco", "Santa Cruz Papalutla", "Santa Cruz Tacache de Mina", "Santa Cruz Tacahua",
    "Santa Cruz Tayata", "Santa Cruz Xitla", "Santa Cruz Xoxocotlán", "Santa Cruz Zenzontepec", "Santa Gertrudis", "Santa Inés del Monte",
    "Santa Inés Yatzeche", "Santa Lucía del Camino", "Santa Lucía Miahuatlán", "Santa Lucía Monteverde", "Santa Lucía Ocotlán",
    "Santa María Alotepec", "Santa María Apazco", "Santa María la Asunción", "Heroica Ciudad de Tlaxiaco", "Ayoquezco de Aldama",
    "Santa María Atzompa", "Santa María Camotlán", "Santa María Colotepec", "Santa María Cortijo", "Santa María Coyotepec",
    "Santa María Chachoápam", "Villa de Chilapa de Díaz", "Santa María Chilchotla", "Santa María Chimalapa",
    "Santa María del Rosario", "Santa María del Tule", "Santa María Ecatepec", "Santa María Guelacé", "Santa María Guienagati",
    "Santa María Huatulco", "Santa María Huazolotitlán", "Santa María Ipalapa", "Santa María Ixcatlán", "Santa María Jacatepec",
    "Santa María Jalapa del Marqués", "Santa María Jaltianguis", "Santa María Lachixío", "Santa María Mixtequilla",
    "Santa María Nativitas", "Santa María Nduayaco", "Santa María Ozolotepec", "Santa María Pápalo", "Santa María Peñoles",
    "Santa María Petapa", "Santa María Quiegolani", "Santa María Sola", "Santa María Tataltepec", "Santa María Tecomavaca",
    "Santa María Temaxcalapa", "Santa María Temaxcaltepec", "Santa María Teopoxco", "Santa María Tepantlali", "Santa María Texcatitlán",
    "Santa María Tlahuitoltepec", "Santa María Tlalixtac", "Santa María Tonameca", "Santa María Totolapilla", "Santa María Xadani",
    "Santa María Yalina", "Santa María Yavesía", "Santa María Yolotepec", "Santa María Yosoyúa", "Santa María Yucuhiti",
    "Santa María Zacatepec", "Santa María Zaniza", "Santa María Zoquitlán", "Santiago Amoltepec", "Santiago Apoala",
    "Villa de Santiago Apostol", "Santiago Astata", "Santiago Atitlán", "Santiago Ayuquililla", "Santiago Cacaloxtepec",
    "Santiago Camotlán", "Santiago Comaltepec", "Santiago Chazumba", "Santiago Choápam", "Santiago del Río", "Santiago Huajolotitlán",
    "Santiago Huauclilla", "Santiago Ihuitlán Plumas", "Santiago Ixcuintepec", "Santiago Ixtayutla", "Santiago Jamiltepec",
    "Santiago Jocotepec", "Santiago Juxtlahuaca", "Santiago Lachiguiri", "Santiago Lalopa", "Santiago Laollaga",
    "Santiago Laxopa", "Santiago Llano Grande", "Santiago Matatlán", "Santiago Miltepec", "Santiago Minas",
    "Santiago Nacaltepec", "Santiago Nejapilla", "Santiago Nundiche", "Santiago Nuyoó", "Santiago Pinotepa Nacional",
    "Santiago Suchilquitongo", "Santiago Tamazola", "Santiago Tapextla", "Villa Tejúpam de la Unión", "Santiago Tenango",
    "Santiago Tepetlapa", "Santiago Tetepec", "Santiago Texcalcingo", "Santiago Textitlán", "Santiago Tilantongo",
    "Santiago Tillo", "Santiago Tlazoyaltepec", "Santiago Xanica", "Santiago Xiacuí", "Santiago Yaitepec", "Santiago Yaveo",
    "Santiago Yolomécatl", "Santiago Yosondúa", "Santiago Yucuyachi", "Santiago Zacatepec", "Santiago Zoochila",
    "Nuevo Zoquiápam", "Santo Domingo Ingenio", "Santo Domingo Albarradas", "Santo Domingo Armenta", "Santo Domingo Chihuitán",
    "Santo Domingo de Morelos", "Santo Domingo Ixcatlán", "Santo Domingo Nuxaá", "Santo Domingo Ozolotepec", "Santo Domingo Petapa",
    "Santo Domingo Roayaga", "Santo Domingo Tehuantepec", "Santo Domingo Teojomulco", "Santo Domingo Tepuxtepec",
    "Santo Domingo Tlatayápam", "Santo Domingo Tomaltepec", "Santo Domingo Tonalá", "Santo Domingo Tonaltepec",
    "Santo Domingo Xagacía", "Santo Domingo Yanhuitlán", "Santo Domingo Yodohino", "Santo Domingo Zanatepec",
    "Santos Reyes Nopala", "Santos Reyes Pápalo", "Santos Reyes Tepejillo", "Santos Reyes Yucuná", "Santo Tomás Jalieza",
    "Santo Tomás Mazaltepec", "Santo Tomás Ocotepec", "Santo Tomás Tamazulapan", "San Vicente Coatlán", "San Vicente Lachixío",
    "San Vicente Nuñú", "Silacayoápam", "Sitio de Xitlapehua", "Soledad Etla", "Villa de Tamazulápam del Progreso",
    "Tanetze de Zaragoza", "Taniche", "Tataltepec de Valdés", "Teococuilco de Marcos Pérez", "Teotitlán de Flores Magón",
    "Teotitlán del Valle", "Teotongo", "Tepelmeme Villa de Morelos", "Heroica Villa Tezoatlán de Segura y Luna, Cuna de la Independencia de Oaxaca",
    "San Jerónimo Tlacochahuaya", "Tlacolula de Matamoros", "Tlacotepec Plumas", "Tlalixtac de Cabrera", "Totontepec Villa de Morelos",
    "Trinidad Zaachila", "La Trinidad Vista Hermosa", "Unión Hidalgo", "Valerio Trujano", "San Juan Bautista Valle Nacional",
    "Villa Díaz Ordaz", "Yaxe", "Magdalena Yodocono de Porfirio Díaz", "Yogana", "Yutanduchi de Guerrero", "Villa de Zaachila",
    "San Mateo Yucutindoo", "Zapotitlán Lagunas", "Zapotitlán Palmas", "Santa Inés de Zaragoza", "Zimatlán de Álvarez"
});

            municipiosPorEstado.Add("Puebla", new List<string> {
    "Acajete", "Acateno", "Acatlán", "Acatzingo", "Acteopan", "Ahuacatlán", "Ahuatlán", "Ahuazotepec", "Ahuehuetitla",
    "Ajalpan", "Albino Zertuche", "Aljojuca", "Altepexi", "Amixtlán", "Amozoc", "Aquixtla", "Atempan", "Atexcal",
    "Atlixco", "Atoyatempan", "Atzala", "Atzitzihuacán", "Atzitzintla", "Axutla", "Ayotoxco de Guerrero", "Calpan",
    "Caltepec", "Camocuautla", "Caxhuacan", "Coatepec", "Coatzingo", "Cohetzala", "Cohuecan", "Coronango", "Coxcatlán",
    "Coyomeapan", "Coyotepec", "Cuapiaxtla de Madero", "Cuautempan", "Cuautinchán", "Cuautlancingo", "Cuayuca de Andrade",
    "Cuetzalan del Progreso", "Cuyoaco", "Chalchicomula de Sesma", "Chapulco", "Chiautla", "Chiautzingo", "Chiconcuautla",
    "Chichiquila", "Chietla", "Chigmecatitlán", "Chignahuapan", "Chignautla", "Chila", "Chila de la Sal", "Honey",
    "Chilchotla", "Chinantla", "Domingo Arenas", "Eloxochitlán", "Epatlán", "Esperanza", "Francisco Z. Mena", "General Felipe Ángeles",
    "Guadalupe", "Guadalupe Victoria", "Hermenegildo Galeana", "Huaquechula", "Huatlatlauca", "Huauchinango", "Huehuetla",
    "Huehuetlán el Chico", "Huejotzingo", "Hueyapan", "Hueytamalco", "Hueytlalpan", "Huitzilan de Serdán", "Huitziltepec",
    "Atlequizayan", "Ixcamilpa de Guerrero", "Ixcaquixtla", "Ixtacamaxtitlán", "Ixtepec", "Izúcar de Matamoros", "Jalpan",
    "Jolalpan", "Jonotla", "Jopala", "Juan C. Bonilla", "Juan Galindo", "Juan N. Méndez", "Lafragua", "Libres", "La Magdalena Tlatlauquitepec",
    "Mazapiltepec de Juárez", "Mixtla", "Molcaxac", "Cañada Morelos", "Naupan", "Nauzontla", "Nealtican", "Nicolás Bravo",
    "Nopalucan", "Ocotepec", "Ocoyucan", "Olintla", "Oriental", "Pahuatlán", "Palmar de Bravo", "Pantepec", "Petlalcingo",
    "Piaxtla", "Puebla", "Quecholac", "Quimixtlán", "Rafael Lara Grajales", "Los Reyes de Juárez", "San Andrés Cholula",
    "San Antonio Cañada", "San Diego la Mesa Tochimiltzingo", "San Felipe Teotlalcingo", "San Felipe Tepatlán", "San Gabriel Chilac",
    "San Gregorio Atzompa", "San Jerónimo Tecuanipan", "San Jerónimo Xayacatlán", "San José Chiapa", "San José Miahuatlán",
    "San Juan Atenco", "San Juan Atzompa", "San Martín Texmelucan", "San Martín Totoltepec", "San Matías Tlalancaleca",
    "San Miguel Ixitlán", "San Miguel Xoxtla", "San Nicolás Buenos Aires", "San Nicolás de los Ranchos", "San Pablo Anicano",
    "San Pedro Cholula", "San Pedro Yeloixtlahuaca", "San Salvador el Seco", "San Salvador el Verde", "San Salvador Huixcolotla",
    "San Sebastián Tlacotepec", "Santa Catarina Tlaltempan", "Santa Inés Ahuatempan", "Santa Isabel Cholula",
    "Santiago Miahuatlán", "Huehuetlán el Grande", "Santo Tomás Hueyotlipan", "Soltepec", "Tecali de Herrera",
    "Tecamachalco", "Tecomatlán", "Tehuacán", "Tehuitzingo", "Tenampulco", "Teopantlán", "Teotlalco", "Tepanco de López",
    "Tepango de Rodríguez", "Tepatlaxco de Hidalgo", "Tepeaca", "Tepemaxalco", "Tepeojuma", "Tepetzintla", "Tepexco",
    "Tepexi de Rodríguez", "Tepeyahualco", "Tepeyahualco de Cuauhtémoc", "Tetela de Ocampo", "Teteles de Avila Castillo",
    "Teziutlán", "Tianguismanalco", "Tilapa", "Tlacotepec de Benito Juárez", "Tlacuilotepec", "Tlachichuca",
    "Tlahuapan", "Tlaltenango", "Tlanepantla", "Tlaola", "Tlapacoya", "Tlapanalá", "Tlatlauquitepec",
    "Tlaxco", "Tochimilco", "Tochtepec", "Totoltepec de Guerrero", "Tulcingo", "Tuzamapan de Galeana",
    "Tzicatlacoyan", "Venustiano Carranza", "Vicente Guerrero", "Xayacatlán de Bravo", "Xicotepec", "Xicotlán",
    "Xiutetelco", "Xochiapulco", "Xochiltepec", "Xochitlán de Vicente Suárez", "Xochitlán Todos Santos",
    "Yaonáhuac", "Yehualtepec", "Zacapala", "Zacapoaxtla", "Zacatlán", "Zapotitlán", "Zapotitlán de Méndez",
    "Zaragoza", "Zautla", "Zihuateutla", "Zinacatepec", "Zongozotla", "Zoquiapan", "Zoquitlán"
});

            municipiosPorEstado.Add("Queretaro", new List<string> {
    "Amealco de Bonfil", "Pinal de Amoles", "Arroyo Seco", "Cadereyta de Montes", "Colon", "Corregidora", "Ezequiel Montes",
    "Huimilpan", "Jalpan de Serra", "Landa de Matamoros", "El Marqués", "Pedro Escobedo", "Peñamiller", "Querétaro",
    "San Joaquín", "San Juan del Río", "Tequisquiapan", "Tolimán"
});

            municipiosPorEstado.Add("Quintana Roo", new List<string> {
    "Cozumel", "Felipe Carrillo Puerto", "Isla Mujeres", "Othón P. Blanco", "Benito Juárez", "José María Morelos",
    "Lázaro Cárdenas", "Solidaridad", "Tulum", "Bacalar"
});

            municipiosPorEstado.Add("San Luis Potosi", new List<string> {
    "Ahualulco", "Alaquines", "Aquismón", "Armadillo de los Infante", "Cárdenas", "Catorce", "Cedral", "Cerritos",
    "Cerro de San Pedro", "Ciudad del Maíz", "Ciudad Fernández", "Tancanhuitz", "Ciudad Valles", "Coxcatlán",
    "Charcas", "Ebano", "Guadalcázar", "Huehuetlán", "Lagunillas", "Matehuala", "Mexquitic de Carmona", "Moctezuma",
    "Rayón", "Rioverde", "Salinas", "San Antonio", "San Ciro de Acosta", "San Luis Potosí", "San Martín Chalchicuautla",
    "San Nicolás Tolentino", "Santa Catarina", "Santa María del Río", "Santo Domingo", "San Vicente Tancuayalab",
    "Soledad de Graciano Sánchez", "Tamasopo", "Tamazunchale", "Tampacán", "Tampamolón Corona", "Tamuín",
    "Tanlajás", "Tanquián de Escobedo", "Tierra Nueva", "Vanegas", "Venado", "Villa de Arista", "Villa de Arriaga",
    "Villa de Guadalupe", "Villa de la Paz", "Villa de Ramos", "Villa de Reyes", "Villa Hidalgo", "Villa Juárez",
    "Axtla de Terrazas", "Xilitla", "Zaragoza", "Villa de la Paz", "Villa de Ramos", "Villa de Reyes", "Villa Hidalgo",
    "Villa Juárez", "Axtla de Terrazas", "Xilitla", "Zaragoza"
});

            municipiosPorEstado.Add("Sinaloa", new List<string> {
    "Ahome", "Angostura", "Badiraguato", "Concordia", "Cosalá", "Culiacán", "Choix", "Elota", "Escuinapa",
    "El Fuerte", "Guasave", "Mazatlán", "Mocorito", "Rosario", "Salvador Alvarado", "San Ignacio", "Sinaloa",
    "Navolato"
});

            municipiosPorEstado.Add("Sonora", new List<string> {
    "Aconchi", "Agua Prieta", "Alamos", "Altar", "Arivechi", "Arizpe", "Atil", "Bacadéhuachi", "Bacanora",
    "Bacerac", "Bacoachi", "Bácum", "Banámichi", "Baviácora", "Bavispe", "Benjamín Hill", "Caborca", "Cajeme",
    "Cananea", "Carbó", "La Colorada", "Cucurpe", "Cumpas", "Divisaderos", "Empalme", "Etchojoa", "Fronteras",
    "Granados", "Guaymas", "Hermosillo", "Huachinera", "Huásabas", "Huatabampo", "Huépac", "Imuris", "Magdalena",
    "Mazatán", "Moctezuma", "Naco", "Nácori Chico", "Nacozari de García", "Navojoa", "Nogales", "Onavas", "Opodepe",
    "Oquitoa", "Pitiquito", "Puerto Peñasco", "Quiriego", "Rayón", "Rosario", "Sahuaripa", "San Felipe de Jesús",
    "San Ignacio Río Muerto", "San Javier", "San Luis Río Colorado", "San Miguel de Horcasitas", "San Pedro de la Cueva",
    "Santa Ana", "Santa Cruz", "Sáric", "Soyopa", "Suaqui Grande", "Tepache", "Trincheras", "Tubutama", "Ures",
    "Villa Hidalgo", "Villa Pesqueira", "Yécora", "General Plutarco Elías Calles", "Benito Juárez", "San Javier"
});

            municipiosPorEstado.Add("Tabasco", new List<string> {
    "Balancán", "Cárdenas", "Centla", "Centro", "Comalcalco", "Cunduacán", "Emiliano Zapata", "Huimanguillo",
    "Jalapa", "Jalpa de Méndez", "Jonuta", "Macuspana", "Nacajuca", "Paraíso", "Tacotalpa", "Teapa",
    "Tenosique", "Balancán"
});

            municipiosPorEstado.Add("Tamaulipas", new List<string> {
    "Abasolo", "Aldama", "Altamira", "Antiguo Morelos", "Burgos", "Bustamante", "Camargo", "Casas", "Ciudad Madero",
    "Cruillas", "Gómez Farías", "González", "Güémez", "Guerrero", "Gustavo Díaz Ordaz", "Hidalgo", "Jaumave",
    "Jiménez", "Llera", "Mainero", "El Mante", "Matamoros", "Méndez", "Mier", "Miguel Alemán", "Miquihuana",
    "Nuevo Laredo", "Nuevo Morelos", "Ocampo", "Padilla", "Palmillas", "Reynosa", "Río Bravo", "San Carlos",
    "San Fernando", "San Nicolás", "Soto la Marina", "Tampico", "Tula", "Valle Hermoso", "Victoria", "Villagrán",
    "Xicoténcatl", "Victoria"
});

            municipiosPorEstado.Add("Tlaxcala", new List<string> {
    "Amaxac de Guerrero", "Apetatitlán de Antonio Carvajal", "Atlangatepec", "Altzayanca", "Apizaco", "Calpulalpan",
    "El Carmen Tequexquitla", "Cuapiaxtla", "Cuaxomulco", "Chiautempan", "Muñoz de Domingo Arenas", "Españita",
    "Huamantla", "Hueyotlipan", "Ixtacuixtla de Mariano Matamoros", "Ixtenco", "Mazatecochco de José María Morelos",
    "Contla de Juan Cuamatzi", "Tepetitla de Lardizábal", "Sanctórum de Lázaro Cárdenas", "Nanacamilpa de Mariano Arista",
    "Acuamanala de Miguel Hidalgo", "Natívitas", "Panotla", "San Pablo del Monte", "Santa Cruz Tlaxcala",
    "Tenancingo", "Teolocholco", "Tepeyanco", "Terrenate", "Tetla de la Solidaridad", "Tetlatlahuca", "Tlaxcala",
    "Tlaxco", "Tocatlán", "Totolac", "Ziltlaltépec de Trinidad Sánchez Santos", "Tzompantepec", "Xaloztoc",
    "Xaltocan", "Papalotla de Xicohténcatl", "Xicohtzinco", "Yauhquemecan", "Zacatelco", "Benito Juárez", "Emiliano Zapata",
    "Lázaro Cárdenas", "La Magdalena Tlaltelulco", "San Damián Texóloc", "San Francisco Tetlanohcan",
    "San Jerónimo Zacualpan", "San José Teacalco", "San Juan Huactzinco", "San Lorenzo Axocomanitla",
    "San Lucas Tecopilco", "Santa Ana Nopalucan", "Santa Apolonia Teacalco", "Santa Catarina Ayometla",
    "Santa Cruz Quilehtla", "Santa Isabel Xiloxoxtla", "Atempan", "Atoyatempan", "Atlixco", "Atzitzihuacán",
    "Axutla", "Ayotoxco de Guerrero", "Calpan", "Caltepec", "Camocuautla", "Caxhuacan", "Coatepec", "Coatzingo",
    "Cohetzala", "Cohuecan", "Coronango", "Coxcatlán", "Coyomeapan", "Coyotepec", "Cuapiaxtla de Madero",
    "Cuautempan", "Cuautinchán", "Cuautlancingo", "Cuayuca de Andrade", "Cuetzalan del Progreso", "Cuyoaco",
    "Chalchicomula de Sesma", "Chapulco", "Chiautla", "Chiautzingo", "Chiconcuautla", "Chichiquila", "Chietla",
    "Chigmecatitlán", "Chignahuapan", "Chignautla", "Chila", "Chila de la Sal", "Honey", "Chilchotla", "Chinantla",
    "Domingo Arenas", "Eloxochitlán", "Epatlán", "Esperanza", "Francisco Z. Mena", "General Felipe Ángeles", "Guadalupe",
    "Guadalupe Victoria", "Hermenegildo Galeana", "Huaquechula", "Huatlatlauca", "Huauchinango", "Huehuetla",
    "Huehuetlán el Chico", "Huejotzingo", "Hueyapan", "Hueytamalco", "Hueytlalpan", "Huitzilan de Serdán", "Huitziltepec",
    "Atlequizayan", "Ixcamilpa de Guerrero", "Ixcaquixtla", "Ixtacamaxtitlán", "Ixtepec", "Izúcar de Matamoros", "Jalpan",
    "Jolalpan", "Jonotla", "Jopala", "Juan C. Bonilla", "Juan Galindo", "Juan N. Méndez", "Lafragua", "Libres",
    "La Magdalena Tlatlauquitepec", "Mazapiltepec de Juárez", "Mixtla", "Molcaxac", "Cañada Morelos", "Naupan", "Nauzontla",
    "Nealtican", "Nicolás Bravo", "Nopalucan", "Ocotepec", "Ocoyucan", "Olintla", "Oriental", "Pahuatlán",
    "Palmar de Bravo", "Pantepec", "Petlalcingo", "Piaxtla", "Puebla", "Quecholac", "Quimixtlán", "Rafael Lara Grajales",
    "Los Reyes de Juárez", "San Andrés Cholula", "San Antonio Cañada", "San Diego la Mesa Tochimiltzingo", "San Felipe Teotlalcingo",
    "San Felipe Tepatlán", "San Gabriel Chilac", "San Gregorio Atzompa", "San Jerónimo Tecuanipan", "San Jerónimo Xayacatlán",
    "San José Chiapa", "San José Miahuatlán", "San Juan Atenco", "San Juan Atzompa", "San Martín Texmelucan", "San Martín Totoltepec",
    "San Matías Tlalancaleca", "San Miguel Ixitlán", "San Miguel Xoxtla", "San Nicolás Buenos Aires", "San Nicolás de los Ranchos",
    "San Pablo Anicano", "San Pedro Cholula", "San Pedro Yeloixtlahuaca", "San Salvador el Seco", "San Salvador el Verde",
    "San Salvador Huixcolotla", "San Sebastián Tlacotepec", "Santa Catarina Tlaltempan", "Santa Inés Ahuatempan",
    "Santa Isabel Cholula", "Santiago Miahuatlán", "Huehuetlán el Grande", "Santo Tomás Hueyotlipan", "Soltepec",
    "Tecali de Herrera", "Tecamachalco", "Tecomatlán", "Tehuacán", "Tehuitzingo", "Tenampulco", "Teopantlán",
    "Teotlalco", "Tepanco de López", "Tepango de Rodríguez", "Tepatlaxco de Hidalgo", "Tepeaca", "Tepemaxalco",
    "Tepeojuma", "Tepetzintla", "Tepexco", "Tepexi de Rodríguez", "Tepeyahualco", "Tepeyahualco de Cuauhtémoc",
    "Tetela de Ocampo", "Teteles de Avila Castillo", "Teziutlán", "Tianguismanalco", "Tilapa", "Tlacotepec de Benito Juárez",
    "Tlacuilotepec", "Tlachichuca", "Tlahuapan", "Tlaltenango", "Tlanepantla", "Tlaola", "Tlapacoya", "Tlapanalá",
    "Tlatlauquitepec", "Tlaxco", "Tochimilco", "Tochtepec", "Totoltepec de Guerrero", "Tulcingo", "Tuzamapan de Galeana",
    "Tzicatlacoyan", "Venustiano Carranza", "Vicente Guerrero", "Xayacatlán de Bravo", "Xicotepec", "Xicotlán", "Xiutetelco",
    "Xochiapulco", "Xochiltepec", "Xochitlán de Vicente Suárez", "Xochitlán Todos Santos", "Yaonáhuac", "Yehualtepec",
    "Zacapala", "Zacapoaxtla", "Zacatlán", "Zapotitlán", "Zapotitlán de Méndez", "Zaragoza", "Zautla", "Zihuateutla",
    "Zinacatepec", "Zongozotla", "Zoquiapan", "Zoquitlán"
});

            municipiosPorEstado.Add("Veracruz", new List<string> {
    "Acajete", "Acatlán", "Acayucan", "Actopan", "Acula", "Acultzingo", "Camarón de Tejeda", "Alpatláhuac",
    "Alto Lucero de Gutiérrez Barrios", "Altotonga", "Alvarado", "Amatitlán", "Naranjos Amatlán", "Amatlán de los Reyes",
    "Angel R. Cabada", "La Antigua", "Apazapan", "Aquila", "Astacinga", "Atlahuilco", "Atoyac", "Atzacan",
    "Atzalan", "Tlaltetela", "Ayahualulco", "Banderilla", "Benito Juárez", "Boca del Río", "Calcahualco", "Camerino Z. Mendoza",
    "Carrillo Puerto", "Catemaco", "Cazones de Herrera", "Cerro Azul", "Citlaltépetl", "Coacoatzintla", "Coahuitlán",
    "Coatepec", "Coatzacoalcos", "Coatzintla", "Coetzala", "Colipa", "Comapa", "Córdoba", "Cosamaloapan de Carpio",
    "Cosautlán de Carvajal", "Coscomatepec", "Cosoleacaque", "Cotaxtla", "Coxquihui", "Coyutla", "Cuichapa",
    "Cuitláhuac", "Chacaltianguis", "Chalma", "Chiconamel", "Chiconquiaco", "Chicontepec", "Chinameca",
    "Chinampa de Gorostiza", "Las Choapas", "Chocamán", "Chontla", "Chumatlán", "Emiliano Zapata", "Espinal",
    "Filomeno Mata", "Fortín", "Gutiérrez Zamora", "Hidalgotitlán", "Huatusco", "Huayacocotla", "Hueyapan de Ocampo",
    "Huiloapan de Cuauhtémoc", "Ignacio de la Llave", "Ilamatlán", "Isla", "Ixcatepec", "Ixhuacán de los Reyes",
    "Ixhuatlán del Café", "Ixhuatlán del Sureste", "Ixhuatlancillo", "Ixmatlahuacan", "Ixtaczoquitlán",
    "Jalacingo", "Xalapa", "Jalcomulco", "Jáltipan", "Jamapa", "Jesús Carranza", "Xico", "Jilotepec", "Juan Rodríguez Clara",
    "Juchique de Ferrer", "Landero y Coss", "Lerdo de Tejada", "Magdalena", "Maltrata", "Manlio Fabio Altamirano",
    "Mariano Escobedo", "Martínez de la Torre", "Mecatlán", "Mecayapan", "Medellín de Bravo", "Miahuatlán",
    "Las Minas", "Minatitlán", "Misantla", "Mixtla de Altamirano", "Moloacán", "Naolinco", "Naranjal", "Nautla",
    "Nogales", "Oluta", "Omealca", "Orizaba", "Otatitlán", "Oteapan", "Ozuluama de Mascareñas", "Pajapan",
    "Pánuco", "Papantla", "Paso del Macho", "Paso de Ovejas", "La Perla", "Perote", "Platón Sánchez", "Playa Vicente",
    "Poza Rica de Hidalgo", "Las Vigas de Ramírez", "Pueblo Viejo", "Puente Nacional", "Rafael Delgado", "Rafael Lucio",
    "Los Reyes", "Río Blanco", "Saltabarranca", "San Andrés Tenejapan", "San Andrés Tuxtla", "San Juan Evangelista",
    "Santiago Tuxtla", "Sayula de Alemán", "Soconusco", "Sochiapa", "Soledad Atzompa", "Soledad de Doblado",
    "Soteapan", "Tamalín", "Tamiahua", "Tampico Alto", "Tancoco", "Tantima", "Tantoyuca", "Tatatila", "Castillo de Teayo",
    "Tecolutla", "Tehuipango", "Álamo Temapache", "Tempoal", "Tenampa", "Tenochtitlán", "Teocelo", "Tepatlaxco",
    "Tepetlán", "Tepetzintla", "Tequila", "José Azueta", "Texcatepec", "Texhuacán", "Texistepec", "Tezonapa",
    "Tierra Blanca", "Tihuatlán", "Tlacojalpan", "Tlacolulan", "Tlacotalpan", "Tlacotepec de Mejía", "Tlachichilco",
    "Tlalixcoyan", "Tlalnelhuayocan", "Tlapacoyan", "Tlaquilpa", "Tlilapan", "Tomatlán", "Tonayán", "Totutla",
    "Tuxpan", "Tuxtilla", "Ursulo Galván", "Vega de Alatorre", "Veracruz", "Villa Aldama", "Xoxocotla", "Yanga",
    "Yecuatla", "Zacualpan", "Zaragoza", "Zentla", "Zongolica", "Zontecomatlán de López y Fuentes", "Zozocolco de Hidalgo"
});
            municipiosPorEstado.Add("Yucatan", new List<string> {
    "Abalá", "Acanceh", "Akil", "Baca", "Bokobá", "Buctzotz", "Cacalchén", "Calotmul", "Cansahcab", "Cantamayec",
    "Celestún", "Cenotillo", "Conkal", "Cuncunul", "Cuzamá", "Chacsinkín", "Chankom", "Chapab", "Chemax", "Chicxulub Pueblo",
    "Chichimilá", "Chikindzonot", "Chocholá", "Chumayel", "Dzán", "Dzemul", "Dzidzantún", "Dzilam de Bravo", "Dzilam González",
    "Dzitás", "Dzoncauich", "Espita", "Halachó", "Hocabá", "Hoctún", "Homún", "Huhí", "Hunucmá", "Ixil", "Izamal", "Kanasín",
    "Kantunil", "Kaua", "Kinchil", "Kopomá", "Mama", "Maní", "Maxcanú", "Mayapán", "Mérida", "Mocochá", "Motul", "Muna",
    "Muxupip", "Opichén", "Oxkutzcab", "Panabá", "Peto", "Progreso", "Quintana Roo", "Río Lagartos", "Sacalum", "Samahil",
    "Sanahcat", "San Felipe", "Santa Elena", "Seyé", "Sinanché", "Sotuta", "Sucilá", "Sudzal", "Suma", "Tahdziú", "Tahmek",
    "Teabo", "Tecoh", "Tekal de Venegas", "Tekantó", "Tekax", "Tekit", "Tekom", "Telchac Pueblo", "Telchac Puerto",
    "Temax", "Temozón", "Tepakán", "Tetiz", "Teya", "Ticul", "Timucuy", "Tinum", "Tixcacalcupul", "Tixkokob", "Tixmehuac",
    "Tixpéhual", "Tizimín", "Tunkás", "Tzucacab", "Uayma", "Ucú", "Umán", "Valladolid", "Xocchel", "Yaxcabá", "Yaxkukul",
    "Yobaín"
});

            municipiosPorEstado.Add("Zacatecas", new List<string> {
    "Apozol", "Apulco", "Atolinga", "Benito Juárez", "Calera", "Cañitas de Felipe Pescador", "Concepción del Oro",
    "Cuauhtémoc", "Chalchihuites", "Fresnillo", "Trinidad García de la Cadena", "Genaro Codina", "General Enrique Estrada",
    "General Francisco R. Murguía", "El Plateado de Joaquín Amaro", "General Pánfilo Natera", "Guadalupe",
    "Huanusco", "Jalpa", "Jerez", "Jiménez del Teul", "Juan Aldama", "Juchipila", "Loreto", "Luis Moya", "Mazapil",
    "Melchor Ocampo", "Mezquital del Oro", "Miguel Auza", "Momax", "Monte Escobedo", "Morelos", "Moyahua de Estrada",
    "Nochistlán de Mejía", "Noria de Ángeles", "Ojocaliente", "Pánuco", "Pinos", "Río Grande", "Sain Alto",
    "El Salvador", "Sombrerete", "Susticacán", "Tabasco", "Tepechitlán", "Tepetongo", "Teúl de González Ortega",
    "Tlaltenango de Sánchez Román", "Valparaíso", "Vetagrande", "Villa de Cos", "Villa García", "Villa González Ortega",
    "Villa Hidalgo", "Villanueva", "Zacatecas", "Trancoso"
});


            // Agrega los demás estados y sus municipios correspondientes

            // Asigna un evento al ComboBox de estados para actualizar el ComboBox de municipios
            cmbEstadoNac.SelectedIndexChanged += CmbEstadoNac_SelectedIndexChanged;
        }

        // Método para llenar el ComboBox de municipios según el estado seleccionado
        private void LlenarComboBoxMunicipios(string estado)
        {
            // Limpia el ComboBox de municipios
            cmbMunicipio.Items.Clear();

            // Obtiene los municipios correspondientes al estado seleccionado
            if (municipiosPorEstado.ContainsKey(estado))
            {
                List<string> municipios = municipiosPorEstado[estado];
                // Agrega los municipios al ComboBox de municipios
                cmbMunicipio.Items.AddRange(municipios.ToArray());
            }
        }

        // Evento que se activa cuando se selecciona un estado
        private void CmbEstadoNac_SelectedIndexChanged(object sender, EventArgs e)
        {
            string estadoSeleccionado = cmbEstadoNac.SelectedItem.ToString();
            LlenarComboBoxMunicipios(estadoSeleccionado);
        }

    }
}
