namespace Proyecto_AdministracionOrgDatos
{
    partial class fmrRegistroAdmin
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
            this.Nombre = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nombreTxt = new System.Windows.Forms.TextBox();
            this.numeroTxt = new System.Windows.Forms.TextBox();
            this.correoTxt = new System.Windows.Forms.TextBox();
            this.rolCombo = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.newAdminButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.administradoresDataGrid = new System.Windows.Forms.DataGridView();
            this.nombreData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correoData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rolData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonoData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.administradoresDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(112, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nuevo Administrador";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Insertar imagen";
            // 
            // Nombre
            // 
            this.Nombre.AutoSize = true;
            this.Nombre.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nombre.Location = new System.Drawing.Point(16, 27);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(65, 19);
            this.Nombre.TabIndex = 2;
            this.Nombre.Text = "Nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Rol";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Correo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(230, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 19);
            this.label6.TabIndex = 5;
            this.label6.Text = "Numero Telefonico";
            // 
            // nombreTxt
            // 
            this.nombreTxt.Location = new System.Drawing.Point(20, 49);
            this.nombreTxt.Name = "nombreTxt";
            this.nombreTxt.Size = new System.Drawing.Size(204, 20);
            this.nombreTxt.TabIndex = 6;
            // 
            // numeroTxt
            // 
            this.numeroTxt.Location = new System.Drawing.Point(234, 203);
            this.numeroTxt.Name = "numeroTxt";
            this.numeroTxt.Size = new System.Drawing.Size(158, 20);
            this.numeroTxt.TabIndex = 7;
            // 
            // correoTxt
            // 
            this.correoTxt.Location = new System.Drawing.Point(20, 131);
            this.correoTxt.Name = "correoTxt";
            this.correoTxt.Size = new System.Drawing.Size(204, 20);
            this.correoTxt.TabIndex = 8;
            // 
            // rolCombo
            // 
            this.rolCombo.FormattingEnabled = true;
            this.rolCombo.Items.AddRange(new object[] {
            "obrera",
            "mamaOso"});
            this.rolCombo.Location = new System.Drawing.Point(25, 202);
            this.rolCombo.Name = "rolCombo";
            this.rolCombo.Size = new System.Drawing.Size(153, 21);
            this.rolCombo.TabIndex = 9;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(471, 93);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(485, 379);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.newAdminButton);
            this.tabPage1.Controls.Add(this.nombreTxt);
            this.tabPage1.Controls.Add(this.rolCombo);
            this.tabPage1.Controls.Add(this.Nombre);
            this.tabPage1.Controls.Add(this.correoTxt);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.numeroTxt);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(477, 353);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Nuevo Admin...";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // newAdminButton
            // 
            this.newAdminButton.Location = new System.Drawing.Point(27, 254);
            this.newAdminButton.Name = "newAdminButton";
            this.newAdminButton.Size = new System.Drawing.Size(150, 20);
            this.newAdminButton.TabIndex = 10;
            this.newAdminButton.Text = "Crear Administrador";
            this.newAdminButton.UseVisualStyleBackColor = true;
            this.newAdminButton.Click += new System.EventHandler(this.newAdminButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.administradoresDataGrid);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(477, 353);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Borrar Admin...";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 26);
            this.button1.TabIndex = 1;
            this.button1.Text = "Eliminar Administrador";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // administradoresDataGrid
            // 
            this.administradoresDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.administradoresDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreData,
            this.correoData,
            this.rolData,
            this.telefonoData});
            this.administradoresDataGrid.Location = new System.Drawing.Point(16, 66);
            this.administradoresDataGrid.Name = "administradoresDataGrid";
            this.administradoresDataGrid.Size = new System.Drawing.Size(445, 270);
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(148, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 26);
            this.button2.TabIndex = 2;
            this.button2.Text = "Confirmar todo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // fmrRegistroAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 484);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "fmrRegistroAdmin";
            this.Text = "fmrRegistroAdmin";
            this.Load += new System.EventHandler(this.fmrRegistroAdmin_Load);
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
        private System.Windows.Forms.Label Nombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox nombreTxt;
        private System.Windows.Forms.TextBox numeroTxt;
        private System.Windows.Forms.TextBox correoTxt;
        private System.Windows.Forms.ComboBox rolCombo;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button newAdminButton;
        private System.Windows.Forms.DataGridView administradoresDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreData;
        private System.Windows.Forms.DataGridViewTextBoxColumn correoData;
        private System.Windows.Forms.DataGridViewTextBoxColumn rolData;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoData;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}