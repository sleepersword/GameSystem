using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameSystem.Items;
using System.Reflection;

namespace ItemEditor
{
    public partial class DialogForm_ChangeID : Form
    {
        private IT_Item _item;

        public int NewID { get; private set; }

        public DialogForm_ChangeID(IT_Item item)
        {
            InitializeComponent();
            _item = item;
        }

        private void DialogForm_ChangeID_Load(object sender, EventArgs e)
        {
            lblName.Text = _item.Name;
            lblOldID.Text = _item.ID.ToString();
            numNewID.Value = _item.ID;

            var st = Assembly.GetExecutingAssembly().GetManifestResourceStream("ItemEditor.Icons." + _item.Type.ToString() + ".png");
            if (st == null)
            {
                picIcon.BackgroundImage = picIcon.ErrorImage;
            }
            else
            {
                picIcon.BackgroundImage = new Bitmap(st);
                st.Dispose();
                st = null;
            }
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            if (_item.ID == numNewID.Value)
            {
                MessageBox.Show("You need to enter a different ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            NewID = (int)numNewID.Value;
            this.Close();
        }

        public static int ShowDialog(IT_Item item)
        {
            var form = new DialogForm_ChangeID(item);

            form.ShowDialog();

            return form.NewID;
        }
    }
}
