using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Media;

//                              ATENCION
/*  Los roles son para crear una jerarquia interna y tener un control.
    El rol de 'obrera' tiene la misma funcionalidad de hasta ahora, no existe algun cambio alguno.
    El rol de 'mama oso' tambien posee la misma estrucutra, con la pecularidad de crear nuevos administradores
    'obrera'. Este rol tambien permite poder borrar a los administradores con etiqueta 'obrero' con confirmacion
    de su contraseña.
*/

//-------------------------------------------------------------------------------------------------------------//
///Estos cambios se pueden cambiar sin ningun problema, tanto como los nombres de los roles, como las caracteristicas de cada una.
///El tema de agregar los administradores 'mama oso' no he pensado si se requiere otro rol de jerarquia alta para crear uno, o el mismo rol permitira crearlos
///y degradar su etiqueta/dar aumento.

namespace Proyecto_AdministracionOrgDatos
{
    public partial class fmrRegistroAdmin : Form
    {
        FileStream login = new FileStream("login.txt", FileMode.Append, FileAccess.Write);
        Random rnd = new Random();

        public fmrRegistroAdmin()
        {
            InitializeComponent();
        }

        private void fmrRegistroAdmin_Load(object sender, EventArgs e)
        {
            //this.FormBorderStyle = FormBorderStyle.None;
        }

        public void camposLimpieza()
        {
            nombreTxt.Text = null;
            correoTxt.Text = null;
            numeroTxt.Text = null;
            rolCombo.Text  = null;
        }

        public void guardar()
        {
            using(StreamWriter writer = new StreamWriter(login))
            {
                //Nombre,Correo, Numero, Rol, contraseña;
                writer.WriteLine($"{nombreTxt.Text.ToLower()},{correoTxt.Text.ToLower()},{numeroTxt.Text},{rolCombo.Text},{rnd.Next(9999999)}");
            }
        }

        private void newAdminButton_Click(object sender, EventArgs e)
        {
            SystemSounds.Exclamation.Play();
            string confirmacion = Interaction.InputBox("Favor de confirmar contraseña", "Contraseña");

            if(int.Parse(confirmacion) == 2)
            {
                guardar();
                camposLimpieza();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Favor de no olvidar todos los datos en casa.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
