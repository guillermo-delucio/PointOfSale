namespace PointOfSale.Views.ReportDesigner
{
    partial class FrmDesigner
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
            this.ReportDesigner = new Stimulsoft.Report.Design.StiDesignerControl();
            this.SuspendLayout();
            // 
            // ReportDesigner
            // 
            this.ReportDesigner.AllowDrop = true;
            this.ReportDesigner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
            this.ReportDesigner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportDesigner.Location = new System.Drawing.Point(0, 0);
            this.ReportDesigner.Name = "ReportDesigner";
            this.ReportDesigner.Size = new System.Drawing.Size(800, 450);
            this.ReportDesigner.TabIndex = 3;
            // 
            // FrmDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ReportDesigner);
            this.Name = "FrmDesigner";
            this.Text = "FrmDesigner";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private Stimulsoft.Report.Design.StiDesignerControl ReportDesigner;
    }
}