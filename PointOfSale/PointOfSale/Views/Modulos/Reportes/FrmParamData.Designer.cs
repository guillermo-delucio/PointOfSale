namespace PointOfSale.Views.Modulos.Reportes
{
    partial class FrmParamData
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
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DpInicial = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.DpFinal = new System.Windows.Forms.DateTimePicker();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.ChkTotasLasFechas = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label13.Location = new System.Drawing.Point(12, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(122, 25);
            this.label13.TabIndex = 244;
            this.label13.Text = "Parámetros";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.label14.Location = new System.Drawing.Point(0, 34);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(286, 10);
            this.label14.TabIndex = 243;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(17, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 18);
            this.label3.TabIndex = 246;
            this.label3.Text = "FECHA INICIAL";
            // 
            // DpInicial
            // 
            this.DpInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.DpInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DpInicial.Location = new System.Drawing.Point(17, 83);
            this.DpInicial.Name = "DpInicial";
            this.DpInicial.Size = new System.Drawing.Size(110, 24);
            this.DpInicial.TabIndex = 245;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(143, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 18);
            this.label1.TabIndex = 248;
            this.label1.Text = "FECHA FINAL";
            // 
            // DpFinal
            // 
            this.DpFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.DpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DpFinal.Location = new System.Drawing.Point(143, 83);
            this.DpFinal.Name = "DpFinal";
            this.DpFinal.Size = new System.Drawing.Size(110, 24);
            this.DpFinal.TabIndex = 247;
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(17, 151);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(236, 38);
            this.BtnAceptar.TabIndex = 272;
            this.BtnAceptar.TabStop = false;
            this.BtnAceptar.Text = "&Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // ChkTotasLasFechas
            // 
            this.ChkTotasLasFechas.AutoSize = true;
            this.ChkTotasLasFechas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.ChkTotasLasFechas.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ChkTotasLasFechas.Location = new System.Drawing.Point(17, 123);
            this.ChkTotasLasFechas.Name = "ChkTotasLasFechas";
            this.ChkTotasLasFechas.Size = new System.Drawing.Size(173, 22);
            this.ChkTotasLasFechas.TabIndex = 273;
            this.ChkTotasLasFechas.Text = "TODAS LAS FECHAS";
            this.ChkTotasLasFechas.UseVisualStyleBackColor = true;
            // 
            // FrmParamData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 215);
            this.Controls.Add(this.ChkTotasLasFechas);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DpFinal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DpInicial);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.MaximumSize = new System.Drawing.Size(299, 254);
            this.Name = "FrmParamData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmParamData";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DpInicial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DpFinal;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.CheckBox ChkTotasLasFechas;
    }
}