namespace ItemEditor
{
    partial class DialogForm_New
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
            this.cmdOk = new System.Windows.Forms.Button();
            this.cmdAbort = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.cmdFileSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdOk
            // 
            this.cmdOk.Location = new System.Drawing.Point(255, 97);
            this.cmdOk.Margin = new System.Windows.Forms.Padding(4);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(108, 31);
            this.cmdOk.TabIndex = 0;
            this.cmdOk.Text = "OK";
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // cmdAbort
            // 
            this.cmdAbort.Location = new System.Drawing.Point(16, 97);
            this.cmdAbort.Margin = new System.Windows.Forms.Padding(4);
            this.cmdAbort.Name = "cmdAbort";
            this.cmdAbort.Size = new System.Drawing.Size(100, 28);
            this.cmdAbort.TabIndex = 1;
            this.cmdAbort.Text = "Abort";
            this.cmdAbort.UseVisualStyleBackColor = true;
            this.cmdAbort.Click += new System.EventHandler(this.cmdAbort_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(72, 12);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(289, 22);
            this.txtName.TabIndex = 3;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "File:";
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(72, 53);
            this.txtFile.Margin = new System.Windows.Forms.Padding(4);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(239, 22);
            this.txtFile.TabIndex = 5;
            this.txtFile.TextChanged += new System.EventHandler(this.txtFile_TextChanged);
            // 
            // cmdFileSelect
            // 
            this.cmdFileSelect.Location = new System.Drawing.Point(320, 50);
            this.cmdFileSelect.Margin = new System.Windows.Forms.Padding(4);
            this.cmdFileSelect.Name = "cmdFileSelect";
            this.cmdFileSelect.Size = new System.Drawing.Size(43, 28);
            this.cmdFileSelect.TabIndex = 6;
            this.cmdFileSelect.Text = "...";
            this.cmdFileSelect.UseVisualStyleBackColor = true;
            this.cmdFileSelect.Click += new System.EventHandler(this.cmdFileSelect_Click);
            // 
            // DialogForm_New
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 139);
            this.ControlBox = false;
            this.Controls.Add(this.cmdFileSelect);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdAbort);
            this.Controls.Add(this.cmdOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DialogForm_New";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New...";
            this.Load += new System.EventHandler(this.DialogForm_New_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdOk;
        private System.Windows.Forms.Button cmdAbort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button cmdFileSelect;
    }
}