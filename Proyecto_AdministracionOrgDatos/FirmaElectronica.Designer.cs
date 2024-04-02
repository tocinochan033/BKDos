namespace Proyecto_AdministracionOrgDatos
{
    partial class FirmaElectronica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirmaElectronica));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitulo_ESA = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_Guardar = new System.Windows.Forms.Button();
            this.button_Limpiar = new System.Windows.Forms.Button();
            this.button_Borrador = new System.Windows.Forms.Button();
            this.button_Pluma = new System.Windows.Forms.Button();
            this.Lienzo = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lienzo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.panel1.Controls.Add(this.lblTitulo_ESA);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(660, 77);
            this.panel1.TabIndex = 0;
            // 
            // lblTitulo_ESA
            // 
            this.lblTitulo_ESA.AutoSize = true;
            this.lblTitulo_ESA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.lblTitulo_ESA.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo_ESA.ForeColor = System.Drawing.Color.White;
            this.lblTitulo_ESA.Location = new System.Drawing.Point(22, 22);
            this.lblTitulo_ESA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo_ESA.Name = "lblTitulo_ESA";
            this.lblTitulo_ESA.Size = new System.Drawing.Size(224, 31);
            this.lblTitulo_ESA.TabIndex = 50;
            this.lblTitulo_ESA.Text = "Captura de Firma";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.button_Guardar);
            this.panel2.Controls.Add(this.button_Limpiar);
            this.panel2.Controls.Add(this.button_Borrador);
            this.panel2.Controls.Add(this.button_Pluma);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(144, 284);
            this.panel2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(11, 127);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button_Guardar
            // 
            this.button_Guardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.button_Guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Guardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.button_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Guardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Guardar.ForeColor = System.Drawing.Color.Snow;
            this.button_Guardar.Image = ((System.Drawing.Image)(resources.GetObject("button_Guardar.Image")));
            this.button_Guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Guardar.Location = new System.Drawing.Point(13, 208);
            this.button_Guardar.Margin = new System.Windows.Forms.Padding(2);
            this.button_Guardar.Name = "button_Guardar";
            this.button_Guardar.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.button_Guardar.Size = new System.Drawing.Size(118, 56);
            this.button_Guardar.TabIndex = 54;
            this.button_Guardar.Text = "Guardar";
            this.button_Guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Guardar.UseVisualStyleBackColor = false;
            this.button_Guardar.Click += new System.EventHandler(this.button_Guardar_Click);
            // 
            // button_Limpiar
            // 
            this.button_Limpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.button_Limpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Limpiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.button_Limpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Limpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Limpiar.ForeColor = System.Drawing.Color.Snow;
            this.button_Limpiar.Image = ((System.Drawing.Image)(resources.GetObject("button_Limpiar.Image")));
            this.button_Limpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Limpiar.Location = new System.Drawing.Point(13, 148);
            this.button_Limpiar.Margin = new System.Windows.Forms.Padding(2);
            this.button_Limpiar.Name = "button_Limpiar";
            this.button_Limpiar.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.button_Limpiar.Size = new System.Drawing.Size(118, 56);
            this.button_Limpiar.TabIndex = 53;
            this.button_Limpiar.Text = "Limpiar";
            this.button_Limpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Limpiar.UseVisualStyleBackColor = false;
            this.button_Limpiar.Click += new System.EventHandler(this.button_Limpiar_Click);
            // 
            // button_Borrador
            // 
            this.button_Borrador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.button_Borrador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Borrador.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.button_Borrador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Borrador.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Borrador.ForeColor = System.Drawing.Color.Snow;
            this.button_Borrador.Image = ((System.Drawing.Image)(resources.GetObject("button_Borrador.Image")));
            this.button_Borrador.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Borrador.Location = new System.Drawing.Point(11, 66);
            this.button_Borrador.Margin = new System.Windows.Forms.Padding(2);
            this.button_Borrador.Name = "button_Borrador";
            this.button_Borrador.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.button_Borrador.Size = new System.Drawing.Size(120, 56);
            this.button_Borrador.TabIndex = 52;
            this.button_Borrador.Text = "Borrador";
            this.button_Borrador.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Borrador.UseVisualStyleBackColor = false;
            this.button_Borrador.Click += new System.EventHandler(this.button_Borrador_Click);
            // 
            // button_Pluma
            // 
            this.button_Pluma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.button_Pluma.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Pluma.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.button_Pluma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Pluma.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Pluma.ForeColor = System.Drawing.Color.Snow;
            this.button_Pluma.Image = ((System.Drawing.Image)(resources.GetObject("button_Pluma.Image")));
            this.button_Pluma.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Pluma.Location = new System.Drawing.Point(11, 6);
            this.button_Pluma.Margin = new System.Windows.Forms.Padding(2);
            this.button_Pluma.Name = "button_Pluma";
            this.button_Pluma.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.button_Pluma.Size = new System.Drawing.Size(120, 56);
            this.button_Pluma.TabIndex = 51;
            this.button_Pluma.Text = "Pluma";
            this.button_Pluma.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Pluma.UseVisualStyleBackColor = false;
            this.button_Pluma.Click += new System.EventHandler(this.button_Pluma_Click);
            // 
            // Lienzo
            // 
            this.Lienzo.BackColor = System.Drawing.Color.White;
            this.Lienzo.Location = new System.Drawing.Point(163, 96);
            this.Lienzo.Name = "Lienzo";
            this.Lienzo.Size = new System.Drawing.Size(477, 244);
            this.Lienzo.TabIndex = 2;
            this.Lienzo.TabStop = false;
            this.Lienzo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Lienzo_MouseDown);
            this.Lienzo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Lienzo_MouseMove);
            this.Lienzo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Lienzo_MouseUp);
            // 
            // FirmaElectronica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(660, 361);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Lienzo);
            this.Name = "FirmaElectronica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FirmaElectronica";
            this.Load += new System.EventHandler(this.FirmaElectronica_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lienzo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTitulo_ESA;
        private System.Windows.Forms.Button button_Pluma;
        private System.Windows.Forms.Button button_Guardar;
        private System.Windows.Forms.Button button_Limpiar;
        private System.Windows.Forms.Button button_Borrador;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox Lienzo;
    }
}