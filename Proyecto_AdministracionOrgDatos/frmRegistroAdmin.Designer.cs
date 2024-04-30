namespace Proyecto_AdministracionOrgDatos
{
    partial class frmRegistroAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAdminContra = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.newAdminButton = new System.Windows.Forms.Button();
            this.rolCombo = new System.Windows.Forms.ComboBox();
            this.Rol = new System.Windows.Forms.Label();
            this.correoTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numeroTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nombreTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.eliminarAdminButton = new System.Windows.Forms.Button();
            this.administradoresDataGrid = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.administradoresDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nuevo";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(415, 15);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(505, 398);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.txtAdminContra);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtContrasena);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.newAdminButton);
            this.tabPage1.Controls.Add(this.rolCombo);
            this.tabPage1.Controls.Add(this.Rol);
            this.tabPage1.Controls.Add(this.correoTxt);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.numeroTxt);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.nombreTxt);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(497, 369);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Nuevo Admin...";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.label9.Location = new System.Drawing.Point(132, 103);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(248, 15);
            this.label9.TabIndex = 13;
            this.label9.Text = "El correo debe contener un @ y terminar en .com";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.label8.Location = new System.Drawing.Point(131, 97);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 28);
            this.label8.TabIndex = 12;
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // txtAdminContra
            // 
            this.txtAdminContra.Location = new System.Drawing.Point(231, 258);
            this.txtAdminContra.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAdminContra.Name = "txtAdminContra";
            this.txtAdminContra.Size = new System.Drawing.Size(217, 22);
            this.txtAdminContra.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.label7.Location = new System.Drawing.Point(225, 229);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 28);
            this.label7.TabIndex = 11;
            this.label7.Text = "Contraseña Admin:";
            // 
            // txtContrasena
            // 
            this.txtContrasena.Location = new System.Drawing.Point(41, 258);
            this.txtContrasena.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(163, 22);
            this.txtContrasena.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.label6.Location = new System.Drawing.Point(36, 229);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 28);
            this.label6.TabIndex = 9;
            this.label6.Text = "Contraseña:";
            // 
            // newAdminButton
            // 
            this.newAdminButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.newAdminButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newAdminButton.ForeColor = System.Drawing.Color.White;
            this.newAdminButton.Location = new System.Drawing.Point(72, 319);
            this.newAdminButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.newAdminButton.Name = "newAdminButton";
            this.newAdminButton.Size = new System.Drawing.Size(344, 39);
            this.newAdminButton.TabIndex = 8;
            this.newAdminButton.Text = "Nuevo Administrador";
            this.newAdminButton.UseVisualStyleBackColor = false;
            this.newAdminButton.Click += new System.EventHandler(this.newAdminButton_Click);
            // 
            // rolCombo
            // 
            this.rolCombo.FormattingEnabled = true;
            this.rolCombo.Items.AddRange(new object[] {
            "Gerente",
            "Administrador general"});
            this.rolCombo.Location = new System.Drawing.Point(41, 199);
            this.rolCombo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rolCombo.Name = "rolCombo";
            this.rolCombo.Size = new System.Drawing.Size(163, 24);
            this.rolCombo.TabIndex = 3;
            // 
            // Rol
            // 
            this.Rol.AutoSize = true;
            this.Rol.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.Rol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.Rol.Location = new System.Drawing.Point(36, 170);
            this.Rol.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Rol.Name = "Rol";
            this.Rol.Size = new System.Drawing.Size(45, 28);
            this.Rol.TabIndex = 6;
            this.Rol.Text = "Rol:";
            // 
            // correoTxt
            // 
            this.correoTxt.Location = new System.Drawing.Point(41, 127);
            this.correoTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.correoTxt.Name = "correoTxt";
            this.correoTxt.Size = new System.Drawing.Size(407, 22);
            this.correoTxt.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.label5.Location = new System.Drawing.Point(36, 97);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 28);
            this.label5.TabIndex = 4;
            this.label5.Text = "Correo:";
            // 
            // numeroTxt
            // 
            this.numeroTxt.Location = new System.Drawing.Point(231, 199);
            this.numeroTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numeroTxt.Name = "numeroTxt";
            this.numeroTxt.Size = new System.Drawing.Size(217, 22);
            this.numeroTxt.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.label4.Location = new System.Drawing.Point(225, 170);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 28);
            this.label4.TabIndex = 2;
            this.label4.Text = "Numero Telefono:";
            // 
            // nombreTxt
            // 
            this.nombreTxt.Location = new System.Drawing.Point(41, 60);
            this.nombreTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nombreTxt.Name = "nombreTxt";
            this.nombreTxt.Size = new System.Drawing.Size(407, 22);
            this.nombreTxt.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.label3.Location = new System.Drawing.Point(36, 31);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nombre:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.eliminarAdminButton);
            this.tabPage2.Controls.Add(this.administradoresDataGrid);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(497, 369);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Borrar Admin...";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // eliminarAdminButton
            // 
            this.eliminarAdminButton.Location = new System.Drawing.Point(16, 20);
            this.eliminarAdminButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.eliminarAdminButton.Name = "eliminarAdminButton";
            this.eliminarAdminButton.Size = new System.Drawing.Size(211, 41);
            this.eliminarAdminButton.TabIndex = 1;
            this.eliminarAdminButton.Text = "Eliminar Administrador";
            this.eliminarAdminButton.UseVisualStyleBackColor = true;
            this.eliminarAdminButton.Click += new System.EventHandler(this.eliminarAdminButton_Click);
            // 
            // administradoresDataGrid
            // 
            this.administradoresDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.administradoresDataGrid.Location = new System.Drawing.Point(16, 68);
            this.administradoresDataGrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.administradoresDataGrid.Name = "administradoresDataGrid";
            this.administradoresDataGrid.RowHeadersWidth = 51;
            this.administradoresDataGrid.Size = new System.Drawing.Size(456, 303);
            this.administradoresDataGrid.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.pictureBox1.Location = new System.Drawing.Point(-8, -12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(399, 447);
            this.pictureBox1.TabIndex = 74;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.pictureBox2.Image = global::Proyecto_AdministracionOrgDatos.Properties.Resources.AddAdminImagen;
            this.pictureBox2.Location = new System.Drawing.Point(69, 169);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(309, 261);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 75;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(16, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 39);
            this.label2.TabIndex = 76;
            this.label2.Text = "Administrador";
            // 
            // frmRegistroAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 427);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmRegistroAdmin";
            this.Text = "frmRegistroAdmin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRegistroAdmin_FormClosing);
            this.Load += new System.EventHandler(this.frmRegistroAdmin_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.administradoresDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox rolCombo;
        private System.Windows.Forms.Label Rol;
        private System.Windows.Forms.TextBox correoTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox numeroTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nombreTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView administradoresDataGrid;
        private System.Windows.Forms.Button newAdminButton;
        private System.Windows.Forms.Button eliminarAdminButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAdminContra;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}