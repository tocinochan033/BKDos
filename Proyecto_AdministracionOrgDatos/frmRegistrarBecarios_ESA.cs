using Microsoft.Win32;
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
        private FuentePersonalizada fontPers;

        public frmRegistrarBecarios_ESA()
        {
            fontPers = new FuentePersonalizada();

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

        private void btnRegresarMenu_ESA_Click(object sender, EventArgs e)
        {
            //Guarda los datos y regresa a la pantalla anterior
            Guardar();
            this.Hide();
        }

        private bool camposImcompletos()
        {
            return txtApaterno.Text == "" || txtAmaterno.Text == "" || txtNombres.Text == "" || txtFechanac.Text == ""
               || txtEdad.Text == "" || txtCURP.Text == "" || CBGenero.Text == "" || cmbEstadoCivil.Text == "" || txtDomicilio.Text == ""
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
            cmbEstadoCivil.Text = "";
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
            BuscarCamposVacios_AgregarDatos();
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
                dgv_Agregar.Rows[seleccion].Cells[7].Value = cmbEstadoCivil.Text;
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
                cmbEstadoCivil.Text = dgv_Agregar.Rows[seleccion].Cells[7].Value.ToString();
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
            CargarFuentes();
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


        public void CargarFuentes()
        {
            // Cargar las fuente desde el archivo TTF
            string nombreFuente = "coolveticaRG.otf";
            fontPers.CargarFuentePersonalizada(nombreFuente);
            // Aplicar la fuente a la etiqueta en lblTitulo_ESA
            fontPers.AplicarFuente(lblTitulo_ESA, 28, FontStyle.Regular);
        }

        public void BuscarCamposVacios_AgregarDatos()
        {
            if (HayCamposVacios())
            {
                MessageBox.Show("Por favor complete todos los campos.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
                int indiceNuevaFila;

                //Sirve para adicionar un nuevo renglon y guardar el indice de este mismo
                indiceNuevaFila = dgv_Agregar.Rows.Add();

                //Colocamos la informacion en el DataGridView
                dgv_Agregar.Rows[indiceNuevaFila].Cells[0].Value = txtApaterno.Text.ToUpper();
                dgv_Agregar.Rows[indiceNuevaFila].Cells[1].Value = txtAmaterno.Text.ToUpper();
                dgv_Agregar.Rows[indiceNuevaFila].Cells[2].Value = txtNombres.Text.ToUpper();
                dgv_Agregar.Rows[indiceNuevaFila].Cells[3].Value = txtFechanac.Text.ToUpper();
                dgv_Agregar.Rows[indiceNuevaFila].Cells[4].Value = txtEdad.Text.ToUpper();
                dgv_Agregar.Rows[indiceNuevaFila].Cells[5].Value = txtCURP.Text.ToUpper();
                dgv_Agregar.Rows[indiceNuevaFila].Cells[6].Value = CBGenero.Text.ToUpper();
                dgv_Agregar.Rows[indiceNuevaFila].Cells[7].Value = cmbEstadoCivil.Text.ToUpper();
                dgv_Agregar.Rows[indiceNuevaFila].Cells[8].Value = txtDomicilio.Text.ToUpper();
                dgv_Agregar.Rows[indiceNuevaFila].Cells[9].Value = txtCodigoPostal.Text.ToUpper();
                dgv_Agregar.Rows[indiceNuevaFila].Cells[10].Value = txtNacionalidad.Text.ToUpper();
                dgv_Agregar.Rows[indiceNuevaFila].Cells[11].Value = txtEstadoNac.Text.ToUpper();
                dgv_Agregar.Rows[indiceNuevaFila].Cells[12].Value = txtMunicipio.Text.ToUpper();
                dgv_Agregar.Rows[indiceNuevaFila].Cells[13].Value = txtCorreoElectronico.Text.ToLower();
                dgv_Agregar.Rows[indiceNuevaFila].Cells[14].Value = txtTelefono.Text.ToUpper();
                dgv_Agregar.Rows[indiceNuevaFila].Cells[15].Value = txtCarrera.Text.ToUpper();
                dgv_Agregar.Rows[indiceNuevaFila].Cells[16].Value = txtPeriodo.Text.ToUpper();
                dgv_Agregar.Rows[indiceNuevaFila].Cells[17].Value = txtPromedio.Text.ToUpper();
                dgv_Agregar.Rows[indiceNuevaFila].Cells[18].Value = cmbCCT.Text.ToUpper();
                dgv_Agregar.Rows[indiceNuevaFila].Cells[19].Value = txtModelo.Text.ToUpper();

                camposLimpieza();

                //Regresar el "cursor" al textbox del nombre
                txtApaterno.Focus();
            }
        }

        // Método para verificar si hay campos vacíos en un TabControl
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
            return false; //Regresa falso si ningun campo esta vacio
        }







        private void dgv_Agregar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void txtModelo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void txtEdad_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtFechanac_ValueChanged(object sender, EventArgs e)
        {

        }
        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
