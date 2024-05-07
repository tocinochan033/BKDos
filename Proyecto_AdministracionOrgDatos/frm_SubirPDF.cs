using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Proyecto_AdministracionOrgDatos
{
    public partial class frm_SubirPDF : Form
    {
        //Adaptador objeto del tipo sqlDataAdapter para intercambiar datos entre una
        //fuente de datos (en este caso sql server) y un almacen de datos
        SqlDataAdapter Adaptador = null;

        //Tabla objeto del tipo DATATABLE respresenta una coleccion de registros en memoria del cliente
        DataTable Tabla = new DataTable();
        // Creación de una instancia de DB_HelperUploadPDF para interactuar con la base de datos.
        private DB_HelperUploadPDF dbHelper = new DB_HelperUploadPDF();

        public frm_SubirPDF()
        {
            InitializeComponent();
            LoadPdfList(); // Método para cargar la lista de archivos PDF.
        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            // Creación de un cuadro de diálogo para seleccionar archivos.
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Configuración del filtro para mostrar solo archivos PDF.
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                // Restaurar el directorio al directorio previamente seleccionado, después de cerrar el cuadro de diálogo.
                openFileDialog.RestoreDirectory = true;

                // Mostrar el cuadro de diálogo y verificar si el usuario seleccionó un archivo y confirmó.
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Obtención de la ruta del archivo seleccionado.
                    string originalFilePath = openFileDialog.FileName;
                    // Extracción del nombre del archivo de la ruta.
                    string fileName = Path.GetFileName(originalFilePath);
                    // Inserción de la información del archivo en la base de datos.
                    dbHelper.InsertPdf(fileName, originalFilePath);
                    // Recarga de la lista de archivos PDF.
                    LoadPdfList();
                }
            }
        }

        private void LoadPdfList()
        {
            // Limpiar la lista actual de archivos PDF.
            listBoxPdf.Items.Clear();
            // Obtención de todos los archivos PDF de la base de datos.
            var files = dbHelper.GetAllPdfFiles();
            // Agregar cada archivo obtenido a la lista en el formulario.
            foreach (var file in files)
            {
                listBoxPdf.Items.Add(file);
            }
        }

        private void frm_SubirPDF_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                SystemSounds.Exclamation.Play();
                // El usuario ha hecho clic en la "X" para cerrar la ventana
                // Puedes poner aquí el código que deseas ejecutar antes de que se cierre la ventana
                DialogResult result = MessageBox.Show("¿Está seguro de que desea cerrar la ventana?", "Confirmar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Verificar la respuesta del usuario
                if (result == DialogResult.No)
                {
                    // Cancelar el cierre de la ventana si el usuario selecciona "No"
                    e.Cancel = true;
                }
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            // Comprobación de que haya un archivo seleccionado en la lista.
            if (listBoxPdf.SelectedItem != null)
            {
                // Obtención de la ruta del archivo seleccionado.
                string filePath = listBoxPdf.SelectedItem.ToString();

                // Mostrar un mensaje indicando que se intentará abrir el archivo.
                MessageBox.Show("Intentando abrir el archivo en: " + filePath);

                // Verificar si el archivo existe en la ruta especificada.
                if (File.Exists(filePath))
                {
                    try
                    {
                        // Creación de una instancia de ProcessStartInfo para abrir el archivo.
                        var psi = new System.Diagnostics.ProcessStartInfo(filePath)
                        {
                            UseShellExecute = true
                        };
                        // Inicio del proceso para abrir el archivo.
                        System.Diagnostics.Process.Start(psi);
                    }
                    catch (Exception ex)
                    {
                        // Mostrar mensaje si ocurre algún error al abrir el archivo.
                        MessageBox.Show("Error al abrir el archivo: " + ex.Message);
                    }
                }
                else
                {
                    // Mostrar mensaje si el archivo no existe.
                    MessageBox.Show("El archivo no existe:" + filePath);
                }
            }
            else
            {
                // Solicitar al usuario que seleccione un archivo de la lista si no ha seleccionado ninguno.
                MessageBox.Show("Seleccione un PDF de la lista.");
            }
        }

        private void listBoxPdf_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void GetPDF()
        {
            //Query Primera Tabla
            using (SqlConnection con = DB_Conexion.GetConnection())
            {
                string Sql = "SELECT FileName , FilePath FROM DatosArchivos ";
                // Sql = "SELECT * from DatosGenerales, DatosAcademicos, DatosContacto";
                Adaptador = new SqlDataAdapter(Sql, con);
                Adaptador.Fill(Tabla);
                dgvPDF.DataSource = Tabla;
            }
        }

        public void RefrescarPDF()
        {

        }
    }
}
