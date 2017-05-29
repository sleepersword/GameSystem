namespace ItemEditor
{
    partial class DialogForm_ChangeID
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numNewID = new System.Windows.Forms.NumericUpDown();
            this.cmdOk = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblOldID = new System.Windows.Forms.Label();
            this.picIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numNewID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Old ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "New ID:";
            // 
            // numNewID
            // 
            this.numNewID.Location = new System.Drawing.Point(75, 68);
            this.numNewID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numNewID.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numNewID.Name = "numNewID";
            this.numNewID.Size = new System.Drawing.Size(120, 22);
            this.numNewID.TabIndex = 3;
            this.numNewID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmdOk
            // 
            this.cmdOk.Location = new System.Drawing.Point(220, 65);
            this.cmdOk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(51, 27);
            this.cmdOk.TabIndex = 4;
            this.cmdOk.Text = "OK";
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Name:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(72, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 17);
            this.lblName.TabIndex = 6;
            // 
            // lblOldID
            // 
            this.lblOldID.AutoSize = true;
            this.lblOldID.Location = new System.Drawing.Point(72, 9);
            this.lblOldID.Name = "lblOldID";
            this.lblOldID.Size = new System.Drawing.Size(0, 17);
            this.lblOldID.TabIndex = 7;
            // 
            // picIcon
            // 
            this.picIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picIcon.Location = new System.Drawing.Point(220, 9);
            this.picIcon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(51, 50);
            this.picIcon.TabIndex = 8;
            this.picIcon.TabStop = false;
            // 
            // DialogForm_ChangeID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 98);
            this.ControlBox = false;
            this.Controls.Add(this.picIcon);
            this.Controls.Add(this.lblOldID);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.numNewID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DialogForm_ChangeID";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change ID";
            this.Load += new System.EventHandler(this.DialogForm_ChangeID_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numNewID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numNewID;
        private System.Windows.Forms.Button cmdOk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblOldID;
        private System.Windows.Forms.PictureBox picIcon;
    }
}