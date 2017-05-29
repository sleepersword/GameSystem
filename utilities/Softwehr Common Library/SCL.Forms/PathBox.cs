using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SCL.Forms
{
    public partial class PathBox : UserControl
    {
        public OpenFileDialog FileDialog { get; private set; }
        public override string Text
        {
            get { return txtPath.Text; } 
            set { txtPath.Text = value; }
        }

        public PathBox()
        {
            InitializeComponent();
            FileDialog = new OpenFileDialog();
        }

        private void PathBox_Resize(object sender, EventArgs e)
        {
            
        }

        private void cmdOFD_Click(object sender, EventArgs e)
        {
            if (FileDialog.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = FileDialog.FileName;
            }
        }
    }
}
