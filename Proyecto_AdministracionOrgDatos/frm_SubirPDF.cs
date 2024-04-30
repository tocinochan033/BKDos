using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_AdministracionOrgDatos
{
    public partial class frm_SubirPDF : Form
    {
        public frm_SubirPDF()
        {
            InitializeComponent();
        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            OpenFileDialog Fd = new OpenFileDialog();
            DialogResult rs = Fd.ShowDialog();
            if(rs == DialogResult.OK)
            {
                ImgCli.Image = Image.FromFile(Fd.FileName);
            }
        }
    }
}
