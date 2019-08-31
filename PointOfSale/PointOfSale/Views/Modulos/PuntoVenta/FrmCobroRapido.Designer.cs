namespace PointOfSale.Views.Modulos.PuntoVenta
{
    partial class FrmCobroRapido
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
            this.TxtPago1 = new System.Windows.Forms.TextBox();
            this.TxtConceptoPago1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtFormaPago1 = new System.Windows.Forms.TextBox();
            this.RTicket = new System.Windows.Forms.RadioButton();
            this.RFactura = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtTotal = new System.Windows.Forms.TextBox();
            this.BtnCXC = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtCambio = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtPago3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtFormaPago2 = new System.Windows.Forms.TextBox();
            this.TxtConceptoPago3 = new System.Windows.Forms.TextBox();
            this.TxtConceptoPago2 = new System.Windows.Forms.TextBox();
            this.TxtFormaPago3 = new System.Windows.Forms.TextBox();
            this.TxtPago2 = new System.Windows.Forms.TextBox();
            this.ChkCobrarConPtos = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtPago1
            // 
            this.TxtPago1.BackColor = System.Drawing.SystemColors.Window;
            this.TxtPago1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtPago1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPago1.ForeColor = System.Drawing.Color.DimGray;
            this.TxtPago1.Location = new System.Drawing.Point(285, 69);
            this.TxtPago1.Name = "TxtPago1";
            this.TxtPago1.Size = new System.Drawing.Size(117, 29);
            this.TxtPago1.TabIndex = 1;
            this.TxtPago1.Text = "0.00";
            this.TxtPago1.TextChanged += new System.EventHandler(this.TxtPago1_TextChanged);
            this.TxtPago1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPago1_KeyDown);
            this.TxtPago1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPago1_KeyPress);
            // 
            // TxtConceptoPago1
            // 
            this.TxtConceptoPago1.BackColor = System.Drawing.SystemColors.Window;
            this.TxtConceptoPago1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtConceptoPago1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtConceptoPago1.ForeColor = System.Drawing.Color.DimGray;
            this.TxtConceptoPago1.Location = new System.Drawing.Point(162, 69);
            this.TxtConceptoPago1.Name = "TxtConceptoPago1";
            this.TxtConceptoPago1.Size = new System.Drawing.Size(117, 29);
            this.TxtConceptoPago1.TabIndex = 248;
            this.TxtConceptoPago1.TabStop = false;
            this.TxtConceptoPago1.Text = "EFECTIVO";
            this.TxtConceptoPago1.TextChanged += new System.EventHandler(this.TxtConceptoPago1_TextChanged);
            this.TxtConceptoPago1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtConceptoPago1_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(15, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 25);
            this.label1.TabIndex = 247;
            this.label1.Text = "♥PAGO1";
            // 
            // TxtFormaPago1
            // 
            this.TxtFormaPago1.BackColor = System.Drawing.SystemColors.Window;
            this.TxtFormaPago1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtFormaPago1.Enabled = false;
            this.TxtFormaPago1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFormaPago1.ForeColor = System.Drawing.Color.DimGray;
            this.TxtFormaPago1.Location = new System.Drawing.Point(126, 69);
            this.TxtFormaPago1.Name = "TxtFormaPago1";
            this.TxtFormaPago1.Size = new System.Drawing.Size(30, 29);
            this.TxtFormaPago1.TabIndex = 246;
            this.TxtFormaPago1.TabStop = false;
            this.TxtFormaPago1.Text = "01";
            this.TxtFormaPago1.TextChanged += new System.EventHandler(this.TxtFormaPago1_TextChanged);
            // 
            // RTicket
            // 
            this.RTicket.AutoSize = true;
            this.RTicket.Checked = true;
            this.RTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RTicket.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.RTicket.Location = new System.Drawing.Point(6, 17);
            this.RTicket.Name = "RTicket";
            this.RTicket.Size = new System.Drawing.Size(94, 28);
            this.RTicket.TabIndex = 2;
            this.RTicket.TabStop = true;
            this.RTicket.Text = "TICKET";
            this.RTicket.UseVisualStyleBackColor = true;
            this.RTicket.CheckedChanged += new System.EventHandler(this.RTicket_CheckedChanged);
            // 
            // RFactura
            // 
            this.RFactura.AutoSize = true;
            this.RFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RFactura.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.RFactura.Location = new System.Drawing.Point(6, 51);
            this.RFactura.Name = "RFactura";
            this.RFactura.Size = new System.Drawing.Size(117, 28);
            this.RFactura.TabIndex = 3;
            this.RFactura.TabStop = true;
            this.RFactura.Text = "FACTURA";
            this.RFactura.UseVisualStyleBackColor = true;
            this.RFactura.CheckedChanged += new System.EventHandler(this.RFactura_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(172, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 25);
            this.label2.TabIndex = 249;
            this.label2.Text = "IMPORTE";
            // 
            // TxtTotal
            // 
            this.TxtTotal.BackColor = System.Drawing.Color.Black;
            this.TxtTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotal.ForeColor = System.Drawing.Color.Lime;
            this.TxtTotal.Location = new System.Drawing.Point(285, 21);
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.ReadOnly = true;
            this.TxtTotal.Size = new System.Drawing.Size(117, 29);
            this.TxtTotal.TabIndex = 250;
            this.TxtTotal.TabStop = false;
            this.TxtTotal.Text = "455.90";
            // 
            // BtnCXC
            // 
            this.BtnCXC.Image = global::PointOfSale.Properties.Resources.writing;
            this.BtnCXC.Location = new System.Drawing.Point(312, 291);
            this.BtnCXC.Name = "BtnCXC";
            this.BtnCXC.Size = new System.Drawing.Size(109, 46);
            this.BtnCXC.TabIndex = 4;
            this.BtnCXC.Text = "CUENTA X COBRAR";
            this.BtnCXC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCXC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCXC.UseVisualStyleBackColor = true;
            this.BtnCXC.Click += new System.EventHandler(this.BtnCXC_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Image = global::PointOfSale.Properties.Resources.back;
            this.BtnCancelar.Location = new System.Drawing.Point(197, 291);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(109, 46);
            this.BtnCancelar.TabIndex = 3;
            this.BtnCancelar.Text = "CANCELAR";
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Image = global::PointOfSale.Properties.Resources.ok;
            this.BtnAceptar.Location = new System.Drawing.Point(82, 291);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(109, 46);
            this.BtnAceptar.TabIndex = 2;
            this.BtnAceptar.Text = "ACEPTAR";
            this.BtnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.RFactura);
            this.groupBox1.Controls.Add(this.TxtCambio);
            this.groupBox1.Controls.Add(this.RTicket);
            this.groupBox1.Location = new System.Drawing.Point(13, 196);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 89);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(185, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 25);
            this.label5.TabIndex = 270;
            this.label5.Text = "CAMBIO";
            // 
            // TxtCambio
            // 
            this.TxtCambio.BackColor = System.Drawing.Color.Black;
            this.TxtCambio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCambio.ForeColor = System.Drawing.Color.Lime;
            this.TxtCambio.Location = new System.Drawing.Point(285, 19);
            this.TxtCambio.Name = "TxtCambio";
            this.TxtCambio.ReadOnly = true;
            this.TxtCambio.Size = new System.Drawing.Size(117, 29);
            this.TxtCambio.TabIndex = 271;
            this.TxtCambio.TabStop = false;
            this.TxtCambio.Text = "0.00";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ChkCobrarConPtos);
            this.groupBox2.Controls.Add(this.TxtPago3);
            this.groupBox2.Controls.Add(this.TxtFormaPago1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.TxtConceptoPago1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.TxtTotal);
            this.groupBox2.Controls.Add(this.TxtPago1);
            this.groupBox2.Controls.Add(this.TxtFormaPago2);
            this.groupBox2.Controls.Add(this.TxtConceptoPago3);
            this.groupBox2.Controls.Add(this.TxtConceptoPago2);
            this.groupBox2.Controls.Add(this.TxtFormaPago3);
            this.groupBox2.Controls.Add(this.TxtPago2);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(408, 178);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // TxtPago3
            // 
            this.TxtPago3.BackColor = System.Drawing.SystemColors.Window;
            this.TxtPago3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtPago3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPago3.ForeColor = System.Drawing.Color.DimGray;
            this.TxtPago3.Location = new System.Drawing.Point(285, 129);
            this.TxtPago3.Name = "TxtPago3";
            this.TxtPago3.Size = new System.Drawing.Size(117, 29);
            this.TxtPago3.TabIndex = 5;
            this.TxtPago3.TextChanged += new System.EventHandler(this.TxtPago3_TextChanged);
            this.TxtPago3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPago3_KeyDown);
            this.TxtPago3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPago3_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(14, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 25);
            this.label4.TabIndex = 268;
            this.label4.Text = "♥PAGO3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(15, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 25);
            this.label3.TabIndex = 267;
            this.label3.Text = "♥PAGO2";
            // 
            // TxtFormaPago2
            // 
            this.TxtFormaPago2.BackColor = System.Drawing.SystemColors.Window;
            this.TxtFormaPago2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtFormaPago2.Enabled = false;
            this.TxtFormaPago2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFormaPago2.ForeColor = System.Drawing.Color.DimGray;
            this.TxtFormaPago2.Location = new System.Drawing.Point(126, 99);
            this.TxtFormaPago2.Name = "TxtFormaPago2";
            this.TxtFormaPago2.Size = new System.Drawing.Size(30, 29);
            this.TxtFormaPago2.TabIndex = 252;
            this.TxtFormaPago2.TabStop = false;
            this.TxtFormaPago2.TextChanged += new System.EventHandler(this.TxtFormaPago2_TextChanged);
            // 
            // TxtConceptoPago3
            // 
            this.TxtConceptoPago3.BackColor = System.Drawing.SystemColors.Window;
            this.TxtConceptoPago3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtConceptoPago3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtConceptoPago3.ForeColor = System.Drawing.Color.DimGray;
            this.TxtConceptoPago3.Location = new System.Drawing.Point(162, 129);
            this.TxtConceptoPago3.Name = "TxtConceptoPago3";
            this.TxtConceptoPago3.Size = new System.Drawing.Size(117, 29);
            this.TxtConceptoPago3.TabIndex = 4;
            this.TxtConceptoPago3.TextChanged += new System.EventHandler(this.TxtConceptoPago3_TextChanged);
            this.TxtConceptoPago3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtConceptoPago3_KeyDown);
            // 
            // TxtConceptoPago2
            // 
            this.TxtConceptoPago2.BackColor = System.Drawing.SystemColors.Window;
            this.TxtConceptoPago2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtConceptoPago2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtConceptoPago2.ForeColor = System.Drawing.Color.DimGray;
            this.TxtConceptoPago2.Location = new System.Drawing.Point(162, 99);
            this.TxtConceptoPago2.Name = "TxtConceptoPago2";
            this.TxtConceptoPago2.Size = new System.Drawing.Size(117, 29);
            this.TxtConceptoPago2.TabIndex = 2;
            this.TxtConceptoPago2.TextChanged += new System.EventHandler(this.TxtConceptoPago2_TextChanged);
            this.TxtConceptoPago2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtConceptoPago2_KeyDown);
            // 
            // TxtFormaPago3
            // 
            this.TxtFormaPago3.BackColor = System.Drawing.SystemColors.Window;
            this.TxtFormaPago3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtFormaPago3.Enabled = false;
            this.TxtFormaPago3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFormaPago3.ForeColor = System.Drawing.Color.DimGray;
            this.TxtFormaPago3.Location = new System.Drawing.Point(126, 129);
            this.TxtFormaPago3.Name = "TxtFormaPago3";
            this.TxtFormaPago3.Size = new System.Drawing.Size(30, 29);
            this.TxtFormaPago3.TabIndex = 256;
            this.TxtFormaPago3.TabStop = false;
            this.TxtFormaPago3.TextChanged += new System.EventHandler(this.TxtFormaPago3_TextChanged);
            // 
            // TxtPago2
            // 
            this.TxtPago2.BackColor = System.Drawing.SystemColors.Window;
            this.TxtPago2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtPago2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPago2.ForeColor = System.Drawing.Color.DimGray;
            this.TxtPago2.Location = new System.Drawing.Point(285, 99);
            this.TxtPago2.Name = "TxtPago2";
            this.TxtPago2.Size = new System.Drawing.Size(117, 29);
            this.TxtPago2.TabIndex = 3;
            this.TxtPago2.TextChanged += new System.EventHandler(this.TxtPago2_TextChanged);
            this.TxtPago2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPago2_KeyDown);
            this.TxtPago2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPago2_KeyPress);
            // 
            // ChkCobrarConPtos
            // 
            this.ChkCobrarConPtos.AutoSize = true;
            this.ChkCobrarConPtos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.ChkCobrarConPtos.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ChkCobrarConPtos.Location = new System.Drawing.Point(19, 24);
            this.ChkCobrarConPtos.Name = "ChkCobrarConPtos";
            this.ChkCobrarConPtos.Size = new System.Drawing.Size(151, 22);
            this.ChkCobrarConPtos.TabIndex = 294;
            this.ChkCobrarConPtos.TabStop = false;
            this.ChkCobrarConPtos.Text = "Cobrar con puntos";
            this.ChkCobrarConPtos.UseVisualStyleBackColor = true;
            // 
            // FrmCobroRapido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 358);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnCXC);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAceptar);
            this.Name = "FrmCobroRapido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCobroRapido";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox TxtPago1;
        private System.Windows.Forms.TextBox TxtConceptoPago1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtFormaPago1;
        private System.Windows.Forms.RadioButton RTicket;
        private System.Windows.Forms.RadioButton RFactura;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtTotal;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnCXC;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtCambio;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtPago3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtFormaPago2;
        private System.Windows.Forms.TextBox TxtConceptoPago3;
        private System.Windows.Forms.TextBox TxtConceptoPago2;
        private System.Windows.Forms.TextBox TxtFormaPago3;
        private System.Windows.Forms.TextBox TxtPago2;
        private System.Windows.Forms.CheckBox ChkCobrarConPtos;
    }
}