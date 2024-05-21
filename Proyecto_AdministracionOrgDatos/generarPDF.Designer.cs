namespace Proyecto_AdministracionOrgDatos
{
    partial class generarPDF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(generarPDF));
            this.dgvMostrar = new System.Windows.Forms.DataGridView();
            this.cmbPDFeleccion = new System.Windows.Forms.ComboBox();
            this.btnImprimirPDF = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.lblTitulo_ESA = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbVista = new System.Windows.Forms.ComboBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.cmbFiltro = new System.Windows.Forms.ComboBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.btnResetFiltro = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMostrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMostrar
            // 
            this.dgvMostrar.AllowUserToAddRows = false;
            this.dgvMostrar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMostrar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMostrar.GridColor = System.Drawing.Color.Silver;
            this.dgvMostrar.Location = new System.Drawing.Point(222, 156);
            this.dgvMostrar.Margin = new System.Windows.Forms.Padding(2);
            this.dgvMostrar.Name = "dgvMostrar";
            this.dgvMostrar.ReadOnly = true;
            this.dgvMostrar.RowHeadersWidth = 51;
            this.dgvMostrar.Size = new System.Drawing.Size(945, 388);
            this.dgvMostrar.TabIndex = 74;
            // 
            // cmbPDFeleccion
            // 
            this.cmbPDFeleccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPDFeleccion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPDFeleccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.cmbPDFeleccion.FormattingEnabled = true;
            this.cmbPDFeleccion.Items.AddRange(new object[] {
            "Informe Individual",
            "Informacion Personal",
            "Informacion de Contacto",
            "Informacion Academica"});
            this.cmbPDFeleccion.Location = new System.Drawing.Point(234, 549);
            this.cmbPDFeleccion.Name = "cmbPDFeleccion";
            this.cmbPDFeleccion.Size = new System.Drawing.Size(145, 23);
            this.cmbPDFeleccion.TabIndex = 5;
            // 
            // btnImprimirPDF
            // 
            this.btnImprimirPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.btnImprimirPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimirPDF.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnImprimirPDF.ForeColor = System.Drawing.Color.Snow;
            this.btnImprimirPDF.Location = new System.Drawing.Point(395, 549);
            this.btnImprimirPDF.Name = "btnImprimirPDF";
            this.btnImprimirPDF.Size = new System.Drawing.Size(127, 31);
            this.btnImprimirPDF.TabIndex = 6;
            this.btnImprimirPDF.Text = "Guardar PDF";
            this.btnImprimirPDF.UseVisualStyleBackColor = false;
            this.btnImprimirPDF.Click += new System.EventHandler(this.btnImprimirPDF_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.button1.ForeColor = System.Drawing.Color.Snow;
            this.button1.Location = new System.Drawing.Point(543, 549);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 30);
            this.button1.TabIndex = 7;
            this.button1.Text = "Firma Electronica";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.pictureBox9.Location = new System.Drawing.Point(197, 0);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(1017, 96);
            this.pictureBox9.TabIndex = 93;
            this.pictureBox9.TabStop = false;
            // 
            // lblTitulo_ESA
            // 
            this.lblTitulo_ESA.AutoSize = true;
            this.lblTitulo_ESA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.lblTitulo_ESA.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo_ESA.ForeColor = System.Drawing.Color.White;
            this.lblTitulo_ESA.Location = new System.Drawing.Point(272, 41);
            this.lblTitulo_ESA.Name = "lblTitulo_ESA";
            this.lblTitulo_ESA.Size = new System.Drawing.Size(242, 31);
            this.lblTitulo_ESA.TabIndex = 94;
            this.lblTitulo_ESA.Text = "Generador de PDF";
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnSalir.ForeColor = System.Drawing.Color.Snow;
            this.btnSalir.Location = new System.Drawing.Point(1102, 555);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(65, 31);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.cmbVista);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox11);
            this.panel1.Controls.Add(this.lblFiltro);
            this.panel1.Controls.Add(this.txtFiltro);
            this.panel1.Controls.Add(this.cmbFiltro);
            this.panel1.Controls.Add(this.lblCategoria);
            this.panel1.Location = new System.Drawing.Point(222, 101);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(861, 43);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // cmbVista
            // 
            this.cmbVista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVista.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbVista.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.cmbVista.FormattingEnabled = true;
            this.cmbVista.Location = new System.Drawing.Point(630, 7);
            this.cmbVista.Margin = new System.Windows.Forms.Padding(2);
            this.cmbVista.Name = "cmbVista";
            this.cmbVista.Size = new System.Drawing.Size(220, 29);
            this.cmbVista.TabIndex = 3;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(406, 11);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(22, 24);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 88;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox11
            // 
            this.pictureBox11.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox11.Image")));
            this.pictureBox11.Location = new System.Drawing.Point(70, 32);
            this.pictureBox11.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(325, 8);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox11.TabIndex = 87;
            this.pictureBox11.TabStop = false;
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFiltro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.lblFiltro.Location = new System.Drawing.Point(8, 11);
            this.lblFiltro.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(63, 21);
            this.lblFiltro.TabIndex = 77;
            this.lblFiltro.Text = "Buscar :";
            this.lblFiltro.Click += new System.EventHandler(this.lblFiltro_Click);
            // 
            // txtFiltro
            // 
            this.txtFiltro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFiltro.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtFiltro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.txtFiltro.Location = new System.Drawing.Point(70, 10);
            this.txtFiltro.Margin = new System.Windows.Forms.Padding(2);
            this.txtFiltro.Multiline = true;
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(325, 23);
            this.txtFiltro.TabIndex = 1;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            // 
            // cmbFiltro
            // 
            this.cmbFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltro.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbFiltro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.cmbFiltro.FormattingEnabled = true;
            this.cmbFiltro.Location = new System.Drawing.Point(475, 7);
            this.cmbFiltro.Margin = new System.Windows.Forms.Padding(2);
            this.cmbFiltro.Name = "cmbFiltro";
            this.cmbFiltro.Size = new System.Drawing.Size(151, 29);
            this.cmbFiltro.TabIndex = 2;
            this.cmbFiltro.SelectedIndexChanged += new System.EventHandler(this.cmbFiltro_SelectedIndexChanged);
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCategoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.lblCategoria.Location = new System.Drawing.Point(439, 11);
            this.lblCategoria.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(34, 21);
            this.lblCategoria.TabIndex = 79;
            this.lblCategoria.Text = "En :";
            // 
            // btnResetFiltro
            // 
            this.btnResetFiltro.BackColor = System.Drawing.Color.Gray;
            this.btnResetFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetFiltro.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetFiltro.ForeColor = System.Drawing.Color.Transparent;
            this.btnResetFiltro.Location = new System.Drawing.Point(997, 555);
            this.btnResetFiltro.Margin = new System.Windows.Forms.Padding(2);
            this.btnResetFiltro.Name = "btnResetFiltro";
            this.btnResetFiltro.Size = new System.Drawing.Size(100, 33);
            this.btnResetFiltro.TabIndex = 8;
            this.btnResetFiltro.Text = "Reiniciar filtros";
            this.btnResetFiltro.UseVisualStyleBackColor = false;
            this.btnResetFiltro.Click += new System.EventHandler(this.btnResetFiltro_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnFiltrar.ForeColor = System.Drawing.Color.Transparent;
            this.btnFiltrar.Location = new System.Drawing.Point(1087, 105);
            this.btnFiltrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(101, 34);
            this.btnFiltrar.TabIndex = 4;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.label1.Location = new System.Drawing.Point(391, 583);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(529, 19);
            this.label1.TabIndex = 99;
            this.label1.Text = "(Nota: Si desea elaborar un reporte individual, seleccione la fila del elemento d" +
    "eseado)";
            // 
            // generarPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1214, 651);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.btnResetFiltro);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblTitulo_ESA);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnImprimirPDF);
            this.Controls.Add(this.cmbPDFeleccion);
            this.Controls.Add(this.dgvMostrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1214, 651);
            this.MinimumSize = new System.Drawing.Size(1214, 651);
            this.Name = "generarPDF";
            this.Text = "Imprimir";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.generarPDF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMostrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMostrar;
        private System.Windows.Forms.ComboBox cmbPDFeleccion;
        private System.Windows.Forms.Button btnImprimirPDF;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label lblTitulo_ESA;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.ComboBox cmbFiltro;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Button btnResetFiltro;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbVista;
    }
}