namespace PointOfSale.Views.Modulos.Logistica
{
    partial class FrmLoteCaducidad
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TxtNoLote = new System.Windows.Forms.TextBox();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.DpFechaCaducidad = new System.Windows.Forms.DateTimePicker();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label21 = new System.Windows.Forms.Label();
            this.Malla = new System.Windows.Forms.DataGridView();
            this.NCantidad = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtDescrip = new System.Windows.Forms.TextBox();
            this.TxtProductoId = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.TxtRestante = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Malla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NCantidad)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtNoLote
            // 
            this.TxtNoLote.BackColor = System.Drawing.SystemColors.Window;
            this.TxtNoLote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNoLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNoLote.ForeColor = System.Drawing.Color.Black;
            this.TxtNoLote.Location = new System.Drawing.Point(9, 37);
            this.TxtNoLote.Name = "TxtNoLote";
            this.TxtNoLote.Size = new System.Drawing.Size(94, 24);
            this.TxtNoLote.TabIndex = 0;
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Location = new System.Drawing.Point(357, 36);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(95, 27);
            this.BtnAgregar.TabIndex = 4;
            this.BtnAgregar.Text = "AGREGAR";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(194, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 18);
            this.label4.TabIndex = 263;
            this.label4.Text = "CADUCIDAD";
            // 
            // DpFechaCaducidad
            // 
            this.DpFechaCaducidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.DpFechaCaducidad.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DpFechaCaducidad.Location = new System.Drawing.Point(197, 38);
            this.DpFechaCaducidad.Name = "DpFechaCaducidad";
            this.DpFechaCaducidad.Size = new System.Drawing.Size(149, 24);
            this.DpFechaCaducidad.TabIndex = 3;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column4.HeaderText = "STOCK ACTUAL";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "STOCK INICIAL";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "CADUCIDAD";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "LOTE";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label21.Location = new System.Drawing.Point(9, 16);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(75, 18);
            this.label21.TabIndex = 267;
            this.label21.Text = "No. LOTE";
            // 
            // Malla
            // 
            this.Malla.AllowUserToAddRows = false;
            this.Malla.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Malla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Malla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Malla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Malla.DefaultCellStyle = dataGridViewCellStyle2;
            this.Malla.Location = new System.Drawing.Point(9, 69);
            this.Malla.Name = "Malla";
            this.Malla.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Malla.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Malla.Size = new System.Drawing.Size(443, 180);
            this.Malla.TabIndex = 265;
            this.Malla.TabStop = false;
            this.Malla.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Malla_KeyDown);
            // 
            // NCantidad
            // 
            this.NCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NCantidad.Location = new System.Drawing.Point(109, 36);
            this.NCantidad.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.NCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NCantidad.Name = "NCantidad";
            this.NCantidad.Size = new System.Drawing.Size(79, 26);
            this.NCantidad.TabIndex = 2;
            this.NCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(106, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 18);
            this.label5.TabIndex = 261;
            this.label5.Text = "CANTIDAD";
            // 
            // TxtDescrip
            // 
            this.TxtDescrip.BackColor = System.Drawing.SystemColors.Window;
            this.TxtDescrip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtDescrip.Enabled = false;
            this.TxtDescrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDescrip.ForeColor = System.Drawing.Color.DimGray;
            this.TxtDescrip.Location = new System.Drawing.Point(9, 59);
            this.TxtDescrip.Name = "TxtDescrip";
            this.TxtDescrip.Size = new System.Drawing.Size(443, 24);
            this.TxtDescrip.TabIndex = 262;
            this.TxtDescrip.TabStop = false;
            // 
            // TxtProductoId
            // 
            this.TxtProductoId.BackColor = System.Drawing.SystemColors.Window;
            this.TxtProductoId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtProductoId.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProductoId.ForeColor = System.Drawing.Color.Black;
            this.TxtProductoId.Location = new System.Drawing.Point(109, 31);
            this.TxtProductoId.Name = "TxtProductoId";
            this.TxtProductoId.Size = new System.Drawing.Size(343, 24);
            this.TxtProductoId.TabIndex = 0;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label22.Location = new System.Drawing.Point(106, 10);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(113, 18);
            this.label22.TabIndex = 261;
            this.label22.Text = "♥PRODUCTO";
            // 
            // TxtRestante
            // 
            this.TxtRestante.BackColor = System.Drawing.SystemColors.Window;
            this.TxtRestante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtRestante.Enabled = false;
            this.TxtRestante.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRestante.ForeColor = System.Drawing.Color.DimGray;
            this.TxtRestante.Location = new System.Drawing.Point(9, 31);
            this.TxtRestante.Name = "TxtRestante";
            this.TxtRestante.Size = new System.Drawing.Size(94, 24);
            this.TxtRestante.TabIndex = 259;
            this.TxtRestante.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 18);
            this.label1.TabIndex = 252;
            this.label1.Text = " RESTANTE";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtNoLote);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.Malla);
            this.groupBox2.Controls.Add(this.BtnAgregar);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.DpFechaCaducidad);
            this.groupBox2.Controls.Add(this.NCantidad);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(6, 155);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(467, 249);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(273, 429);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(95, 39);
            this.BtnCancelar.TabIndex = 6;
            this.BtnCancelar.Text = "SALIR";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptar.Location = new System.Drawing.Point(374, 429);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(95, 39);
            this.BtnAceptar.TabIndex = 5;
            this.BtnAceptar.Text = "&ACEPTAR";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtDescrip);
            this.groupBox1.Controls.Add(this.TxtProductoId);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.TxtRestante);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.DimGray;
            this.groupBox1.Location = new System.Drawing.Point(6, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(467, 92);
            this.groupBox1.TabIndex = 239;
            this.groupBox1.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label13.Location = new System.Drawing.Point(5, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(163, 25);
            this.label13.TabIndex = 244;
            this.label13.Text = "Control de lotes";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.label14.Location = new System.Drawing.Point(7, 34);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(466, 10);
            this.label14.TabIndex = 243;
            // 
            // FrmLoteCaducidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 476);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Name = "FrmLoteCaducidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLoteCaducidad";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.Malla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NCantidad)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtNoLote;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DpFechaCaducidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DataGridView Malla;
        private System.Windows.Forms.NumericUpDown NCantidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtDescrip;
        private System.Windows.Forms.TextBox TxtProductoId;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox TxtRestante;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
    }
}