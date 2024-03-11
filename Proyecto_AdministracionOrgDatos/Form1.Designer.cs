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
            System.Windows.Forms.Button btnInicioSesion_ESA;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin_ESA));
            this.btnSalir_ESA = new System.Windows.Forms.Button();
            this.txtContraseña_ESA = new System.Windows.Forms.TextBox();
            this.txtUsuario_ESA = new System.Windows.Forms.TextBox();
            this.lblNombreAlumno_ESA = new System.Windows.Forms.Label();
            this.HoraFecha = new System.Windows.Forms.Timer(this.components);
            this.FechaC = new System.Windows.Forms.Label();
            this.HoraC = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errorLogin = new System.Windows.Forms.Label();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblTitulo_ESA = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            btnInicioSesion_ESA = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInicioSesion_ESA
            // 
            btnInicioSesion_ESA.BackColor = System.Drawing.Color.SteelBlue;
            btnInicioSesion_ESA.Cursor = System.Windows.Forms.Cursors.Hand;
            btnInicioSesion_ESA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnInicioSesion_ESA.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnInicioSesion_ESA.ForeColor = System.Drawing.Color.AliceBlue;
            btnInicioSesion_ESA.Location = new System.Drawing.Point(207, 244);
            btnInicioSesion_ESA.Margin = new System.Windows.Forms.Padding(2);
            btnInicioSesion_ESA.Name = "btnInicioSesion_ESA";
            btnInicioSesion_ESA.Size = new System.Drawing.Size(114, 25);
            btnInicioSesion_ESA.TabIndex = 14;
            btnInicioSesion_ESA.Text = "Iniciar Sesión";
            btnInicioSesion_ESA.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            btnInicioSesion_ESA.UseVisualStyleBackColor = false;
            btnInicioSesion_ESA.Click += new System.EventHandler(this.btnInicioSesion_ESA_Click);
            // 
            // btnSalir_ESA
            // 
            this.btnSalir_ESA.BackColor = System.Drawing.SystemColors.GrayText;
            this.btnSalir_ESA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir_ESA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir_ESA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir_ESA.ForeColor = System.Drawing.Color.Snow;
            this.btnSalir_ESA.Location = new System.Drawing.Point(163, 244);
            this.btnSalir_ESA.Margin = new System.Windows.Forms.Padding(2);
            this.btnSalir_ESA.Name = "btnSalir_ESA";
            this.btnSalir_ESA.Size = new System.Drawing.Size(44, 25);
            this.btnSalir_ESA.TabIndex = 15;
            this.btnSalir_ESA.Text = "Salir";
            this.btnSalir_ESA.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir_ESA.UseVisualStyleBackColor = false;
            this.btnSalir_ESA.Click += new System.EventHandler(this.btnSalir_ESA_Click);
            // 
            // txtContraseña_ESA
            // 
            this.txtContraseña_ESA.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtContraseña_ESA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContraseña_ESA.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraseña_ESA.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtContraseña_ESA.Location = new System.Drawing.Point(23, 170);
            this.txtContraseña_ESA.Margin = new System.Windows.Forms.Padding(2);
            this.txtContraseña_ESA.Name = "txtContraseña_ESA";
            this.txtContraseña_ESA.PasswordChar = '*';
            this.txtContraseña_ESA.Size = new System.Drawing.Size(298, 22);
            this.txtContraseña_ESA.TabIndex = 13;
            this.toolTip1.SetToolTip(this.txtContraseña_ESA, "Ingresa tu contraseña.");
            // 
            // txtUsuario_ESA
            // 
            this.txtUsuario_ESA.AccessibleDescription = "";
            this.txtUsuario_ESA.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUsuario_ESA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsuario_ESA.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario_ESA.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtUsuario_ESA.Location = new System.Drawing.Point(23, 114);
            this.txtUsuario_ESA.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuario_ESA.Name = "txtUsuario_ESA";
            this.txtUsuario_ESA.Size = new System.Drawing.Size(298, 22);
            this.txtUsuario_ESA.TabIndex = 12;
            this.toolTip1.SetToolTip(this.txtUsuario_ESA, "Ingresa tu nombre de usuario.");
            // 
            // lblNombreAlumno_ESA
            // 
            this.lblNombreAlumno_ESA.AutoSize = true;
            this.lblNombreAlumno_ESA.BackColor = System.Drawing.Color.White;
            this.lblNombreAlumno_ESA.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreAlumno_ESA.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblNombreAlumno_ESA.Location = new System.Drawing.Point(134, 58);
            this.lblNombreAlumno_ESA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreAlumno_ESA.Name = "lblNombreAlumno_ESA";
            this.lblNombreAlumno_ESA.Size = new System.Drawing.Size(168, 18);
            this.lblNombreAlumno_ESA.TabIndex = 10;
            this.lblNombreAlumno_ESA.Text = "Equipo \"Los hijos del trueno\"";
            // 
            // HoraFecha
            // 
            this.HoraFecha.Enabled = true;
            this.HoraFecha.Tick += new System.EventHandler(this.HoraFecha_Tick);
            // 
            // FechaC
            // 
            this.FechaC.AutoSize = true;
            this.FechaC.BackColor = System.Drawing.Color.White;
            this.FechaC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaC.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.FechaC.Location = new System.Drawing.Point(20, 256);
            this.FechaC.Name = "FechaC";
            this.FechaC.Size = new System.Drawing.Size(65, 13);
            this.FechaC.TabIndex = 16;
            this.FechaC.Text = "00/00/0000";
            // 
            // HoraC
            // 
            this.HoraC.AutoSize = true;
            this.HoraC.BackColor = System.Drawing.Color.White;
            this.HoraC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HoraC.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.HoraC.Location = new System.Drawing.Point(20, 238);
            this.HoraC.Name = "HoraC";
            this.HoraC.Size = new System.Drawing.Size(54, 13);
            this.HoraC.TabIndex = 17;
            this.HoraC.Text = "00:00 a.m";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(19, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Usuario :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(20, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Contraseña :";
            // 
            // errorLogin
            // 
            this.errorLogin.AutoSize = true;
            this.errorLogin.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLogin.ForeColor = System.Drawing.Color.SteelBlue;
            this.errorLogin.Location = new System.Drawing.Point(67, 203);
            this.errorLogin.Name = "errorLogin";
            this.errorLogin.Size = new System.Drawing.Size(188, 13);
            this.errorLogin.TabIndex = 20;
            this.errorLogin.Text = "Usuario y/o Contraseña incorrecto.";
            this.errorLogin.UseWaitCursor = true;
            this.errorLogin.Visible = false;
            // 
            // pictureBox15
            // 
            this.pictureBox15.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox15.Image")));
            this.pictureBox15.Location = new System.Drawing.Point(23, 135);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new System.Drawing.Size(298, 10);
            this.pictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox15.TabIndex = 91;
            this.pictureBox15.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(23, 188);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(298, 10);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 92;
            this.pictureBox2.TabStop = false;
            // 
            // lblTitulo_ESA
            // 
            this.lblTitulo_ESA.AutoSize = true;
            this.lblTitulo_ESA.BackColor = System.Drawing.Color.White;
            this.lblTitulo_ESA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTitulo_ESA.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo_ESA.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTitulo_ESA.Location = new System.Drawing.Point(11, 16);
            this.lblTitulo_ESA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo_ESA.Name = "lblTitulo_ESA";
            this.lblTitulo_ESA.Size = new System.Drawing.Size(337, 42);
            this.lblTitulo_ESA.TabIndex = 93;
            this.lblTitulo_ESA.Text = "Registro de becas";
            this.lblTitulo_ESA.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.SteelBlue;
            this.pictureBox3.Location = new System.Drawing.Point(340, -1);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(194, 282);
            this.pictureBox3.TabIndex = 94;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.SteelBlue;
            this.pictureBox1.Image = global::Proyecto_AdministracionOrgDatos.Properties.Resources._5bbd9abb_5618_4750_ad86_7379fc3a08a0;
            this.pictureBox1.Location = new System.Drawing.Point(347, 129);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(169, 157);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 95;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.SteelBlue;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(384, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 15);
            this.label3.TabIndex = 96;
            this.label3.Text = "Administrador de";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.SteelBlue;
            this.label4.Font = new System.Drawing.Font("Lovelo Black", 47.99999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(373, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 82);
            this.label4.TabIndex = 97;
            this.label4.Text = "BK2";
            // 
            // FormLogin_ESA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(527, 280);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTitulo_ESA);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox15);
            this.Controls.Add(this.errorLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HoraC);
            this.Controls.Add(this.FechaC);
            this.Controls.Add(this.btnSalir_ESA);
            this.Controls.Add(btnInicioSesion_ESA);
            this.Controls.Add(this.txtContraseña_ESA);
            this.Controls.Add(this.txtUsuario_ESA);
            this.Controls.Add(this.lblNombreAlumno_ESA);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox3);
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormLogin_ESA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BK2";
            this.Load += new System.EventHandler(this.FormLogin_ESA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSalir_ESA;
        private System.Windows.Forms.TextBox txtContraseña_ESA;
        private System.Windows.Forms.TextBox txtUsuario_ESA;
        private System.Windows.Forms.Label lblNombreAlumno_ESA;
        private System.Windows.Forms.Timer HoraFecha;
        private System.Windows.Forms.Label FechaC;
        private System.Windows.Forms.Label HoraC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label errorLogin;
        private System.Windows.Forms.PictureBox pictureBox15;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblTitulo_ESA;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

