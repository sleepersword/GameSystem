using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItemEditor
{
    public partial class DialogForm_New : Form
    {
        public string SetName = "default";
        public string FilePath = "";

        public DialogForm_New()
        {
            InitializeComponent();

            DialogResult = DialogResult.Abort;
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            if (txtFile.Text == "" ||txtName.Text == "")
            {
                MessageBox.Show("Fill out all fields!", "Error", MessageBoxButtons.OK);
            } else
            {
                this.Close();
                DialogResult = DialogResult.OK;
            }
        }

        private void cmdFileSelect_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog()
            {
                Filter = "ItemSet file (*" + Document.EXTENSION + "|*" + Document.EXTENSION,
                FilterIndex = 0,
                AddExtension = true,
                CreatePrompt = true,
                ValidateNames = true,
                CheckPathExists = true,
                Title = "Select the path of the new Document...",
                RestoreDirectory = false,
                InitialDirectory = Application.StartupPath
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = sfd.FileName;
            }
        }

        private void cmdAbort_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void txtFile_TextChanged(object sender, EventArgs e)
        {
            FilePath = txtFile.Text;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            SetName = txtName.Text;
        }

        private void DialogForm_New_Load(object sender, EventArgs e)
        {
            txtFile.Text = Application.StartupPath;
            OpenFileDialog ofd = new OpenFileDialog();
        }
    }
}
