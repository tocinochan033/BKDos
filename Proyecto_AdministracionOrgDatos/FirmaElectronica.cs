using iTextSharp.text.pdf.intern;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Media;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_AdministracionOrgDatos
{
    public partial class FirmaElectronica : Form
    {
        private FuentePersonalizada fontPers;
        public FirmaElectronica()
        {
            InitializeComponent();
            //fuente personalizada
            fontPers = new FuentePersonalizada();
            //Para inicializar el Lienzo
            this.Width = 676;
            this.Height = 400;
            BM = new Bitmap(this.Width, this.Height);
            G = Graphics.FromImage(BM);
            G.Clear(Color.White);
            Lienzo.Image = BM;
        }

        //En este apartado estamos declarando las variables que usaremos para las respectivas herramientas:
        Bitmap BM;
        Graphics G;
        //Nos dira si la herramienta estara activa o no y en que localizacion
        bool Pintar = false;
        Point px, py;
        //Variable de la pluma
        Pen pluma = new Pen(Color.Black, 2);
        //Variable del borrador
        Pen borrador = new Pen(Color.White, 20);

        private void FirmaElectronica_Load(object sender, EventArgs e)
        {

        }

        int index;

        //Aqui es donde pintamos
        private void Lienzo_MouseDown(object sender, MouseEventArgs e)
        {
            Pintar = true;
            py = e.Location;
        }

        private void Lienzo_MouseMove(object sender, MouseEventArgs e)
        {
            if (Pintar)
            {
                if (index == 1)
                {
                    px = e.Location;
                    G.DrawLine(pluma, px, py);
                    py = px;
                }
                if (index == 2)
                {
                    px = e.Location;
                    G.DrawLine(borrador, px, py);
                    py = px;
                }
            }
            Lienzo.Refresh();

            }

        //Aqui dejamos de pintar
        private void Lienzo_MouseUp(object sender, MouseEventArgs e)
        {
            Pintar = false;
        }

        private void button_Pluma_Click(object sender, EventArgs e)
        {
            index = 1;
        }

        private void button_Borrador_Click(object sender, EventArgs e)
        {
            index = 2;
        }

        //Para limpiar el lienzo
        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            G.Clear(Color.White);
            Lienzo.Image = BM;
            index = 0;
        }

        //Para guardar la firma
        private void button_Guardar_Click(object sender, EventArgs e)
        {
            var GuardarF = new SaveFileDialog();
            GuardarF.Filter = "Image(*.jpg)|*.jpg|(*.*|*.*";
            if (GuardarF.ShowDialog() == DialogResult.OK)
            {
                Bitmap btm = BM.Clone(new Rectangle(0,0,Lienzo.Width,Lienzo.Height),BM.PixelFormat);
                btm.Save(GuardarF.FileName,ImageFormat.Jpeg);
            }
        }

        private void FirmaElectronica_FormClosing(object sender, FormClosingEventArgs e)
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
