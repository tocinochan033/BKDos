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
            this.dgvPDF = new System.Windows.Forms.DataGridView();
            this.btnSubir = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.listBoxPdf = new System.Windows.Forms.ListBox();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPDF)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPDF
            // 
            this.dgvPDF.AllowUserToAddRows = false;
            this.dgvPDF.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvPDF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPDF.GridColor = System.Drawing.Color.Silver;
            this.dgvPDF.Location = new System.Drawing.Point(119, 225);
            this.dgvPDF.Name = "dgvPDF";
            this.dgvPDF.ReadOnly = true;
            this.dgvPDF.RowHeadersWidth = 51;
            this.dgvPDF.Size = new System.Drawing.Size(636, 113);
            this.dgvPDF.TabIndex = 74;
            // 
            // btnSubir
            // 
            this.btnSubir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.btnSubir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubir.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnSubir.ForeColor = System.Drawing.Color.Transparent;
            this.btnSubir.Location = new System.Drawing.Point(119, 366);
            this.btnSubir.Name = "btnSubir";
            this.btnSubir.Size = new System.Drawing.Size(113, 37);
            this.btnSubir.TabIndex = 77;
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
            this.btnSalir.Location = new System.Drawing.Point(642, 366);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(113, 37);
            this.btnSalir.TabIndex = 78;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // listBoxPdf
            // 
            this.listBoxPdf.FormattingEnabled = true;
            this.listBoxPdf.Location = new System.Drawing.Point(119, 12);
            this.listBoxPdf.Name = "listBoxPdf";
            this.listBoxPdf.Size = new System.Drawing.Size(636, 186);
            this.listBoxPdf.TabIndex = 79;
            this.listBoxPdf.SelectedIndexChanged += new System.EventHandler(this.listBoxPdf_SelectedIndexChanged);
            // 
            // btnAbrir
            // 
            this.btnAbrir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.btnAbrir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrir.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAbrir.ForeColor = System.Drawing.Color.Transparent;
            this.btnAbrir.Location = new System.Drawing.Point(248, 366);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(113, 37);
            this.btnAbrir.TabIndex = 80;
            this.btnAbrir.Text = "Abrir PDF";
            this.btnAbrir.UseVisualStyleBackColor = false;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frm_SubirPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAbrir);
            this.Controls.Add(this.listBoxPdf);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnSubir);
            this.Controls.Add(this.dgvPDF);
            this.Name = "frm_SubirPDF";
            this.Text = "frm_SubirPDF";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_SubirPDF_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPDF)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPDF;
        private System.Windows.Forms.Button btnSubir;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ListBox listBoxPdf;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}