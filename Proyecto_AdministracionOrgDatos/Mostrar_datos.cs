using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using Microsoft.VisualBasic;

namespace Proyecto_AdministracionOrgDatos
{
    public partial class Mostrar_datos : Form
    {
        private FuentePersonalizada fontPers;
        //Variables para las diferentes pantallas
        frmMenu_ESA PantallaMenu;

        //Indicadores de filtro
        static bool validarFiltro = false; 
        static int tipoReporte = 0;

        //Variable para el calculo de la inactividad
        private Timer temporizadorInactividad;

        public Mostrar_datos()
        {
            InitializeComponent();
            fontPers = new FuentePersonalizada();

            //Creacion del temporizador y su tiempo
            temporizadorInactividad = new Timer();
            temporizadorInactividad.Interval = 1000;
            //Al llegar al tiempo especificado se accede al metodo
            temporizadorInactividad.Tick += (sender, e) => Verificarlnactividad();
            //Inicializacion del temporizador
            temporizadorInactividad.Start();


            //Inicialiazcion de combo box de tipos de reporte
            cmbPDFeleccion.Items.Add("Informacion personal");
            cmbPDFeleccion.Items.Add("Informacion de contacto");
            cmbPDFeleccion.Items.Add("Informacion academica");


            //Se iniciliazan los elementos del combo box
            cmbFiltro.Items.Add("Nombre");
            cmbFiltro.Items.Add("CCT");
            cmbFiltro.Items.Add("Promedio");

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

        private void dgv_Agregar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Verificamos si hay una fila seleccionada
            if (dgvMostrar.CurrentRow.Index > -1)
            {
                //Nota: "RemoveAt" borra lo seleccionado en base al index
                dgvMostrar.Rows.RemoveAt(dgvMostrar.CurrentRow.Index);
                Guardar();
            }

        }

        private void Guardar()
        {
            //Se guardan los datos de los becados en el archivo txt
            //Se tiene que sobreescribir ya que si es que se eliminan datos
            //los indices estarian mal para las siguientes veces que se desplegara el programa
            FileStream becados = new FileStream("Becados.txt", FileMode.Create, FileAccess.Write);
            using (StreamWriter writer = new StreamWriter(becados))
            {
                //Se recorren todas las filas del datagridview
                foreach (DataGridViewRow row in dgvMostrar.Rows)
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DatosInactividad.control = false; //Indicador al cerrar este formulario
            this.Close();
        }

        private void PantallaRegistroCerrada(object sender, FormClosedEventArgs e)
        {
            PantallaMenu = null;
        }


        /* private void filtroTextBox_TextChanged_1(object sender, EventArgs e)
         {
             if (filtroTextBox.Text != null)
             {
                 dgvMostrar.CurrentCell = null;
                 foreach (DataGridViewRow row in dgvMostrar.Rows)
                 {
                     row.Visible = false;
                 }

                 foreach (DataGridViewRow row in dgvMostrar.Rows)
                 {
                     foreach (DataGridViewCell cell in row.Cells)
                     {
                         if (cell.Value.ToString().ToUpper().IndexOf(filtroTextBox.Text.ToUpper()) == 0)
                         {
                             row.Visible = true;
                             break;
                         }
                     }
                 }
             }
         }*/

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (cmbPDFeleccion.Text == "")
            {
                MessageBox.Show("Favor de seleccionar alguna opcion valida", "Datos incompatibles", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbPDFeleccion.Focus();
            }
            else
            {
                //Asignacion de tipo de reporte a utilizar
                if (cmbPDFeleccion.Text == "Informacion personal") { tipoReporte = 1;}
                else if(cmbPDFeleccion.Text == "Informacion de contacto") { tipoReporte = 2; }
                else if (cmbPDFeleccion.Text == "Informacion academica") { tipoReporte = 3; }

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
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            //Si hay algo entonces se ejecuta
            if (txtFiltro.Text != "")
            {
                if (cmbFiltro.Text != "")
                {
                    //Asignacion de celda
                    string auxiliar = cmbFiltro.Text;
                    switch (auxiliar)
                    {
                        case "Nombre":
                            auxiliar = "2";
                            break;
                        case "CCT":
                            auxiliar = "18";
                            break;
                        case "Promedio":
                            auxiliar = "17";
                            break;
                    }

                    dgvMostrar.CurrentCell = null;

                    //Recorrer filas para desaparecer todas
                    foreach (DataGridViewRow row in dgvMostrar.Rows)
                    { row.Visible = false; }

                    //Se recorren las filas para buscar el valor
                    foreach (DataGridViewRow row in dgvMostrar.Rows)
                    {
                        //Se recorre de celda en celda la fila del foreach anterior
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            //Comparar celda con el textbox de busqueda
                            if (row.Cells[Int32.Parse(auxiliar)].Value.ToString().ToUpper().IndexOf(txtFiltro.Text.ToUpper()) == 0)
                            {
                                row.Visible = true;
                                validarFiltro = true;//Indicador de imprimir el pdf con los filtros
                                break;
                            }
                        }
                    }
                }

            }
            else
            { MessageBox.Show("Faltan datos por colocar"); }
        }

        /*public void CargarEscuelas()
        {
            //Abrimos archivo en modo lectura
            //   FileStream becados = new FileStream("Becados.txt", FileMode.Create, FileAccess.Write);
            FileStream becarios = new FileStream("Becados.txt", FileMode.OpenOrCreate, FileAccess.Read);

            //Lee linea por linea
            using (StreamReader reader = new StreamReader(becarios))
            {
                string linea = reader.ReadLine();
                while(linea != null)
                {
                    //Reconstruye el objeto a partir de los datos

                    string datos = linea;

                    //Crear string para separar y mostrar datos
                    datos = string.Join("",datos.Split(','));

                    //Referencia al comboBox para agregarlo a los elementos
                    cmbFiltrar.Items.Add(datos);

                    linea = reader.ReadLine();
                }

            }
            //Cerramos archivo
            becarios.Close();
            //Fin de lectura de archivo
        }
        */
        private void cmbFiltrar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvMostrar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FechaC_Click(object sender, EventArgs e)
        {

        }

        private void btnResetFiltro_Click(object sender, EventArgs e)
        {
            txtFiltro.Text = "";
            cmbFiltro.Text = "";
            cmbPDFeleccion.Text = "";
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

            return paginahtml_texto ;
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

        private void Mostrar_datos_Load(object sender, EventArgs e)
        {
            CargarFuentes();
            this.FormBorderStyle = FormBorderStyle.None;
        }

        public void CargarFuentes()
        {
            // Cargar las fuente desde el archivo TTF
            string nombreFuente = "coolveticaRG.otf";
            fontPers.CargarFuentePersonalizada(nombreFuente);
            // Aplicar la fuente a la etiqueta en lblTitulo_ESA
            fontPers.AplicarFuente(lblTitulo_ESA, 28, FontStyle.Regular);
        }

        private void cmbPDFeleccion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
