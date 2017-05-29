using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IBFTest
{
    public partial class PictureForm : Form
    {
        public Image Image;

        public PictureForm(Image img)
        {
            InitializeComponent();
            if (img != null)
            {
                Image = img;
                this.ClientSize = Image.Size;
                PictureBox pBox = new PictureBox {Size = img.Size, Location = new Point(0, 0), Image = img};
                this.Controls.Add(pBox);
            }
        }

        private void PictureForm_Load(object sender, EventArgs e)
        {
        }

        private void PictureForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }

        ~PictureForm() 
        {
            Image.Dispose();
        }

        private void PictureForm_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
