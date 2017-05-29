namespace ItemEditor
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cmdFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.copyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.changeIDToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainContainer = new System.Windows.Forms.SplitContainer();
            this.viewItems = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuItemView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.boxAutoSave = new System.Windows.Forms.CheckBox();
            this.cmdResetItem = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmdReqAdd = new System.Windows.Forms.Button();
            this.numReqValue = new System.Windows.Forms.NumericUpDown();
            this.boxReqOperator = new System.Windows.Forms.ComboBox();
            this.boxReqSkill = new System.Windows.Forms.ComboBox();
            this.txtItemRequire = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmdSaveItem = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.numItemMass = new System.Windows.Forms.NumericUpDown();
            this.numItemValue = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.picItemIcon = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.boxItemDamaged = new System.Windows.Forms.CheckBox();
            this.boxItemDestroyable = new System.Windows.Forms.CheckBox();
            this.boxItemSellable = new System.Windows.Forms.CheckBox();
            this.boxItemType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numItemID = new System.Windows.Forms.NumericUpDown();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.boxItemStackable = new System.Windows.Forms.CheckBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).BeginInit();
            this.mainContainer.Panel1.SuspendLayout();
            this.mainContainer.Panel2.SuspendLayout();
            this.mainContainer.SuspendLayout();
            this.contextMenuItemView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numReqValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numItemMass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numItemValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItemIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numItemID)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdFile,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1040, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Enter += new System.EventHandler(this.toolStrip1_Enter);
            // 
            // cmdFile
            // 
            this.cmdFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.cmdFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdFile.Name = "cmdFile";
            this.cmdFile.Size = new System.Drawing.Size(46, 24);
            this.cmdFile.Text = "File";
            this.cmdFile.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.cmdFile.ToolTipText = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAsToolStripMenuItem.Image")));
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loadToolStripMenuItem.Image")));
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.loadToolStripMenuItem.Text = "Load...";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("quitToolStripMenuItem.Image")));
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem1,
            this.removeToolStripMenuItem1,
            this.changeIDToolStripMenuItem1,
            this.toolStripSeparator2,
            this.exportToolStripMenuItem1,
            this.importToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(49, 24);
            this.toolStripDropDownButton1.Text = "Edit";
            // 
            // copyToolStripMenuItem1
            // 
            this.copyToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem1.Image")));
            this.copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            this.copyToolStripMenuItem1.Size = new System.Drawing.Size(153, 26);
            this.copyToolStripMenuItem1.Text = "Copy";
            this.copyToolStripMenuItem1.Click += new System.EventHandler(this.copyToolStripMenuItem1_Click);
            // 
            // removeToolStripMenuItem1
            // 
            this.removeToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("removeToolStripMenuItem1.Image")));
            this.removeToolStripMenuItem1.Name = "removeToolStripMenuItem1";
            this.removeToolStripMenuItem1.Size = new System.Drawing.Size(153, 26);
            this.removeToolStripMenuItem1.Text = "Remove";
            this.removeToolStripMenuItem1.Click += new System.EventHandler(this.removeToolStripMenuItem1_Click);
            // 
            // changeIDToolStripMenuItem1
            // 
            this.changeIDToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("changeIDToolStripMenuItem1.Image")));
            this.changeIDToolStripMenuItem1.Name = "changeIDToolStripMenuItem1";
            this.changeIDToolStripMenuItem1.Size = new System.Drawing.Size(153, 26);
            this.changeIDToolStripMenuItem1.Text = "Change ID";
            this.changeIDToolStripMenuItem1.Click += new System.EventHandler(this.changeIDToolStripMenuItem1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(150, 6);
            // 
            // exportToolStripMenuItem1
            // 
            this.exportToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("exportToolStripMenuItem1.Image")));
            this.exportToolStripMenuItem1.Name = "exportToolStripMenuItem1";
            this.exportToolStripMenuItem1.Size = new System.Drawing.Size(153, 26);
            this.exportToolStripMenuItem1.Text = "Export...";
            this.exportToolStripMenuItem1.Click += new System.EventHandler(this.exportToolStripMenuItem1_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("importToolStripMenuItem.Image")));
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
            this.importToolStripMenuItem.Text = "Import...";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // mainContainer
            // 
            this.mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContainer.Location = new System.Drawing.Point(0, 27);
            this.mainContainer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mainContainer.Name = "mainContainer";
            // 
            // mainContainer.Panel1
            // 
            this.mainContainer.Panel1.Controls.Add(this.viewItems);
            this.mainContainer.Panel1.Controls.Add(this.txtSearch);
            // 
            // mainContainer.Panel2
            // 
            this.mainContainer.Panel2.Controls.Add(this.boxItemStackable);
            this.mainContainer.Panel2.Controls.Add(this.boxAutoSave);
            this.mainContainer.Panel2.Controls.Add(this.cmdResetItem);
            this.mainContainer.Panel2.Controls.Add(this.label11);
            this.mainContainer.Panel2.Controls.Add(this.label10);
            this.mainContainer.Panel2.Controls.Add(this.label9);
            this.mainContainer.Panel2.Controls.Add(this.cmdReqAdd);
            this.mainContainer.Panel2.Controls.Add(this.numReqValue);
            this.mainContainer.Panel2.Controls.Add(this.boxReqOperator);
            this.mainContainer.Panel2.Controls.Add(this.boxReqSkill);
            this.mainContainer.Panel2.Controls.Add(this.txtItemRequire);
            this.mainContainer.Panel2.Controls.Add(this.label8);
            this.mainContainer.Panel2.Controls.Add(this.cmdSaveItem);
            this.mainContainer.Panel2.Controls.Add(this.label7);
            this.mainContainer.Panel2.Controls.Add(this.numItemMass);
            this.mainContainer.Panel2.Controls.Add(this.numItemValue);
            this.mainContainer.Panel2.Controls.Add(this.label6);
            this.mainContainer.Panel2.Controls.Add(this.picItemIcon);
            this.mainContainer.Panel2.Controls.Add(this.label5);
            this.mainContainer.Panel2.Controls.Add(this.label4);
            this.mainContainer.Panel2.Controls.Add(this.boxItemDamaged);
            this.mainContainer.Panel2.Controls.Add(this.boxItemDestroyable);
            this.mainContainer.Panel2.Controls.Add(this.boxItemSellable);
            this.mainContainer.Panel2.Controls.Add(this.boxItemType);
            this.mainContainer.Panel2.Controls.Add(this.label3);
            this.mainContainer.Panel2.Controls.Add(this.label2);
            this.mainContainer.Panel2.Controls.Add(this.numItemID);
            this.mainContainer.Panel2.Controls.Add(this.txtItemName);
            this.mainContainer.Panel2.Controls.Add(this.label1);
            this.mainContainer.Size = new System.Drawing.Size(1040, 656);
            this.mainContainer.SplitterDistance = 408;
            this.mainContainer.SplitterWidth = 5;
            this.mainContainer.TabIndex = 1;
            this.mainContainer.SplitterMoving += new System.Windows.Forms.SplitterCancelEventHandler(this.mainContainer_SplitterMoving);
            // 
            // viewItems
            // 
            this.viewItems.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.viewItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.viewItems.ContextMenuStrip = this.contextMenuItemView;
            this.viewItems.FullRowSelect = true;
            this.viewItems.GridLines = true;
            this.viewItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.viewItems.HideSelection = false;
            this.viewItems.LargeImageList = this.imgList;
            this.viewItems.Location = new System.Drawing.Point(4, 31);
            this.viewItems.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.viewItems.MultiSelect = false;
            this.viewItems.Name = "viewItems";
            this.viewItems.Size = new System.Drawing.Size(404, 597);
            this.viewItems.SmallImageList = this.imgList;
            this.viewItems.TabIndex = 1;
            this.viewItems.UseCompatibleStateImageBehavior = false;
            this.viewItems.View = System.Windows.Forms.View.Details;
            this.viewItems.SelectedIndexChanged += new System.EventHandler(this.viewItems_SelectedIndexChanged);
            this.viewItems.Enter += new System.EventHandler(this.viewItems_Enter);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "";
            this.columnHeader2.Width = 26;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ID";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 65;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Name";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 105;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Type";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Value";
            this.columnHeader6.Width = 58;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Mass";
            this.columnHeader7.Width = 57;
            // 
            // contextMenuItemView
            // 
            this.contextMenuItemView.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuItemView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.changeIDToolStripMenuItem,
            this.toolStripSeparator1,
            this.exportToolStripMenuItem,
            this.importToolStripMenuItem1});
            this.contextMenuItemView.Name = "contextMenuItemView";
            this.contextMenuItemView.Size = new System.Drawing.Size(154, 140);
            this.contextMenuItemView.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuItemView_Opening);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("removeToolStripMenuItem.Image")));
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // changeIDToolStripMenuItem
            // 
            this.changeIDToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("changeIDToolStripMenuItem.Image")));
            this.changeIDToolStripMenuItem.Name = "changeIDToolStripMenuItem";
            this.changeIDToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
            this.changeIDToolStripMenuItem.Text = "Change ID";
            this.changeIDToolStripMenuItem.Click += new System.EventHandler(this.changeIDToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(150, 6);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exportToolStripMenuItem.Image")));
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
            this.exportToolStripMenuItem.Text = "Export...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem1
            // 
            this.importToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("importToolStripMenuItem1.Image")));
            this.importToolStripMenuItem1.Name = "importToolStripMenuItem1";
            this.importToolStripMenuItem1.Size = new System.Drawing.Size(153, 26);
            this.importToolStripMenuItem1.Text = "Import...";
            this.importToolStripMenuItem1.Click += new System.EventHandler(this.importToolStripMenuItem1_Click);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "Amulet.png");
            this.imgList.Images.SetKeyName(1, "Arrow.png");
            this.imgList.Images.SetKeyName(2, "Axe1H.png");
            this.imgList.Images.SetKeyName(3, "Axe2H.png");
            this.imgList.Images.SetKeyName(4, "Baked.png");
            this.imgList.Images.SetKeyName(5, "Beer.png");
            this.imgList.Images.SetKeyName(6, "Book.png");
            this.imgList.Images.SetKeyName(7, "Boose.png");
            this.imgList.Images.SetKeyName(8, "Bow.png");
            this.imgList.Images.SetKeyName(9, "Bracelet.png");
            this.imgList.Images.SetKeyName(10, "Dagger1H.png");
            this.imgList.Images.SetKeyName(11, "Fish.png");
            this.imgList.Images.SetKeyName(12, "Flask.png");
            this.imgList.Images.SetKeyName(13, "Flesh.png");
            this.imgList.Images.SetKeyName(14, "FoodOther.png");
            this.imgList.Images.SetKeyName(15, "Fruits.png");
            this.imgList.Images.SetKeyName(16, "Fur.png");
            this.imgList.Images.SetKeyName(17, "Gemstone.png");
            this.imgList.Images.SetKeyName(18, "Hat.png");
            this.imgList.Images.SetKeyName(19, "HeavyBoots.png");
            this.imgList.Images.SetKeyName(20, "HeavyBreastplate.png");
            this.imgList.Images.SetKeyName(21, "HeavyHelmet.png");
            this.imgList.Images.SetKeyName(22, "HeavyShield.png");
            this.imgList.Images.SetKeyName(23, "HuntingTrophy.png");
            this.imgList.Images.SetKeyName(24, "Ingot.png");
            this.imgList.Images.SetKeyName(25, "Key.png");
            this.imgList.Images.SetKeyName(26, "LightBoots.png");
            this.imgList.Images.SetKeyName(27, "LightBreastplate.png");
            this.imgList.Images.SetKeyName(28, "LightHelmet.png");
            this.imgList.Images.SetKeyName(29, "LightShield.png");
            this.imgList.Images.SetKeyName(30, "Mace1H.png");
            this.imgList.Images.SetKeyName(31, "Mace2H.png");
            this.imgList.Images.SetKeyName(32, "Map.png");
            this.imgList.Images.SetKeyName(33, "Miscellaneous.png");
            this.imgList.Images.SetKeyName(34, "Ore.png");
            this.imgList.Images.SetKeyName(35, "Plant.png");
            this.imgList.Images.SetKeyName(36, "PlantSpecial.png");
            this.imgList.Images.SetKeyName(37, "Potion.png");
            this.imgList.Images.SetKeyName(38, "PotionSpecial.png");
            this.imgList.Images.SetKeyName(39, "Rapier1H.png");
            this.imgList.Images.SetKeyName(40, "Rapier2H.png");
            this.imgList.Images.SetKeyName(41, "ResourceOther.png");
            this.imgList.Images.SetKeyName(42, "Ring.png");
            this.imgList.Images.SetKeyName(43, "Robe.png");
            this.imgList.Images.SetKeyName(44, "Scroll.png");
            this.imgList.Images.SetKeyName(45, "Spear2H.png");
            this.imgList.Images.SetKeyName(46, "Stone.png");
            this.imgList.Images.SetKeyName(47, "Sweets.png");
            this.imgList.Images.SetKeyName(48, "Sword1H.png");
            this.imgList.Images.SetKeyName(49, "Sword2H.png");
            this.imgList.Images.SetKeyName(50, "ThrowingKnife.png");
            this.imgList.Images.SetKeyName(51, "Tool.png");
            this.imgList.Images.SetKeyName(52, "Torch.png");
            this.imgList.Images.SetKeyName(53, "Wand1H.png");
            this.imgList.Images.SetKeyName(54, "Wand2H.png");
            this.imgList.Images.SetKeyName(55, "Water.png");
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(4, 4);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(404, 22);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // boxAutoSave
            // 
            this.boxAutoSave.AutoSize = true;
            this.boxAutoSave.Checked = true;
            this.boxAutoSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.boxAutoSave.Location = new System.Drawing.Point(367, 588);
            this.boxAutoSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.boxAutoSave.Name = "boxAutoSave";
            this.boxAutoSave.Size = new System.Drawing.Size(126, 21);
            this.boxAutoSave.TabIndex = 3;
            this.boxAutoSave.Text = "Autosave Items";
            this.boxAutoSave.UseVisualStyleBackColor = true;
            // 
            // cmdResetItem
            // 
            this.cmdResetItem.Location = new System.Drawing.Point(19, 578);
            this.cmdResetItem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdResetItem.Name = "cmdResetItem";
            this.cmdResetItem.Size = new System.Drawing.Size(89, 39);
            this.cmdResetItem.TabIndex = 30;
            this.cmdResetItem.Text = "Reset";
            this.cmdResetItem.UseVisualStyleBackColor = true;
            this.cmdResetItem.Click += new System.EventHandler(this.cmdResetItem_Click);
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label11.Location = new System.Drawing.Point(7, 555);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(616, 17);
            this.label11.TabIndex = 29;
            this.label11.Text = "____________________________________________________________________________";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label10.Location = new System.Drawing.Point(4, 300);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(616, 17);
            this.label10.TabIndex = 28;
            this.label10.Text = "____________________________________________________________________________";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 326);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(164, 17);
            this.label9.TabIndex = 27;
            this.label9.Text = "Custom Type Properties:";
            // 
            // cmdReqAdd
            // 
            this.cmdReqAdd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmdReqAdd.Location = new System.Drawing.Point(304, 273);
            this.cmdReqAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdReqAdd.Name = "cmdReqAdd";
            this.cmdReqAdd.Size = new System.Drawing.Size(75, 23);
            this.cmdReqAdd.TabIndex = 26;
            this.cmdReqAdd.Text = "Add";
            this.cmdReqAdd.UseVisualStyleBackColor = true;
            this.cmdReqAdd.Click += new System.EventHandler(this.cmdReqAdd_Click);
            // 
            // numReqValue
            // 
            this.numReqValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numReqValue.Location = new System.Drawing.Point(175, 273);
            this.numReqValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numReqValue.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numReqValue.Name = "numReqValue";
            this.numReqValue.Size = new System.Drawing.Size(99, 22);
            this.numReqValue.TabIndex = 25;
            this.numReqValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // boxReqOperator
            // 
            this.boxReqOperator.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.boxReqOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxReqOperator.FormattingEnabled = true;
            this.boxReqOperator.Items.AddRange(new object[] {
            "==",
            ">=",
            "<=",
            ">>",
            "<<"});
            this.boxReqOperator.Location = new System.Drawing.Point(115, 273);
            this.boxReqOperator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.boxReqOperator.Name = "boxReqOperator";
            this.boxReqOperator.Size = new System.Drawing.Size(52, 24);
            this.boxReqOperator.TabIndex = 24;
            // 
            // boxReqSkill
            // 
            this.boxReqSkill.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.boxReqSkill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxReqSkill.FormattingEnabled = true;
            this.boxReqSkill.Items.AddRange(new object[] {
            "lvl",
            "xpe",
            "mhp",
            "mmp",
            "msp",
            "str",
            "int",
            "dex",
            "wpw",
            "chr",
            "knw",
            "crf",
            "alc",
            "m2h",
            "m1h",
            "rap",
            "nbw",
            "cbw",
            "wnd",
            "dgr",
            "har",
            "lar",
            "rob",
            "lck",
            "lrp"});
            this.boxReqSkill.Location = new System.Drawing.Point(37, 273);
            this.boxReqSkill.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.boxReqSkill.Name = "boxReqSkill";
            this.boxReqSkill.Size = new System.Drawing.Size(69, 24);
            this.boxReqSkill.TabIndex = 23;
            // 
            // txtItemRequire
            // 
            this.txtItemRequire.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtItemRequire.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemRequire.Location = new System.Drawing.Point(24, 161);
            this.txtItemRequire.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtItemRequire.Multiline = true;
            this.txtItemRequire.Name = "txtItemRequire";
            this.txtItemRequire.Size = new System.Drawing.Size(371, 106);
            this.txtItemRequire.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "Requirements:";
            // 
            // cmdSaveItem
            // 
            this.cmdSaveItem.Location = new System.Drawing.Point(520, 578);
            this.cmdSaveItem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdSaveItem.Name = "cmdSaveItem";
            this.cmdSaveItem.Size = new System.Drawing.Size(89, 39);
            this.cmdSaveItem.TabIndex = 20;
            this.cmdSaveItem.Text = "Save";
            this.cmdSaveItem.UseVisualStyleBackColor = true;
            this.cmdSaveItem.Click += new System.EventHandler(this.cmdSaveItem_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(432, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "Value:";
            // 
            // numItemMass
            // 
            this.numItemMass.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numItemMass.Location = new System.Drawing.Point(486, 230);
            this.numItemMass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numItemMass.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numItemMass.Name = "numItemMass";
            this.numItemMass.Size = new System.Drawing.Size(123, 22);
            this.numItemMass.TabIndex = 18;
            this.numItemMass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numItemValue
            // 
            this.numItemValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numItemValue.Location = new System.Drawing.Point(486, 195);
            this.numItemValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numItemValue.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numItemValue.Name = "numItemValue";
            this.numItemValue.Size = new System.Drawing.Size(123, 22);
            this.numItemValue.TabIndex = 17;
            this.numItemValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(432, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Mass:";
            // 
            // picItemIcon
            // 
            this.picItemIcon.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.picItemIcon.BackColor = System.Drawing.Color.White;
            this.picItemIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picItemIcon.Location = new System.Drawing.Point(77, 63);
            this.picItemIcon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picItemIcon.Name = "picItemIcon";
            this.picItemIcon.Size = new System.Drawing.Size(64, 64);
            this.picItemIcon.TabIndex = 15;
            this.picItemIcon.TabStop = false;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Icon:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(5, 29);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(616, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "____________________________________________________________________________";
            // 
            // boxItemDamaged
            // 
            this.boxItemDamaged.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.boxItemDamaged.AutoSize = true;
            this.boxItemDamaged.Location = new System.Drawing.Point(451, 120);
            this.boxItemDamaged.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.boxItemDamaged.Name = "boxItemDamaged";
            this.boxItemDamaged.Size = new System.Drawing.Size(105, 21);
            this.boxItemDamaged.TabIndex = 12;
            this.boxItemDamaged.Text = "Is Damaged";
            this.boxItemDamaged.UseVisualStyleBackColor = true;
            // 
            // boxItemDestroyable
            // 
            this.boxItemDestroyable.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.boxItemDestroyable.AutoSize = true;
            this.boxItemDestroyable.Checked = true;
            this.boxItemDestroyable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.boxItemDestroyable.Location = new System.Drawing.Point(451, 92);
            this.boxItemDestroyable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.boxItemDestroyable.Name = "boxItemDestroyable";
            this.boxItemDestroyable.Size = new System.Drawing.Size(120, 21);
            this.boxItemDestroyable.TabIndex = 11;
            this.boxItemDestroyable.Text = "Is Destroyable";
            this.boxItemDestroyable.UseVisualStyleBackColor = true;
            // 
            // boxItemSellable
            // 
            this.boxItemSellable.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.boxItemSellable.AutoSize = true;
            this.boxItemSellable.Checked = true;
            this.boxItemSellable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.boxItemSellable.Location = new System.Drawing.Point(451, 63);
            this.boxItemSellable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.boxItemSellable.Name = "boxItemSellable";
            this.boxItemSellable.Size = new System.Drawing.Size(94, 21);
            this.boxItemSellable.TabIndex = 9;
            this.boxItemSellable.Text = "Is Sellable";
            this.boxItemSellable.UseVisualStyleBackColor = true;
            // 
            // boxItemType
            // 
            this.boxItemType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.boxItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxItemType.FormattingEnabled = true;
            this.boxItemType.Location = new System.Drawing.Point(224, 77);
            this.boxItemType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.boxItemType.Name = "boxItemType";
            this.boxItemType.Size = new System.Drawing.Size(183, 24);
            this.boxItemType.TabIndex = 5;
            this.boxItemType.SelectedIndexChanged += new System.EventHandler(this.boxItemType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(173, 81);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Type:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(447, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "ID:";
            // 
            // numItemID
            // 
            this.numItemID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numItemID.Location = new System.Drawing.Point(488, 3);
            this.numItemID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numItemID.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numItemID.Name = "numItemID";
            this.numItemID.Size = new System.Drawing.Size(123, 22);
            this.numItemID.TabIndex = 2;
            this.numItemID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtItemName
            // 
            this.txtItemName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtItemName.Location = new System.Drawing.Point(77, 3);
            this.txtItemName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(348, 22);
            this.txtItemName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblStatus,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.lblCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 658);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1040, 25);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(52, 20);
            this.toolStripStatusLabel1.Text = "Status:";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(65, 20);
            this.lblStatus.Text = "Standart";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(13, 20);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(130, 20);
            this.toolStripStatusLabel3.Text = "Number Of Items: ";
            // 
            // lblCount
            // 
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(0, 20);
            // 
            // boxItemStackable
            // 
            this.boxItemStackable.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.boxItemStackable.AutoSize = true;
            this.boxItemStackable.Location = new System.Drawing.Point(451, 149);
            this.boxItemStackable.Margin = new System.Windows.Forms.Padding(4);
            this.boxItemStackable.Name = "boxItemStackable";
            this.boxItemStackable.Size = new System.Drawing.Size(105, 21);
            this.boxItemStackable.TabIndex = 31;
            this.boxItemStackable.Text = "Is Damaged";
            this.boxItemStackable.UseVisualStyleBackColor = true;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 683);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mainContainer);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(1062, 732);
            this.MinimumSize = new System.Drawing.Size(1062, 723);
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mainForm_KeyDown);
            this.Leave += new System.EventHandler(this.mainForm_Leave);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.mainContainer.Panel1.ResumeLayout(false);
            this.mainContainer.Panel1.PerformLayout();
            this.mainContainer.Panel2.ResumeLayout(false);
            this.mainContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).EndInit();
            this.mainContainer.ResumeLayout(false);
            this.contextMenuItemView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numReqValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numItemMass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numItemValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItemIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numItemID)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer mainContainer;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ListView viewItems;
        private System.Windows.Forms.ToolStripDropDownButton cmdFile;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lblCount;
        private System.Windows.Forms.ContextMenuStrip contextMenuItemView;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numItemID;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox boxItemType;
        private System.Windows.Forms.CheckBox boxItemSellable;
        private System.Windows.Forms.CheckBox boxItemDamaged;
        private System.Windows.Forms.CheckBox boxItemDestroyable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox picItemIcon;
        private System.Windows.Forms.NumericUpDown numItemMass;
        private System.Windows.Forms.NumericUpDown numItemValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.Button cmdSaveItem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtItemRequire;
        private System.Windows.Forms.ComboBox boxReqSkill;
        private System.Windows.Forms.ComboBox boxReqOperator;
        private System.Windows.Forms.NumericUpDown numReqValue;
        private System.Windows.Forms.Button cmdReqAdd;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button cmdResetItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.CheckBox boxAutoSave;
        private System.Windows.Forms.ToolStripMenuItem changeIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem changeIDToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem1;
        private System.Windows.Forms.CheckBox boxItemStackable;
    }
}

