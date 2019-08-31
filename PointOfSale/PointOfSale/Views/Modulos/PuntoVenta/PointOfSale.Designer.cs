namespace PointOfSale.Views.Modulos.PuntoVenta
{
    partial class PointOfSale
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnCobroPago = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtFecha = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PbxImagen = new System.Windows.Forms.PictureBox();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnMinimizar = new System.Windows.Forms.Button();
            this.BtnDirectoImp = new System.Windows.Forms.Button();
            this.BtnBuscarProd = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtDescrip = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.TxtCliente = new System.Windows.Forms.TextBox();
            this.TxtProductoId = new System.Windows.Forms.TextBox();
            this.BtnBorrarPartida = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtTotal = new System.Windows.Forms.TextBox();
            this.TxtSubtotal = new System.Windows.Forms.TextBox();
            this.Malla = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TxtPrecioCliente = new System.Windows.Forms.TextBox();
            this.BtnRecalculaTotales = new System.Windows.Forms.Button();
            this.BtnBuscarCliente = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ChkSoloConLicencia = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LblUltDocumento = new System.Windows.Forms.Label();
            this.LblCambio = new System.Windows.Forms.Label();
            this.TimerPDV = new System.Windows.Forms.Timer(this.components);
            this.LblUnidades = new System.Windows.Forms.Label();
            this.BtnOpcionesImpr = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxImagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Malla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(317, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 18);
            this.label6.TabIndex = 254;
            this.label6.Text = "Caja";
            // 
            // BtnCobroPago
            // 
            this.BtnCobroPago.Image = global::PointOfSale.Properties.Resources.dollar1;
            this.BtnCobroPago.Location = new System.Drawing.Point(932, 161);
            this.BtnCobroPago.Name = "BtnCobroPago";
            this.BtnCobroPago.Size = new System.Drawing.Size(84, 46);
            this.BtnCobroPago.TabIndex = 284;
            this.BtnCobroPago.TabStop = false;
            this.BtnCobroPago.Text = "Cobro y Pago";
            this.BtnCobroPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCobroPago.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCobroPago.UseVisualStyleBackColor = true;
            this.BtnCobroPago.Click += new System.EventHandler(this.BtnCobroPago_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtFecha);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(519, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(497, 84);
            this.groupBox1.TabIndex = 281;
            this.groupBox1.TabStop = false;
            // 
            // TxtFecha
            // 
            this.TxtFecha.BackColor = System.Drawing.SystemColors.Window;
            this.TxtFecha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtFecha.Enabled = false;
            this.TxtFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFecha.ForeColor = System.Drawing.Color.DimGray;
            this.TxtFecha.Location = new System.Drawing.Point(303, 49);
            this.TxtFecha.Name = "TxtFecha";
            this.TxtFecha.Size = new System.Drawing.Size(188, 24);
            this.TxtFecha.TabIndex = 257;
            this.TxtFecha.TabStop = false;
            this.TxtFecha.Text = "13/06/2019 - 10:18 P.M";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(248, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 18);
            this.label7.TabIndex = 256;
            this.label7.Text = "Fecha";
            // 
            // comboBox3
            // 
            this.comboBox3.Enabled = false;
            this.comboBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(361, 9);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(43, 24);
            this.comboBox3.TabIndex = 255;
            this.comboBox3.TabStop = false;
            this.comboBox3.Text = "1";
            // 
            // comboBox2
            // 
            this.comboBox2.Enabled = false;
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(91, 46);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(138, 24);
            this.comboBox2.TabIndex = 253;
            this.comboBox2.TabStop = false;
            this.comboBox2.Text = "SAL VENTA";
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(86, 15);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(43, 24);
            this.comboBox1.TabIndex = 252;
            this.comboBox1.TabStop = false;
            this.comboBox1.Text = "1";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.Window;
            this.textBox5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox5.Enabled = false;
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.ForeColor = System.Drawing.Color.DimGray;
            this.textBox5.Location = new System.Drawing.Point(150, 10);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(147, 24);
            this.textBox5.TabIndex = 251;
            this.textBox5.TabStop = false;
            this.textBox5.Text = "BODEGA MATRIZ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(15, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 18);
            this.label5.TabIndex = 250;
            this.label5.Text = "Tipo Mov";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(15, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 18);
            this.label4.TabIndex = 249;
            this.label4.Text = "Almacen";
            // 
            // PbxImagen
            // 
            this.PbxImagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbxImagen.Image = global::PointOfSale.Properties.Resources.Aspirina1;
            this.PbxImagen.Location = new System.Drawing.Point(836, 213);
            this.PbxImagen.Name = "PbxImagen";
            this.PbxImagen.Size = new System.Drawing.Size(178, 169);
            this.PbxImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbxImagen.TabIndex = 280;
            this.PbxImagen.TabStop = false;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::PointOfSale.Properties.Resources.exit;
            this.BtnSalir.Location = new System.Drawing.Point(899, 444);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(117, 46);
            this.BtnSalir.TabIndex = 289;
            this.BtnSalir.Text = "&Salir";
            this.BtnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnMinimizar
            // 
            this.BtnMinimizar.Image = global::PointOfSale.Properties.Resources.inside;
            this.BtnMinimizar.Location = new System.Drawing.Point(836, 444);
            this.BtnMinimizar.Name = "BtnMinimizar";
            this.BtnMinimizar.Size = new System.Drawing.Size(57, 46);
            this.BtnMinimizar.TabIndex = 288;
            this.BtnMinimizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnMinimizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnMinimizar.UseVisualStyleBackColor = true;
            // 
            // BtnDirectoImp
            // 
            this.BtnDirectoImp.Image = global::PointOfSale.Properties.Resources.printer;
            this.BtnDirectoImp.Location = new System.Drawing.Point(940, 119);
            this.BtnDirectoImp.Name = "BtnDirectoImp";
            this.BtnDirectoImp.Size = new System.Drawing.Size(35, 35);
            this.BtnDirectoImp.TabIndex = 285;
            this.BtnDirectoImp.TabStop = false;
            this.BtnDirectoImp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnDirectoImp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnDirectoImp.UseVisualStyleBackColor = true;
            this.BtnDirectoImp.Click += new System.EventHandler(this.BtnDirectoImp_Click);
            // 
            // BtnBuscarProd
            // 
            this.BtnBuscarProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscarProd.ForeColor = System.Drawing.Color.DimGray;
            this.BtnBuscarProd.Location = new System.Drawing.Point(978, 390);
            this.BtnBuscarProd.Name = "BtnBuscarProd";
            this.BtnBuscarProd.Size = new System.Drawing.Size(38, 37);
            this.BtnBuscarProd.TabIndex = 283;
            this.BtnBuscarProd.Text = "♥";
            this.BtnBuscarProd.UseVisualStyleBackColor = true;
            this.BtnBuscarProd.Click += new System.EventHandler(this.BtnBuscarProd_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(15, 433);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 18);
            this.label8.TabIndex = 282;
            this.label8.Text = "Producto";
            // 
            // TxtDescrip
            // 
            this.TxtDescrip.BackColor = System.Drawing.SystemColors.Window;
            this.TxtDescrip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtDescrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDescrip.ForeColor = System.Drawing.Color.Black;
            this.TxtDescrip.Location = new System.Drawing.Point(15, 454);
            this.TxtDescrip.Name = "TxtDescrip";
            this.TxtDescrip.Size = new System.Drawing.Size(295, 35);
            this.TxtDescrip.TabIndex = 279;
            this.TxtDescrip.TabStop = false;
            // 
            // TxtCliente
            // 
            this.TxtCliente.BackColor = System.Drawing.SystemColors.Window;
            this.TxtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCliente.ForeColor = System.Drawing.Color.Black;
            this.TxtCliente.Location = new System.Drawing.Point(17, 115);
            this.TxtCliente.Name = "TxtCliente";
            this.TxtCliente.Size = new System.Drawing.Size(463, 35);
            this.TxtCliente.TabIndex = 265;
            this.toolTip1.SetToolTip(this.TxtCliente, "Busque el cliente para la venta");
            this.TxtCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCliente_KeyDown);
            // 
            // TxtProductoId
            // 
            this.TxtProductoId.BackColor = System.Drawing.SystemColors.Window;
            this.TxtProductoId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtProductoId.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProductoId.ForeColor = System.Drawing.Color.Black;
            this.TxtProductoId.Location = new System.Drawing.Point(836, 394);
            this.TxtProductoId.Name = "TxtProductoId";
            this.TxtProductoId.Size = new System.Drawing.Size(136, 31);
            this.TxtProductoId.TabIndex = 267;
            this.TxtProductoId.TextChanged += new System.EventHandler(this.TxtProductoId_TextChanged);
            this.TxtProductoId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtProductoId_KeyDown);
            // 
            // BtnBorrarPartida
            // 
            this.BtnBorrarPartida.Image = global::PointOfSale.Properties.Resources.garbage;
            this.BtnBorrarPartida.Location = new System.Drawing.Point(836, 161);
            this.BtnBorrarPartida.Name = "BtnBorrarPartida";
            this.BtnBorrarPartida.Size = new System.Drawing.Size(82, 46);
            this.BtnBorrarPartida.TabIndex = 278;
            this.BtnBorrarPartida.TabStop = false;
            this.BtnBorrarPartida.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnBorrarPartida.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnBorrarPartida.UseVisualStyleBackColor = true;
            this.BtnBorrarPartida.Click += new System.EventHandler(this.BtnBorrarPartida_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(659, 431);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 20);
            this.label3.TabIndex = 277;
            this.label3.Text = "$";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(540, 431);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 20);
            this.label2.TabIndex = 276;
            this.label2.Text = "$";
            // 
            // TxtTotal
            // 
            this.TxtTotal.BackColor = System.Drawing.SystemColors.Window;
            this.TxtTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotal.ForeColor = System.Drawing.Color.Black;
            this.TxtTotal.Location = new System.Drawing.Point(679, 429);
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.Size = new System.Drawing.Size(103, 24);
            this.TxtTotal.TabIndex = 275;
            this.TxtTotal.TabStop = false;
            // 
            // TxtSubtotal
            // 
            this.TxtSubtotal.BackColor = System.Drawing.SystemColors.Window;
            this.TxtSubtotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSubtotal.ForeColor = System.Drawing.Color.Black;
            this.TxtSubtotal.Location = new System.Drawing.Point(560, 429);
            this.TxtSubtotal.Name = "TxtSubtotal";
            this.TxtSubtotal.Size = new System.Drawing.Size(92, 24);
            this.TxtSubtotal.TabIndex = 274;
            this.TxtSubtotal.TabStop = false;
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
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column11});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Malla.DefaultCellStyle = dataGridViewCellStyle2;
            this.Malla.EnableHeadersVisualStyles = false;
            this.Malla.Location = new System.Drawing.Point(17, 164);
            this.Malla.MultiSelect = false;
            this.Malla.Name = "Malla";
            this.Malla.Size = new System.Drawing.Size(813, 261);
            this.Malla.TabIndex = 273;
            this.Malla.TabStop = false;
            this.Malla.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Malla_CellEndEdit);
            this.Malla.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.Malla_EditingControlShowing);
            this.Malla.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Malla_KeyDown);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "NOMBRE";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 300;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "STOCK";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 50;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "CANT";
            this.Column3.Name = "Column3";
            this.Column3.Width = 50;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "PRECIO";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 80;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "SUBTOTAL";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 70;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "IMP1";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 40;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "IMP2";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 40;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "IMPORTE";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 70;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "LOTE";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 50;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "ProductoId";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Visible = false;
            // 
            // TxtPrecioCliente
            // 
            this.TxtPrecioCliente.Location = new System.Drawing.Point(530, 129);
            this.TxtPrecioCliente.Name = "TxtPrecioCliente";
            this.TxtPrecioCliente.ReadOnly = true;
            this.TxtPrecioCliente.Size = new System.Drawing.Size(23, 20);
            this.TxtPrecioCliente.TabIndex = 272;
            this.TxtPrecioCliente.TabStop = false;
            // 
            // BtnRecalculaTotales
            // 
            this.BtnRecalculaTotales.Location = new System.Drawing.Point(559, 126);
            this.BtnRecalculaTotales.Name = "BtnRecalculaTotales";
            this.BtnRecalculaTotales.Size = new System.Drawing.Size(73, 24);
            this.BtnRecalculaTotales.TabIndex = 271;
            this.BtnRecalculaTotales.TabStop = false;
            this.BtnRecalculaTotales.Text = "Recalcula";
            this.BtnRecalculaTotales.UseVisualStyleBackColor = true;
            this.BtnRecalculaTotales.Click += new System.EventHandler(this.BtnRecalculaTotales_Click);
            // 
            // BtnBuscarCliente
            // 
            this.BtnBuscarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscarCliente.ForeColor = System.Drawing.Color.DimGray;
            this.BtnBuscarCliente.Location = new System.Drawing.Point(486, 113);
            this.BtnBuscarCliente.Name = "BtnBuscarCliente";
            this.BtnBuscarCliente.Size = new System.Drawing.Size(38, 37);
            this.BtnBuscarCliente.TabIndex = 266;
            this.BtnBuscarCliente.Text = "♥";
            this.BtnBuscarCliente.UseVisualStyleBackColor = true;
            this.BtnBuscarCliente.Click += new System.EventHandler(this.BtnBuscarCliente_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PointOfSale.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(6, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(498, 105);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 270;
            this.pictureBox1.TabStop = false;
            // 
            // ChkSoloConLicencia
            // 
            this.ChkSoloConLicencia.AutoSize = true;
            this.ChkSoloConLicencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.ChkSoloConLicencia.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ChkSoloConLicencia.Location = new System.Drawing.Point(530, 101);
            this.ChkSoloConLicencia.Name = "ChkSoloConLicencia";
            this.ChkSoloConLicencia.Size = new System.Drawing.Size(140, 22);
            this.ChkSoloConLicencia.TabIndex = 269;
            this.ChkSoloConLicencia.TabStop = false;
            this.ChkSoloConLicencia.Text = "Sólo con licencia";
            this.ChkSoloConLicencia.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(12, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 18);
            this.label1.TabIndex = 268;
            this.label1.Text = "♥CLIENTE";
            // 
            // LblUltDocumento
            // 
            this.LblUltDocumento.AutoSize = true;
            this.LblUltDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUltDocumento.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblUltDocumento.Location = new System.Drawing.Point(324, 466);
            this.LblUltDocumento.Name = "LblUltDocumento";
            this.LblUltDocumento.Size = new System.Drawing.Size(92, 24);
            this.LblUltDocumento.TabIndex = 291;
            this.LblUltDocumento.Text = "TICKET  -";
            // 
            // LblCambio
            // 
            this.LblCambio.AutoSize = true;
            this.LblCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCambio.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblCambio.Location = new System.Drawing.Point(324, 433);
            this.LblCambio.Name = "LblCambio";
            this.LblCambio.Size = new System.Drawing.Size(168, 24);
            this.LblCambio.TabIndex = 290;
            this.LblCambio.Text = "SU CAMBIO: 00.00";
            // 
            // TimerPDV
            // 
            this.TimerPDV.Enabled = true;
            this.TimerPDV.Interval = 1000;
            this.TimerPDV.Tick += new System.EventHandler(this.TimerPDV_Tick);
            // 
            // LblUnidades
            // 
            this.LblUnidades.AutoSize = true;
            this.LblUnidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUnidades.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblUnidades.Location = new System.Drawing.Point(676, 466);
            this.LblUnidades.Name = "LblUnidades";
            this.LblUnidades.Size = new System.Drawing.Size(14, 20);
            this.LblUnidades.TabIndex = 292;
            this.LblUnidades.Text = "-";
            // 
            // BtnOpcionesImpr
            // 
            this.BtnOpcionesImpr.Image = global::PointOfSale.Properties.Resources.searchO;
            this.BtnOpcionesImpr.Location = new System.Drawing.Point(981, 118);
            this.BtnOpcionesImpr.Name = "BtnOpcionesImpr";
            this.BtnOpcionesImpr.Size = new System.Drawing.Size(35, 35);
            this.BtnOpcionesImpr.TabIndex = 287;
            this.BtnOpcionesImpr.TabStop = false;
            this.BtnOpcionesImpr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnOpcionesImpr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnOpcionesImpr.UseVisualStyleBackColor = true;
            // 
            // PointOfSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 496);
            this.ControlBox = false;
            this.Controls.Add(this.LblUnidades);
            this.Controls.Add(this.LblUltDocumento);
            this.Controls.Add(this.LblCambio);
            this.Controls.Add(this.BtnCobroPago);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.PbxImagen);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.BtnMinimizar);
            this.Controls.Add(this.BtnOpcionesImpr);
            this.Controls.Add(this.BtnDirectoImp);
            this.Controls.Add(this.BtnBuscarProd);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TxtDescrip);
            this.Controls.Add(this.TxtProductoId);
            this.Controls.Add(this.BtnBorrarPartida);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtTotal);
            this.Controls.Add(this.TxtSubtotal);
            this.Controls.Add(this.Malla);
            this.Controls.Add(this.TxtPrecioCliente);
            this.Controls.Add(this.BtnRecalculaTotales);
            this.Controls.Add(this.BtnBuscarCliente);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ChkSoloConLicencia);
            this.Controls.Add(this.TxtCliente);
            this.Controls.Add(this.label1);
            this.Name = "PointOfSale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PointOfSale";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxImagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Malla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnCobroPago;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtFecha;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox PbxImagen;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnMinimizar;
        private System.Windows.Forms.Button BtnDirectoImp;
        private System.Windows.Forms.Button BtnBuscarProd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtDescrip;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox TxtCliente;
        private System.Windows.Forms.TextBox TxtProductoId;
        private System.Windows.Forms.Button BtnBorrarPartida;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtTotal;
        private System.Windows.Forms.TextBox TxtSubtotal;
        private System.Windows.Forms.DataGridView Malla;
        private System.Windows.Forms.TextBox TxtPrecioCliente;
        private System.Windows.Forms.Button BtnRecalculaTotales;
        private System.Windows.Forms.Button BtnBuscarCliente;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox ChkSoloConLicencia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblUltDocumento;
        private System.Windows.Forms.Label LblCambio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.Timer TimerPDV;
        private System.Windows.Forms.Label LblUnidades;
        private System.Windows.Forms.Button BtnOpcionesImpr;
    }
}