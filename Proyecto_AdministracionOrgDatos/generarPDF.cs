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
       

        //Variable de tipo string para almacenar el nombre de la base de datos
        String Base_Datos = "BKDOS";
        int indice = 0;

       


        /*------------------------METODO PARA CARGAR DATOS--------------------*/
        private FuentePersonalizada fontPers;
        public generarPDF()
        {
            InitializeComponent();
            LlenarDGV();
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
                else if (cmbPDFeleccion.Text == "Informe Individual") { tipoReporte = 4; } 

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
                    if(tipoReporte == 1 | tipoReporte == 2 | tipoReporte == 3)
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
                            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.Sombrero, System.Drawing.Imaging.ImageFormat.Png);
                            img.ScaleToFit(60, 40); //Tamaño
                            img.Alignment = iTextSharp.text.Image.ALIGN_LEFT; //Alineacion en el documento
                            img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 60); //Posicion
                            pdfDoc.Add(img);//Agregar imagen al PDF

                            iTextSharp.text.Image img2 = iTextSharp.text.Image.GetInstance(Properties.Resources.BK222, System.Drawing.Imaging.ImageFormat.Png);
                            pdfDoc.Add(img2);//Agregar imagen al PDF

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

                                validarFiltro = false;//Reinicio del indicador 
                            }
                            pdfDoc.Close();
                            stream.Close();
                        }
                    }
                    else
                    {
                        //Creacion del documento para leer o escribir
                        using (FileStream stream = new FileStream(guardar.FileName, FileMode.Create))
                        {

                            //Creacion del documento PDF especificando tipo de hoja y margenes
                            Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);

                            //Guardado de los cambios del PDF al documento
                            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);

                            pdfDoc.Open();
                            pdfDoc.Add(new Phrase(""));

                            //Almacenar la imagen del logo en la variable img
                            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.Sombrero, System.Drawing.Imaging.ImageFormat.Png);
                            img.ScaleToFit(60, 40); //Tamaño
                            img.Alignment = iTextSharp.text.Image.ALIGN_LEFT; //Alineacion en el documento
                            img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 60); //Posicion
                            pdfDoc.Add(img);//Agregar imagen al PDF

                            iTextSharp.text.Image img2 = iTextSharp.text.Image.GetInstance(Properties.Resources.BK222, System.Drawing.Imaging.ImageFormat.Png);
                            img2.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
                            pdfDoc.Add(img2);//Agregar imagen al PDF

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

                                validarFiltro = false;//Reinicio del indicador 
                            }
                            pdfDoc.Close();
                            stream.Close();
                        }
                    }
                    
                }
            }

            this.Close();
        }

        public string WriterHTML()
        {
            string paginahtml_texto = null, filas = string.Empty; ;//Inicializacion

            //Declaracion de variables necesarias para el formato individual
            string nombres = string.Empty, apellidoMaterno = string.Empty, apellidoPaterno = string.Empty,
                edad = string.Empty, curp = string.Empty, genero = string.Empty, estadoCivil = string.Empty,
                domicilio = string.Empty, codigoPostal = string.Empty, nacionalidad = string.Empty, estadoNacimiento = string.Empty,
                municipio = string.Empty, correo = string.Empty, telefono = string.Empty, carrera = string.Empty, periodo = string.Empty,
                promedio = string.Empty, cct = string.Empty, modelo = string.Empty, fechaNacimiento = string.Empty;

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
                case 4:
                    paginahtml_texto = Properties.Resources.PlantillaGeneral.ToString();
                    break;
            }

            if (tipoReporte == 1 | tipoReporte == 2 || tipoReporte == 3)
            {
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
                        filas += "<td>" + row.Cells["ApellidoPaterno"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["ApellidoMaterno"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["Nombres"].Value.ToString() + "</td>";
                        filas += "<td>" + ((DateTime)(row.Cells["FechaNacimiento"].Value)).ToString("dd/MM/yyyy") + "</td>";
                        filas += "<td>" + row.Cells["Edad"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["Curp"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["Genero"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["Estadocivil"].Value.ToString() + "</td>";
                    }
                    if (tipoReporte == 2)
                    {
                        filas += "<td>" + row.Cells["ApellidoPaterno"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["ApellidoMaterno"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["Nombres"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["Domicilio"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["CodigoPostal"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["Nacionalidad"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["EstadoNacimiento"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["Municipio"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["Correo"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["Telefono"].Value.ToString() + "</td>";
                    }
                    if (tipoReporte == 3)
                    {
                        filas += "<td>" + row.Cells["ApellidoPaterno"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["ApellidoMaterno"].Value.ToString() + "</td>";
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
            else if(tipoReporte == 4)
            {
                if (dgvMostrar.CurrentRow.Index > -1)
                {
                    //Se asignan todos los valores individuales a las respectivas variables que se representaran en el formato html

                    /*IMPORTANTE: "this.dgvMostrar.CurrentRow.Cells[1].Value.ToString()" hace referencia  los datos de la fila
                     * seleccionada en el datagridview, el indice que esta dentro del espacio cell, es la posicion (columna) en la
                     * que se encuentra el dato deseado, se tiene que saber el indice de dicho dato para poder asignarselo a la variable
                     * en caso de querer agregar otro,  es el mismo codigo solo se modifica ese indice*/

                    apellidoPaterno = this.dgvMostrar.CurrentRow.Cells[1].Value.ToString();
                    apellidoMaterno = this.dgvMostrar.CurrentRow.Cells[2].Value.ToString();
                    nombres = this.dgvMostrar.CurrentRow.Cells[3].Value.ToString();
                    fechaNacimiento = this.dgvMostrar.CurrentRow.Cells[4].Value.ToString();
                    edad = this.dgvMostrar.CurrentRow.Cells[5].Value.ToString();
                    curp = this.dgvMostrar.CurrentRow.Cells[6].Value.ToString();
                    genero = this.dgvMostrar.CurrentRow.Cells[8].Value.ToString();
                    estadoCivil = this.dgvMostrar.CurrentRow.Cells[7].Value.ToString();
                    domicilio = this.dgvMostrar.CurrentRow.Cells[10].Value.ToString();
                    codigoPostal = this.dgvMostrar.CurrentRow.Cells[11].Value.ToString();
                    nacionalidad = this.dgvMostrar.CurrentRow.Cells[12].Value.ToString();
                    estadoNacimiento = this.dgvMostrar.CurrentRow.Cells[13].Value.ToString();
                    municipio = this.dgvMostrar.CurrentRow.Cells[14].Value.ToString();
                    correo = this.dgvMostrar.CurrentRow.Cells[15].Value.ToString();
                    telefono = this.dgvMostrar.CurrentRow.Cells[16].Value.ToString();
                    carrera = this.dgvMostrar.CurrentRow.Cells[18].Value.ToString();
                    periodo = this.dgvMostrar.CurrentRow.Cells[19].Value.ToString();
                    promedio = this.dgvMostrar.CurrentRow.Cells[20].Value.ToString();
                    cct = this.dgvMostrar.CurrentRow.Cells[22].Value.ToString();
                    modelo = this.dgvMostrar.CurrentRow.Cells[21].Value.ToString();
                }
                
                //Remplazando fecha en el reporte individual
                paginahtml_texto = paginahtml_texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));

                //Remplazando los datos del alumno en el reporte individual
                paginahtml_texto = paginahtml_texto.Replace("@APATERNO", apellidoPaterno);
                paginahtml_texto = paginahtml_texto.Replace("@AMATERNO", apellidoMaterno);
                paginahtml_texto = paginahtml_texto.Replace("@NOMBRES", nombres);
                paginahtml_texto = paginahtml_texto.Replace("@EDAD", edad);
                paginahtml_texto = paginahtml_texto.Replace("@FECHANAC", fechaNacimiento);
                paginahtml_texto = paginahtml_texto.Replace("@CURP", curp);
                paginahtml_texto = paginahtml_texto.Replace("@GENERO", genero);
                paginahtml_texto = paginahtml_texto.Replace("@ESTCIVIL", estadoCivil);
                paginahtml_texto = paginahtml_texto.Replace("@CORREO", correo);
                paginahtml_texto = paginahtml_texto.Replace("@CELULAR", telefono);
                paginahtml_texto = paginahtml_texto.Replace("@DOMICILIO", domicilio);
                paginahtml_texto = paginahtml_texto.Replace("@CODIGOPOS", codigoPostal);
                paginahtml_texto = paginahtml_texto.Replace("@ESTNAC", estadoNacimiento);
                paginahtml_texto = paginahtml_texto.Replace("@MUNICIPIO", municipio);
                paginahtml_texto = paginahtml_texto.Replace("@NACIONALIDAD", nacionalidad);
                paginahtml_texto = paginahtml_texto.Replace("@UNI", cct);
                paginahtml_texto = paginahtml_texto.Replace("@MODELO", modelo);
                paginahtml_texto = paginahtml_texto.Replace("@CARRERA", carrera);
                paginahtml_texto = paginahtml_texto.Replace("@PROMEDIO", promedio);
                paginahtml_texto = paginahtml_texto.Replace("@PERIODO", periodo);



                return paginahtml_texto;
            }

            return paginahtml_texto;
        }

       

        public string WriterHTMLfiltro()
        {
            string paginahtml_texto = null, filas = string.Empty; ;//Inicializacion

            //Declaracion de variables necesarias para el formato individual
            string nombres = string.Empty, apellidoMaterno = string.Empty, apellidoPaterno = string.Empty,
                edad = string.Empty, curp = string.Empty, genero = string.Empty, estadoCivil = string.Empty,
                domicilio = string.Empty, codigoPostal = string.Empty, nacionalidad = string.Empty, estadoNacimiento = string.Empty,
                municipio = string.Empty, correo = string.Empty, telefono = string.Empty, carrera = string.Empty, periodo = string.Empty,
                promedio = string.Empty, cct = string.Empty, modelo = string.Empty, fechaNacimiento = string.Empty;

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
                case 4:
                    paginahtml_texto = Properties.Resources.PlantillaGeneral.ToString();
                    break;
            }

            if (tipoReporte == 1 | tipoReporte == 2 || tipoReporte == 3)
            {
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
                            filas += "<td>" + row.Cells["ApellidoPaterno"].Value.ToString() + "</td>";
                            filas += "<td>" + row.Cells["ApellidoMaterno"].Value.ToString() + "</td>";
                            filas += "<td>" + row.Cells["Nombres"].Value.ToString() + "</td>";
                            filas += "<td>" + ((DateTime)(row.Cells["FechaNacimiento"].Value)).ToString("dd/MM/yyyy") + "</td>";
                            filas += "<td>" + row.Cells["Edad"].Value.ToString() + "</td>";
                            filas += "<td>" + row.Cells["Curp"].Value.ToString() + "</td>";
                            filas += "<td>" + row.Cells["Genero"].Value.ToString() + "</td>";
                            filas += "<td>" + row.Cells["Estadocivil"].Value.ToString() + "</td>";
                        }
                        if (tipoReporte == 2)
                        {
                            filas += "<td>" + row.Cells["ApellidoPaterno"].Value.ToString() + "</td>";
                            filas += "<td>" + row.Cells["ApellidoMaterno"].Value.ToString() + "</td>";
                            filas += "<td>" + row.Cells["Nombres"].Value.ToString() + "</td>";
                            filas += "<td>" + row.Cells["Domicilio"].Value.ToString() + "</td>";
                            filas += "<td>" + row.Cells["CodigoPostal"].Value.ToString() + "</td>";
                            filas += "<td>" + row.Cells["Nacionalidad"].Value.ToString() + "</td>";
                            filas += "<td>" + row.Cells["EstadoNacimiento"].Value.ToString() + "</td>";
                            filas += "<td>" + row.Cells["Municipio"].Value.ToString() + "</td>";
                            filas += "<td>" + row.Cells["Correo"].Value.ToString() + "</td>";
                            filas += "<td>" + row.Cells["Telefono"].Value.ToString() + "</td>";
                        }
                        if (tipoReporte == 3)
                        {
                            filas += "<td>" + row.Cells["ApellidoPaterno"].Value.ToString() + "</td>";
                            filas += "<td>" + row.Cells["ApellidoMaterno"].Value.ToString() + "</td>";
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
            else if (tipoReporte == 4)
            {
                if (dgvMostrar.CurrentRow.Index > -1)
                {
                    //Se asignan todos los valores individuales a las respectivas variables que se representaran en el formato html

                    /*IMPORTANTE: "this.dgvMostrar.CurrentRow.Cells[1].Value.ToString()" hace referencia  los datos de la fila
                     * seleccionada en el datagridview, el indice que esta dentro del espacio cell, es la posicion (columna) en la
                     * que se encuentra el dato deseado, se tiene que saber el indice de dicho dato para poder asignarselo a la variable
                     * en caso de querer agregar otro,  es el mismo codigo solo se modifica ese indice*/

                    apellidoPaterno = this.dgvMostrar.CurrentRow.Cells[1].Value.ToString();
                    apellidoMaterno = this.dgvMostrar.CurrentRow.Cells[2].Value.ToString();
                    nombres = this.dgvMostrar.CurrentRow.Cells[3].Value.ToString();
                    fechaNacimiento = this.dgvMostrar.CurrentRow.Cells[4].Value.ToString();
                    edad = this.dgvMostrar.CurrentRow.Cells[5].Value.ToString();
                    curp = this.dgvMostrar.CurrentRow.Cells[6].Value.ToString();
                    genero = this.dgvMostrar.CurrentRow.Cells[8].Value.ToString();
                    estadoCivil = this.dgvMostrar.CurrentRow.Cells[7].Value.ToString();
                    domicilio = this.dgvMostrar.CurrentRow.Cells[10].Value.ToString();
                    codigoPostal = this.dgvMostrar.CurrentRow.Cells[11].Value.ToString();
                    nacionalidad = this.dgvMostrar.CurrentRow.Cells[12].Value.ToString();
                    estadoNacimiento = this.dgvMostrar.CurrentRow.Cells[13].Value.ToString();
                    municipio = this.dgvMostrar.CurrentRow.Cells[14].Value.ToString();
                    correo = this.dgvMostrar.CurrentRow.Cells[15].Value.ToString();
                    telefono = this.dgvMostrar.CurrentRow.Cells[16].Value.ToString();
                    carrera = this.dgvMostrar.CurrentRow.Cells[18].Value.ToString();
                    periodo = this.dgvMostrar.CurrentRow.Cells[19].Value.ToString();
                    promedio = this.dgvMostrar.CurrentRow.Cells[20].Value.ToString();
                    cct = this.dgvMostrar.CurrentRow.Cells[22].Value.ToString();
                    modelo = this.dgvMostrar.CurrentRow.Cells[21].Value.ToString();
                }

                //Remplazando fecha en el reporte individual
                paginahtml_texto = paginahtml_texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));

                //Remplazando los datos del alumno en el reporte individual
                paginahtml_texto = paginahtml_texto.Replace("@APATERNO", apellidoPaterno);
                paginahtml_texto = paginahtml_texto.Replace("@AMATERNO", apellidoMaterno);
                paginahtml_texto = paginahtml_texto.Replace("@NOMBRES", nombres);
                paginahtml_texto = paginahtml_texto.Replace("@EDAD", edad);
                paginahtml_texto = paginahtml_texto.Replace("@FECHANAC", fechaNacimiento);
                paginahtml_texto = paginahtml_texto.Replace("@CURP", curp);
                paginahtml_texto = paginahtml_texto.Replace("@GENERO", genero);
                paginahtml_texto = paginahtml_texto.Replace("@ESTCIVIL", estadoCivil);
                paginahtml_texto = paginahtml_texto.Replace("@CORREO", correo);
                paginahtml_texto = paginahtml_texto.Replace("@CELULAR", telefono);
                paginahtml_texto = paginahtml_texto.Replace("@DOMICILIO", domicilio);
                paginahtml_texto = paginahtml_texto.Replace("@CODIGOPOS", codigoPostal);
                paginahtml_texto = paginahtml_texto.Replace("@ESTNAC", estadoNacimiento);
                paginahtml_texto = paginahtml_texto.Replace("@MUNICIPIO", municipio);
                paginahtml_texto = paginahtml_texto.Replace("@NACIONALIDAD", nacionalidad);
                paginahtml_texto = paginahtml_texto.Replace("@UNI", cct);
                paginahtml_texto = paginahtml_texto.Replace("@MODELO", modelo);
                paginahtml_texto = paginahtml_texto.Replace("@CARRERA", carrera);
                paginahtml_texto = paginahtml_texto.Replace("@PROMEDIO", promedio);
                paginahtml_texto = paginahtml_texto.Replace("@PERIODO", periodo);



                return paginahtml_texto;
            }

            return paginahtml_texto;
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            Form LienzoF = new FirmaElectronica();
            LienzoF.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DatosInactividad.control = false; //Indicador al cerrar este formulario
            this.Close();
        }

        public void LlenarDGV()
        {
            using(SqlConnection con= DB_Conexion.GetConnection())
            {
                Sql = "SELECT Id_Alumno, ApellidoPaterno, ApellidoMaterno, Nombres, FechaNacimiento, Edad, Curp, EstadoCivil, Genero, DatosContacto.Id_DatosContacto, Domicilio, CodigoPostal, Nacionalidad, EstadoNacimiento, Municipio, Correo, Telefono, DatosAcademicos.Id_DatosAcademicos,Carrera, Periodo, Promedio, Modelo, CCT " +
               "FROM DatosGenerales JOIN DatosContacto ON DatosContacto.Id_DatosContacto = DatosGenerales.Id_DatosContacto " +
               "JOIN DatosAcademicos ON DatosAcademicos.Id_DatosAcademicos = DatosGenerales.Id_DatosAcademicos WHERE Estado = 1 ";
                // Sql = "SELECT * from DatosGenerales, DatosAcademicos, DatosContacto";
                Adaptador = new SqlDataAdapter(Sql, con);
                Adaptador.Fill(Tabla);
                dgvMostrar.DataSource = Tabla;
            }

           
        }      
    }
}
