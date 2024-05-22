using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_AdministracionOrgDatos
{
    public partial class FrmEditarFoto : Form
    {
        //declaro objeto que se va a heredar
        private object SelecID;
        private object SelectPater;
        private object SelectApe;
        private object SelectNom;

       

        //Comando objeto del tipo SQLcommand para representar las instrucciones SQL NO SE BORRA
        SqlCommand Comando;
        public FrmEditarFoto(object SelecID, object SelectPater, object SelectApe, object SelectNom)
        {
            InitializeComponent();
            this.SelecID = SelecID;
            this.SelectPater = SelectPater;
            this.SelectApe = SelectApe;
            this.SelectNom = SelectNom;
            //Llena los texbox del id

            txtId.Text= SelecID.ToString();
            txtNombres.Text = SelectPater.ToString() + " " + SelectApe.ToString() + " " + SelectNom.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

      //public void Llenarcampos
        //{

        //}


        private void btnModificar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = DB_Conexion.GetConnection())
            {
               string Sql = "";

                //UPDATE Nombre Tabla SET campo = @variable WHERE valor de referencias
                Sql = "UPDATE DatosGenerales set Imagen = @Imagen WHERE Id_Alumno = @Id_Alumno";
                Comando = new SqlCommand(Sql, con);
                Comando.Parameters.AddWithValue("@Id_Alumno", txtId.Text);
                byte[] imageBytes;
                using (MemoryStream ms = new MemoryStream())
                {
                    pbxImagen.Image.Save(ms, pbxImagen.Image.RawFormat);
                    imageBytes = ms.ToArray();
                }
                Comando.Parameters.AddWithValue("@Imagen", imageBytes);
                
                try
                {
                    //Ejecutamos la instruccion del sql para afectar las filas
                    Comando.ExecuteNonQuery();

                    MessageBox.Show("Registro Actualizado: Imagen");
                    //  RefresacarDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error tabla general: " + ex.Message);
                }
            }
               
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnImg_Click(object sender, EventArgs e)
        {
            //Abre ventana para seleccionar archivo
            OpenFileDialog foto = new OpenFileDialog();
            //Dialogo para confirmar seleccion
            DialogResult result = foto.ShowDialog();
            if (result == DialogResult.OK)
            {
                pbxImagen.Image = Image.FromFile(foto.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void FrmEditarFoto_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
               
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
    }
}
