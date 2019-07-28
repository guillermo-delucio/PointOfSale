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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Clientes");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Proveedores");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Productos");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Categorías");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Laboratorios");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Impuestos");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Sustancias");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Estaciones");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Claves Sat");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Presentaciones", 1, 2);
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Unidades Medida");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Usuarios", 1, 2);
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Catalogos", 5, 5, new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Producto-Sustancias", 1, 2);
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Productos Completo", 1, 2);
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Producto Impuesto", 1, 2);
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Concenptos de egresos", 1, 5);
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Concenptos de ingresos", 1, 5);
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Tipos de movimientos de almacen", 1, 5);
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Configuración", 3, 3, new System.Windows.Forms.TreeNode[] {
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBusinessManager));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.importarDesdeExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnBMUpdate = new System.Windows.Forms.Button();
            this.BtnBMEliminar = new System.Windows.Forms.Button();
            this.BtnBMAgregar = new System.Windows.Forms.Button();
            this.BMtree = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
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
            this.contextMenuStrip1.Size = new System.Drawing.Size(185, 26);
            // 
            // importarDesdeExcelToolStripMenuItem
            // 
            this.importarDesdeExcelToolStripMenuItem.Name = "importarDesdeExcelToolStripMenuItem";
            this.importarDesdeExcelToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
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
            this.Grid1.Size = new System.Drawing.Size(633, 436);
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
            this.panel1.Size = new System.Drawing.Size(633, 73);
            this.panel1.TabIndex = 3;
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
            // BtnBMUpdate
            // 
            this.BtnBMUpdate.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnBMUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBMUpdate.Location = new System.Drawing.Point(357, 0);
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
            this.BtnBMEliminar.Location = new System.Drawing.Point(449, 0);
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
            this.BtnBMAgregar.Location = new System.Drawing.Point(541, 0);
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
            treeNode1.ContextMenuStrip = this.contextMenuStrip1;
            treeNode1.ImageIndex = 1;
            treeNode1.Name = "NodoClientes";
            treeNode1.SelectedImageKey = "folderOpen.png";
            treeNode1.Text = "Clientes";
            treeNode2.ContextMenuStrip = this.contextMenuStrip1;
            treeNode2.ImageIndex = 1;
            treeNode2.Name = "NodoProveedores";
            treeNode2.SelectedImageKey = "folderOpen.png";
            treeNode2.Text = "Proveedores";
            treeNode3.ContextMenuStrip = this.contextMenuStrip1;
            treeNode3.ImageIndex = 1;
            treeNode3.Name = "NodoProductos";
            treeNode3.SelectedImageKey = "folderOpen.png";
            treeNode3.Text = "Productos";
            treeNode4.ContextMenuStrip = this.contextMenuStrip1;
            treeNode4.ImageKey = "folder.png";
            treeNode4.Name = "NodoCategorias";
            treeNode4.SelectedImageKey = "folderOpen.png";
            treeNode4.Text = "Categorías";
            treeNode5.ContextMenuStrip = this.contextMenuStrip1;
            treeNode5.ImageKey = "folder.png";
            treeNode5.Name = "NodoLaboratorios";
            treeNode5.SelectedImageKey = "folderOpen.png";
            treeNode5.Text = "Laboratorios";
            treeNode6.ImageKey = "folder.png";
            treeNode6.Name = "NodoImpuestos";
            treeNode6.SelectedImageKey = "folderOpen.png";
            treeNode6.Text = "Impuestos";
            treeNode7.ContextMenuStrip = this.contextMenuStrip1;
            treeNode7.ImageKey = "folder.png";
            treeNode7.Name = "NodoSustancias";
            treeNode7.SelectedImageKey = "folderOpen.png";
            treeNode7.Text = "Sustancias";
            treeNode8.ImageKey = "folder.png";
            treeNode8.Name = "NodoEstaciones";
            treeNode8.SelectedImageIndex = 2;
            treeNode8.Text = "Estaciones";
            treeNode9.ContextMenuStrip = this.contextMenuStrip1;
            treeNode9.ImageKey = "folder.png";
            treeNode9.Name = "NodoClavesSat";
            treeNode9.SelectedImageKey = "folderOpen.png";
            treeNode9.Text = "Claves Sat";
            treeNode10.ContextMenuStrip = this.contextMenuStrip1;
            treeNode10.ImageIndex = 1;
            treeNode10.Name = "NodoPresentaciones";
            treeNode10.SelectedImageIndex = 2;
            treeNode10.Text = "Presentaciones";
            treeNode11.ContextMenuStrip = this.contextMenuStrip1;
            treeNode11.ImageKey = "folder.png";
            treeNode11.Name = "NodoUnidadesMedida";
            treeNode11.SelectedImageKey = "folderOpen.png";
            treeNode11.Text = "Unidades Medida";
            treeNode12.ImageIndex = 1;
            treeNode12.Name = "NodoUsuarios";
            treeNode12.SelectedImageIndex = 2;
            treeNode12.Text = "Usuarios";
            treeNode13.ImageIndex = 5;
            treeNode13.Name = "NodoRoot";
            treeNode13.SelectedImageIndex = 5;
            treeNode13.Text = "Catalogos";
            treeNode14.ContextMenuStrip = this.contextMenuStrip1;
            treeNode14.ImageIndex = 1;
            treeNode14.Name = "NodoProdSus";
            treeNode14.SelectedImageIndex = 2;
            treeNode14.Text = "Producto-Sustancias";
            treeNode15.ContextMenuStrip = this.contextMenuStrip1;
            treeNode15.ImageIndex = 1;
            treeNode15.Name = "NodoProductosCompleto";
            treeNode15.SelectedImageIndex = 2;
            treeNode15.Text = "Productos Completo";
            treeNode16.ContextMenuStrip = this.contextMenuStrip1;
            treeNode16.ImageIndex = 1;
            treeNode16.Name = "NodoProdImp";
            treeNode16.SelectedImageIndex = 2;
            treeNode16.Text = "Producto Impuesto";
            treeNode17.ImageIndex = 1;
            treeNode17.Name = "NodoConEgre";
            treeNode17.SelectedImageIndex = 5;
            treeNode17.Text = "Concenptos de egresos";
            treeNode18.ImageIndex = 1;
            treeNode18.Name = "NodoConIngre";
            treeNode18.SelectedImageIndex = 5;
            treeNode18.Text = "Concenptos de ingresos";
            treeNode19.ImageIndex = 1;
            treeNode19.Name = "NodoConMovsInv";
            treeNode19.SelectedImageIndex = 5;
            treeNode19.Text = "Tipos de movimientos de almacen";
            treeNode20.ContextMenuStrip = this.contextMenuStrip1;
            treeNode20.ImageIndex = 3;
            treeNode20.Name = "NodoConfiguracion";
            treeNode20.SelectedImageIndex = 3;
            treeNode20.Text = "Configuración";
            this.BMtree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode20});
            this.BMtree.SelectedImageIndex = 0;
            this.BMtree.Size = new System.Drawing.Size(238, 509);
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
            // FrmBusinessManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 509);
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