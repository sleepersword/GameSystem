namespace SCL.Forms
{
    partial class PathBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdOFD = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmdOFD
            // 
            this.cmdOFD.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmdOFD.Location = new System.Drawing.Point(400, 0);
            this.cmdOFD.Name = "cmdOFD";
            this.cmdOFD.Size = new System.Drawing.Size(50, 30);
            this.cmdOFD.TabIndex = 0;
            this.cmdOFD.Text = "...";
            this.cmdOFD.UseVisualStyleBackColor = true;
            this.cmdOFD.Click += new System.EventHandler(this.cmdOFD_Click);
            // 
            // txtPath
            // 
            this.txtPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPath.Location = new System.Drawing.Point(0, 0);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(400, 26);
            this.txtPath.TabIndex = 1;
            // 
            // PathBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.cmdOFD);
            this.Name = "PathBox";
            this.Size = new System.Drawing.Size(450, 30);
            this.Resize += new System.EventHandler(this.PathBox_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdOFD;
        private System.Windows.Forms.TextBox txtPath;
    }
}
