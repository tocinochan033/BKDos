namespace Proyecto_AdministracionOrgDatos
{
    partial class FormLogin_ESA
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin_ESA));
            this.imgLogin_ESA = new System.Windows.Forms.PictureBox();
            this.btnSalir_ESA = new System.Windows.Forms.Button();
            this.btnInicioSesion_ESA = new System.Windows.Forms.Button();
            this.txtContraseña_ESA = new System.Windows.Forms.TextBox();
            this.txtUsuario_ESA = new System.Windows.Forms.TextBox();
            this.lblFecha_ESA = new System.Windows.Forms.Label();
            this.lblNombreAlumno_ESA = new System.Windows.Forms.Label();
            this.lblTitulo_ESA = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogin_ESA)).BeginInit();
            this.SuspendLayout();
            // 
            // imgLogin_ESA
            // 
            this.imgLogin_ESA.BackColor = System.Drawing.Color.DarkRed;
            this.imgLogin_ESA.ErrorImage = null;
            this.imgLogin_ESA.Image = ((System.Drawing.Image)(resources.GetObject("imgLogin_ESA.Image")));
            this.imgLogin_ESA.InitialImage = null;
            this.imgLogin_ESA.Location = new System.Drawing.Point(290, 89);
            this.imgLogin_ESA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.imgLogin_ESA.Name = "imgLogin_ESA";
            this.imgLogin_ESA.Size = new System.Drawing.Size(274, 258);
            this.imgLogin_ESA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLogin_ESA.TabIndex = 8;
            this.imgLogin_ESA.TabStop = false;
            this.imgLogin_ESA.Click += new System.EventHandler(this.imgLogin_ACO_Click);
            // 
            // btnSalir_ESA
            // 
            this.btnSalir_ESA.BackColor = System.Drawing.Color.Sienna;
            this.btnSalir_ESA.Font = new System.Drawing.Font("Bell MT", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir_ESA.ForeColor = System.Drawing.Color.Snow;
            this.btnSalir_ESA.Location = new System.Drawing.Point(631, 450);
            this.btnSalir_ESA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSalir_ESA.Name = "btnSalir_ESA";
            this.btnSalir_ESA.Size = new System.Drawing.Size(188, 44);
            this.btnSalir_ESA.TabIndex = 15;
            this.btnSalir_ESA.Text = "Salir";
            this.btnSalir_ESA.UseVisualStyleBackColor = false;
            this.btnSalir_ESA.Click += new System.EventHandler(this.btnSalir_ESA_Click);
            // 
            // btnInicioSesion_ESA
            // 
            this.btnInicioSesion_ESA.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnInicioSesion_ESA.Font = new System.Drawing.Font("Bell MT", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicioSesion_ESA.ForeColor = System.Drawing.Color.Snow;
            this.btnInicioSesion_ESA.Location = new System.Drawing.Point(260, 450);
            this.btnInicioSesion_ESA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnInicioSesion_ESA.Name = "btnInicioSesion_ESA";
            this.btnInicioSesion_ESA.Size = new System.Drawing.Size(324, 44);
            this.btnInicioSesion_ESA.TabIndex = 14;
            this.btnInicioSesion_ESA.Text = "Iniciar Sesión";
            this.btnInicioSesion_ESA.UseVisualStyleBackColor = false;
            this.btnInicioSesion_ESA.Click += new System.EventHandler(this.btnInicioSesion_ESA_Click);
            // 
            // txtContraseña_ESA
            // 
            this.txtContraseña_ESA.Font = new System.Drawing.Font("Bell MT", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraseña_ESA.Location = new System.Drawing.Point(260, 397);
            this.txtContraseña_ESA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtContraseña_ESA.Name = "txtContraseña_ESA";
            this.txtContraseña_ESA.PasswordChar = '*';
            this.txtContraseña_ESA.Size = new System.Drawing.Size(325, 41);
            this.txtContraseña_ESA.TabIndex = 13;
            // 
            // txtUsuario_ESA
            // 
            this.txtUsuario_ESA.Font = new System.Drawing.Font("Bell MT", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario_ESA.Location = new System.Drawing.Point(260, 353);
            this.txtUsuario_ESA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUsuario_ESA.Name = "txtUsuario_ESA";
            this.txtUsuario_ESA.Size = new System.Drawing.Size(325, 41);
            this.txtUsuario_ESA.TabIndex = 12;
            // 
            // lblFecha_ESA
            // 
            this.lblFecha_ESA.AutoSize = true;
            this.lblFecha_ESA.Font = new System.Drawing.Font("Bell MT", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha_ESA.ForeColor = System.Drawing.Color.Snow;
            this.lblFecha_ESA.Location = new System.Drawing.Point(626, 36);
            this.lblFecha_ESA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFecha_ESA.Name = "lblFecha_ESA";
            this.lblFecha_ESA.Size = new System.Drawing.Size(210, 29);
            this.lblFecha_ESA.TabIndex = 11;
            this.lblFecha_ESA.Text = "Fecha: 12-12-2020";
            // 
            // lblNombreAlumno_ESA
            // 
            this.lblNombreAlumno_ESA.AutoSize = true;
            this.lblNombreAlumno_ESA.Font = new System.Drawing.Font("Bell MT", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreAlumno_ESA.ForeColor = System.Drawing.Color.Snow;
            this.lblNombreAlumno_ESA.Location = new System.Drawing.Point(509, 7);
            this.lblNombreAlumno_ESA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreAlumno_ESA.Name = "lblNombreAlumno_ESA";
            this.lblNombreAlumno_ESA.Size = new System.Drawing.Size(334, 31);
            this.lblNombreAlumno_ESA.TabIndex = 10;
            this.lblNombreAlumno_ESA.Text = "Equipo los hijos del trueno";
            // 
            // lblTitulo_ESA
            // 
            this.lblTitulo_ESA.AutoSize = true;
            this.lblTitulo_ESA.Font = new System.Drawing.Font("Bell MT", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo_ESA.ForeColor = System.Drawing.Color.Snow;
            this.lblTitulo_ESA.Location = new System.Drawing.Point(42, 14);
            this.lblTitulo_ESA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo_ESA.Name = "lblTitulo_ESA";
            this.lblTitulo_ESA.Size = new System.Drawing.Size(398, 56);
            this.lblTitulo_ESA.TabIndex = 9;
            this.lblTitulo_ESA.Text = "Registro de becas";
            this.lblTitulo_ESA.Click += new System.EventHandler(this.lblTitulo_ACO_Click);
            // 
            // FormLogin_ESA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(847, 510);
            this.Controls.Add(this.imgLogin_ESA);
            this.Controls.Add(this.btnSalir_ESA);
            this.Controls.Add(this.btnInicioSesion_ESA);
            this.Controls.Add(this.txtContraseña_ESA);
            this.Controls.Add(this.txtUsuario_ESA);
            this.Controls.Add(this.lblFecha_ESA);
            this.Controls.Add(this.lblNombreAlumno_ESA);
            this.Controls.Add(this.lblTitulo_ESA);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormLogin_ESA";
            this.Text = "21u";
            ((System.ComponentModel.ISupportInitialize)(this.imgLogin_ESA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox imgLogin_ESA;
        private System.Windows.Forms.Button btnSalir_ESA;
        private System.Windows.Forms.Button btnInicioSesion_ESA;
        private System.Windows.Forms.TextBox txtContraseña_ESA;
        private System.Windows.Forms.TextBox txtUsuario_ESA;
        private System.Windows.Forms.Label lblFecha_ESA;
        private System.Windows.Forms.Label lblNombreAlumno_ESA;
        private System.Windows.Forms.Label lblTitulo_ESA;

    }
}

