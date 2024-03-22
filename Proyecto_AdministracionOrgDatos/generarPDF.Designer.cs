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
            this.APaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AMaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaNac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Curp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Genero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estadocivil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Domicilio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nacionalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoNacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Municipio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Correo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Carrera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Periodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Promedio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbPDFeleccion = new System.Windows.Forms.ComboBox();
            this.btnImprimirPDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMostrar)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMostrar
            // 
            this.dgvMostrar.AllowUserToAddRows = false;
            this.dgvMostrar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMostrar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMostrar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.APaterno,
            this.AMaterno,
            this.Nombres,
            this.FechaNac,
            this.Edad,
            this.Curp,
            this.Genero,
            this.Estadocivil,
            this.Domicilio,
            this.CP,
            this.Nacionalidad,
            this.EstadoNacimiento,
            this.Municipio,
            this.Correo,
            this.Telefono,
            this.Carrera,
            this.Periodo,
            this.Promedio,
            this.CCT,
            this.Modelo});
            this.dgvMostrar.GridColor = System.Drawing.Color.Silver;
            this.dgvMostrar.Location = new System.Drawing.Point(163, 12);
            this.dgvMostrar.Name = "dgvMostrar";
            this.dgvMostrar.ReadOnly = true;
            this.dgvMostrar.RowHeadersWidth = 51;
            this.dgvMostrar.Size = new System.Drawing.Size(477, 288);
            this.dgvMostrar.TabIndex = 74;
            // 
            // APaterno
            // 
            this.APaterno.HeaderText = "A.Paterno";
            this.APaterno.MinimumWidth = 6;
            this.APaterno.Name = "APaterno";
            this.APaterno.ReadOnly = true;
            this.APaterno.Width = 125;
            // 
            // AMaterno
            // 
            this.AMaterno.HeaderText = "A.Materno";
            this.AMaterno.MinimumWidth = 6;
            this.AMaterno.Name = "AMaterno";
            this.AMaterno.ReadOnly = true;
            this.AMaterno.Width = 125;
            // 
            // Nombres
            // 
            this.Nombres.HeaderText = "Nombres";
            this.Nombres.MinimumWidth = 6;
            this.Nombres.Name = "Nombres";
            this.Nombres.ReadOnly = true;
            this.Nombres.Width = 125;
            // 
            // FechaNac
            // 
            this.FechaNac.HeaderText = "FechaNac.";
            this.FechaNac.MinimumWidth = 6;
            this.FechaNac.Name = "FechaNac";
            this.FechaNac.ReadOnly = true;
            this.FechaNac.Width = 125;
            // 
            // Edad
            // 
            this.Edad.HeaderText = "Edad";
            this.Edad.MinimumWidth = 6;
            this.Edad.Name = "Edad";
            this.Edad.ReadOnly = true;
            this.Edad.Width = 125;
            // 
            // Curp
            // 
            this.Curp.HeaderText = "Curp";
            this.Curp.MinimumWidth = 6;
            this.Curp.Name = "Curp";
            this.Curp.ReadOnly = true;
            this.Curp.Width = 125;
            // 
            // Genero
            // 
            this.Genero.HeaderText = "Genero";
            this.Genero.MinimumWidth = 6;
            this.Genero.Name = "Genero";
            this.Genero.ReadOnly = true;
            this.Genero.Width = 125;
            // 
            // Estadocivil
            // 
            this.Estadocivil.HeaderText = "EstadoCivil";
            this.Estadocivil.MinimumWidth = 6;
            this.Estadocivil.Name = "Estadocivil";
            this.Estadocivil.ReadOnly = true;
            this.Estadocivil.Width = 125;
            // 
            // Domicilio
            // 
            this.Domicilio.HeaderText = "Domicilio";
            this.Domicilio.MinimumWidth = 6;
            this.Domicilio.Name = "Domicilio";
            this.Domicilio.ReadOnly = true;
            this.Domicilio.Width = 125;
            // 
            // CP
            // 
            this.CP.HeaderText = "C.P";
            this.CP.MinimumWidth = 6;
            this.CP.Name = "CP";
            this.CP.ReadOnly = true;
            this.CP.Width = 125;
            // 
            // Nacionalidad
            // 
            this.Nacionalidad.HeaderText = "Nacionalidad";
            this.Nacionalidad.MinimumWidth = 6;
            this.Nacionalidad.Name = "Nacionalidad";
            this.Nacionalidad.ReadOnly = true;
            this.Nacionalidad.Width = 125;
            // 
            // EstadoNacimiento
            // 
            this.EstadoNacimiento.HeaderText = "Estd.Nacimiento";
            this.EstadoNacimiento.MinimumWidth = 6;
            this.EstadoNacimiento.Name = "EstadoNacimiento";
            this.EstadoNacimiento.ReadOnly = true;
            this.EstadoNacimiento.Width = 125;
            // 
            // Municipio
            // 
            this.Municipio.HeaderText = "Municipio";
            this.Municipio.MinimumWidth = 6;
            this.Municipio.Name = "Municipio";
            this.Municipio.ReadOnly = true;
            this.Municipio.Width = 125;
            // 
            // Correo
            // 
            this.Correo.HeaderText = "Correo";
            this.Correo.MinimumWidth = 6;
            this.Correo.Name = "Correo";
            this.Correo.ReadOnly = true;
            this.Correo.Width = 125;
            // 
            // Telefono
            // 
            this.Telefono.HeaderText = "Telefono";
            this.Telefono.MinimumWidth = 6;
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
            this.Telefono.Width = 125;
            // 
            // Carrera
            // 
            this.Carrera.HeaderText = "Carrera";
            this.Carrera.MinimumWidth = 6;
            this.Carrera.Name = "Carrera";
            this.Carrera.ReadOnly = true;
            this.Carrera.Width = 125;
            // 
            // Periodo
            // 
            this.Periodo.HeaderText = "Periodo";
            this.Periodo.MinimumWidth = 6;
            this.Periodo.Name = "Periodo";
            this.Periodo.ReadOnly = true;
            this.Periodo.Width = 125;
            // 
            // Promedio
            // 
            this.Promedio.HeaderText = "Promedio";
            this.Promedio.MinimumWidth = 6;
            this.Promedio.Name = "Promedio";
            this.Promedio.ReadOnly = true;
            this.Promedio.Width = 125;
            // 
            // CCT
            // 
            this.CCT.HeaderText = "CCT";
            this.CCT.MinimumWidth = 6;
            this.CCT.Name = "CCT";
            this.CCT.ReadOnly = true;
            this.CCT.Width = 125;
            // 
            // Modelo
            // 
            this.Modelo.HeaderText = "Modelo";
            this.Modelo.MinimumWidth = 6;
            this.Modelo.Name = "Modelo";
            this.Modelo.ReadOnly = true;
            this.Modelo.Width = 125;
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
            this.cmbPDFeleccion.Location = new System.Drawing.Point(12, 54);
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
            this.btnImprimirPDF.Location = new System.Drawing.Point(12, 269);
            this.btnImprimirPDF.Name = "btnImprimirPDF";
            this.btnImprimirPDF.Size = new System.Drawing.Size(84, 31);
            this.btnImprimirPDF.TabIndex = 91;
            this.btnImprimirPDF.Text = "Imprimir PDF";
            this.btnImprimirPDF.UseVisualStyleBackColor = false;
            this.btnImprimirPDF.Click += new System.EventHandler(this.btnImprimirPDF_Click);
            // 
            // generarPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 312);
            this.Controls.Add(this.btnImprimirPDF);
            this.Controls.Add(this.cmbPDFeleccion);
            this.Controls.Add(this.dgvMostrar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "generarPDF";
            this.Text = "Imprimir";
            this.Load += new System.EventHandler(this.generarPDF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMostrar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMostrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn APaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn AMaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaNac;
        private System.Windows.Forms.DataGridViewTextBoxColumn Edad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Curp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Genero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estadocivil;
        private System.Windows.Forms.DataGridViewTextBoxColumn Domicilio;
        private System.Windows.Forms.DataGridViewTextBoxColumn CP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nacionalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoNacimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Municipio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Correo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Carrera;
        private System.Windows.Forms.DataGridViewTextBoxColumn Periodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Promedio;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modelo;
        private System.Windows.Forms.ComboBox cmbPDFeleccion;
        private System.Windows.Forms.Button btnImprimirPDF;
    }
}