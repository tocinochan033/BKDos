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
            ((System.ComponentModel.ISupportInitialize)(this.dgvMostrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMostrar
            // 
            this.dgvMostrar.AllowUserToAddRows = false;
            this.dgvMostrar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMostrar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMostrar.GridColor = System.Drawing.Color.Silver;
            this.dgvMostrar.Location = new System.Drawing.Point(212, 113);
            this.dgvMostrar.Name = "dgvMostrar";
            this.dgvMostrar.ReadOnly = true;
            this.dgvMostrar.RowHeadersWidth = 51;
            this.dgvMostrar.Size = new System.Drawing.Size(963, 409);
            this.dgvMostrar.TabIndex = 74;
            // 
            // cmbPDFeleccion
            // 
            this.cmbPDFeleccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPDFeleccion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPDFeleccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.cmbPDFeleccion.FormattingEnabled = true;
            this.cmbPDFeleccion.Items.AddRange(new object[] {
            "Informacion Personal",
            "Informacion de Contacto",
            "Informacion Academica"});
            this.cmbPDFeleccion.Location = new System.Drawing.Point(251, 558);
            this.cmbPDFeleccion.Name = "cmbPDFeleccion";
            this.cmbPDFeleccion.Size = new System.Drawing.Size(145, 23);
            this.cmbPDFeleccion.TabIndex = 90;
            // 
            // btnImprimirPDF
            // 
            this.btnImprimirPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.btnImprimirPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimirPDF.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnImprimirPDF.ForeColor = System.Drawing.Color.Snow;
            this.btnImprimirPDF.Location = new System.Drawing.Point(416, 550);
            this.btnImprimirPDF.Name = "btnImprimirPDF";
            this.btnImprimirPDF.Size = new System.Drawing.Size(127, 31);
            this.btnImprimirPDF.TabIndex = 91;
            this.btnImprimirPDF.Text = "Imprimir PDF";
            this.btnImprimirPDF.UseVisualStyleBackColor = false;
            this.btnImprimirPDF.Click += new System.EventHandler(this.btnImprimirPDF_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.button1.ForeColor = System.Drawing.Color.Snow;
            this.button1.Location = new System.Drawing.Point(577, 550);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 30);
            this.button1.TabIndex = 92;
            this.button1.Text = "Firma Electronica";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.pictureBox9.Location = new System.Drawing.Point(197, -1);
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
            this.lblTitulo_ESA.Location = new System.Drawing.Point(272, 40);
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
            this.btnSalir.Location = new System.Drawing.Point(1110, 558);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(65, 31);
            this.btnSalir.TabIndex = 95;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // generarPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1214, 651);
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
    }
}