namespace PointOfSale.Views.ReportDesigner
{
    partial class FrmDisenador
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ChkParam = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtReporte = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnNuevo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.BtnVisualizar = new System.Windows.Forms.Button();
            this.BtnDisenar = new System.Windows.Forms.Button();
            this.TxtSecuenciaEnc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.TxtReporteSeleccionad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtQuery = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(909, 59);
            this.panel1.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTitulo.Location = new System.Drawing.Point(7, 19);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(225, 25);
            this.lblTitulo.TabIndex = 131;
            this.lblTitulo.Text = "Diseñador de reportes";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.label14.Location = new System.Drawing.Point(3, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(901, 10);
            this.label14.TabIndex = 127;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ChkParam);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.TxtReporte);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(909, 63);
            this.groupBox1.TabIndex = 130;
            this.groupBox1.TabStop = false;
            // 
            // ChkParam
            // 
            this.ChkParam.AutoSize = true;
            this.ChkParam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkParam.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ChkParam.Location = new System.Drawing.Point(181, 8);
            this.ChkParam.Name = "ChkParam";
            this.ChkParam.Size = new System.Drawing.Size(85, 24);
            this.ChkParam.TabIndex = 136;
            this.ChkParam.Text = "PARAM";
            this.ChkParam.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(1, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(174, 20);
            this.label6.TabIndex = 135;
            this.label6.Text = "♥BUSCAR REPORTE";
            // 
            // TxtReporte
            // 
            this.TxtReporte.BackColor = System.Drawing.SystemColors.Window;
            this.TxtReporte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtReporte.ForeColor = System.Drawing.Color.Black;
            this.TxtReporte.Location = new System.Drawing.Point(6, 32);
            this.TxtReporte.Name = "TxtReporte";
            this.TxtReporte.Size = new System.Drawing.Size(897, 24);
            this.TxtReporte.TabIndex = 133;
            this.TxtReporte.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtReporte_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnNuevo);
            this.groupBox2.Controls.Add(this.btnGuardar);
            this.groupBox2.Controls.Add(this.BtnVisualizar);
            this.groupBox2.Controls.Add(this.BtnDisenar);
            this.groupBox2.Controls.Add(this.TxtSecuenciaEnc);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.BtnSalir);
            this.groupBox2.Controls.Add(this.TxtReporteSeleccionad);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 380);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(909, 76);
            this.groupBox2.TabIndex = 131;
            this.groupBox2.TabStop = false;
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnNuevo.Location = new System.Drawing.Point(556, 16);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(70, 57);
            this.BtnNuevo.TabIndex = 153;
            this.BtnNuevo.Text = "&Nuevo";
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnGuardar.Location = new System.Drawing.Point(626, 16);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(70, 57);
            this.btnGuardar.TabIndex = 152;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnVisualizar
            // 
            this.BtnVisualizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnVisualizar.Location = new System.Drawing.Point(696, 16);
            this.BtnVisualizar.Name = "BtnVisualizar";
            this.BtnVisualizar.Size = new System.Drawing.Size(70, 57);
            this.BtnVisualizar.TabIndex = 151;
            this.BtnVisualizar.Text = "&Visualizar";
            this.BtnVisualizar.UseVisualStyleBackColor = true;
            this.BtnVisualizar.Click += new System.EventHandler(this.BtnVisualizar_Click);
            // 
            // BtnDisenar
            // 
            this.BtnDisenar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnDisenar.Location = new System.Drawing.Point(766, 16);
            this.BtnDisenar.Name = "BtnDisenar";
            this.BtnDisenar.Size = new System.Drawing.Size(70, 57);
            this.BtnDisenar.TabIndex = 150;
            this.BtnDisenar.Text = "&Diseñar";
            this.BtnDisenar.UseVisualStyleBackColor = true;
            this.BtnDisenar.Click += new System.EventHandler(this.BtnDisenar_Click);
            // 
            // TxtSecuenciaEnc
            // 
            this.TxtSecuenciaEnc.BackColor = System.Drawing.SystemColors.Window;
            this.TxtSecuenciaEnc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtSecuenciaEnc.Enabled = false;
            this.TxtSecuenciaEnc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSecuenciaEnc.ForeColor = System.Drawing.Color.Black;
            this.TxtSecuenciaEnc.Location = new System.Drawing.Point(235, 49);
            this.TxtSecuenciaEnc.Name = "TxtSecuenciaEnc";
            this.TxtSecuenciaEnc.Size = new System.Drawing.Size(315, 24);
            this.TxtSecuenciaEnc.TabIndex = 148;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(18, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 20);
            this.label1.TabIndex = 149;
            this.label1.Text = "SECUENCIA ENCRIPTADO";
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSalir.Location = new System.Drawing.Point(836, 16);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(70, 57);
            this.BtnSalir.TabIndex = 147;
            this.BtnSalir.Text = "&Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // TxtReporteSeleccionad
            // 
            this.TxtReporteSeleccionad.BackColor = System.Drawing.SystemColors.Window;
            this.TxtReporteSeleccionad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtReporteSeleccionad.Enabled = false;
            this.TxtReporteSeleccionad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtReporteSeleccionad.ForeColor = System.Drawing.Color.Black;
            this.TxtReporteSeleccionad.Location = new System.Drawing.Point(235, 18);
            this.TxtReporteSeleccionad.Name = "TxtReporteSeleccionad";
            this.TxtReporteSeleccionad.Size = new System.Drawing.Size(315, 24);
            this.TxtReporteSeleccionad.TabIndex = 145;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 20);
            this.label2.TabIndex = 146;
            this.label2.Text = "REPORTE SELECCIONADO";
            // 
            // TxtQuery
            // 
            this.TxtQuery.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TxtQuery.Location = new System.Drawing.Point(0, 147);
            this.TxtQuery.Margin = new System.Windows.Forms.Padding(2);
            this.TxtQuery.Name = "TxtQuery";
            this.TxtQuery.Size = new System.Drawing.Size(909, 233);
            this.TxtQuery.TabIndex = 136;
            this.TxtQuery.Text = "select * from Producto where ProductoId = [prodId] and PrecioCompra= [pCompra] an" +
    "d PrecioCaja =[pCaja] and Precio1= [precio1]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(2, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 20);
            this.label3.TabIndex = 137;
            this.label3.Text = "COMANDO SQL";
            // 
            // FrmDisenador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 456);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtQuery);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(925, 495);
            this.MinimumSize = new System.Drawing.Size(925, 495);
            this.Name = "FrmDisenador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDisenador";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtReporte;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnNuevo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button BtnVisualizar;
        private System.Windows.Forms.Button BtnDisenar;
        private System.Windows.Forms.TextBox TxtSecuenciaEnc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.TextBox TxtReporteSeleccionad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox TxtQuery;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ChkParam;
    }
}