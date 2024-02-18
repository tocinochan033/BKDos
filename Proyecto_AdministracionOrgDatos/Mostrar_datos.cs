using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_AdministracionOrgDatos
{
    public partial class Mostrar_datos : Form
    {
        public Mostrar_datos()
        {
            InitializeComponent();

            //Se inicializan variables 
            string nombre, telefono, correo, estado;
            int auxiliar;

            //Se cargan las variables del archivo de texto

            //Abrimos el archivo de texto en modo lectura
            FileStream becados = new FileStream("Becados.txt", FileMode.OpenOrCreate, FileAccess.Read);

            //Leemos linea por linea y cargamos esta misma en el datagridview
            using (StreamReader lector = new StreamReader(becados))
            {
                string renglon = lector.ReadLine();
                while (renglon != null)
                {
                    //Se usa el metodo split para leer los datos de manera individual
                    string[] datos = renglon.Split(',');

                    //Adicionamos nuevo renglon y regresamos su indice
                    auxiliar = dgvMostrar.Rows.Add();

                    //Asignamos el valor a las variables
                    nombre = datos[0];
                    telefono = datos[1];
                    correo = datos[2];
                    estado = datos[3];

                    //Colocamos la informacion en el datagridview
                    dgvMostrar.Rows[auxiliar].Cells[0].Value = nombre;
                    dgvMostrar.Rows[auxiliar].Cells[1].Value = telefono;
                    dgvMostrar.Rows[auxiliar].Cells[2].Value = correo;
                    dgvMostrar.Rows[auxiliar].Cells[3].Value = estado;

                    renglon = lector.ReadLine();
                }
            }
            //Finalizamos la carga y cerramos el archivo
            becados.Close();
        }

        private void dgv_Agregar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Verificamos si hay una fila seleccionada
            if (dgvMostrar.CurrentRow.Index > -1)
            {
                //Nota: "RemoveAt" borra lo seleccionado en base al index
                dgvMostrar.Rows.RemoveAt(dgvMostrar.CurrentRow.Index);
                Guardar();
            }
           
        }

        private void Guardar()
        {
            //Se guardan los datos de los becados en el archivo txt
            //Se tiene que sobreescribir ya que si es que se eliminan datos
            //los indices estarian mal para las siguientes veces que se desplegara el programa
            FileStream becados = new FileStream("Becados.txt", FileMode.Create, FileAccess.Write);
            using (StreamWriter writer = new StreamWriter(becados))
            {
                //Se recorren todas las filas del datagridview
                foreach (DataGridViewRow row in dgvMostrar.Rows)
                {
                    writer.WriteLine($"{row.Cells[0].Value},{row.Cells[1].Value},{row.Cells[2].Value},{row.Cells[3].Value}");
                }
            }
            //Se terminan de guardar los datos y se cierra el archivo
            becados.Close();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Form objMenu_ESA = new frmMenu_ESA();
            objMenu_ESA.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
