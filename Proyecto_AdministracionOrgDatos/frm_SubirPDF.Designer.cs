namespace Proyecto_AdministracionOrgDatos
{
    partial class frm_SubirPDF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_SubirPDF));
            this.dgvPDF = new System.Windows.Forms.DataGridView();
            this.btnSubir = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.lblTitulo_ESA = new System.Windows.Forms.Label();
            this.btnAbrir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPDF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPDF
            // 
            this.dgvPDF.AllowUserToAddRows = false;
            this.dgvPDF.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvPDF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPDF.GridColor = System.Drawing.Color.Silver;
            this.dgvPDF.Location = new System.Drawing.Point(381, 128);
            this.dgvPDF.Name = "dgvPDF";
            this.dgvPDF.ReadOnly = true;
            this.dgvPDF.RowHeadersWidth = 51;
            this.dgvPDF.Size = new System.Drawing.Size(780, 378);
            this.dgvPDF.TabIndex = 74;
            // 
            // btnSubir
            // 
            this.btnSubir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.btnSubir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubir.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnSubir.ForeColor = System.Drawing.Color.Transparent;
            this.btnSubir.Location = new System.Drawing.Point(381, 546);
            this.btnSubir.Name = "btnSubir";
            this.btnSubir.Size = new System.Drawing.Size(113, 37);
            this.btnSubir.TabIndex = 3;
            this.btnSubir.Text = "Subir PDF";
            this.btnSubir.UseVisualStyleBackColor = false;
            this.btnSubir.Click += new System.EventHandler(this.btnSubir_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Gray;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnSalir.ForeColor = System.Drawing.Color.Transparent;
            this.btnSalir.Location = new System.Drawing.Point(1048, 546);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(113, 37);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.pictureBox9.Location = new System.Drawing.Point(197, -1);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(1019, 96);
            this.pictureBox9.TabIndex = 91;
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
            this.lblTitulo_ESA.Size = new System.Drawing.Size(248, 31);
            this.lblTitulo_ESA.TabIndex = 92;
            this.lblTitulo_ESA.Text = "Subir archivos PDF";
            // 
            // btnAbrir
            // 
            this.btnAbrir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.btnAbrir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrir.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAbrir.ForeColor = System.Drawing.Color.Transparent;
            this.btnAbrir.Location = new System.Drawing.Point(507, 546);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(113, 37);
            this.btnAbrir.TabIndex = 4;
            this.btnAbrir.Text = "Abrir PDF";
            this.btnAbrir.UseVisualStyleBackColor = false;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // frm_SubirPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 651);
            this.Controls.Add(this.btnAbrir);
            this.Controls.Add(this.lblTitulo_ESA);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnSubir);
            this.Controls.Add(this.dgvPDF);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1214, 651);
            this.MinimumSize = new System.Drawing.Size(1214, 651);
            this.Name = "frm_SubirPDF";
            this.Text = "Reportes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_SubirPDF_FormClosing);
            this.Load += new System.EventHandler(this.frm_SubirPDF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPDF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPDF;
        private System.Windows.Forms.Button btnSubir;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label lblTitulo_ESA;
        private System.Windows.Forms.Button btnAbrir;
    }
}