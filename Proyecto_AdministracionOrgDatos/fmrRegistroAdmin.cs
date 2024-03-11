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
    de su contraseña (NO IMPLEMENTADO).
*/

//-------------------------------------------------------------------------------------------------------------//
///Estos cambios se pueden cambiar sin ningun problema, tanto como los nombres de los roles, como las caracteristicas de cada una.
///El tema de agregar los administradores 'mama oso' no he pensado si se requiere otro rol de jerarquia alta para crear uno, o el mismo rol permitira crearlos
///y degradar su etiqueta/dar aumento.

namespace Proyecto_AdministracionOrgDatos
{
    public partial class fmrRegistroAdmin : Form
    {
        //crea aleatoriamente numeros de 6 digitos para la contraseña
        Random rnd = new Random();

        public fmrRegistroAdmin()
        {
            InitializeComponent();
            cargaDatos();
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

        public void guardar() //campo para guarda los datos dentro de una linea nuevo del archivo
        {
            using(FileStream login = new FileStream("login.txt", FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(login))
                {
                    //nombre,correo,numero,rol,contraseña
                    writer.WriteLine($"{nombreTxt.Text.ToLower()},{correoTxt.Text.ToLower()},{numeroTxt.Text},{rolCombo.Text},{rnd.Next(9999999)}");
                }
                login.Close();
            }
        }

        private void newAdminButton_Click(object sender, EventArgs e)
        {
            SystemSounds.Exclamation.Play();
            string confirmacion = Interaction.InputBox("Favor de confirmar contraseña", "Contraseña"); //messageBox con textbos incluido. Confirma contraseña

            if(int.Parse(confirmacion) == 2) //Cada nuevo administrador requiere confirmacion de contraseña: 2
            {
                guardar();
                camposLimpieza();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Favor de no olvidar todos los datos en casa.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //login.Close();
        }

        public void cargaDatos()
        {
            int indiceNuevoRenglon;
            string nombre, correo, numero, rol;

            using (FileStream loginStream = new FileStream("login.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader lector = new StreamReader(loginStream))
                {
                    string renglon;
                    while ((renglon = lector.ReadLine()) != null)
                    {
                        string[] datos = renglon.Split(',');

                        indiceNuevoRenglon = administradoresDataGrid.Rows.Add();

                        nombre = datos[0];
                        correo = datos[1];
                        rol = datos[2];
                        numero = datos[3];

                        administradoresDataGrid.Rows[indiceNuevoRenglon].Cells[0].Value = nombre;
                        administradoresDataGrid.Rows[indiceNuevoRenglon].Cells[1].Value = correo;
                        administradoresDataGrid.Rows[indiceNuevoRenglon].Cells[2].Value = rol;
                        administradoresDataGrid.Rows[indiceNuevoRenglon].Cells[3].Value = numero;
                    }
                    loginStream.Close();
                }
            }
        }
    }
}

