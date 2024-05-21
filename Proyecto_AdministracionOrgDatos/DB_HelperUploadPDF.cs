using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System;

namespace Proyecto_AdministracionOrgDatos
{
    public class DB_HelperUploadPDF
    {
        //Adaptador objeto del tipo sqlDataAdapter para intercambiar datos entre una
        //fuente de datos (en este caso sql server) y un almacen de datos
        //SqlDataAdapter Adaptador = null;

        //Tabla objeto del tipo DATATABLE respresenta una coleccion de registros en memoria del cliente
        //DataTable Tabla = new DataTable();


        // Cadena de conexión para conectarse a la base de datos SQL Server.
        private string connectionString = "Data Source =DESKTOP-1M2HN6J; Initial Catalog = BKDOS; integrated security=true";

        public void InsertPdf(string fileName, string originalFilePath)
        {
            // Obtener la ruta del directorio 'Documentos' del usuario actual.
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            // Crear o asegurarse de que existe una carpeta llamada 'PDFs' dentro de 'Documentos'.
            string pdfsFolderPath = Path.Combine(documentsPath, "PDFs");
            if (!Directory.Exists(pdfsFolderPath))
                Directory.CreateDirectory(pdfsFolderPath);

            // Componer la nueva ruta del archivo dentro de la carpeta 'PDFs'.
            string newFilePath = Path.Combine(pdfsFolderPath, fileName);
            // Copiar el archivo original a la nueva ubicación, permitiendo sobrescribir si ya existe.
            File.Copy(originalFilePath, newFilePath, true);

            // Usar la conexión a SQL para ejecutar una instrucción de inserción.
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                string query = "INSERT INTO ArchivosBecarios (FileName, FilePath) VALUES (@FileName, @FilePath)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    
                    // Añadir los parámetros para evitar inyección SQL.
                    command.Parameters.AddWithValue("@FileName", fileName);
                    command.Parameters.AddWithValue("@FilePath", newFilePath);
                    // Abrir la conexión y ejecutar la consulta.
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                
            }
        }
     /*   public List<string> GetAllPDFiles()
        {
            List<string> files = new List<string>();

            using (SqlConnection connection = new SqlConnection (connectionString))
            {
                string query = "SELECT FilePath FROM ArchivosBecarios";
                using (SqlCommand command = new SqlCommand(query, connection) )
                {
                    connection.Open();
                    using(SqlDataReader reader = command.ExecuteReader() )
                    { 
                        while(reader.Read())
                        {
                            //Añadimos los archivos a la lista
                            files.Add(reader["FilePath"].ToString());

                        }
                    }
                }
            }
            return files;
        }
     */

    }
}