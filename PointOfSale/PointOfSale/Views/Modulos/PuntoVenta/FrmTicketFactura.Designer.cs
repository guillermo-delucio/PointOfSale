namespace PointOfSale.Views.Modulos.PuntoVenta
{
    partial class FrmTicketFactura
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
            this.label1 = new System.Windows.Forms.Label();
            this.Malla = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.TxtNoRereren = new System.Windows.Forms.TextBox();
            this.TxtFormaPago = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ChkMismoCliente = new System.Windows.Forms.CheckBox();
            this.TxtMetodoPago = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtUsoCFDI = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtCliente = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Malla)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 18);
            this.label1.TabIndex = 228;
            this.label1.Text = "♥NO. DE TICKET O CÓDIGO DE BARRAS";
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
            this.Column3,
            this.Column2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Malla.DefaultCellStyle = dataGridViewCellStyle2;
            this.Malla.EnableHeadersVisualStyles = false;
            this.Malla.Location = new System.Drawing.Point(12, 196);
            this.Malla.MultiSelect = false;
            this.Malla.Name = "Malla";
            this.Malla.Size = new System.Drawing.Size(612, 122);
            this.Malla.TabIndex = 274;
            this.Malla.TabStop = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "TICKET";
            this.Column1.Name = "Column1";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "STATUS";
            this.Column3.Name = "Column3";
            this.Column3.Width = 70;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "DATOS";
            this.Column2.Name = "Column2";
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptar.Location = new System.Drawing.Point(529, 324);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(95, 39);
            this.BtnAceptar.TabIndex = 6;
            this.BtnAceptar.Text = "&FACTURAR";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(428, 324);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(95, 39);
            this.BtnCancelar.TabIndex = 7;
            this.BtnCancelar.Text = "SALIR";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // TxtNoRereren
            // 
            this.TxtNoRereren.BackColor = System.Drawing.SystemColors.Window;
            this.TxtNoRereren.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNoRereren.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNoRereren.ForeColor = System.Drawing.Color.Black;
            this.TxtNoRereren.Location = new System.Drawing.Point(12, 40);
            this.TxtNoRereren.Name = "TxtNoRereren";
            this.TxtNoRereren.Size = new System.Drawing.Size(301, 24);
            this.TxtNoRereren.TabIndex = 0;
            this.TxtNoRereren.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtNoRereren_KeyDown);
            this.TxtNoRereren.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNoRereren_KeyPress);
            // 
            // TxtFormaPago
            // 
            this.TxtFormaPago.BackColor = System.Drawing.SystemColors.Window;
            this.TxtFormaPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtFormaPago.Enabled = false;
            this.TxtFormaPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFormaPago.ForeColor = System.Drawing.Color.Black;
            this.TxtFormaPago.Location = new System.Drawing.Point(12, 153);
            this.TxtFormaPago.Name = "TxtFormaPago";
            this.TxtFormaPago.Size = new System.Drawing.Size(301, 24);
            this.TxtFormaPago.TabIndex = 4;
            this.TxtFormaPago.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtFormaPago_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(9, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 18);
            this.label2.TabIndex = 287;
            this.label2.Text = "♥FORMA DE PAGO";
            // 
            // ChkMismoCliente
            // 
            this.ChkMismoCliente.AutoSize = true;
            this.ChkMismoCliente.BackColor = System.Drawing.Color.LightGray;
            this.ChkMismoCliente.Checked = true;
            this.ChkMismoCliente.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkMismoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.ChkMismoCliente.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ChkMismoCliente.Location = new System.Drawing.Point(341, 38);
            this.ChkMismoCliente.Name = "ChkMismoCliente";
            this.ChkMismoCliente.Size = new System.Drawing.Size(283, 22);
            this.ChkMismoCliente.TabIndex = 1;
            this.ChkMismoCliente.Text = "FACTURAR AL CLIENTE DEL TICKET";
            this.ChkMismoCliente.UseVisualStyleBackColor = false;
            this.ChkMismoCliente.CheckedChanged += new System.EventHandler(this.ChkMismoCliente_CheckedChanged);
            // 
            // TxtMetodoPago
            // 
            this.TxtMetodoPago.BackColor = System.Drawing.SystemColors.Window;
            this.TxtMetodoPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtMetodoPago.Enabled = false;
            this.TxtMetodoPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMetodoPago.ForeColor = System.Drawing.Color.Black;
            this.TxtMetodoPago.Location = new System.Drawing.Point(341, 153);
            this.TxtMetodoPago.Name = "TxtMetodoPago";
            this.TxtMetodoPago.Size = new System.Drawing.Size(283, 24);
            this.TxtMetodoPago.TabIndex = 5;
            this.TxtMetodoPago.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtMetodoPago_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(338, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 18);
            this.label3.TabIndex = 289;
            this.label3.Text = "♥MÉTODO PAGO";
            // 
            // TxtUsoCFDI
            // 
            this.TxtUsoCFDI.BackColor = System.Drawing.SystemColors.Window;
            this.TxtUsoCFDI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtUsoCFDI.Enabled = false;
            this.TxtUsoCFDI.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUsoCFDI.ForeColor = System.Drawing.Color.Black;
            this.TxtUsoCFDI.Location = new System.Drawing.Point(341, 93);
            this.TxtUsoCFDI.Name = "TxtUsoCFDI";
            this.TxtUsoCFDI.Size = new System.Drawing.Size(283, 24);
            this.TxtUsoCFDI.TabIndex = 3;
            this.TxtUsoCFDI.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtUsoCFDI_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(338, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 18);
            this.label4.TabIndex = 291;
            this.label4.Text = "♥USO DEL CFDI";
            // 
            // TxtCliente
            // 
            this.TxtCliente.BackColor = System.Drawing.SystemColors.Window;
            this.TxtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtCliente.Enabled = false;
            this.TxtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCliente.ForeColor = System.Drawing.Color.Black;
            this.TxtCliente.Location = new System.Drawing.Point(12, 93);
            this.TxtCliente.Name = "TxtCliente";
            this.TxtCliente.Size = new System.Drawing.Size(301, 24);
            this.TxtCliente.TabIndex = 2;
            this.TxtCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCliente_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(9, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 18);
            this.label5.TabIndex = 293;
            this.label5.Text = "♥CLIENTE";
            // 
            // FrmTicketFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 367);
            this.Controls.Add(this.TxtCliente);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtUsoCFDI);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtMetodoPago);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ChkMismoCliente);
            this.Controls.Add(this.TxtFormaPago);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtNoRereren);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.Malla);
            this.Controls.Add(this.label1);
            this.Name = "FrmTicketFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONVERTIR UN TICKET A FACTURA";
            ((System.ComponentModel.ISupportInitialize)(this.Malla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView Malla;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.TextBox TxtNoRereren;
        private System.Windows.Forms.TextBox TxtFormaPago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ChkMismoCliente;
        private System.Windows.Forms.TextBox TxtMetodoPago;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtUsoCFDI;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtCliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}