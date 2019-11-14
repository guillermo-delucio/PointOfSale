namespace PointOfSale.Views.Modulos.PuntoVenta
{
    partial class FrmFacturaGlobal3
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.TxtImpuestos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtTotal = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.TxtSubtotal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtImporteExcento = new System.Windows.Forms.NumericUpDown();
            this.TxtImporteIva16 = new System.Windows.Forms.NumericUpDown();
            this.TxtImporteImpuestoExcento = new System.Windows.Forms.TextBox();
            this.TxtImporteImpuestoIva16 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtImporteExcento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtImporteIva16)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.TxtImpuestos);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.TxtTotal);
            this.groupBox5.Controls.Add(this.label26);
            this.groupBox5.Controls.Add(this.TxtSubtotal);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Location = new System.Drawing.Point(9, 161);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(457, 113);
            this.groupBox5.TabIndex = 266;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "TOTALES";
            // 
            // TxtImpuestos
            // 
            this.TxtImpuestos.BackColor = System.Drawing.SystemColors.Window;
            this.TxtImpuestos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtImpuestos.Enabled = false;
            this.TxtImpuestos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtImpuestos.ForeColor = System.Drawing.Color.DimGray;
            this.TxtImpuestos.Location = new System.Drawing.Point(210, 45);
            this.TxtImpuestos.Name = "TxtImpuestos";
            this.TxtImpuestos.ReadOnly = true;
            this.TxtImpuestos.Size = new System.Drawing.Size(235, 24);
            this.TxtImpuestos.TabIndex = 246;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(96, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 18);
            this.label1.TabIndex = 247;
            this.label1.Text = "IMPUESTOS $";
            // 
            // TxtTotal
            // 
            this.TxtTotal.BackColor = System.Drawing.SystemColors.Window;
            this.TxtTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtTotal.Enabled = false;
            this.TxtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotal.ForeColor = System.Drawing.Color.DimGray;
            this.TxtTotal.Location = new System.Drawing.Point(210, 75);
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.ReadOnly = true;
            this.TxtTotal.Size = new System.Drawing.Size(235, 24);
            this.TxtTotal.TabIndex = 231;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label26.Location = new System.Drawing.Point(137, 78);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(67, 18);
            this.label26.TabIndex = 232;
            this.label26.Text = "TOTAL $";
            // 
            // TxtSubtotal
            // 
            this.TxtSubtotal.BackColor = System.Drawing.SystemColors.Window;
            this.TxtSubtotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtSubtotal.Enabled = false;
            this.TxtSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSubtotal.ForeColor = System.Drawing.Color.DimGray;
            this.TxtSubtotal.Location = new System.Drawing.Point(210, 15);
            this.TxtSubtotal.Name = "TxtSubtotal";
            this.TxtSubtotal.ReadOnly = true;
            this.TxtSubtotal.Size = new System.Drawing.Size(235, 24);
            this.TxtSubtotal.TabIndex = 227;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(106, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 18);
            this.label8.TabIndex = 228;
            this.label8.Text = "SUBTOTAL $";
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptar.Location = new System.Drawing.Point(258, 280);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(95, 39);
            this.BtnAceptar.TabIndex = 244;
            this.BtnAceptar.Text = "&ACEPTAR";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(359, 280);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(95, 39);
            this.BtnCancelar.TabIndex = 245;
            this.BtnCancelar.Text = "SALIR";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.label14.Location = new System.Drawing.Point(6, 34);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(463, 10);
            this.label14.TabIndex = 267;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label13.Location = new System.Drawing.Point(18, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(149, 25);
            this.label13.TabIndex = 268;
            this.label13.Text = "Factura global";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtImporteExcento);
            this.groupBox1.Controls.Add(this.TxtImporteIva16);
            this.groupBox1.Controls.Add(this.TxtImporteImpuestoExcento);
            this.groupBox1.Controls.Add(this.TxtImporteImpuestoIva16);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(9, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(457, 108);
            this.groupBox1.TabIndex = 267;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PARTIDAS";
            // 
            // TxtImporteExcento
            // 
            this.TxtImporteExcento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.TxtImporteExcento.Location = new System.Drawing.Point(122, 71);
            this.TxtImporteExcento.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.TxtImporteExcento.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TxtImporteExcento.Name = "TxtImporteExcento";
            this.TxtImporteExcento.Size = new System.Drawing.Size(152, 26);
            this.TxtImporteExcento.TabIndex = 270;
            this.TxtImporteExcento.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TxtImporteIva16
            // 
            this.TxtImporteIva16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.TxtImporteIva16.Location = new System.Drawing.Point(122, 41);
            this.TxtImporteIva16.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.TxtImporteIva16.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TxtImporteIva16.Name = "TxtImporteIva16";
            this.TxtImporteIva16.Size = new System.Drawing.Size(152, 26);
            this.TxtImporteIva16.TabIndex = 269;
            this.TxtImporteIva16.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TxtImporteIva16.ValueChanged += new System.EventHandler(this.TxtImporteIva16_ValueChanged);
            // 
            // TxtImporteImpuestoExcento
            // 
            this.TxtImporteImpuestoExcento.BackColor = System.Drawing.SystemColors.Window;
            this.TxtImporteImpuestoExcento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtImporteImpuestoExcento.Enabled = false;
            this.TxtImporteImpuestoExcento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtImporteImpuestoExcento.ForeColor = System.Drawing.Color.DimGray;
            this.TxtImporteImpuestoExcento.Location = new System.Drawing.Point(280, 71);
            this.TxtImporteImpuestoExcento.Name = "TxtImporteImpuestoExcento";
            this.TxtImporteImpuestoExcento.ReadOnly = true;
            this.TxtImporteImpuestoExcento.Size = new System.Drawing.Size(165, 24);
            this.TxtImporteImpuestoExcento.TabIndex = 253;
            this.TxtImporteImpuestoExcento.Text = "0.000000";
            // 
            // TxtImporteImpuestoIva16
            // 
            this.TxtImporteImpuestoIva16.BackColor = System.Drawing.SystemColors.Window;
            this.TxtImporteImpuestoIva16.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtImporteImpuestoIva16.Enabled = false;
            this.TxtImporteImpuestoIva16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtImporteImpuestoIva16.ForeColor = System.Drawing.Color.DimGray;
            this.TxtImporteImpuestoIva16.Location = new System.Drawing.Point(280, 41);
            this.TxtImporteImpuestoIva16.Name = "TxtImporteImpuestoIva16";
            this.TxtImporteImpuestoIva16.ReadOnly = true;
            this.TxtImporteImpuestoIva16.Size = new System.Drawing.Size(165, 24);
            this.TxtImporteImpuestoIva16.TabIndex = 252;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(280, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 18);
            this.label2.TabIndex = 251;
            this.label2.Text = "IMPUESTO A GRABAR";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(46, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 18);
            this.label10.TabIndex = 249;
            this.label10.Text = "EXENTO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(67, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 18);
            this.label3.TabIndex = 248;
            this.label3.Text = "IVA 16";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(119, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 18);
            this.label4.TabIndex = 228;
            this.label4.Text = "IMPORTE A GRABAR";
            // 
            // FrmFacturaGlobal3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 330);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.BtnCancelar);
            this.Name = "FrmFacturaGlobal3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmFacturaGlobal3";
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtImporteExcento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtImporteIva16)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox TxtImpuestos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtTotal;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.TextBox TxtSubtotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtImporteImpuestoExcento;
        private System.Windows.Forms.TextBox TxtImporteImpuestoIva16;
        private System.Windows.Forms.NumericUpDown TxtImporteIva16;
        private System.Windows.Forms.NumericUpDown TxtImporteExcento;
    }
}