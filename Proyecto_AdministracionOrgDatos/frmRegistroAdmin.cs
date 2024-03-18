using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Proyecto_AdministracionOrgDatos
{
    public partial class frmRegistroAdmin : Form
    {
        //crea aleatoriamente numeros de 6 digitos para la contraseña
        Random rnd = new Random();

        public frmRegistroAdmin()
        {
            InitializeComponent();
            cargaDatos();
        }

        private void cargaDatos() //Carga los datos al datagridview
        {
            //Imprime los datos guardados del archivo al datagridview
            int indiceNuevoRenglon;
            string nombre, correo, numero, rol;

            FileStream loginStream = new FileStream("login.txt", FileMode.OpenOrCreate, FileAccess.Read);

            using (StreamReader lector = new StreamReader(loginStream))
            {
                string renglon = lector.ReadLine();
                while (renglon != null)
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

                    renglon = lector.ReadLine();
                }
                loginStream.Close();
            }
        }

        private void newAdminButton_Click(object sender, EventArgs e)
        {
            //Añadir nuevo administrador
            SystemSounds.Exclamation.Play();
            string confirmacion = Interaction.InputBox("Favor de confirmar contraseña", "Contraseña"); //messageBox con textbos incluido. Confirma contraseña

            if (int.Parse(confirmacion) == 2) //Cada nuevo administrador requiere confirmacion de contraseña: 2
            {
                guardarDatos();
                camposLimpieza();
            }
            else
            {
                MessageBox.Show("Favor de no olvidar todos los datos en casa.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //login.Close();
        }

        private void guardarDatos() //campo para guarda los datos dentro de una linea nuevo del archivo
        {
            using (FileStream login = new FileStream("login.txt", FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(login))
                {
                    //nombre,correo,numero,rol,contraseña
                    writer.WriteLine($"{nombreTxt.Text.ToLower()},{correoTxt.Text.ToLower()},{numeroTxt.Text},{rolCombo.Text},{rnd.Next(9999999)}");
                }
                login.Close();
            }
        }

        public void camposLimpieza()
        {
            nombreTxt.Text = null;
            correoTxt.Text = null;
            numeroTxt.Text = null;
            rolCombo.Text = null;
        }

        private void eliminarAdminButton_Click(object sender, EventArgs e)
        {
            //Utiliza la misma logica para borrar datos de becarios. A excepcion de pedir contraseña: 2
            if (administradoresDataGrid.CurrentRow.Index > -1)
            {
                SystemSounds.Exclamation.Play();
                string confirmacion = Interaction.InputBox("Favor de confirmar contraseña", "Contraseña"); //messageBox con textbos incluido. Confirma contraseña

                if (int.Parse(confirmacion) == 2)
                {

                    administradoresDataGrid.Rows.RemoveAt(administradoresDataGrid.CurrentRow.Index);
                }
            }
        }

        private void confirmarTodoButton_Click(object sender, EventArgs e)
        {
            //Boton Confirmar todo
            sobreescribirDatos();
            this.Hide();
        }

        private void sobreescribirDatos()
        {
            ///Se guardan los datos de los becados en el archivo txt
            ///Se tiene que sobreescribir ya que si es que se eliminan datos
            ///los indices estarian mal para las siguientes veces que se desplegara el programa
            FileStream login = new FileStream("login.txt", FileMode.Create, FileAccess.Write);
            using (StreamWriter writer = new StreamWriter(login))
            {
                //Se recorren todas las filas del datagridview
                foreach (DataGridViewRow row in administradoresDataGrid.Rows)
                {
                    if (!row.IsNewRow) //borra las lineas vacios del archivo !NO BORRAR!
                    {
                        //nombre,correo,rol,numero
                        writer.WriteLine($"{row.Cells[0].Value},{row.Cells[1].Value},{row.Cells[2].Value},{row.Cells[3].Value}");
                    }
                }
            }
            //Se terminan de guardar los datos y se cierra el archivo
            login.Close();
        }
    }
}
