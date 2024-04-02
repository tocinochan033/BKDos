using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Proyecto_AdministracionOrgDatos
{
    public partial class frmMenu_ESA : Form
    {
        Form loginForm = new FormLogin_ESA();
        private FuentePersonalizada fontPers = new FuentePersonalizada();

        //Variables para las diferentes pantallas
        frmRegistrarBecarios_ESA PantallaRegistro;
        Mostrar_datos PantallaConsulta;
        generarPDF PantallaPDF;

        //Variable para el calculo de la inactividad
        private Timer temporizadorInactividad;

        private static frmMenu_ESA instancia = null; //Inicializacion del formulario estatico

        //Metodo para obtener solamente un formulario abierto de tipo "frmMenu_ESA"
        public static frmMenu_ESA ventanaUnica()
        {   //Evaluar 
            if(instancia == null)
            {
                //Crear uno nuevo
                instancia = new frmMenu_ESA();
                return instancia;
            }
            //Regresar el que se creo con anterioridad
            return instancia;
        }

        public frmMenu_ESA()
        {
            InitializeComponent();
            activarTimer();
        }


        //Metodo para evaluar si ya se ha creado un formulario(evita duplicar)
        bool formIsOpen(string nombre_form)
        {   
            //Recorrer formulario hijos en el Padre
            foreach(var form_hijo in this.MdiChildren) 
            {
                //Validar si existe
                if(form_hijo.Text == nombre_form)
                {
                    form_hijo.Show();
                    return true; 
                }

                return false;
            }
            return false;
        }

        //Configuracion del boton de Registrar y modificar
        private void btnRegistrarUsuarios_ESA_Click(object sender, EventArgs e)
        {
            /*
            Form objRegistrarUsuarios_ACO = new frmRegistrarBecarios_ESA();
            objRegistrarUsuarios_ACO.Show();
            this.Hide();*/

            //Se comprueba si ese formulario existe para mostrarlo o crearlo
            if(formIsOpen("frmRegistrarBecarios_ESA")==false)
            {
                PantallaRegistro = new frmRegistrarBecarios_ESA();
                PantallaRegistro.FormClosed += PantallasCerradas;
                PantallaRegistro.MdiParent = this;
                PantallaRegistro.Show();
                
            }
            DatosInactividad.control = true; //Indicador
            timerInactividad.Enabled = false; //Detener temporizador(aplica solo al menu)
        }

        private void PantallasCerradas (object sender, FormClosedEventArgs e)
        {
            PantallaRegistro = null;
            PantallaConsulta = null;
        }


        // ----------------------------------------------------------------------

        private void btnCerrarSesion_ESA_Click(object sender, EventArgs e)
        {
            this.Hide(); loginForm.Show();
        }

        private void frmMenu_ESA_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }

        //Configuracion del boton de Consultas
        private void btnConsultar_ESA_Click(object sender, EventArgs e)
        {
            /*
            Form pbjMostrarDatos = new Mostrar_datos();
            pbjMostrarDatos.Show();
            this.Hide();*/

            //Se comprueba si ese formulario existe para mostrarlo o crearlo
            if (formIsOpen("Mostrar_datos") == false)
            {
                PantallaConsulta = new Mostrar_datos();
                PantallaConsulta.FormClosed += PantallasCerradas;
                PantallaConsulta.MdiParent = this;
                PantallaConsulta.Show();
            }
            DatosInactividad.control = true; //Indicador
            timerInactividad.Enabled = false; //Detener temporizador(aplica solo al menu)
        }


        private void frmMenu_ESA_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Al cerrar el formulario, entonces esa instancia creada se "limpia",
            //necesario para el metodo "ventanaUnica()"
            instancia = null; 
        }

        private void timerInactividad_Tick(object sender, EventArgs e)
        {
            //Evaluar tiempo de inactividad
            if (DatosInactividad.GetInputIdleTime().TotalSeconds > 1800)//30min
            {
                //Detener temporizador
                timerInactividad.Enabled = false;

                //Notificacion de inactividad
                MessageBox.Show("Inactividad detectada. Vuelva a iniciar sesion!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                //Cerra la ventana y regresar al login
                this.Close();
                Program.loginEstatico.Show();
            }
        }

        private void activarTimer()
        {   
            //Evaluar indicador, para volver a activar el temporizador y seguir 
            //validando la inactividad
            if (DatosInactividad.control == false)
            {    timerInactividad.Enabled = true; }
        }

        public void CargarFuentes()
        {
            // Cargar las fuente desde el archivo TTF
            string nombreFuente = "coolveticaRG.otf";
            fontPers.CargarFuentePersonalizada(nombreFuente);
            // Aplicar la fuente a la etiqueta en lblTitulo_ESA
            fontPers.AplicarFuente(label4, 48, FontStyle.Regular);
        }

        //Aqui estan las propiedades para agregar la fecha y la hora al programa
        private void FechaHora1_Tick(object sender, EventArgs e)
        {
                HoraC.Text = DateTime.Now.ToShortTimeString();
                FechaC.Text = DateTime.Now.ToShortDateString();
        }

        private void btnGenerarPDF_ESA_Click(object sender, EventArgs e)
        {
            
            if (formIsOpen("generarPDF") == false)
            {
                PantallaPDF = new generarPDF();
                PantallaPDF.FormClosed += PantallasCerradas;
                PantallaPDF.MdiParent = this;
                PantallaPDF.Show();

            }
            DatosInactividad.control = true; //Indicador
            timerInactividad.Enabled = false; //Detener temporizador(aplica solo al menu)
        }
    }
}
