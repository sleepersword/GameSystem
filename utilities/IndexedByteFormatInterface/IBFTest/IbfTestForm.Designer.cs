namespace IBFTest
{
    partial class IbfTestForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabCreate = new System.Windows.Forms.TabPage();
            this.txtDocName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cmdSelectFiles = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSelectedFiles = new System.Windows.Forms.TextBox();
            this.tabAnalize = new System.Windows.Forms.TabPage();
            this.cmdSelectAnal = new System.Windows.Forms.Button();
            this.lbElementIndices = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHeadMembers = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDocPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdAnalize = new System.Windows.Forms.Button();
            this.tabEdit = new System.Windows.Forms.TabPage();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.txtAddPath = new System.Windows.Forms.TextBox();
            this.cmdOFD = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.numID = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabCreate.SuspendLayout();
            this.tabAnalize.SuspendLayout();
            this.tabEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numID)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabCreate);
            this.tabControl.Controls.Add(this.tabAnalize);
            this.tabControl.Controls.Add(this.tabEdit);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(883, 638);
            this.tabControl.TabIndex = 0;
            // 
            // tabCreate
            // 
            this.tabCreate.Controls.Add(this.txtDocName);
            this.tabCreate.Controls.Add(this.label2);
            this.tabCreate.Controls.Add(this.button1);
            this.tabCreate.Controls.Add(this.cmdSelectFiles);
            this.tabCreate.Controls.Add(this.label1);
            this.tabCreate.Controls.Add(this.txtSelectedFiles);
            this.tabCreate.Location = new System.Drawing.Point(4, 29);
            this.tabCreate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabCreate.Name = "tabCreate";
            this.tabCreate.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabCreate.Size = new System.Drawing.Size(875, 605);
            this.tabCreate.TabIndex = 0;
            this.tabCreate.Text = "Creation";
            this.tabCreate.Enter += new System.EventHandler(this.tabCreate_Enter);
            // 
            // txtDocName
            // 
            this.txtDocName.Location = new System.Drawing.Point(503, 37);
            this.txtDocName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDocName.Name = "txtDocName";
            this.txtDocName.Size = new System.Drawing.Size(288, 26);
            this.txtDocName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(499, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name of IBF Document:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(735, 537);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 50);
            this.button1.TabIndex = 3;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdSelectFiles
            // 
            this.cmdSelectFiles.Location = new System.Drawing.Point(214, 6);
            this.cmdSelectFiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdSelectFiles.Name = "cmdSelectFiles";
            this.cmdSelectFiles.Size = new System.Drawing.Size(112, 39);
            this.cmdSelectFiles.TabIndex = 2;
            this.cmdSelectFiles.Text = "Select";
            this.cmdSelectFiles.UseVisualStyleBackColor = true;
            this.cmdSelectFiles.Click += new System.EventHandler(this.cmdSelectFiles_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Selected files(0):";
            // 
            // txtSelectedFiles
            // 
            this.txtSelectedFiles.Location = new System.Drawing.Point(8, 51);
            this.txtSelectedFiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSelectedFiles.Multiline = true;
            this.txtSelectedFiles.Name = "txtSelectedFiles";
            this.txtSelectedFiles.Size = new System.Drawing.Size(455, 536);
            this.txtSelectedFiles.TabIndex = 0;
            // 
            // tabAnalize
            // 
            this.tabAnalize.Controls.Add(this.cmdSelectAnal);
            this.tabAnalize.Controls.Add(this.lbElementIndices);
            this.tabAnalize.Controls.Add(this.label5);
            this.tabAnalize.Controls.Add(this.txtHeadMembers);
            this.tabAnalize.Controls.Add(this.label4);
            this.tabAnalize.Controls.Add(this.txtDocPath);
            this.tabAnalize.Controls.Add(this.label3);
            this.tabAnalize.Controls.Add(this.cmdAnalize);
            this.tabAnalize.Location = new System.Drawing.Point(4, 29);
            this.tabAnalize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabAnalize.Name = "tabAnalize";
            this.tabAnalize.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabAnalize.Size = new System.Drawing.Size(875, 605);
            this.tabAnalize.TabIndex = 1;
            this.tabAnalize.Text = "Analization";
            this.tabAnalize.Enter += new System.EventHandler(this.tabAnalize_Enter);
            // 
            // cmdSelectAnal
            // 
            this.cmdSelectAnal.Location = new System.Drawing.Point(790, 5);
            this.cmdSelectAnal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdSelectAnal.Name = "cmdSelectAnal";
            this.cmdSelectAnal.Size = new System.Drawing.Size(79, 35);
            this.cmdSelectAnal.TabIndex = 7;
            this.cmdSelectAnal.Text = "Select...";
            this.cmdSelectAnal.UseVisualStyleBackColor = true;
            this.cmdSelectAnal.Click += new System.EventHandler(this.cmdSelectAnal_Click);
            // 
            // lbElementIndices
            // 
            this.lbElementIndices.FormattingEnabled = true;
            this.lbElementIndices.ItemHeight = 20;
            this.lbElementIndices.Location = new System.Drawing.Point(413, 66);
            this.lbElementIndices.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbElementIndices.Name = "lbElementIndices";
            this.lbElementIndices.Size = new System.Drawing.Size(444, 364);
            this.lbElementIndices.TabIndex = 6;
            this.lbElementIndices.SelectedIndexChanged += new System.EventHandler(this.lbElementIndices_SelectedIndexChanged);
            this.lbElementIndices.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lbElementIndices_KeyUp);
            this.lbElementIndices.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbElementIndices_MouseDoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(409, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Elements:";
            // 
            // txtHeadMembers
            // 
            this.txtHeadMembers.Location = new System.Drawing.Point(12, 66);
            this.txtHeadMembers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHeadMembers.Multiline = true;
            this.txtHeadMembers.Name = "txtHeadMembers";
            this.txtHeadMembers.Size = new System.Drawing.Size(381, 523);
            this.txtHeadMembers.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Head:";
            // 
            // txtDocPath
            // 
            this.txtDocPath.Location = new System.Drawing.Point(50, 9);
            this.txtDocPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDocPath.Name = "txtDocPath";
            this.txtDocPath.Size = new System.Drawing.Size(734, 26);
            this.txtDocPath.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "File:";
            // 
            // cmdAnalize
            // 
            this.cmdAnalize.Location = new System.Drawing.Point(725, 529);
            this.cmdAnalize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdAnalize.Name = "cmdAnalize";
            this.cmdAnalize.Size = new System.Drawing.Size(132, 60);
            this.cmdAnalize.TabIndex = 0;
            this.cmdAnalize.Text = "Analize";
            this.cmdAnalize.UseVisualStyleBackColor = true;
            this.cmdAnalize.Click += new System.EventHandler(this.cmdAnalize_Click);
            // 
            // tabEdit
            // 
            this.tabEdit.Controls.Add(this.label7);
            this.tabEdit.Controls.Add(this.numID);
            this.tabEdit.Controls.Add(this.label6);
            this.tabEdit.Controls.Add(this.cmdOFD);
            this.tabEdit.Controls.Add(this.txtAddPath);
            this.tabEdit.Controls.Add(this.cmdEdit);
            this.tabEdit.Location = new System.Drawing.Point(4, 29);
            this.tabEdit.Name = "tabEdit";
            this.tabEdit.Size = new System.Drawing.Size(875, 605);
            this.tabEdit.TabIndex = 2;
            this.tabEdit.Text = "Editing";
            this.tabEdit.UseVisualStyleBackColor = true;
            // 
            // cmdEdit
            // 
            this.cmdEdit.Location = new System.Drawing.Point(330, 89);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(122, 42);
            this.cmdEdit.TabIndex = 0;
            this.cmdEdit.Text = "Execute";
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // txtAddPath
            // 
            this.txtAddPath.Location = new System.Drawing.Point(60, 18);
            this.txtAddPath.Name = "txtAddPath";
            this.txtAddPath.Size = new System.Drawing.Size(327, 26);
            this.txtAddPath.TabIndex = 1;
            // 
            // cmdOFD
            // 
            this.cmdOFD.Location = new System.Drawing.Point(393, 18);
            this.cmdOFD.Name = "cmdOFD";
            this.cmdOFD.Size = new System.Drawing.Size(43, 26);
            this.cmdOFD.TabIndex = 2;
            this.cmdOFD.Text = "...";
            this.cmdOFD.UseVisualStyleBackColor = true;
            this.cmdOFD.Click += new System.EventHandler(this.cmdOFD_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Path:";
            // 
            // numID
            // 
            this.numID.Location = new System.Drawing.Point(60, 50);
            this.numID.Name = "numID";
            this.numID.Size = new System.Drawing.Size(120, 26);
            this.numID.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "ID:";
            // 
            // IbfTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 639);
            this.Controls.Add(this.tabControl);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "IbfTestForm";
            this.Text = "IndexedByteFormat Tester";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.tabCreate.ResumeLayout(false);
            this.tabCreate.PerformLayout();
            this.tabAnalize.ResumeLayout(false);
            this.tabAnalize.PerformLayout();
            this.tabEdit.ResumeLayout(false);
            this.tabEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabCreate;
        private System.Windows.Forms.TabPage tabAnalize;
        private System.Windows.Forms.TextBox txtSelectedFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdSelectFiles;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtDocName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDocPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdAnalize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHeadMembers;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lbElementIndices;
        private System.Windows.Forms.Button cmdSelectAnal;
        private System.Windows.Forms.TabPage tabEdit;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.Button cmdOFD;
        private System.Windows.Forms.TextBox txtAddPath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numID;
    }
}

