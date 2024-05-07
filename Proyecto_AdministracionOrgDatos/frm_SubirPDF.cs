using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_AdministracionOrgDatos
{
    public partial class frm_SubirPDF : Form
    {
        private FuentePersonalizada fontPers;
        public frm_SubirPDF()
        {
            InitializeComponent();
            fontPers = new FuentePersonalizada();
        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            OpenFileDialog Fd = new OpenFileDialog();
            DialogResult rs = Fd.ShowDialog();
            if(rs == DialogResult.OK)
            {
                //ImgCli.Image = Image.FromFile(Fd.FileName);
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

        private void frm_SubirPDF_Load(object sender, EventArgs e)
        {

        }

        public void CargarFuentes()
        {
            // Cargar las fuente desde el archivo TTF
            string nombreFuente = "coolveticaRG.otf";
            fontPers.CargarFuentePersonalizada(nombreFuente);
            // Aplicar la fuente a la etiqueta en lblTitulo_ESA
            fontPers.AplicarFuente(lblTitulo_ESA, 28, FontStyle.Regular);
        }
    }
}
