using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_AdministracionOrgDatos
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// 
        /// no cambios de fichero.
        /// </summary>
        public static FormLogin_ESA loginEstatico;//Login estatico, para evitar que se duplique
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(loginEstatico = new FormLogin_ESA());
        }
    }
}
