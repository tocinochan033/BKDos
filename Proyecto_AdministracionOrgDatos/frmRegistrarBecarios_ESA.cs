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

        public frmRegistrarBecarios_ESA()
        {
            InitializeComponent();
            LlenarComboBoxEscuelas();


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

            //Inicializacion de los estados de la republica
            cmbEstadoNac.Items.Add("Aguascalientes");
            cmbEstadoNac.Items.Add("Baja California");
            cmbEstadoNac.Items.Add("Baja California Sur");
            cmbEstadoNac.Items.Add("Campeche");
            cmbEstadoNac.Items.Add("Coahuila");
            cmbEstadoNac.Items.Add("Colima");
            cmbEstadoNac.Items.Add("Chiapas");
            cmbEstadoNac.Items.Add("Chihuahua");
            cmbEstadoNac.Items.Add("Distrito Federal");
            cmbEstadoNac.Items.Add("Durango");
            cmbEstadoNac.Items.Add("Guanajuato");
            cmbEstadoNac.Items.Add("Guerrero");
            cmbEstadoNac.Items.Add("Hidalgo");
            cmbEstadoNac.Items.Add("Jalisco");
            cmbEstadoNac.Items.Add("Mexico");
            cmbEstadoNac.Items.Add("Michoacan");
            cmbEstadoNac.Items.Add("Morelos");
            cmbEstadoNac.Items.Add("Nayarit");
            cmbEstadoNac.Items.Add("Nuevo Leon");
            cmbEstadoNac.Items.Add("Oaxaca");
            cmbEstadoNac.Items.Add("Puebla");
            cmbEstadoNac.Items.Add("Queretaro");
            cmbEstadoNac.Items.Add("Quintana Roo");
            cmbEstadoNac.Items.Add("San Luis Potosi");
            cmbEstadoNac.Items.Add("Sinaloa");
            cmbEstadoNac.Items.Add("Sonora");
            cmbEstadoNac.Items.Add("Tabasco");
            cmbEstadoNac.Items.Add("Tamaulipas");
            cmbEstadoNac.Items.Add("Tlaxcala ");
            cmbEstadoNac.Items.Add("Veracruz");
            cmbEstadoNac.Items.Add("Yucatan");
            cmbEstadoNac.Items.Add("Zacatecas");
            cmbEstadoNac.Items.Add("Extranjero");

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
               || txtEdad.Text == "" || CBGenero.Text == "" || txtEstadoCivil.Text == "" || txtDomicilio.Text == ""
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
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se admiten letras", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtCarrera_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
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
    }
}
