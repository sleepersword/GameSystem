namespace CharacterView
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolsMain = new System.Windows.Forms.ToolStrip();
            this.cmdNewChar = new System.Windows.Forms.ToolStripButton();
            this.cmdSave = new System.Windows.Forms.ToolStripButton();
            this.cmdOpen = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.cmdIDSet = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cmdCreateChar = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.cmdBonusRem = new System.Windows.Forms.Button();
            this.cmdBonusAdd = new System.Windows.Forms.Button();
            this.cmdLevelUp = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lvSkills = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.consoleCtrl = new ConsoleControl.ConsoleControl();
            this.toolsMain.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolsMain
            // 
            this.toolsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdNewChar,
            this.cmdSave,
            this.cmdOpen});
            this.toolsMain.Location = new System.Drawing.Point(0, 0);
            this.toolsMain.Name = "toolsMain";
            this.toolsMain.Size = new System.Drawing.Size(782, 27);
            this.toolsMain.TabIndex = 0;
            // 
            // cmdNewChar
            // 
            this.cmdNewChar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdNewChar.Image = ((System.Drawing.Image)(resources.GetObject("cmdNewChar.Image")));
            this.cmdNewChar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdNewChar.Name = "cmdNewChar";
            this.cmdNewChar.Size = new System.Drawing.Size(24, 24);
            this.cmdNewChar.Text = "New";
            this.cmdNewChar.Click += new System.EventHandler(this.cmdNewChar_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(24, 24);
            this.cmdSave.Text = "Save As";
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdOpen
            // 
            this.cmdOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdOpen.Image = ((System.Drawing.Image)(resources.GetObject("cmdOpen.Image")));
            this.cmdOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdOpen.Name = "cmdOpen";
            this.cmdOpen.Size = new System.Drawing.Size(24, 24);
            this.cmdOpen.Text = "Open From";
            this.cmdOpen.Click += new System.EventHandler(this.cmdOpen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name:";
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(43, 30);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(77, 22);
            this.txtID.TabIndex = 3;
            this.txtID.Text = "1210000001";
            // 
            // cmdIDSet
            // 
            this.cmdIDSet.Location = new System.Drawing.Point(126, 30);
            this.cmdIDSet.Name = "cmdIDSet";
            this.cmdIDSet.Size = new System.Drawing.Size(75, 23);
            this.cmdIDSet.TabIndex = 4;
            this.cmdIDSet.Text = "Set ID";
            this.cmdIDSet.UseVisualStyleBackColor = true;
            this.cmdIDSet.Click += new System.EventHandler(this.cmdIDSet_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(278, 30);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(262, 22);
            this.txtName.TabIndex = 5;
            this.txtName.Text = "Max Mustermann";
            // 
            // cmdCreateChar
            // 
            this.cmdCreateChar.Location = new System.Drawing.Point(695, 30);
            this.cmdCreateChar.Name = "cmdCreateChar";
            this.cmdCreateChar.Size = new System.Drawing.Size(75, 23);
            this.cmdCreateChar.TabIndex = 6;
            this.cmdCreateChar.Text = "Create";
            this.cmdCreateChar.UseVisualStyleBackColor = true;
            this.cmdCreateChar.Click += new System.EventHandler(this.cmdCreateChar_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlMain.Controls.Add(this.cmdBonusRem);
            this.pnlMain.Controls.Add(this.cmdBonusAdd);
            this.pnlMain.Controls.Add(this.cmdLevelUp);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.lvSkills);
            this.pnlMain.Enabled = false;
            this.pnlMain.Location = new System.Drawing.Point(0, 59);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(782, 402);
            this.pnlMain.TabIndex = 7;
            // 
            // cmdBonusRem
            // 
            this.cmdBonusRem.Location = new System.Drawing.Point(215, 3);
            this.cmdBonusRem.Name = "cmdBonusRem";
            this.cmdBonusRem.Size = new System.Drawing.Size(112, 23);
            this.cmdBonusRem.TabIndex = 4;
            this.cmdBonusRem.Text = "Remove Bonus";
            this.cmdBonusRem.UseVisualStyleBackColor = true;
            this.cmdBonusRem.Click += new System.EventHandler(this.cmdBonusRem_Click);
            // 
            // cmdBonusAdd
            // 
            this.cmdBonusAdd.Location = new System.Drawing.Point(122, 3);
            this.cmdBonusAdd.Name = "cmdBonusAdd";
            this.cmdBonusAdd.Size = new System.Drawing.Size(87, 23);
            this.cmdBonusAdd.TabIndex = 3;
            this.cmdBonusAdd.Text = "Add Bonus";
            this.cmdBonusAdd.UseVisualStyleBackColor = true;
            this.cmdBonusAdd.Click += new System.EventHandler(this.cmdBonusAdd_Click);
            // 
            // cmdLevelUp
            // 
            this.cmdLevelUp.Location = new System.Drawing.Point(555, 6);
            this.cmdLevelUp.Name = "cmdLevelUp";
            this.cmdLevelUp.Size = new System.Drawing.Size(75, 29);
            this.cmdLevelUp.TabIndex = 2;
            this.cmdLevelUp.Text = "Level Up";
            this.cmdLevelUp.UseVisualStyleBackColor = true;
            this.cmdLevelUp.Click += new System.EventHandler(this.cmdLevelUp_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Skills:";
            // 
            // lvSkills
            // 
            this.lvSkills.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvSkills.GridLines = true;
            this.lvSkills.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvSkills.Location = new System.Drawing.Point(3, 29);
            this.lvSkills.MultiSelect = false;
            this.lvSkills.Name = "lvSkills";
            this.lvSkills.Size = new System.Drawing.Size(324, 366);
            this.lvSkills.TabIndex = 0;
            this.lvSkills.UseCompatibleStateImageBehavior = false;
            this.lvSkills.View = System.Windows.Forms.View.Details;
            this.lvSkills.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lvSkills_ColumnWidthChanging);
            this.lvSkills.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvSkills_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Symbol";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Events";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 58;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Boni";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Count";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // consoleCtrl
            // 
            this.consoleCtrl.AutoScroll = true;
            this.consoleCtrl.Font = new System.Drawing.Font("Lucida Console", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consoleCtrl.IsInputEnabled = true;
            this.consoleCtrl.Location = new System.Drawing.Point(0, 463);
            this.consoleCtrl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.consoleCtrl.Name = "consoleCtrl";
            this.consoleCtrl.SendKeyboardCommandsToProcess = false;
            this.consoleCtrl.ShowDiagnostics = false;
            this.consoleCtrl.Size = new System.Drawing.Size(782, 175);
            this.consoleCtrl.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(782, 637);
            this.Controls.Add(this.consoleCtrl);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.cmdCreateChar);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.cmdIDSet);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolsMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(800, 682);
            this.MinimumSize = new System.Drawing.Size(800, 682);
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CharacterView";
            this.toolsMain.ResumeLayout(false);
            this.toolsMain.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolsMain;
        private System.Windows.Forms.ToolStripButton cmdNewChar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button cmdIDSet;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button cmdCreateChar;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lvSkills;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button cmdLevelUp;
        private System.Windows.Forms.ToolStripButton cmdSave;
        private System.Windows.Forms.ToolStripButton cmdOpen;
        private System.Windows.Forms.Button cmdBonusAdd;
        private System.Windows.Forms.Button cmdBonusRem;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private ConsoleControl.ConsoleControl consoleCtrl;
    }
}

