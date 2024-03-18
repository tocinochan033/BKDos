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
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
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
            this.confirmarTodoButton = new System.Windows.Forms.Button();
            this.eliminarAdminButton = new System.Windows.Forms.Button();
            this.administradoresDataGrid = new System.Windows.Forms.DataGridView();
            this.nombreData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correoData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rolData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonoData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.administradoresDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nuevo Administrador";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(172, 261);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Insertar Imagen";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(387, 101);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(463, 340);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
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
            this.tabPage1.Size = new System.Drawing.Size(455, 314);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Nuevo Admin...";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // newAdminButton
            // 
            this.newAdminButton.Location = new System.Drawing.Point(36, 247);
            this.newAdminButton.Name = "newAdminButton";
            this.newAdminButton.Size = new System.Drawing.Size(114, 22);
            this.newAdminButton.TabIndex = 8;
            this.newAdminButton.Text = "Nuevo Administrador";
            this.newAdminButton.UseVisualStyleBackColor = true;
            this.newAdminButton.Click += new System.EventHandler(this.newAdminButton_Click);
            // 
            // rolCombo
            // 
            this.rolCombo.FormattingEnabled = true;
            this.rolCombo.Items.AddRange(new object[] {
            "mamaoso",
            "obrera"});
            this.rolCombo.Location = new System.Drawing.Point(31, 198);
            this.rolCombo.Name = "rolCombo";
            this.rolCombo.Size = new System.Drawing.Size(153, 21);
            this.rolCombo.TabIndex = 7;
            // 
            // Rol
            // 
            this.Rol.AutoSize = true;
            this.Rol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rol.Location = new System.Drawing.Point(27, 176);
            this.Rol.Name = "Rol";
            this.Rol.Size = new System.Drawing.Size(33, 20);
            this.Rol.TabIndex = 6;
            this.Rol.Text = "Rol";
            // 
            // correoTxt
            // 
            this.correoTxt.Location = new System.Drawing.Point(31, 119);
            this.correoTxt.Name = "correoTxt";
            this.correoTxt.Size = new System.Drawing.Size(186, 20);
            this.correoTxt.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Correo";
            // 
            // numeroTxt
            // 
            this.numeroTxt.Location = new System.Drawing.Point(236, 199);
            this.numeroTxt.Name = "numeroTxt";
            this.numeroTxt.Size = new System.Drawing.Size(186, 20);
            this.numeroTxt.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(232, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Numero";
            // 
            // nombreTxt
            // 
            this.nombreTxt.Location = new System.Drawing.Point(31, 55);
            this.nombreTxt.Name = "nombreTxt";
            this.nombreTxt.Size = new System.Drawing.Size(186, 20);
            this.nombreTxt.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nombre";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.confirmarTodoButton);
            this.tabPage2.Controls.Add(this.eliminarAdminButton);
            this.tabPage2.Controls.Add(this.administradoresDataGrid);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(455, 314);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Borrar Admin...";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // confirmarTodoButton
            // 
            this.confirmarTodoButton.Location = new System.Drawing.Point(140, 26);
            this.confirmarTodoButton.Name = "confirmarTodoButton";
            this.confirmarTodoButton.Size = new System.Drawing.Size(112, 23);
            this.confirmarTodoButton.TabIndex = 2;
            this.confirmarTodoButton.Text = "Confirmar todo";
            this.confirmarTodoButton.UseVisualStyleBackColor = true;
            this.confirmarTodoButton.Click += new System.EventHandler(this.confirmarTodoButton_Click);
            // 
            // eliminarAdminButton
            // 
            this.eliminarAdminButton.Location = new System.Drawing.Point(12, 26);
            this.eliminarAdminButton.Name = "eliminarAdminButton";
            this.eliminarAdminButton.Size = new System.Drawing.Size(122, 23);
            this.eliminarAdminButton.TabIndex = 1;
            this.eliminarAdminButton.Text = "Eliminar Administrador";
            this.eliminarAdminButton.UseVisualStyleBackColor = true;
            this.eliminarAdminButton.Click += new System.EventHandler(this.eliminarAdminButton_Click);
            // 
            // administradoresDataGrid
            // 
            this.administradoresDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.administradoresDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreData,
            this.correoData,
            this.rolData,
            this.telefonoData});
            this.administradoresDataGrid.Location = new System.Drawing.Point(12, 55);
            this.administradoresDataGrid.Name = "administradoresDataGrid";
            this.administradoresDataGrid.Size = new System.Drawing.Size(426, 246);
            this.administradoresDataGrid.TabIndex = 0;
            // 
            // nombreData
            // 
            this.nombreData.HeaderText = "Nombre";
            this.nombreData.Name = "nombreData";
            // 
            // correoData
            // 
            this.correoData.HeaderText = "Correo";
            this.correoData.Name = "correoData";
            // 
            // rolData
            // 
            this.rolData.HeaderText = "Rol";
            this.rolData.Name = "rolData";
            // 
            // telefonoData
            // 
            this.telefonoData.HeaderText = "Num. Telefono";
            this.telefonoData.Name = "telefonoData";
            // 
            // frmRegistroAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 459);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmRegistroAdmin";
            this.Text = "frmRegistroAdmin";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.administradoresDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreData;
        private System.Windows.Forms.DataGridViewTextBoxColumn correoData;
        private System.Windows.Forms.DataGridViewTextBoxColumn rolData;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoData;
        private System.Windows.Forms.Button newAdminButton;
        private System.Windows.Forms.Button confirmarTodoButton;
        private System.Windows.Forms.Button eliminarAdminButton;
    }
}