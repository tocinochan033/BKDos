using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Org.BouncyCastle.Asn1.Crmf;
using iTextSharp.text.html;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;

namespace Proyecto_AdministracionOrgDatos
{
    public class FuentePersonalizada
    {
        //clase de la libreria System.Drawing.Text
        private PrivateFontCollection fontCollection;

        public FuentePersonalizada()
        {
            fontCollection = new PrivateFontCollection();
        }

        public void CargarFuentePersonalizada(string nombreArchivo)
        {

            // Obtener la ruta de la carpeta donde se encuentra el ejecutable
            string rutaEjecutable = AppDomain.CurrentDomain.BaseDirectory;

            // Construir la ruta completa al archivo de fuente usando la ruta relativa
            string rutaCompletaFuente = Path.Combine(rutaEjecutable, "Fuentes", nombreArchivo);

            // Cargar la fuente desde el archivo
            fontCollection.AddFontFile(rutaCompletaFuente);

        }

        public void AplicarFuente(Control control, float tamano, FontStyle estilo)
        {
            // Verificar si hay al menos una fuente cargada
            if (fontCollection.Families.Length > 0)
            {
                // Crear una nueva fuente desde la colección de fuentes cargadas
                Font nuevaFuente = new Font(fontCollection.Families[0], tamano, estilo);

                // Asignar la nueva fuente al control
                control.Font = nuevaFuente;
            }
            else
            {
                // Manejar el caso en que no se haya cargado ninguna fuente
                MessageBox.Show("Error: No se cargó ninguna fuente personalizada.", "Error de fuente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

    public class TextoGuia
    {

        //Cuando el cuadro de texto obtiene el foco, este manejador de eventos se ejecutará.
        public void CuadroTexto_Enter(System.Windows.Forms.TextBox cuadroTexto, string textoMarcador)
        {
            if (cuadroTexto.Text == textoMarcador)
            {
                cuadroTexto.Clear();
                cuadroTexto.ForeColor = SystemColors.ActiveBorder;
            }
            else { CuadroTexto_Leave(cuadroTexto, textoMarcador); }
        }
        //Cuando el cuadro de texto pierde el foco, este manejador de eventos se ejecutará.
        public void CuadroTexto_Leave(System.Windows.Forms.TextBox cuadroTexto, string textoMarcador)
        {
            if (string.IsNullOrWhiteSpace(cuadroTexto.Text))
            {
                cuadroTexto.Clear();
                cuadroTexto.Text = textoMarcador;
                cuadroTexto.ForeColor = SystemColors.ActiveBorder;
            }
        }

        public void CuadroTexto_TextChanged(System.Windows.Forms.TextBox cuadroTexto)
        {
            // Cambiar el color a azul cuando se comienza a escribir
            if (cuadroTexto.ForeColor == SystemColors.ActiveBorder)
            {
                cuadroTexto.ForeColor = Color.SteelBlue;
            }
            if (string.IsNullOrWhiteSpace(cuadroTexto.Text))
            {
                cuadroTexto.ForeColor = SystemColors.ActiveBorder;
            }
        }

        public void CuadroTexto_TextChangedPassword(System.Windows.Forms.TextBox cuadroTexto)
        {
            // Cambiar el color a azul cuando se comienza a escribir
            if (cuadroTexto.ForeColor == SystemColors.ActiveBorder)
            {
                cuadroTexto.ForeColor = Color.SteelBlue;
                cuadroTexto.PasswordChar = '*';
            }
            if (string.IsNullOrWhiteSpace(cuadroTexto.Text))
            {
                cuadroTexto.ForeColor = SystemColors.ActiveBorder;

            }
        }

    }
}
