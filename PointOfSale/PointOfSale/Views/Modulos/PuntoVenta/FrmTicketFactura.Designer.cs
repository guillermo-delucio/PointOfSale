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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.Malla = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.TxtNoRereren = new System.Windows.Forms.TextBox();
            this.TxtClienteId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ChkMismoCliente = new System.Windows.Forms.CheckBox();
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
            this.Column2});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Malla.DefaultCellStyle = dataGridViewCellStyle4;
            this.Malla.EnableHeadersVisualStyles = false;
            this.Malla.Location = new System.Drawing.Point(12, 124);
            this.Malla.MultiSelect = false;
            this.Malla.Name = "Malla";
            this.Malla.Size = new System.Drawing.Size(631, 122);
            this.Malla.TabIndex = 274;
            this.Malla.TabStop = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "TICKET";
            this.Column1.Name = "Column1";
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
            this.BtnAceptar.Location = new System.Drawing.Point(548, 252);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(95, 39);
            this.BtnAceptar.TabIndex = 3;
            this.BtnAceptar.Text = "&FACTURAR";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(447, 252);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(95, 39);
            this.BtnCancelar.TabIndex = 4;
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
            this.TxtNoRereren.Size = new System.Drawing.Size(631, 24);
            this.TxtNoRereren.TabIndex = 0;
            this.TxtNoRereren.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtNoRereren_KeyDown);
            this.TxtNoRereren.Leave += new System.EventHandler(this.TxtNoRereren_Leave);
            // 
            // TxtClienteId
            // 
            this.TxtClienteId.BackColor = System.Drawing.SystemColors.Window;
            this.TxtClienteId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtClienteId.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtClienteId.ForeColor = System.Drawing.Color.Black;
            this.TxtClienteId.Location = new System.Drawing.Point(12, 94);
            this.TxtClienteId.Name = "TxtClienteId";
            this.TxtClienteId.Size = new System.Drawing.Size(631, 24);
            this.TxtClienteId.TabIndex = 2;
            this.TxtClienteId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtClienteId_KeyDown);
            this.TxtClienteId.Leave += new System.EventHandler(this.TxtClienteId_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(9, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(344, 18);
            this.label2.TabIndex = 287;
            this.label2.Text = "♥CLIENTE (SI LA CASILLA NO ESTÁ MARCADA)";
            // 
            // ChkMismoCliente
            // 
            this.ChkMismoCliente.AutoSize = true;
            this.ChkMismoCliente.Checked = true;
            this.ChkMismoCliente.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkMismoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.ChkMismoCliente.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ChkMismoCliente.Location = new System.Drawing.Point(360, 15);
            this.ChkMismoCliente.Name = "ChkMismoCliente";
            this.ChkMismoCliente.Size = new System.Drawing.Size(283, 22);
            this.ChkMismoCliente.TabIndex = 1;
            this.ChkMismoCliente.Text = "FACTURAR AL CLIENTE DEL TICKET";
            this.ChkMismoCliente.UseVisualStyleBackColor = true;
            this.ChkMismoCliente.Leave += new System.EventHandler(this.ChkMismoCliente_Leave);
            // 
            // FrmTicketFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 308);
            this.Controls.Add(this.ChkMismoCliente);
            this.Controls.Add(this.TxtClienteId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtNoRereren);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.Malla);
            this.Controls.Add(this.label1);
            this.Name = "FrmTicketFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTicketFactura";
            ((System.ComponentModel.ISupportInitialize)(this.Malla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView Malla;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.TextBox TxtNoRereren;
        private System.Windows.Forms.TextBox TxtClienteId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ChkMismoCliente;
    }
}