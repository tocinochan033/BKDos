using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_AdministracionOrgDatos
{
    class ClaseBD
    {
        SqlConnection conx;
        //Comando objeto del tipo SQLcommand para representar las instrucciones SQL
        SqlCommand Comando;
        public ClaseBD()
        {
            try
            {
                // Conexion objeto del tipo sqlConnection para conectarnos fisicamente a la base de datos
                conx = new SqlConnection(@"server=pc\DESKTOP-JGTCE3J; Initial Catalog=BKDOS; integrated security=true");
                conx.Open();
                MessageBox.Show("Mensaje de conexion", "Conexion realizada correctamente", MessageBoxButtons.OK);

                // Asegúrate de cerrar la conexión después de usarla
                conx.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR: " + e.Message, "Error inesperado", MessageBoxButtons.OK);
            }
        }

        public bool InsertarDatosAcademicos(string carrera, string periodo, int promedio,string modelo, int idCCT)
        {

            /*Insercion de tercera tabla Datos academicos*/
         
            string Sql = "insert into DatosAcademicos (Carrera, Periodo, Promedio, Modelo, Id_cct) values (@Carrera, @Periodo, @Promedio, @Modelo, @Id_cct)";
            
            try
            {
                /*Tercera tabla*/
                using(SqlCommand comando= new SqlCommand (Sql,conx))
                {
                    comando.Parameters.AddWithValue("@Carrera", carrera);
                    comando.Parameters.AddWithValue("@Periodo", periodo);
                    comando.Parameters.AddWithValue("@Promedio", promedio);
                    comando.Parameters.AddWithValue("@Modelo", modelo);
                    comando.Parameters.AddWithValue("@Id_cct", idCCT);
                    comando.ExecuteNonQuery();
                    return true;
                }
               
            }
            catch(Exception)
            {
                return false;
            }
           
        }
    }
}