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
    public partial class frmRegistrarBecarios_ESA : Form
    {
        public frmRegistrarBecarios_ESA()
        {
            InitializeComponent();

            string nombre, telefono, correo, estado;
            int indicieNuevoRenglon;

            //Abrimos el archivo de texto en modo lectura
            FileStream becados = new FileStream("Becados.txt",FileMode.OpenOrCreate,FileAccess.Read);

            //Leemos linea por linea y cargamos esta misma en el datagridview
            using(StreamReader lector = new StreamReader(becados))
            {
                string renglon = lector.ReadLine();
                while (renglon != null)
                {
                    //Se usa el metodo split para leer los datos de manera individual
                    string[] datos = renglon.Split(',');

                    //Adicionamos nuevo renglon y regresamos su indice
                    indicieNuevoRenglon = dgv_Agregar.Rows.Add();

                    //Asignamos el valor a las variables
                    nombre = datos[0];
                    telefono = datos[1];
                    correo = datos[2];
                    estado = datos[3];

                    //Colocamos la informacion en el datagridview
                    dgv_Agregar.Rows[indicieNuevoRenglon].Cells[0].Value = nombre;
                    dgv_Agregar.Rows[indicieNuevoRenglon].Cells[1].Value = telefono;
                    dgv_Agregar.Rows[indicieNuevoRenglon].Cells[2].Value = correo;
                    dgv_Agregar.Rows[indicieNuevoRenglon].Cells[3].Value = estado;

                    renglon = lector.ReadLine();
                }
            }
            becados.Close();
        }

        private void btnRegresarMenu_ESA_Click(object sender, EventArgs e)
        {
            //Guarda los datos y regresa a la pantalla anterior
            Guardar();
            Form objMenu_ESA = new frmMenu_ESA();
            objMenu_ESA.Show();
            this.Hide();

        }

        private bool camposImcompletos()
        {
            return txtNombre_ESA.Text == "" || TxtCorreo_ESA.Text == "" || Txt_Estado_ESA.Text == "" || Txt_Telefono_ESA.Text == "";
        }

        private void btnAgregar_ESA_Click(object sender, EventArgs e)
        {
            if(camposImcompletos())
            {
                MessageBox.Show("Favor de no olvidar todos los datos en casa.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNombre_ESA.Focus();
            }
            else
            {
                int indiceNuevaFila;

                //Sirve para adicionar un nuevo renglon y guardar el indice de este mismo
                indiceNuevaFila = dgv_Agregar.Rows.Add();

                //Colocamos la informacion en el DataGridView
                dgv_Agregar.Rows[indiceNuevaFila].Cells[0].Value = txtNombre_ESA.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[1].Value = Txt_Telefono_ESA.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[2].Value = TxtCorreo_ESA.Text;
                dgv_Agregar.Rows[indiceNuevaFila].Cells[3].Value = Txt_Estado_ESA.Text;

                txtNombre_ESA.Text = "";
                Txt_Telefono_ESA.Text = "";
                TxtCorreo_ESA.Text = "";
                Txt_Estado_ESA.Text = "";

                //Regresar el "cursor" al label del nombre
                txtNombre_ESA.Focus();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Verificamos si hay una celda seleccionada
            if (this.dgv_Agregar.SelectedRows.Count == 1)
            {
                //Se cargan los datos actuales en los textbox en el datagridview para actualizar sus valores
                int seleccion = dgv_Agregar.CurrentRow.Index;
                dgv_Agregar.Rows[seleccion].Cells[0].Value = txtNombre_ESA.Text;
                dgv_Agregar.Rows[seleccion].Cells[1].Value = Txt_Telefono_ESA.Text;
                dgv_Agregar.Rows[seleccion].Cells[2].Value = TxtCorreo_ESA.Text;
                dgv_Agregar.Rows[seleccion].Cells[3].Value = Txt_Estado_ESA.Text;

                //Limpiamos espacios para evitar errores
                txtNombre_ESA.Text = "";
                Txt_Telefono_ESA.Text = "";
                TxtCorreo_ESA.Text = "";
                Txt_Estado_ESA.Text = "";

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Verificamos si hay una fila seleccionada
            if(dgv_Agregar.CurrentRow.Index > -1)
            {
                DialogResult confirmacion = MessageBox.Show("¿Está seguro que desea eliminar esta fila permanentemente? Permanentemente es mucho tiempo.", 
                    "Confirmar eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                
                //Usuario confirma eliminacion
                if(confirmacion == DialogResult.Yes)
                {
                    dgv_Agregar.Rows.RemoveAt(dgv_Agregar.CurrentRow.Index);
                }
            }
        }

        private void dgv_Agregar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Verificamos si hay una celda seleccionada
            if(this.dgv_Agregar.SelectedRows.Count == 1)
            {
                //Definimos el indice de la fila
                int seleccion = dgv_Agregar.CurrentRow.Index;

                //Cargamos los textbox con los datos de la fila seleccionada en sus celdas correspondientes
                txtNombre_ESA.Text = dgv_Agregar.Rows[seleccion].Cells[0].Value.ToString();
                Txt_Telefono_ESA.Text = dgv_Agregar.Rows[seleccion].Cells[1].Value.ToString();
                TxtCorreo_ESA.Text = dgv_Agregar.Rows[seleccion].Cells[2].Value.ToString();
                Txt_Estado_ESA.Text = dgv_Agregar.Rows[seleccion].Cells[3].Value.ToString();
            }
        }

        private void Guardar()
        {
            ///Se guardan los datos de los becados en el archivo txt
            ///Se tiene que sobreescribir ya que si es que se eliminan datos
            ///los indices estarian mal para las siguientes veces que se desplegara el programa
            FileStream becados = new FileStream("Becados.txt", FileMode.Create, FileAccess.Write);
            using (StreamWriter writer = new StreamWriter(becados))
            {
                //Se recorren todas las filas del datagridview
                foreach(DataGridViewRow row in dgv_Agregar.Rows)
                {
                    writer.WriteLine($"{row.Cells[0].Value},{row.Cells[1].Value},{row.Cells[2].Value},{row.Cells[3].Value}");
                }
            }
            //Se terminan de guardar los datos y se cierra el archivo
            becados.Close();    
        }

        //Aqui estan las propiedades para agregar la fecha y la hora al programa
        private void FechaHora2_Tick(object sender, EventArgs e)
        {
            HoraC.Text = DateTime.Now.ToShortTimeString();
            FechaC.Text = DateTime.Now.ToShortDateString();
        }

        private void frmRegistrarBecarios_ESA_Load(object sender, EventArgs e)
        {

        }

        private void dgv_Agregar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
