namespace Terrain_Generator
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
            this.cmdStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pbImage = new SCL.Forms.PathBox();
            this.pbOriginal = new System.Windows.Forms.PictureBox();
            this.pbMap = new System.Windows.Forms.PictureBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pbOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdStart
            // 
            this.cmdStart.Location = new System.Drawing.Point(461, 202);
            this.cmdStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(102, 46);
            this.cmdStart.TabIndex = 0;
            this.cmdStart.Text = "Start";
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Image:";
            // 
            // pbImage
            // 
            this.pbImage.BackColor = System.Drawing.Color.Transparent;
            this.pbImage.Location = new System.Drawing.Point(68, 12);
            this.pbImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(400, 24);
            this.pbImage.TabIndex = 2;
            this.pbImage.Load += new System.EventHandler(this.pathBox1_Load);
            // 
            // pbOriginal
            // 
            this.pbOriginal.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pbOriginal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbOriginal.Location = new System.Drawing.Point(14, 46);
            this.pbOriginal.Name = "pbOriginal";
            this.pbOriginal.Size = new System.Drawing.Size(200, 200);
            this.pbOriginal.TabIndex = 3;
            this.pbOriginal.TabStop = false;
            // 
            // pbMap
            // 
            this.pbMap.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pbMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbMap.Location = new System.Drawing.Point(234, 46);
            this.pbMap.Name = "pbMap";
            this.pbMap.Size = new System.Drawing.Size(200, 200);
            this.pbMap.TabIndex = 4;
            this.pbMap.TabStop = false;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(461, 55);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(84, 22);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 258);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.pbMap);
            this.Controls.Add(this.pbOriginal);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdStart);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Terrain Generator";
            ((System.ComponentModel.ISupportInitialize)(this.pbOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.Label label1;
        private SCL.Forms.PathBox pbImage;
        private System.Windows.Forms.PictureBox pbOriginal;
        private System.Windows.Forms.PictureBox pbMap;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}

