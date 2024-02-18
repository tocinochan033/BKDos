namespace Proyecto_AdministracionOrgDatos
{
    partial class frmRegistrarBecarios_ESA
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistrarBecarios_ESA));
            this.lblCorreo_ESA = new System.Windows.Forms.Label();
            this.btnAgregar_ESA = new System.Windows.Forms.Button();
            this.TxtCorreo_ESA = new System.Windows.Forms.TextBox();
            this.lblNombre_ESA = new System.Windows.Forms.Label();
            this.txtNombre_ESA = new System.Windows.Forms.TextBox();
            this.btnRegresarMenu_ESA = new System.Windows.Forms.Button();
            this.FechaC = new System.Windows.Forms.Label();
            this.lblTitulo_ESA = new System.Windows.Forms.Label();
            this.dgv_Agregar = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Correo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_Telefono = new System.Windows.Forms.Label();
            this.lbl_Estado = new System.Windows.Forms.Label();
            this.Txt_Telefono_ESA = new System.Windows.Forms.TextBox();
            this.Txt_Estado_ESA = new System.Windows.Forms.TextBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.HoraC = new System.Windows.Forms.Label();
            this.FechaHora2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Agregar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCorreo_ESA
            // 
            this.lblCorreo_ESA.AutoSize = true;
            this.lblCorreo_ESA.Font = new System.Drawing.Font("Cocogoose", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorreo_ESA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(87)))), ((int)(((byte)(137)))));
            this.lblCorreo_ESA.Location = new System.Drawing.Point(91, 158);
            this.lblCorreo_ESA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCorreo_ESA.Name = "lblCorreo_ESA";
            this.lblCorreo_ESA.Size = new System.Drawing.Size(247, 31);
            this.lblCorreo_ESA.TabIndex = 58;
            this.lblCorreo_ESA.Text = "Correo eléctronico:";
            // 
            // btnAgregar_ESA
            // 
            this.btnAgregar_ESA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(87)))), ((int)(((byte)(137)))));
            this.btnAgregar_ESA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar_ESA.Font = new System.Drawing.Font("Cocogoose", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar_ESA.ForeColor = System.Drawing.Color.Snow;
            this.btnAgregar_ESA.Location = new System.Drawing.Point(26, 424);
            this.btnAgregar_ESA.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregar_ESA.Name = "btnAgregar_ESA";
            this.btnAgregar_ESA.Size = new System.Drawing.Size(138, 51);
            this.btnAgregar_ESA.TabIndex = 57;
            this.btnAgregar_ESA.Text = "Agregar";
            this.btnAgregar_ESA.UseVisualStyleBackColor = false;
            this.btnAgregar_ESA.Click += new System.EventHandler(this.btnAgregar_ESA_Click);
            // 
            // TxtCorreo_ESA
            // 
            this.TxtCorreo_ESA.Font = new System.Drawing.Font("Louis George Cafe", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCorreo_ESA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.TxtCorreo_ESA.Location = new System.Drawing.Point(88, 194);
            this.TxtCorreo_ESA.Margin = new System.Windows.Forms.Padding(2);
            this.TxtCorreo_ESA.Name = "TxtCorreo_ESA";
            this.TxtCorreo_ESA.Size = new System.Drawing.Size(309, 39);
            this.TxtCorreo_ESA.TabIndex = 55;
            // 
            // lblNombre_ESA
            // 
            this.lblNombre_ESA.AutoSize = true;
            this.lblNombre_ESA.Font = new System.Drawing.Font("Cocogoose", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre_ESA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(87)))), ((int)(((byte)(137)))));
            this.lblNombre_ESA.Location = new System.Drawing.Point(90, 62);
            this.lblNombre_ESA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombre_ESA.Name = "lblNombre_ESA";
            this.lblNombre_ESA.Size = new System.Drawing.Size(117, 31);
            this.lblNombre_ESA.TabIndex = 54;
            this.lblNombre_ESA.Text = "Nombre:";
            // 
            // txtNombre_ESA
            // 
            this.txtNombre_ESA.Font = new System.Drawing.Font("Louis George Cafe", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre_ESA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtNombre_ESA.Location = new System.Drawing.Point(88, 99);
            this.txtNombre_ESA.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombre_ESA.Name = "txtNombre_ESA";
            this.txtNombre_ESA.Size = new System.Drawing.Size(309, 39);
            this.txtNombre_ESA.TabIndex = 53;
            // 
            // btnRegresarMenu_ESA
            // 
            this.btnRegresarMenu_ESA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnRegresarMenu_ESA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegresarMenu_ESA.Font = new System.Drawing.Font("Cocogoose", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresarMenu_ESA.ForeColor = System.Drawing.Color.Snow;
            this.btnRegresarMenu_ESA.Location = new System.Drawing.Point(601, 424);
            this.btnRegresarMenu_ESA.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegresarMenu_ESA.Name = "btnRegresarMenu_ESA";
            this.btnRegresarMenu_ESA.Size = new System.Drawing.Size(225, 51);
            this.btnRegresarMenu_ESA.TabIndex = 52;
            this.btnRegresarMenu_ESA.Text = "Guardar y Salir";
            this.btnRegresarMenu_ESA.UseVisualStyleBackColor = false;
            this.btnRegresarMenu_ESA.Click += new System.EventHandler(this.btnRegresarMenu_ESA_Click);
            // 
            // FechaC
            // 
            this.FechaC.AutoSize = true;
            this.FechaC.Font = new System.Drawing.Font("Louis George Cafe", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(87)))), ((int)(((byte)(137)))));
            this.FechaC.Location = new System.Drawing.Point(642, 10);
            this.FechaC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FechaC.Name = "FechaC";
            this.FechaC.Size = new System.Drawing.Size(183, 30);
            this.FechaC.TabIndex = 51;
            this.FechaC.Text = "00/00/0000";
            // 
            // lblTitulo_ESA
            // 
            this.lblTitulo_ESA.AutoSize = true;
            this.lblTitulo_ESA.Font = new System.Drawing.Font("Cocogoose", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo_ESA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblTitulo_ESA.Location = new System.Drawing.Point(4, 10);
            this.lblTitulo_ESA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo_ESA.Name = "lblTitulo_ESA";
            this.lblTitulo_ESA.Size = new System.Drawing.Size(309, 39);
            this.lblTitulo_ESA.TabIndex = 49;
            this.lblTitulo_ESA.Text = "Registrar Becarios";
            // 
            // dgv_Agregar
            // 
            this.dgv_Agregar.AllowUserToAddRows = false;
            this.dgv_Agregar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_Agregar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Agregar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Telefono,
            this.Correo,
            this.Estado});
            this.dgv_Agregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgv_Agregar.GridColor = System.Drawing.Color.Silver;
            this.dgv_Agregar.Location = new System.Drawing.Point(205, 259);
            this.dgv_Agregar.Name = "dgv_Agregar";
            this.dgv_Agregar.ReadOnly = true;
            this.dgv_Agregar.Size = new System.Drawing.Size(445, 150);
            this.dgv_Agregar.TabIndex = 60;
            this.dgv_Agregar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Agregar_CellContentClick);
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Telefono
            // 
            this.Telefono.HeaderText = "Telefono";
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
            // 
            // Correo
            // 
            this.Correo.HeaderText = "Correo";
            this.Correo.Name = "Correo";
            this.Correo.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // lbl_Telefono
            // 
            this.lbl_Telefono.AutoSize = true;
            this.lbl_Telefono.Font = new System.Drawing.Font("Cocogoose", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Telefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(87)))), ((int)(((byte)(137)))));
            this.lbl_Telefono.Location = new System.Drawing.Point(445, 66);
            this.lbl_Telefono.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Telefono.Name = "lbl_Telefono";
            this.lbl_Telefono.Size = new System.Drawing.Size(125, 31);
            this.lbl_Telefono.TabIndex = 61;
            this.lbl_Telefono.Text = "Telefono:";
            // 
            // lbl_Estado
            // 
            this.lbl_Estado.AutoSize = true;
            this.lbl_Estado.Font = new System.Drawing.Font("Cocogoose", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Estado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(87)))), ((int)(((byte)(137)))));
            this.lbl_Estado.Location = new System.Drawing.Point(445, 162);
            this.lbl_Estado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Estado.Name = "lbl_Estado";
            this.lbl_Estado.Size = new System.Drawing.Size(102, 31);
            this.lbl_Estado.TabIndex = 62;
            this.lbl_Estado.Text = "Estado:";
            // 
            // Txt_Telefono_ESA
            // 
            this.Txt_Telefono_ESA.Font = new System.Drawing.Font("Louis George Cafe", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Telefono_ESA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Txt_Telefono_ESA.Location = new System.Drawing.Point(450, 99);
            this.Txt_Telefono_ESA.Margin = new System.Windows.Forms.Padding(2);
            this.Txt_Telefono_ESA.Name = "Txt_Telefono_ESA";
            this.Txt_Telefono_ESA.Size = new System.Drawing.Size(309, 39);
            this.Txt_Telefono_ESA.TabIndex = 63;
            // 
            // Txt_Estado_ESA
            // 
            this.Txt_Estado_ESA.Font = new System.Drawing.Font("Louis George Cafe", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Estado_ESA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Txt_Estado_ESA.Location = new System.Drawing.Point(450, 195);
            this.Txt_Estado_ESA.Margin = new System.Windows.Forms.Padding(2);
            this.Txt_Estado_ESA.Name = "Txt_Estado_ESA";
            this.Txt_Estado_ESA.Size = new System.Drawing.Size(309, 39);
            this.Txt_Estado_ESA.TabIndex = 64;
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(87)))), ((int)(((byte)(137)))));
            this.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificar.Font = new System.Drawing.Font("Cocogoose", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.Color.Snow;
            this.btnModificar.Location = new System.Drawing.Point(185, 424);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(2);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(153, 51);
            this.btnModificar.TabIndex = 65;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(87)))), ((int)(((byte)(137)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Font = new System.Drawing.Font("Cocogoose", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.Snow;
            this.btnEliminar.Location = new System.Drawing.Point(359, 424);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(143, 51);
            this.btnEliminar.TabIndex = 66;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // HoraC
            // 
            this.HoraC.AutoSize = true;
            this.HoraC.Font = new System.Drawing.Font("Louis George Cafe", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HoraC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(87)))), ((int)(((byte)(137)))));
            this.HoraC.Location = new System.Drawing.Point(674, 40);
            this.HoraC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.HoraC.Name = "HoraC";
            this.HoraC.Size = new System.Drawing.Size(151, 30);
            this.HoraC.TabIndex = 67;
            this.HoraC.Text = "00:00 a.m";
            // 
            // FechaHora2
            // 
            this.FechaHora2.Enabled = true;
            this.FechaHora2.Tick += new System.EventHandler(this.FechaHora2_Tick);
            // 
            // frmRegistrarBecarios_ESA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(836, 489);
            this.Controls.Add(this.HoraC);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.Txt_Estado_ESA);
            this.Controls.Add(this.Txt_Telefono_ESA);
            this.Controls.Add(this.lbl_Estado);
            this.Controls.Add(this.lbl_Telefono);
            this.Controls.Add(this.dgv_Agregar);
            this.Controls.Add(this.lblCorreo_ESA);
            this.Controls.Add(this.btnAgregar_ESA);
            this.Controls.Add(this.TxtCorreo_ESA);
            this.Controls.Add(this.lblNombre_ESA);
            this.Controls.Add(this.txtNombre_ESA);
            this.Controls.Add(this.btnRegresarMenu_ESA);
            this.Controls.Add(this.FechaC);
            this.Controls.Add(this.lblTitulo_ESA);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmRegistrarBecarios_ESA";
            this.Text = "Registro";
            this.Load += new System.EventHandler(this.frmRegistrarBecarios_ESA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Agregar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblCorreo_ESA;
        private System.Windows.Forms.Button btnAgregar_ESA;
        private System.Windows.Forms.TextBox TxtCorreo_ESA;
        private System.Windows.Forms.Label lblNombre_ESA;
        private System.Windows.Forms.TextBox txtNombre_ESA;
        private System.Windows.Forms.Button btnRegresarMenu_ESA;
        private System.Windows.Forms.Label FechaC;
        private System.Windows.Forms.Label lblTitulo_ESA;
        private System.Windows.Forms.DataGridView dgv_Agregar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Correo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.Label lbl_Telefono;
        private System.Windows.Forms.Label lbl_Estado;
        private System.Windows.Forms.TextBox Txt_Telefono_ESA;
        private System.Windows.Forms.TextBox Txt_Estado_ESA;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label HoraC;
        private System.Windows.Forms.Timer FechaHora2;
    }
}