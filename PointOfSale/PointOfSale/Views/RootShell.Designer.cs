namespace PointOfSale.Views
{
    partial class RootShell
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RootShell));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.BtnReporteador = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnLogin = new System.Windows.Forms.ToolStripSplitButton();
            this.menúPrincipalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.BtnReporteador,
            this.BtnLogin});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(825, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel.Text = "Estado";
            // 
            // BtnReporteador
            // 
            this.BtnReporteador.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BtnReporteador.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.BtnReporteador.Image = ((System.Drawing.Image)(resources.GetObject("BtnReporteador.Image")));
            this.BtnReporteador.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnReporteador.Name = "BtnReporteador";
            this.BtnReporteador.Size = new System.Drawing.Size(91, 20);
            this.BtnReporteador.Text = "Reporteador ";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "Menú principal";
            // 
            // BtnLogin
            // 
            this.BtnLogin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnLogin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menúPrincipalToolStripMenuItem});
            this.BtnLogin.Image = ((System.Drawing.Image)(resources.GetObject("BtnLogin.Image")));
            this.BtnLogin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(32, 20);
            this.BtnLogin.Text = "toolStripSplitButton1";
            this.BtnLogin.ButtonClick += new System.EventHandler(this.BtnLogin_ButtonClick);
            // 
            // menúPrincipalToolStripMenuItem
            // 
            this.menúPrincipalToolStripMenuItem.Name = "menúPrincipalToolStripMenuItem";
            this.menúPrincipalToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.menúPrincipalToolStripMenuItem.Text = "Menú principal";
            // 
            // RootShell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 453);
            this.Controls.Add(this.statusStrip);
            this.IsMdiContainer = true;
            this.Name = "RootShell";
            this.Text = "RootShell";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripSplitButton BtnLogin;
        private System.Windows.Forms.ToolStripMenuItem menúPrincipalToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton BtnReporteador;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}



