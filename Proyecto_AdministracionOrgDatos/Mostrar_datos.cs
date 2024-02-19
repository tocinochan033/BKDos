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

namespace Proyecto_AdministracionOrgDatos
{
    public partial class Mostrar_datos : Form
    {
        public Mostrar_datos()
        {
            InitializeComponent();

            //Se inicializan variables 
            string nombre, telefono, correo, estado;
            int auxiliar;

            //Se cargan las variables del archivo de texto

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
                    auxiliar = dgvMostrar.Rows.Add();

                    //Asignamos el valor a las variables
                    nombre = datos[0];
                    telefono = datos[1];
                    correo = datos[2];
                    estado = datos[3];

                    //Colocamos la informacion en el datagridview
                    dgvMostrar.Rows[auxiliar].Cells[0].Value = nombre;
                    dgvMostrar.Rows[auxiliar].Cells[1].Value = telefono;
                    dgvMostrar.Rows[auxiliar].Cells[2].Value = correo;
                    dgvMostrar.Rows[auxiliar].Cells[3].Value = estado;

                    renglon = lector.ReadLine();
                }
            }
            //Finalizamos la carga y cerramos el archivo
            becados.Close();
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
                    writer.WriteLine($"{row.Cells[0].Value},{row.Cells[1].Value},{row.Cells[2].Value},{row.Cells[3].Value}");
                }
            }
            //Se terminan de guardar los datos y se cierra el archivo
            becados.Close();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Form objMenu_ESA = new frmMenu_ESA();
            objMenu_ESA.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Empleo de clase para guardar el archivo mediante ubicacion
            SaveFileDialog guardar = new SaveFileDialog();

            //Despliega el explorador de archivos para guardar el archivo, de nombre toma la fecha actual
            guardar.FileName = DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";

            //Se pasa el formato del HTML como texto
            string paginahtml_texto = Properties.Resources.plantilla.ToString();

            //Se reemplaza el texto "@FECHA" para colocar la fecha actual
            paginahtml_texto = paginahtml_texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));


            string filas = string.Empty;//Crear cadena de texto vacia

            //Se recorre el DataGridViewRow por filas
            foreach (DataGridViewRow row in dgvMostrar.Rows)
            {
                //Se guarda en formato HTML el valor de las columnas del DataGridViewRow
                filas += "<tr>";
                filas += "<td>" + row.Cells["Nombre"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Telefono"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Correo"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Estado"].Value.ToString() + "</td>";
                filas += "</tr>";
            }

            //Se reemplaza el texto "@FILAS" del HTML para colocar las filas obtenidas del DataGridViewRow
            paginahtml_texto = paginahtml_texto.Replace("@FILAS", filas);


             //Se evalua que en el explorador de archivos, se presione guardar para
            //iniciar con la configuracion de guardado del PDF
            if (guardar.ShowDialog() == DialogResult.OK)
            {
                //Creacion del documento para leer o escribir
                using (FileStream stream = new FileStream(guardar.FileName, FileMode.Create))
                {
                    //Creacion del documento PDF especificando tipo de hoja y margenes
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

                    //Guardado de los cambios del PDF al documento
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);

                    pdfDoc.Open();
                    pdfDoc.Add(new Phrase(""));

                    //Almacenar la imagen del logo en la variable img
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.Ajolote, System.Drawing.Imaging.ImageFormat.Png);
                    img.ScaleToFit(80, 60); //Tamaño
                    img.Alignment = iTextSharp.text.Image.UNDERLYING; //Alineacion en el documento
                    img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top-60); //Posicion
                    pdfDoc.Add(img);//Agregar imagen al PDF

                    //Creacion de objeto para realizar la lectura del HTML para pasarlo al PDF
                    using (StringReader reader = new StringReader(paginahtml_texto))
                    {   
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, reader);
                    }

                    pdfDoc.Close();
                    stream.Close();
                }
            }
        }

        //Aqui estan las propiedades para agregar la fecha y la hora al programa
        private void FechaHora3_Tick(object sender, EventArgs e)
        {
            HoraC.Text = DateTime.Now.ToShortTimeString();
            FechaC.Text = DateTime.Now.ToShortDateString();
        }

       private void button1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
