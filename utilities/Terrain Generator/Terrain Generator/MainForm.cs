using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VolxEngine.Terrain;

namespace Terrain_Generator
{
    public partial class MainForm : Form
    {
        private Bitmap _img;
        private GreyscaleMap _map;

        public MainForm()
        {
            InitializeComponent();
            pbImage.Text = @"H:\Bilder\nick.jpg";
            numericUpDown1.Value = 122;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pbImage.Text)) return;
            _img = (Bitmap)Image.FromFile(pbImage.Text);

            pbOriginal.BackgroundImage = _img;
            _map = GreyscaleMap.FromImage(_img);
            pbMap.BackgroundImage = _map.ToGreyscaleImage(true, 122);
        }

        private void pathBox1_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (_img != null)
            {
                pbMap.BackgroundImage = _map.ToGreyscaleImage(true, (int) numericUpDown1.Value);
            }
        }
    }
}
