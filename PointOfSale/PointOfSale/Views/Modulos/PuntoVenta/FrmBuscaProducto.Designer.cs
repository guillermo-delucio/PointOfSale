namespace PointOfSale.Views.Modulos.PuntoVenta
{
    partial class FrmBuscaProducto
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
            this.TxtDescrip = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtSustancia = new System.Windows.Forms.TextBox();
            this.BtnBuscarXDescrip = new System.Windows.Forms.Button();
            this.BtnBuscarXSustancia = new System.Windows.Forms.Button();
            this.Mallap = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PbxImagen = new System.Windows.Forms.PictureBox();
            this.Mallas = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnSeleccionar = new System.Windows.Forms.Button();
            this.LblCoincidencias = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Mallap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxImagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mallas)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtDescrip
            // 
            this.TxtDescrip.BackColor = System.Drawing.SystemColors.Window;
            this.TxtDescrip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtDescrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDescrip.ForeColor = System.Drawing.Color.DimGray;
            this.TxtDescrip.Location = new System.Drawing.Point(15, 30);
            this.TxtDescrip.Name = "TxtDescrip";
            this.TxtDescrip.Size = new System.Drawing.Size(219, 24);
            this.TxtDescrip.TabIndex = 0;
            this.TxtDescrip.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtDescrip_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 18);
            this.label4.TabIndex = 253;
            this.label4.Text = "Filtrar por descripción";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(509, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 18);
            this.label1.TabIndex = 255;
            this.label1.Text = "Filtrar por sustancia";
            // 
            // TxtSustancia
            // 
            this.TxtSustancia.BackColor = System.Drawing.SystemColors.Window;
            this.TxtSustancia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtSustancia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSustancia.ForeColor = System.Drawing.Color.DimGray;
            this.TxtSustancia.Location = new System.Drawing.Point(512, 30);
            this.TxtSustancia.Name = "TxtSustancia";
            this.TxtSustancia.Size = new System.Drawing.Size(219, 24);
            this.TxtSustancia.TabIndex = 2;
            this.TxtSustancia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSustancia_KeyDown);
            // 
            // BtnBuscarXDescrip
            // 
            this.BtnBuscarXDescrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscarXDescrip.ForeColor = System.Drawing.Color.DimGray;
            this.BtnBuscarXDescrip.Location = new System.Drawing.Point(240, 28);
            this.BtnBuscarXDescrip.Name = "BtnBuscarXDescrip";
            this.BtnBuscarXDescrip.Size = new System.Drawing.Size(28, 26);
            this.BtnBuscarXDescrip.TabIndex = 1;
            this.BtnBuscarXDescrip.Text = "♥";
            this.BtnBuscarXDescrip.UseVisualStyleBackColor = true;
            this.BtnBuscarXDescrip.Click += new System.EventHandler(this.BtnBuscarXDescrip_Click);
            // 
            // BtnBuscarXSustancia
            // 
            this.BtnBuscarXSustancia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscarXSustancia.ForeColor = System.Drawing.Color.DimGray;
            this.BtnBuscarXSustancia.Location = new System.Drawing.Point(737, 30);
            this.BtnBuscarXSustancia.Name = "BtnBuscarXSustancia";
            this.BtnBuscarXSustancia.Size = new System.Drawing.Size(28, 26);
            this.BtnBuscarXSustancia.TabIndex = 3;
            this.BtnBuscarXSustancia.Text = "♥";
            this.BtnBuscarXSustancia.UseVisualStyleBackColor = true;
            this.BtnBuscarXSustancia.Click += new System.EventHandler(this.BtnBuscarXSustancia_Click);
            // 
            // Mallap
            // 
            this.Mallap.AllowUserToAddRows = false;
            this.Mallap.BackgroundColor = System.Drawing.Color.White;
            this.Mallap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Mallap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Mallap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column9});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Mallap.DefaultCellStyle = dataGridViewCellStyle1;
            this.Mallap.Location = new System.Drawing.Point(15, 60);
            this.Mallap.Name = "Mallap";
            this.Mallap.Size = new System.Drawing.Size(757, 155);
            this.Mallap.TabIndex = 4;
            this.Mallap.SelectionChanged += new System.EventHandler(this.Mallap_SelectionChanged);
            this.Mallap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Mallap_KeyDown);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "DESCRIPCIÓN";
            this.Column1.Name = "Column1";
            this.Column1.Width = 300;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "CONTENIDO";
            this.Column2.Name = "Column2";
            this.Column2.Width = 80;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "PRES";
            this.Column3.Name = "Column3";
            this.Column3.Width = 50;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "LAB";
            this.Column4.Name = "Column4";
            this.Column4.Width = 50;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "UNIDADES";
            this.Column5.Name = "Column5";
            this.Column5.Width = 70;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "PVENTA";
            this.Column6.Name = "Column6";
            this.Column6.Width = 70;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "STOCK";
            this.Column7.Name = "Column7";
            this.Column7.Width = 75;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "productoId";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Visible = false;
            // 
            // PbxImagen
            // 
            this.PbxImagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbxImagen.Image = global::PointOfSale.Properties.Resources.Aspirina1;
            this.PbxImagen.Location = new System.Drawing.Point(321, 232);
            this.PbxImagen.Name = "PbxImagen";
            this.PbxImagen.Size = new System.Drawing.Size(282, 190);
            this.PbxImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbxImagen.TabIndex = 259;
            this.PbxImagen.TabStop = false;
            // 
            // Mallas
            // 
            this.Mallas.AllowUserToAddRows = false;
            this.Mallas.AllowUserToDeleteRows = false;
            this.Mallas.BackgroundColor = System.Drawing.Color.White;
            this.Mallas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Mallas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Mallas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Mallas.DefaultCellStyle = dataGridViewCellStyle2;
            this.Mallas.Location = new System.Drawing.Point(15, 232);
            this.Mallas.Name = "Mallas";
            this.Mallas.Size = new System.Drawing.Size(300, 190);
            this.Mallas.TabIndex = 260;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column8.HeaderText = "SUSTANCIA";
            this.Column8.Name = "Column8";
            // 
            // BtnSalir
            // 
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Location = new System.Drawing.Point(631, 376);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(134, 46);
            this.BtnSalir.TabIndex = 261;
            this.BtnSalir.Text = "&Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            // 
            // BtnSeleccionar
            // 
            this.BtnSeleccionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSeleccionar.Location = new System.Drawing.Point(631, 324);
            this.BtnSeleccionar.Name = "BtnSeleccionar";
            this.BtnSeleccionar.Size = new System.Drawing.Size(134, 46);
            this.BtnSeleccionar.TabIndex = 5;
            this.BtnSeleccionar.Text = "&Seleccionar";
            this.BtnSeleccionar.UseVisualStyleBackColor = true;
            this.BtnSeleccionar.Click += new System.EventHandler(this.BtnSeleccionar_Click);
            // 
            // LblCoincidencias
            // 
            this.LblCoincidencias.AutoSize = true;
            this.LblCoincidencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCoincidencias.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblCoincidencias.Location = new System.Drawing.Point(344, 30);
            this.LblCoincidencias.Name = "LblCoincidencias";
            this.LblCoincidencias.Size = new System.Drawing.Size(94, 15);
            this.LblCoincidencias.TabIndex = 263;
            this.LblCoincidencias.Text = "0 Coincidencias";
            // 
            // FrmBuscaProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 434);
            this.Controls.Add(this.LblCoincidencias);
            this.Controls.Add(this.BtnSeleccionar);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.Mallas);
            this.Controls.Add(this.PbxImagen);
            this.Controls.Add(this.Mallap);
            this.Controls.Add(this.BtnBuscarXSustancia);
            this.Controls.Add(this.BtnBuscarXDescrip);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtSustancia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtDescrip);
            this.MaximumSize = new System.Drawing.Size(800, 473);
            this.Name = "FrmBuscaProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBuscaProducto";
            ((System.ComponentModel.ISupportInitialize)(this.Mallap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxImagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mallas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtDescrip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtSustancia;
        private System.Windows.Forms.Button BtnBuscarXDescrip;
        private System.Windows.Forms.Button BtnBuscarXSustancia;
        private System.Windows.Forms.DataGridView Mallap;
        private System.Windows.Forms.PictureBox PbxImagen;
        private System.Windows.Forms.DataGridView Mallas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnSeleccionar;
        private System.Windows.Forms.Label LblCoincidencias;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    }
}