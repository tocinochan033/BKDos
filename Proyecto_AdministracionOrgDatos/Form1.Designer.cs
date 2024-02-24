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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin_ESA));
            this.imgLogin_ESA = new System.Windows.Forms.PictureBox();
            this.btnSalir_ESA = new System.Windows.Forms.Button();
            this.btnInicioSesion_ESA = new System.Windows.Forms.Button();
            this.txtContraseña_ESA = new System.Windows.Forms.TextBox();
            this.txtUsuario_ESA = new System.Windows.Forms.TextBox();
            this.lblNombreAlumno_ESA = new System.Windows.Forms.Label();
            this.lblTitulo_ESA = new System.Windows.Forms.Label();
            this.HoraFecha = new System.Windows.Forms.Timer(this.components);
            this.FechaC = new System.Windows.Forms.Label();
            this.HoraC = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errorLogin = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogin_ESA)).BeginInit();
            this.SuspendLayout();
            // 
            // imgLogin_ESA
            // 
            this.imgLogin_ESA.BackColor = System.Drawing.Color.WhiteSmoke;
            this.imgLogin_ESA.ErrorImage = null;
            this.imgLogin_ESA.Image = ((System.Drawing.Image)(resources.GetObject("imgLogin_ESA.Image")));
            this.imgLogin_ESA.InitialImage = null;
            this.imgLogin_ESA.Location = new System.Drawing.Point(63, 111);
            this.imgLogin_ESA.Margin = new System.Windows.Forms.Padding(2);
            this.imgLogin_ESA.Name = "imgLogin_ESA";
            this.imgLogin_ESA.Size = new System.Drawing.Size(334, 322);
            this.imgLogin_ESA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLogin_ESA.TabIndex = 8;
            this.imgLogin_ESA.TabStop = false;
            this.imgLogin_ESA.Click += new System.EventHandler(this.imgLogin_ACO_Click);
            // 
            // btnSalir_ESA
            // 
            this.btnSalir_ESA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnSalir_ESA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir_ESA.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir_ESA.ForeColor = System.Drawing.Color.Snow;
            this.btnSalir_ESA.Location = new System.Drawing.Point(705, 449);
            this.btnSalir_ESA.Margin = new System.Windows.Forms.Padding(2);
            this.btnSalir_ESA.Name = "btnSalir_ESA";
            this.btnSalir_ESA.Size = new System.Drawing.Size(126, 44);
            this.btnSalir_ESA.TabIndex = 15;
            this.btnSalir_ESA.Text = "Salir";
            this.btnSalir_ESA.UseVisualStyleBackColor = false;
            this.btnSalir_ESA.Click += new System.EventHandler(this.btnSalir_ESA_Click);
            // 
            // btnInicioSesion_ESA
            // 
            this.btnInicioSesion_ESA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(87)))), ((int)(((byte)(137)))));
            this.btnInicioSesion_ESA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInicioSesion_ESA.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicioSesion_ESA.ForeColor = System.Drawing.Color.Snow;
            this.btnInicioSesion_ESA.Location = new System.Drawing.Point(488, 371);
            this.btnInicioSesion_ESA.Margin = new System.Windows.Forms.Padding(2);
            this.btnInicioSesion_ESA.Name = "btnInicioSesion_ESA";
            this.btnInicioSesion_ESA.Size = new System.Drawing.Size(240, 44);
            this.btnInicioSesion_ESA.TabIndex = 14;
            this.btnInicioSesion_ESA.Text = "Iniciar Sesión";
            this.btnInicioSesion_ESA.UseVisualStyleBackColor = false;
            this.btnInicioSesion_ESA.Click += new System.EventHandler(this.btnInicioSesion_ESA_Click);
            // 
            // txtContraseña_ESA
            // 
            this.txtContraseña_ESA.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraseña_ESA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtContraseña_ESA.Location = new System.Drawing.Point(450, 271);
            this.txtContraseña_ESA.Margin = new System.Windows.Forms.Padding(2);
            this.txtContraseña_ESA.Name = "txtContraseña_ESA";
            this.txtContraseña_ESA.PasswordChar = '*';
            this.txtContraseña_ESA.Size = new System.Drawing.Size(325, 38);
            this.txtContraseña_ESA.TabIndex = 13;
            // 
            // txtUsuario_ESA
            // 
            this.txtUsuario_ESA.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario_ESA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtUsuario_ESA.Location = new System.Drawing.Point(450, 176);
            this.txtUsuario_ESA.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuario_ESA.Name = "txtUsuario_ESA";
            this.txtUsuario_ESA.Size = new System.Drawing.Size(325, 38);
            this.txtUsuario_ESA.TabIndex = 12;
            // 
            // lblNombreAlumno_ESA
            // 
            this.lblNombreAlumno_ESA.AutoSize = true;
            this.lblNombreAlumno_ESA.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreAlumno_ESA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(87)))), ((int)(((byte)(137)))));
            this.lblNombreAlumno_ESA.Location = new System.Drawing.Point(16, 59);
            this.lblNombreAlumno_ESA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreAlumno_ESA.Name = "lblNombreAlumno_ESA";
            this.lblNombreAlumno_ESA.Size = new System.Drawing.Size(287, 25);
            this.lblNombreAlumno_ESA.TabIndex = 10;
            this.lblNombreAlumno_ESA.Text = "Equipo \"Los hijos del trueno\"";
            // 
            // lblTitulo_ESA
            // 
            this.lblTitulo_ESA.AutoSize = true;
            this.lblTitulo_ESA.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitulo_ESA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTitulo_ESA.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo_ESA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblTitulo_ESA.Location = new System.Drawing.Point(11, 9);
            this.lblTitulo_ESA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo_ESA.Name = "lblTitulo_ESA";
            this.lblTitulo_ESA.Size = new System.Drawing.Size(296, 39);
            this.lblTitulo_ESA.TabIndex = 9;
            this.lblTitulo_ESA.Text = "Registro de becas";
            this.lblTitulo_ESA.Click += new System.EventHandler(this.lblTitulo_ACO_Click);
            // 
            // HoraFecha
            // 
            this.HoraFecha.Enabled = true;
            this.HoraFecha.Tick += new System.EventHandler(this.HoraFecha_Tick);
            // 
            // FechaC
            // 
            this.FechaC.AutoSize = true;
            this.FechaC.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(87)))), ((int)(((byte)(137)))));
            this.FechaC.Location = new System.Drawing.Point(652, 9);
            this.FechaC.Name = "FechaC";
            this.FechaC.Size = new System.Drawing.Size(160, 31);
            this.FechaC.TabIndex = 16;
            this.FechaC.Text = "00/00/0000";
            // 
            // HoraC
            // 
            this.HoraC.AutoSize = true;
            this.HoraC.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HoraC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(87)))), ((int)(((byte)(137)))));
            this.HoraC.Location = new System.Drawing.Point(680, 39);
            this.HoraC.Name = "HoraC";
            this.HoraC.Size = new System.Drawing.Size(143, 31);
            this.HoraC.TabIndex = 17;
            this.HoraC.Text = "00:00 a.m";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(87)))), ((int)(((byte)(137)))));
            this.label1.Location = new System.Drawing.Point(443, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 31);
            this.label1.TabIndex = 18;
            this.label1.Text = "Usuario :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(87)))), ((int)(((byte)(137)))));
            this.label2.Location = new System.Drawing.Point(443, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 31);
            this.label2.TabIndex = 19;
            this.label2.Text = "Contraseña :";
            // 
            // errorLogin
            // 
            this.errorLogin.AutoSize = true;
            this.errorLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLogin.ForeColor = System.Drawing.Color.Red;
            this.errorLogin.Location = new System.Drawing.Point(446, 326);
            this.errorLogin.Name = "errorLogin";
            this.errorLogin.Size = new System.Drawing.Size(210, 16);
            this.errorLogin.TabIndex = 20;
            this.errorLogin.Text = "Usuario y/o Contraseña incorrecto";
            this.errorLogin.UseWaitCursor = true;
            this.errorLogin.Visible = false;
            // 
            // FormLogin_ESA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(847, 510);
            this.Controls.Add(this.errorLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HoraC);
            this.Controls.Add(this.FechaC);
            this.Controls.Add(this.imgLogin_ESA);
            this.Controls.Add(this.btnSalir_ESA);
            this.Controls.Add(this.btnInicioSesion_ESA);
            this.Controls.Add(this.txtContraseña_ESA);
            this.Controls.Add(this.txtUsuario_ESA);
            this.Controls.Add(this.lblNombreAlumno_ESA);
            this.Controls.Add(this.lblTitulo_ESA);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormLogin_ESA";
            this.Text = "BK2";
            this.Load += new System.EventHandler(this.FormLogin_ESA_Load);
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
        private System.Windows.Forms.Label lblNombreAlumno_ESA;
        private System.Windows.Forms.Label lblTitulo_ESA;
        private System.Windows.Forms.Timer HoraFecha;
        private System.Windows.Forms.Label FechaC;
        private System.Windows.Forms.Label HoraC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label errorLogin;
    }
}

