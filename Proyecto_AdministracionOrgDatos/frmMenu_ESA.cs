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
    public partial class frmMenu_ESA : Form
    {
        //Variables para las diferentes pantallas
        frmRegistrarBecarios_ESA PantallaRegistro;
        Mostrar_datos PantallaConsulta;

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

        private void btnInventario_ACO_Click(object sender, EventArgs e)
        {

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
            Application.Exit();
        }

        private void frmMenu_ESA_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void btnDarBaja_ESA_Click(object sender, EventArgs e)
        {
           
            
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



        //-----------------------------------------------------------------------

        //Aqui esta el codigo de deslizamiento de la barra de menu
        bool sidebarExpand;
        private void SideBarTimer_Tick(object sender, EventArgs e)
        {

            if (sidebarExpand)
            {
                
                sidebar.Width -= 10;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    SideBarTimer.Stop();
                }
            }else
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    SideBarTimer.Stop();
                }
            }
        }

        //Boton del menu
        private void menuButton_Click(object sender, EventArgs e)
        {
            SideBarTimer.Start();
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

    }
}
