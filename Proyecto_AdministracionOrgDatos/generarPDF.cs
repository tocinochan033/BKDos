using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
//Se agrega libreria dataclient
//Espacio de nombres requerido para interactuar con SQL SERVER
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_AdministracionOrgDatos
{
    public partial class generarPDF : Form
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
        private FuentePersonalizada fontPers;
        public generarPDF()
        {
            InitializeComponent();
            cargaData();
            fontPers = new FuentePersonalizada();
        }

        private void generarPDF_Load(object sender, EventArgs e)
        {

        }
        
        static bool validarFiltro = false;
        static int tipoReporte = 0;

        private void btnImprimirPDF_Click(object sender, EventArgs e)
        {
            if (cmbPDFeleccion.Text == "")
            {
                MessageBox.Show("Favor de seleccionar alguna opcion valida", "Datos incompatibles", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbPDFeleccion.Focus();
            }
            else
            {
                //Asignacion de tipo de reporte a utilizar
                if (cmbPDFeleccion.Text == "Informacion Personal") { tipoReporte = 1; }
                else if (cmbPDFeleccion.Text == "Informacion de Contacto") { tipoReporte = 2; }
                else if (cmbPDFeleccion.Text == "Informacion Academica") { tipoReporte = 3; }

                //Empleo de clase para guardar el archivo mediante ubicacion
                SaveFileDialog guardar = new SaveFileDialog();

                //Se especifica el tipo de archivo al abri el explorador de archivos
                guardar.Filter = "PDF Files(*.pdf)|*.pdf";

                //Despliega el explorador de archivos para guardar el archivo, de nombre toma la fecha actual
                guardar.FileName = DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";

                //Se evalua que en el explorador de archivos, se presione guardar para
                //iniciar con la configuracion de guardado del PDF
                if (guardar.ShowDialog() == DialogResult.OK)
                {
                    //Creacion del documento para leer o escribir
                    using (FileStream stream = new FileStream(guardar.FileName, FileMode.Create))
                    {
                        //Creacion del documento PDF especificando tipo de hoja y margenes
                        Document pdfDoc = new Document(PageSize.A4.Rotate(), 10, 10, 10, 10);

                        //Guardado de los cambios del PDF al documento
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);

                        pdfDoc.Open();
                        pdfDoc.Add(new Phrase(""));

                        //Almacenar la imagen del logo en la variable img
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.Ajolote, System.Drawing.Imaging.ImageFormat.Png);
                        img.ScaleToFit(80, 60); //Tamaño
                        img.Alignment = iTextSharp.text.Image.UNDERLYING; //Alineacion en el documento
                        img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 60); //Posicion
                        pdfDoc.Add(img);//Agregar imagen al PDF

                        //Se evalua la aplicacion del filtro como tipo de reporte al pdf
                        if (validarFiltro == false)    //Sin filtro
                        {
                            //Creacion de objeto para realizar la lectura del HTML para pasarlo al PDF
                            using (StringReader reader = new StringReader(WriterHTML()))
                            { XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, reader); }
                        }
                        else    //Con filtro
                        {
                            //Creacion de objeto para realizar la lectura del HTML para pasarlo al PDF
                            using (StringReader reader = new StringReader(WriterHTMLfiltro()))
                            { XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, reader); }
                        }
                        pdfDoc.Close();
                        stream.Close();
                    }
                }
            }

            this.Close();
        }

        public string WriterHTML()
        {
            string paginahtml_texto = null, filas = string.Empty; ;//Inicializacion

            //Empleo de switch para obtener el tipo de reporte seleccionado y cargar el formato HTML como texto
            switch (tipoReporte)
            {
                case 1:
                    paginahtml_texto = Properties.Resources.plantilla.ToString();
                    break;
                case 2:
                    paginahtml_texto = Properties.Resources.plantillacontacto.ToString();
                    break;
                case 3:
                    paginahtml_texto = Properties.Resources.plantillaAcademica.ToString();
                    break;
            }

            //Se reemplaza el texto "@FECHA" para colocar la fecha actual
            paginahtml_texto = paginahtml_texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));

            //Se recorre el DataGridViewRow por filas
            foreach (DataGridViewRow row in dgvMostrar.Rows)
            {
                //Se guarda en formato HTML el valor de las columnas del DataGridViewRow
                filas += "<tr>";

                //Condicional para colocar la info correspodiente de acuerdo al tipo de reporte
                if (tipoReporte == 1)
                {
                    filas += "<td>" + row.Cells["APaterno"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["AMaterno"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["Nombres"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["FechaNac"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["Edad"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["Curp"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["Genero"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["Estadocivil"].Value.ToString() + "</td>";
                }
                if (tipoReporte == 2)
                {
                    filas += "<td>" + row.Cells["APaterno"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["AMaterno"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["Nombres"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["Domicilio"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["CP"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["Nacionalidad"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["EstadoNacimiento"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["Municipio"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["Correo"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["Telefono"].Value.ToString() + "</td>";
                }
                if (tipoReporte == 3)
                {
                    filas += "<td>" + row.Cells["APaterno"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["AMaterno"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["Nombres"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["Carrera"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["Periodo"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["Promedio"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["CCT"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["Modelo"].Value.ToString() + "</td>";
                }

                filas += "</tr>";
            }

            //Se reemplaza el texto "@FILAS" del HTML para colocar las filas obtenidas del DataGridViewRow
            paginahtml_texto = paginahtml_texto.Replace("@FILAS", filas);

            return paginahtml_texto;
        }

       

        public string WriterHTMLfiltro()
        {
            string paginahtml_texto = null, filas = string.Empty; ;//Inicializacion

            //Empleo de switch para obtener el tipo de reporte seleccionado y cargar el formato HTML como texto
            switch (tipoReporte)
            {
                case 1:
                    paginahtml_texto = Properties.Resources.plantilla.ToString();
                    break;
                case 2:
                    paginahtml_texto = Properties.Resources.plantillacontacto.ToString();
                    break;
                case 3:
                    paginahtml_texto = Properties.Resources.plantillaAcademica.ToString();
                    break;
            }

            //Se reemplaza el texto "@FECHA" para colocar la fecha actual
            paginahtml_texto = paginahtml_texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));

            //Se recorre el DataGridViewRow por filas
            foreach (DataGridViewRow row in dgvMostrar.Rows)
            {   //Si en el DataGrid las filas son visibles(contienen el filtro de la busqueda)
                //entonces se pasan al HTML para imprimir
                if (row.Visible == true)
                {
                    //Se guarda en formato HTML el valor de las columnas del DataGridViewRow
                    filas += "<tr>";

                    //Condicional para colocar la info correspodiente de acuerdo al tipo de reporte
                    if (tipoReporte == 1)
                    {
                        filas += "<td>" + row.Cells["APaterno"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["AMaterno"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["Nombres"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["FechaNac"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["Edad"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["Curp"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["Genero"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["Estadocivil"].Value.ToString() + "</td>";
                    }
                    if (tipoReporte == 2)
                    {
                        filas += "<td>" + row.Cells["APaterno"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["AMaterno"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["Nombres"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["Domicilio"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["CP"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["Nacionalidad"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["EstadoNacimiento"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["Municipio"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["Correo"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["Telefono"].Value.ToString() + "</td>";
                    }
                    if (tipoReporte == 3)
                    {
                        filas += "<td>" + row.Cells["APaterno"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["AMaterno"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["Nombres"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["Carrera"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["Periodo"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["Promedio"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["CCT"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["Modelo"].Value.ToString() + "</td>";
                    }
                    filas += "</tr>";
                }
            }
            //Se reemplaza el texto "@FILAS" del HTML para colocar las filas obtenidas del DataGridViewRow
            paginahtml_texto = paginahtml_texto.Replace("@FILAS", filas);

            return paginahtml_texto;
        }

        public void cargaData()
        {
            //Se inicializan variables 
            string aPaterno, aMaterno, nombres, fechanac, edad, curp, genero, estado_civil;
            string domicilio, codigo_postal, nacionalidad, estado_nacimiento, municipio, correo_electronico, telefono;
            string carrera, periodo, promedio, cct, modelo;
            int indicieNuevoRenglon;

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
                    indicieNuevoRenglon = dgvMostrar.Rows.Add();

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
                    dgvMostrar.Rows[indicieNuevoRenglon].Cells[0].Value = aPaterno;
                    dgvMostrar.Rows[indicieNuevoRenglon].Cells[1].Value = aMaterno;
                    dgvMostrar.Rows[indicieNuevoRenglon].Cells[2].Value = nombres;
                    dgvMostrar.Rows[indicieNuevoRenglon].Cells[3].Value = fechanac;
                    dgvMostrar.Rows[indicieNuevoRenglon].Cells[4].Value = edad;
                    dgvMostrar.Rows[indicieNuevoRenglon].Cells[5].Value = curp;
                    dgvMostrar.Rows[indicieNuevoRenglon].Cells[6].Value = genero;
                    dgvMostrar.Rows[indicieNuevoRenglon].Cells[7].Value = estado_civil;
                    dgvMostrar.Rows[indicieNuevoRenglon].Cells[8].Value = domicilio;
                    dgvMostrar.Rows[indicieNuevoRenglon].Cells[9].Value = codigo_postal;
                    dgvMostrar.Rows[indicieNuevoRenglon].Cells[10].Value = nacionalidad;
                    dgvMostrar.Rows[indicieNuevoRenglon].Cells[11].Value = estado_nacimiento;
                    dgvMostrar.Rows[indicieNuevoRenglon].Cells[12].Value = municipio;
                    dgvMostrar.Rows[indicieNuevoRenglon].Cells[13].Value = correo_electronico;
                    dgvMostrar.Rows[indicieNuevoRenglon].Cells[14].Value = telefono;
                    dgvMostrar.Rows[indicieNuevoRenglon].Cells[15].Value = carrera;
                    dgvMostrar.Rows[indicieNuevoRenglon].Cells[16].Value = periodo;
                    dgvMostrar.Rows[indicieNuevoRenglon].Cells[17].Value = promedio;
                    dgvMostrar.Rows[indicieNuevoRenglon].Cells[18].Value = cct;
                    dgvMostrar.Rows[indicieNuevoRenglon].Cells[19].Value = modelo;

                    renglon = lector.ReadLine();
                }
            }
            //Finalizamos la carga y cerramos el archivo
            becados.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form LienzoF = new FirmaElectronica();
            LienzoF.Show();
        }

        public void CargarFuentes()
        {
            // Cargar las fuente desde el archivo TTF
            string nombreFuente = "coolveticaRG.otf";
            fontPers.CargarFuentePersonalizada(nombreFuente);
            // Aplicar la fuente a la etiqueta en lblTitulo_ESA
            fontPers.AplicarFuente(lblTitulo_ESA, 28, FontStyle.Regular);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DatosInactividad.control = false; //Indicador al cerrar este formulario
            this.Close();
        }
    }
}
