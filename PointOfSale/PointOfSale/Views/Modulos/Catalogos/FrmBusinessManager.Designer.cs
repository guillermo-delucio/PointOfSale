namespace PointOfSale.Views.Modulos.Catalogos
{
    partial class FrmBusinessManager
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
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Clientes");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Proveedores");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Productos");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Categorías");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Laboratorios");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Impuestos");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Sustancias");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Almacenes");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Estaciones");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Claves Sat");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Presentaciones", 1, 2);
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Unidades Medida");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("Usuarios", 1, 2);
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Catalogos", 5, 5, new System.Windows.Forms.TreeNode[] {
            treeNode18,
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22,
            treeNode23,
            treeNode24,
            treeNode25,
            treeNode26,
            treeNode27,
            treeNode28,
            treeNode29,
            treeNode30});
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("Producto-Sustancias", 1, 2);
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("Producto-Impuesto");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("Configuración", 3, 3, new System.Windows.Forms.TreeNode[] {
            treeNode32,
            treeNode33});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBusinessManager));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.importarDesdeExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnBMUpdate = new System.Windows.Forms.Button();
            this.BtnBMEliminar = new System.Windows.Forms.Button();
            this.BtnBMAgregar = new System.Windows.Forms.Button();
            this.BMtree = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importarDesdeExcelToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip1.Size = new System.Drawing.Size(184, 26);
            // 
            // importarDesdeExcelToolStripMenuItem
            // 
            this.importarDesdeExcelToolStripMenuItem.Name = "importarDesdeExcelToolStripMenuItem";
            this.importarDesdeExcelToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.importarDesdeExcelToolStripMenuItem.Text = "Importar desde excel";
            this.importarDesdeExcelToolStripMenuItem.Click += new System.EventHandler(this.ImportarDesdeExcelToolStripMenuItem_Click);
            // 
            // Grid1
            // 
            this.Grid1.AllowUserToAddRows = false;
            this.Grid1.AllowUserToDeleteRows = false;
            this.Grid1.AllowUserToOrderColumns = true;
            this.Grid1.AllowUserToResizeColumns = false;
            this.Grid1.AllowUserToResizeRows = false;
            this.Grid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.Grid1.BackgroundColor = System.Drawing.Color.DarkGray;
            this.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid1.Location = new System.Drawing.Point(238, 73);
            this.Grid1.MultiSelect = false;
            this.Grid1.Name = "Grid1";
            this.Grid1.ReadOnly = true;
            this.Grid1.Size = new System.Drawing.Size(552, 350);
            this.Grid1.TabIndex = 5;
            this.Grid1.SelectionChanged += new System.EventHandler(this.Grid1_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.BtnBMUpdate);
            this.panel1.Controls.Add(this.BtnBMEliminar);
            this.panel1.Controls.Add(this.BtnBMAgregar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(238, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(552, 73);
            this.panel1.TabIndex = 3;
            // 
            // BtnBMUpdate
            // 
            this.BtnBMUpdate.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnBMUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBMUpdate.Location = new System.Drawing.Point(276, 0);
            this.BtnBMUpdate.Name = "BtnBMUpdate";
            this.BtnBMUpdate.Size = new System.Drawing.Size(92, 73);
            this.BtnBMUpdate.TabIndex = 1;
            this.BtnBMUpdate.Text = "ACTUALIZAR";
            this.BtnBMUpdate.UseVisualStyleBackColor = true;
            this.BtnBMUpdate.Click += new System.EventHandler(this.BtnBMUpdate_Click);
            // 
            // BtnBMEliminar
            // 
            this.BtnBMEliminar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnBMEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBMEliminar.Location = new System.Drawing.Point(368, 0);
            this.BtnBMEliminar.Name = "BtnBMEliminar";
            this.BtnBMEliminar.Size = new System.Drawing.Size(92, 73);
            this.BtnBMEliminar.TabIndex = 1;
            this.BtnBMEliminar.Text = "ELIMINAR";
            this.BtnBMEliminar.UseVisualStyleBackColor = true;
            this.BtnBMEliminar.Click += new System.EventHandler(this.BtnBMEliminar_Click);
            // 
            // BtnBMAgregar
            // 
            this.BtnBMAgregar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnBMAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBMAgregar.Location = new System.Drawing.Point(460, 0);
            this.BtnBMAgregar.Name = "BtnBMAgregar";
            this.BtnBMAgregar.Size = new System.Drawing.Size(92, 73);
            this.BtnBMAgregar.TabIndex = 1;
            this.BtnBMAgregar.Text = "AGREGAR";
            this.BtnBMAgregar.UseVisualStyleBackColor = true;
            this.BtnBMAgregar.Click += new System.EventHandler(this.BtnBMAgregar_Click);
            // 
            // BMtree
            // 
            this.BMtree.Dock = System.Windows.Forms.DockStyle.Left;
            this.BMtree.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BMtree.ImageIndex = 0;
            this.BMtree.ImageList = this.imageList1;
            this.BMtree.Location = new System.Drawing.Point(0, 0);
            this.BMtree.Name = "BMtree";
            treeNode18.ContextMenuStrip = this.contextMenuStrip1;
            treeNode18.ImageIndex = 1;
            treeNode18.Name = "NodoClientes";
            treeNode18.SelectedImageKey = "folderOpen.png";
            treeNode18.Text = "Clientes";
            treeNode19.ContextMenuStrip = this.contextMenuStrip1;
            treeNode19.ImageIndex = 1;
            treeNode19.Name = "NodoProveedores";
            treeNode19.SelectedImageKey = "folderOpen.png";
            treeNode19.Text = "Proveedores";
            treeNode20.ContextMenuStrip = this.contextMenuStrip1;
            treeNode20.ImageIndex = 1;
            treeNode20.Name = "NodoProductos";
            treeNode20.SelectedImageKey = "folderOpen.png";
            treeNode20.Text = "Productos";
            treeNode21.ContextMenuStrip = this.contextMenuStrip1;
            treeNode21.ImageKey = "folder.png";
            treeNode21.Name = "NodoCategorias";
            treeNode21.SelectedImageKey = "folderOpen.png";
            treeNode21.Text = "Categorías";
            treeNode22.ContextMenuStrip = this.contextMenuStrip1;
            treeNode22.ImageKey = "folder.png";
            treeNode22.Name = "NodoLaboratorios";
            treeNode22.SelectedImageKey = "folderOpen.png";
            treeNode22.Text = "Laboratorios";
            treeNode23.ImageKey = "folder.png";
            treeNode23.Name = "NodoImpuestos";
            treeNode23.SelectedImageKey = "folderOpen.png";
            treeNode23.Text = "Impuestos";
            treeNode24.ContextMenuStrip = this.contextMenuStrip1;
            treeNode24.ImageKey = "folder.png";
            treeNode24.Name = "NodoSustancias";
            treeNode24.SelectedImageKey = "folderOpen.png";
            treeNode24.Text = "Sustancias";
            treeNode25.ImageKey = "folder.png";
            treeNode25.Name = "NodoAlmacenes";
            treeNode25.SelectedImageKey = "folderOpen.png";
            treeNode25.Text = "Almacenes";
            treeNode26.ImageKey = "folder.png";
            treeNode26.Name = "NodoEstaciones";
            treeNode26.SelectedImageIndex = 2;
            treeNode26.Text = "Estaciones";
            treeNode27.ContextMenuStrip = this.contextMenuStrip1;
            treeNode27.ImageKey = "folder.png";
            treeNode27.Name = "NodoClavesSat";
            treeNode27.SelectedImageKey = "folderOpen.png";
            treeNode27.Text = "Claves Sat";
            treeNode28.ContextMenuStrip = this.contextMenuStrip1;
            treeNode28.ImageIndex = 1;
            treeNode28.Name = "NodoPresentaciones";
            treeNode28.SelectedImageIndex = 2;
            treeNode28.Text = "Presentaciones";
            treeNode29.ContextMenuStrip = this.contextMenuStrip1;
            treeNode29.ImageKey = "folder.png";
            treeNode29.Name = "NodoUnidadesMedida";
            treeNode29.SelectedImageKey = "folderOpen.png";
            treeNode29.Text = "Unidades Medida";
            treeNode30.ImageIndex = 1;
            treeNode30.Name = "NodoUsuarios";
            treeNode30.SelectedImageIndex = 2;
            treeNode30.Text = "Usuarios";
            treeNode31.ImageIndex = 5;
            treeNode31.Name = "NodoRoot";
            treeNode31.SelectedImageIndex = 5;
            treeNode31.Text = "Catalogos";
            treeNode32.ContextMenuStrip = this.contextMenuStrip1;
            treeNode32.ImageIndex = 1;
            treeNode32.Name = "NodoProdSus";
            treeNode32.SelectedImageIndex = 2;
            treeNode32.Text = "Producto-Sustancias";
            treeNode33.ContextMenuStrip = this.contextMenuStrip1;
            treeNode33.ImageIndex = 1;
            treeNode33.Name = "NodoProdImp";
            treeNode33.SelectedImageKey = "folderOpen.png";
            treeNode33.Text = "Producto-Impuesto";
            treeNode34.ContextMenuStrip = this.contextMenuStrip1;
            treeNode34.ImageIndex = 3;
            treeNode34.Name = "NodoConfiguracion";
            treeNode34.SelectedImageIndex = 3;
            treeNode34.Text = "Configuración";
            this.BMtree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode31,
            treeNode34});
            this.BMtree.SelectedImageIndex = 0;
            this.BMtree.Size = new System.Drawing.Size(238, 423);
            this.BMtree.TabIndex = 4;
            this.BMtree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.BMtree_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "worldwide.png");
            this.imageList1.Images.SetKeyName(1, "folder.png");
            this.imageList1.Images.SetKeyName(2, "folderOpen.png");
            this.imageList1.Images.SetKeyName(3, "Dtafalonso.ico");
            this.imageList1.Images.SetKeyName(4, "SettingsC.ico");
            this.imageList1.Images.SetKeyName(5, "Catalogos.png");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::PointOfSale.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(236, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // FrmBusinessManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 423);
            this.Controls.Add(this.Grid1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BMtree);
            this.Name = "FrmBusinessManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBusinessManager";
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Grid1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem importarDesdeExcelToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnBMUpdate;
        private System.Windows.Forms.Button BtnBMEliminar;
        private System.Windows.Forms.Button BtnBMAgregar;
        private System.Windows.Forms.TreeView BMtree;
        private System.Windows.Forms.ImageList imageList1;
    }
}