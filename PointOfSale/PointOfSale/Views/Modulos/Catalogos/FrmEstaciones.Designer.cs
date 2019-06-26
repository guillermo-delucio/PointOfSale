namespace PointOfSale.Views.Modulos.Catalogos
{
    partial class FrmEstaciones
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.CboINC = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtClave = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CboIT = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CboIF = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ChkSumarUnidades = new System.Windows.Forms.CheckBox();
            this.ChkSolicitarFMpago = new System.Windows.Forms.CheckBox();
            this.ChkVentaSinExistencia = new System.Windows.Forms.CheckBox();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTitulo.Location = new System.Drawing.Point(-1, 6);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(118, 25);
            this.lblTitulo.TabIndex = 129;
            this.lblTitulo.Text = "Estaciones";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.label14.Location = new System.Drawing.Point(1, 31);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(562, 10);
            this.label14.TabIndex = 128;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(4, 44);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(555, 351);
            this.tabControl1.TabIndex = 148;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.CboINC);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.TxtClave);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.TxtNombre);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.CboIT);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.CboIF);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(547, 325);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Config básica";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // CboINC
            // 
            this.CboINC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.CboINC.FormattingEnabled = true;
            this.CboINC.Location = new System.Drawing.Point(6, 209);
            this.CboINC.Name = "CboINC";
            this.CboINC.Size = new System.Drawing.Size(433, 26);
            this.CboINC.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 18);
            this.label6.TabIndex = 146;
            this.label6.Text = "♥CLAVE";
            // 
            // TxtClave
            // 
            this.TxtClave.BackColor = System.Drawing.SystemColors.Window;
            this.TxtClave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtClave.ForeColor = System.Drawing.Color.Black;
            this.TxtClave.Location = new System.Drawing.Point(6, 37);
            this.TxtClave.Name = "TxtClave";
            this.TxtClave.Size = new System.Drawing.Size(206, 24);
            this.TxtClave.TabIndex = 0;
            this.TxtClave.Leave += new System.EventHandler(this.TxtClave_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(230, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 18);
            this.label1.TabIndex = 133;
            this.label1.Text = "NOMBRE";
            // 
            // TxtNombre
            // 
            this.TxtNombre.BackColor = System.Drawing.SystemColors.Window;
            this.TxtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombre.ForeColor = System.Drawing.Color.Black;
            this.TxtNombre.Location = new System.Drawing.Point(233, 37);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(206, 24);
            this.TxtNombre.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(6, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(223, 18);
            this.label5.TabIndex = 143;
            this.label5.Text = "IMPRESORA NOTAS CRÉDITO";
            // 
            // CboIT
            // 
            this.CboIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.CboIT.FormattingEnabled = true;
            this.CboIT.Location = new System.Drawing.Point(6, 100);
            this.CboIT.Name = "CboIT";
            this.CboIT.Size = new System.Drawing.Size(433, 26);
            this.CboIT.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(6, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 18);
            this.label2.TabIndex = 137;
            this.label2.Text = "IMPRESORA TICKETS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(6, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 18);
            this.label4.TabIndex = 141;
            this.label4.Text = "IMPRESORA FACTURAS";
            // 
            // CboIF
            // 
            this.CboIF.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.CboIF.FormattingEnabled = true;
            this.CboIF.Location = new System.Drawing.Point(6, 156);
            this.CboIF.Name = "CboIF";
            this.CboIF.Size = new System.Drawing.Size(433, 26);
            this.CboIF.TabIndex = 5;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ChkSumarUnidades);
            this.tabPage2.Controls.Add(this.ChkSolicitarFMpago);
            this.tabPage2.Controls.Add(this.ChkVentaSinExistencia);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(547, 325);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Config adicional";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ChkSumarUnidades
            // 
            this.ChkSumarUnidades.AutoSize = true;
            this.ChkSumarUnidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.ChkSumarUnidades.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ChkSumarUnidades.Location = new System.Drawing.Point(16, 79);
            this.ChkSumarUnidades.Name = "ChkSumarUnidades";
            this.ChkSumarUnidades.Size = new System.Drawing.Size(203, 22);
            this.ChkSumarUnidades.TabIndex = 232;
            this.ChkSumarUnidades.TabStop = false;
            this.ChkSumarUnidades.Text = "Sumar unidades en el PDV";
            this.ChkSumarUnidades.UseVisualStyleBackColor = true;
            // 
            // ChkSolicitarFMpago
            // 
            this.ChkSolicitarFMpago.AutoSize = true;
            this.ChkSolicitarFMpago.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.ChkSolicitarFMpago.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ChkSolicitarFMpago.Location = new System.Drawing.Point(16, 51);
            this.ChkSolicitarFMpago.Name = "ChkSolicitarFMpago";
            this.ChkSolicitarFMpago.Size = new System.Drawing.Size(246, 22);
            this.ChkSolicitarFMpago.TabIndex = 231;
            this.ChkSolicitarFMpago.TabStop = false;
            this.ChkSolicitarFMpago.Text = "Solicitar forma y método de pago";
            this.ChkSolicitarFMpago.UseVisualStyleBackColor = true;
            // 
            // ChkVentaSinExistencia
            // 
            this.ChkVentaSinExistencia.AutoSize = true;
            this.ChkVentaSinExistencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.ChkVentaSinExistencia.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ChkVentaSinExistencia.Location = new System.Drawing.Point(16, 23);
            this.ChkVentaSinExistencia.Name = "ChkVentaSinExistencia";
            this.ChkVentaSinExistencia.Size = new System.Drawing.Size(165, 22);
            this.ChkVentaSinExistencia.TabIndex = 230;
            this.ChkVentaSinExistencia.TabStop = false;
            this.ChkVentaSinExistencia.Text = "Vender sin existencia";
            this.ChkVentaSinExistencia.UseVisualStyleBackColor = true;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(407, 397);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(148, 40);
            this.BtnCancelar.TabIndex = 150;
            this.BtnCancelar.Text = "SALIR";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(254, 397);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(148, 40);
            this.BtnAceptar.TabIndex = 149;
            this.BtnAceptar.Text = "ACEPTAR";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click_1);
            // 
            // FrmEstaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 447);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.label14);
            this.Name = "FrmEstaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEstaciones";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox CboINC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtClave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CboIT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CboIF;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox ChkVentaSinExistencia;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.CheckBox ChkSolicitarFMpago;
        private System.Windows.Forms.CheckBox ChkSumarUnidades;
    }
}