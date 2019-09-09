namespace PointOfSale.Views.Modulos.PuntoVenta
{
    partial class FrmFacturas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Malla = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ChkSinTimbrar = new System.Windows.Forms.CheckBox();
            this.BtnFiltrarFecha = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.DpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.DpFechaIni = new System.Windows.Forms.DateTimePicker();
            this.BtnFacturar = new System.Windows.Forms.Button();
            this.BtnCambiarCliente = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Malla)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Malla
            // 
            this.Malla.AllowUserToAddRows = false;
            this.Malla.AllowUserToDeleteRows = false;
            this.Malla.AllowUserToOrderColumns = true;
            this.Malla.BackgroundColor = System.Drawing.Color.White;
            this.Malla.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Malla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Malla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column5,
            this.Column3,
            this.Column4,
            this.Column6});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Malla.DefaultCellStyle = dataGridViewCellStyle2;
            this.Malla.EnableHeadersVisualStyles = false;
            this.Malla.Location = new System.Drawing.Point(12, 90);
            this.Malla.MultiSelect = false;
            this.Malla.Name = "Malla";
            this.Malla.ReadOnly = true;
            this.Malla.Size = new System.Drawing.Size(909, 261);
            this.Malla.TabIndex = 275;
            this.Malla.TabStop = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "VENTA";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 80;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "No. DOC.";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 80;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "FECHA";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "CLIENTE";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 300;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "IMPORTE";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.HeaderText = "UUID";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ChkSinTimbrar);
            this.groupBox1.Controls.Add(this.BtnFiltrarFecha);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.DpFechaFin);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.DpFechaIni);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(909, 72);
            this.groupBox1.TabIndex = 276;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(295, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 18);
            this.label2.TabIndex = 243;
            this.label2.Text = "|";
            // 
            // ChkSinTimbrar
            // 
            this.ChkSinTimbrar.AutoSize = true;
            this.ChkSinTimbrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.ChkSinTimbrar.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ChkSinTimbrar.Location = new System.Drawing.Point(319, 31);
            this.ChkSinTimbrar.Name = "ChkSinTimbrar";
            this.ChkSinTimbrar.Size = new System.Drawing.Size(167, 22);
            this.ChkSinTimbrar.TabIndex = 242;
            this.ChkSinTimbrar.Text = "SÓLO SIN TIMBRAR";
            this.ChkSinTimbrar.UseVisualStyleBackColor = true;
            // 
            // BtnFiltrarFecha
            // 
            this.BtnFiltrarFecha.Location = new System.Drawing.Point(841, 13);
            this.BtnFiltrarFecha.Name = "BtnFiltrarFecha";
            this.BtnFiltrarFecha.Size = new System.Drawing.Size(62, 56);
            this.BtnFiltrarFecha.TabIndex = 238;
            this.BtnFiltrarFecha.Text = "FILTRAR";
            this.BtnFiltrarFecha.UseVisualStyleBackColor = true;
            this.BtnFiltrarFecha.Click += new System.EventHandler(this.BtnFiltrarFecha_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(145, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 18);
            this.label4.TabIndex = 237;
            this.label4.Text = "FECHA FINAL";
            // 
            // DpFechaFin
            // 
            this.DpFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.DpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DpFechaFin.Location = new System.Drawing.Point(145, 29);
            this.DpFechaFin.Name = "DpFechaFin";
            this.DpFechaFin.Size = new System.Drawing.Size(133, 24);
            this.DpFechaFin.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(6, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 18);
            this.label3.TabIndex = 230;
            this.label3.Text = "FECHA INICIAL";
            // 
            // DpFechaIni
            // 
            this.DpFechaIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.DpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DpFechaIni.Location = new System.Drawing.Point(6, 29);
            this.DpFechaIni.Name = "DpFechaIni";
            this.DpFechaIni.Size = new System.Drawing.Size(133, 24);
            this.DpFechaIni.TabIndex = 3;
            // 
            // BtnFacturar
            // 
            this.BtnFacturar.BackColor = System.Drawing.SystemColors.Control;
            this.BtnFacturar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFacturar.Location = new System.Drawing.Point(12, 356);
            this.BtnFacturar.Name = "BtnFacturar";
            this.BtnFacturar.Size = new System.Drawing.Size(95, 39);
            this.BtnFacturar.TabIndex = 277;
            this.BtnFacturar.Text = "&FACTURAR";
            this.BtnFacturar.UseVisualStyleBackColor = false;
            this.BtnFacturar.Click += new System.EventHandler(this.BtnFacturar_Click);
            // 
            // BtnCambiarCliente
            // 
            this.BtnCambiarCliente.Location = new System.Drawing.Point(214, 357);
            this.BtnCambiarCliente.Name = "BtnCambiarCliente";
            this.BtnCambiarCliente.Size = new System.Drawing.Size(127, 38);
            this.BtnCambiarCliente.TabIndex = 278;
            this.BtnCambiarCliente.Text = "ACTUALIZAR DATOS DEL CLIENTE ";
            this.BtnCambiarCliente.UseVisualStyleBackColor = true;
            this.BtnCambiarCliente.Click += new System.EventHandler(this.BtnCambiarCliente_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Location = new System.Drawing.Point(826, 357);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(95, 39);
            this.BtnSalir.TabIndex = 281;
            this.BtnSalir.Text = "SALIR";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(113, 356);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(95, 39);
            this.BtnCancelar.TabIndex = 282;
            this.BtnCancelar.Text = "&CANCELAR";
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LimeGreen;
            this.textBox1.Location = new System.Drawing.Point(475, 366);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 283;
            this.textBox1.Text = "Timbrada vigente";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(369, 367);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 284;
            this.textBox2.Text = "Por timbrar";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.Red;
            this.textBox3.Location = new System.Drawing.Point(716, 366);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 285;
            this.textBox3.Text = "Cancelada";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.Orange;
            this.textBox4.Location = new System.Drawing.Point(581, 366);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(129, 20);
            this.textBox4.TabIndex = 286;
            this.textBox4.Text = "Esperando cancelación";
            // 
            // FrmFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 407);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.BtnFacturar);
            this.Controls.Add(this.BtnCambiarCliente);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Malla);
            this.Name = "FrmFacturas";
            this.Text = "Facturas";
            this.Load += new System.EventHandler(this.FrmFacturas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Malla)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Malla;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DpFechaFin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DpFechaIni;
        private System.Windows.Forms.Button BtnFiltrarFecha;
        private System.Windows.Forms.Button BtnFacturar;
        private System.Windows.Forms.Button BtnCambiarCliente;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.CheckBox ChkSinTimbrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
    }
}