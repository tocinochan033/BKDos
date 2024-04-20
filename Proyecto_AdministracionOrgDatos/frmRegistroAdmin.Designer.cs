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
            this.btnBack = new System.Windows.Forms.Button();
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
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nuevo";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(311, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(379, 323);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
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
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(371, 297);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Nuevo Admin...";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtAdminContra
            // 
            this.txtAdminContra.Location = new System.Drawing.Point(173, 210);
            this.txtAdminContra.Name = "txtAdminContra";
            this.txtAdminContra.Size = new System.Drawing.Size(164, 20);
            this.txtAdminContra.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.label7.Location = new System.Drawing.Point(169, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 21);
            this.label7.TabIndex = 11;
            this.label7.Text = "Contraseña Admin:";
            // 
            // txtContrasena
            // 
            this.txtContrasena.Location = new System.Drawing.Point(31, 210);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(123, 20);
            this.txtContrasena.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.label6.Location = new System.Drawing.Point(27, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 21);
            this.label6.TabIndex = 9;
            this.label6.Text = "Contraseña:";
            // 
            // newAdminButton
            // 
            this.newAdminButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.newAdminButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newAdminButton.ForeColor = System.Drawing.Color.White;
            this.newAdminButton.Location = new System.Drawing.Point(54, 259);
            this.newAdminButton.Name = "newAdminButton";
            this.newAdminButton.Size = new System.Drawing.Size(258, 32);
            this.newAdminButton.TabIndex = 8;
            this.newAdminButton.Text = "Nuevo Administrador";
            this.newAdminButton.UseVisualStyleBackColor = false;
            this.newAdminButton.Click += new System.EventHandler(this.newAdminButton_Click);
            // 
            // rolCombo
            // 
            this.rolCombo.FormattingEnabled = true;
            this.rolCombo.Items.AddRange(new object[] {
            "mamaoso",
            "obrera"});
            this.rolCombo.Location = new System.Drawing.Point(31, 162);
            this.rolCombo.Name = "rolCombo";
            this.rolCombo.Size = new System.Drawing.Size(123, 21);
            this.rolCombo.TabIndex = 7;
            // 
            // Rol
            // 
            this.Rol.AutoSize = true;
            this.Rol.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.Rol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.Rol.Location = new System.Drawing.Point(27, 138);
            this.Rol.Name = "Rol";
            this.Rol.Size = new System.Drawing.Size(38, 21);
            this.Rol.TabIndex = 6;
            this.Rol.Text = "Rol:";
            // 
            // correoTxt
            // 
            this.correoTxt.Location = new System.Drawing.Point(31, 103);
            this.correoTxt.Name = "correoTxt";
            this.correoTxt.Size = new System.Drawing.Size(306, 20);
            this.correoTxt.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.label5.Location = new System.Drawing.Point(27, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "Correo:";
            // 
            // numeroTxt
            // 
            this.numeroTxt.Location = new System.Drawing.Point(173, 162);
            this.numeroTxt.Name = "numeroTxt";
            this.numeroTxt.Size = new System.Drawing.Size(164, 20);
            this.numeroTxt.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.label4.Location = new System.Drawing.Point(169, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 21);
            this.label4.TabIndex = 2;
            this.label4.Text = "Numero:";
            // 
            // nombreTxt
            // 
            this.nombreTxt.Location = new System.Drawing.Point(31, 49);
            this.nombreTxt.Name = "nombreTxt";
            this.nombreTxt.Size = new System.Drawing.Size(306, 20);
            this.nombreTxt.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.label3.Location = new System.Drawing.Point(27, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nombre:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnBack);
            this.tabPage2.Controls.Add(this.eliminarAdminButton);
            this.tabPage2.Controls.Add(this.administradoresDataGrid);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(371, 297);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Borrar Admin...";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // eliminarAdminButton
            // 
            this.eliminarAdminButton.Location = new System.Drawing.Point(12, 16);
            this.eliminarAdminButton.Name = "eliminarAdminButton";
            this.eliminarAdminButton.Size = new System.Drawing.Size(158, 33);
            this.eliminarAdminButton.TabIndex = 1;
            this.eliminarAdminButton.Text = "Eliminar Administrador";
            this.eliminarAdminButton.UseVisualStyleBackColor = true;
            this.eliminarAdminButton.Click += new System.EventHandler(this.eliminarAdminButton_Click);
            // 
            // administradoresDataGrid
            // 
            this.administradoresDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.administradoresDataGrid.Location = new System.Drawing.Point(12, 55);
            this.administradoresDataGrid.Name = "administradoresDataGrid";
            this.administradoresDataGrid.Size = new System.Drawing.Size(342, 246);
            this.administradoresDataGrid.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.pictureBox1.Location = new System.Drawing.Point(-6, -10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(299, 363);
            this.pictureBox1.TabIndex = 74;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.pictureBox2.Image = global::Proyecto_AdministracionOrgDatos.Properties.Resources.AddAdminImagen;
            this.pictureBox2.Location = new System.Drawing.Point(21, 137);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(232, 212);
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
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 31);
            this.label2.TabIndex = 76;
            this.label2.Text = "Administrador";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(196, 16);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(158, 33);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Regresar LOGIN";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // frmRegistroAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 347);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmRegistroAdmin";
            this.Text = "frmRegistroAdmin";
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
        private System.Windows.Forms.Button btnBack;
    }
}