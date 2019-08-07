namespace PointOfSale.Views.Menus
{
    partial class FrmMenuConfig
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
            this.BtnEmpresa = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.BtnEstaciones = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.BtnMonedero = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label13.Location = new System.Drawing.Point(12, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(151, 25);
            this.label13.TabIndex = 242;
            this.label13.Text = "Configuración ";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.label14.Location = new System.Drawing.Point(1, 34);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(517, 10);
            this.label14.TabIndex = 241;
            // 
            // BtnEmpresa
            // 
            this.BtnEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEmpresa.Location = new System.Drawing.Point(30, 71);
            this.BtnEmpresa.Name = "BtnEmpresa";
            this.BtnEmpresa.Size = new System.Drawing.Size(133, 49);
            this.BtnEmpresa.TabIndex = 243;
            this.BtnEmpresa.Text = "&EMPRESA";
            this.BtnEmpresa.UseVisualStyleBackColor = true;
            this.BtnEmpresa.Click += new System.EventHandler(this.BtnEmpresa_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(30, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 49);
            this.button1.TabIndex = 244;
            this.button1.Text = "&TRASPASOS";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // BtnEstaciones
            // 
            this.BtnEstaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEstaciones.Location = new System.Drawing.Point(271, 71);
            this.BtnEstaciones.Name = "BtnEstaciones";
            this.BtnEstaciones.Size = new System.Drawing.Size(133, 49);
            this.BtnEstaciones.TabIndex = 245;
            this.BtnEstaciones.Text = "&ESTACIONES";
            this.BtnEstaciones.UseVisualStyleBackColor = true;
            this.BtnEstaciones.Click += new System.EventHandler(this.BtnEstaciones_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(271, 145);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(133, 49);
            this.button3.TabIndex = 246;
            this.button3.Text = "&PUNTO DE VENTA";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(30, 215);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(133, 49);
            this.button4.TabIndex = 247;
            this.button4.Text = "&RESPALDOS";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // BtnMonedero
            // 
            this.BtnMonedero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMonedero.Location = new System.Drawing.Point(271, 215);
            this.BtnMonedero.Name = "BtnMonedero";
            this.BtnMonedero.Size = new System.Drawing.Size(133, 49);
            this.BtnMonedero.TabIndex = 248;
            this.BtnMonedero.Text = "&MONEDERO ELETRÓNICO";
            this.BtnMonedero.UseVisualStyleBackColor = true;
            this.BtnMonedero.Click += new System.EventHandler(this.BtnMonedero_Click);
            // 
            // FrmMenuConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 373);
            this.Controls.Add(this.BtnMonedero);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.BtnEstaciones);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BtnEmpresa);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Name = "FrmMenuConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMenuConfig";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button BtnEmpresa;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BtnEstaciones;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button BtnMonedero;
    }
}