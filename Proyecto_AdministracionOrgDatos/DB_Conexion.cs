using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_AdministracionOrgDatos
{
    internal class DB_Conexion
    {
        private static string Conexion = "Data Source =DESKTOP-28QI84Q; Initial Catalog = BKDOS; integrated security=true";

        public static SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(Conexion);

            //Valida el estado de la conexion
            if(con.State != System.Data.ConnectionState.Open)
            {
                con.Open();
            }
            return con;
        }
    }
}
