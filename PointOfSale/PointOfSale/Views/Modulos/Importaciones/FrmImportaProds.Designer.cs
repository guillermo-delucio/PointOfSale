namespace PointOfSale.Views.Modulos.Importaciones
{
    partial class FrmImportaProds
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
            this.Bgw = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.TxtRuta = new System.Windows.Forms.TextBox();
            this.BtnOpenDialog = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblProgreso = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTitulo.Location = new System.Drawing.Point(-5, 1);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(277, 25);
            this.lblTitulo.TabIndex = 125;
            this.lblTitulo.Text = "Importa productos completo";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.label14.Location = new System.Drawing.Point(-3, 26);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(459, 10);
            this.label14.TabIndex = 124;
            // 
            // Bgw
            // 
            this.Bgw.WorkerReportsProgress = true;
            this.Bgw.WorkerSupportsCancellation = true;
            this.Bgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Bgw_DoWork);
            this.Bgw.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Bgw_ProgressChanged);
            this.Bgw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Bgw_RunWorkerCompleted);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Excel files|*.XLSX";
            // 
            // TxtRuta
            // 
            this.TxtRuta.BackColor = System.Drawing.SystemColors.Window;
            this.TxtRuta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtRuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRuta.ForeColor = System.Drawing.Color.Black;
            this.TxtRuta.Location = new System.Drawing.Point(12, 53);
            this.TxtRuta.Name = "TxtRuta";
            this.TxtRuta.Size = new System.Drawing.Size(402, 24);
            this.TxtRuta.TabIndex = 128;
            // 
            // BtnOpenDialog
            // 
            this.BtnOpenDialog.Location = new System.Drawing.Point(420, 52);
            this.BtnOpenDialog.Name = "BtnOpenDialog";
            this.BtnOpenDialog.Size = new System.Drawing.Size(31, 27);
            this.BtnOpenDialog.TabIndex = 129;
            this.BtnOpenDialog.Text = "- - -";
            this.BtnOpenDialog.UseVisualStyleBackColor = true;
            this.BtnOpenDialog.Click += new System.EventHandler(this.BtnOpenDialog_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 83);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(439, 23);
            this.progressBar1.TabIndex = 130;
            // 
            // lblProgreso
            // 
            this.lblProgreso.AutoSize = true;
            this.lblProgreso.BackColor = System.Drawing.Color.Transparent;
            this.lblProgreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgreso.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblProgreso.Location = new System.Drawing.Point(12, 109);
            this.lblProgreso.Name = "lblProgreso";
            this.lblProgreso.Size = new System.Drawing.Size(27, 16);
            this.lblProgreso.TabIndex = 131;
            this.lblProgreso.Text = "0%";
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(345, 144);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(101, 33);
            this.BtnCancelar.TabIndex = 132;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(238, 144);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(101, 33);
            this.BtnAceptar.TabIndex = 133;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // FrmImportaProds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 189);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.lblProgreso);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.BtnOpenDialog);
            this.Controls.Add(this.TxtRuta);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.label14);
            this.Name = "FrmImportaProds";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmImportaProds";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label14;
        private System.ComponentModel.BackgroundWorker Bgw;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox TxtRuta;
        private System.Windows.Forms.Button BtnOpenDialog;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblProgreso;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAceptar;
    }
}