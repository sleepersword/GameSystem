using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameSystem.Items;
using GameSystem;

namespace ItemEditor
{
    public partial class mainForm : Form
    {

        #region Document Doc
        public Document Doc { get; private set; }

        private void Doc_OnSave(object sender, EventArgs e)
        {
            this.Text = _title;
        }

        private void Doc_OnEdit(object sender, EventArgs e)
        {
            this.Text = _title + " *";
            lblCount.Text = Doc.Lib.Count.ToString();
        }
        #endregion
       
        public IT_Item EditedItem;

        private string _title
        {
            get { return Assembly.GetExecutingAssembly().GetName().Name + 
                    " v." + Assembly.GetExecutingAssembly().GetName().Version + ": " + Doc.Name; }
        }

        public mainForm(StartupResults startRes)
        {
            Doc = new Document();

            InitializeComponent();
            Init();

            switch (startRes)
            {
                case StartupResults.New:
                    NewFile();
                    break;
                case StartupResults.Load:
                    LoadFile();
                    break;
                default:
                    NewFile();
                    break;
            }
        }

        private void Init()
        {
            boxItemType.Items.AddRange(Enum.GetNames(typeof(IT_Types)));
            boxItemType.SelectedIndex = 65;
            boxReqOperator.SelectedIndex = 3;
            boxReqSkill.SelectedIndex = 0;

        }

        private void ReloadItemView()
        {
            viewItems.Items.Clear();

            foreach (IT_Item i in Doc.Lib)
            {
                ListViewItem li = new ListViewItem
                    (new string[] {"", i.ID.ToString(), i.Name, i.Type.ToString(), i.Value.ToString(), i.Mass.ToString() }, i.Type.ToString() + ".png");
                li.UseItemStyleForSubItems = true;
                
                viewItems.Items.Add(li);
            }
        }
        
        private void SetActiveItem(IT_Item item)
        {
            if (item.ID == numItemID.Value)
            {
                return;
            } else
            {
                SaveItem();
            }

            //requirements
            boxReqOperator.SelectedIndex = 3;
            boxReqSkill.SelectedIndex = 0;
            numReqValue.Value = 0;

            //item
            txtItemName.Text = item.Name;
            txtItemRequire.Text = Requirement.ToString(item.Requirements);

            boxItemDamaged.Checked = item.IsDamaged;
            boxItemDestroyable.Checked = item.IsDestroyable;
            boxItemSellable.Checked = item.IsSellable;

            boxItemType.SelectedItem = item.Type.ToString();

            numItemValue.Value = item.Value;
            numItemID.Value = item.ID;
            numItemMass.Value = (decimal)item.Mass;

            if (Doc.Lib.Contains(item.ID))
            {
                numItemID.Enabled = false;
            }
            else
            {
                numItemID.Enabled = true;
            }
        }

        private void RemoveItem()
        {
            for (int i = 0; i < viewItems.SelectedItems.Count; i++)
            {
                int id = int.Parse(viewItems.SelectedItems[i].SubItems[1].Text);
                Doc.Remove(id);
            }
        }

        #region Event Methods

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Doc != null) { Dispose(); }
        }

        private void mainContainer_SplitterMoving(object sender, SplitterCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyItem();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveItem();
        }

        //Key Handling
        private void mainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.S:
                    if (e.Control) SaveFile();
                    break;
                case Keys.Delete:
                    RemoveItem();
                    break;
                case Keys.C:
                    if (e.Control) CopyItem();
                    break;
            }
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            this.Text = _title;
            lblCount.Text = Doc.Lib.Count.ToString();

            this.Activate();
        }
        
        private void contextMenuItemView_Opening(object sender, CancelEventArgs e)
        {
            if (viewItems.SelectedIndices.Count < 1)
            {
                changeIDToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
                removeToolStripMenuItem.Enabled = false;
                exportToolStripMenuItem.Enabled = false;
                importToolStripMenuItem.Enabled = true;
            }
            else
            {
                if (viewItems.SelectedIndices.Count == 1)
                {
                    changeIDToolStripMenuItem.Enabled = true;
                    copyToolStripMenuItem.Enabled = true;
                    removeToolStripMenuItem.Enabled = true;
                    exportToolStripMenuItem.Enabled = true;
                    importToolStripMenuItem.Enabled = false;
                }
                else
                {
                    changeIDToolStripMenuItem.Enabled = false;
                    copyToolStripMenuItem.Enabled = false;
                    removeToolStripMenuItem.Enabled = false;
                    exportToolStripMenuItem.Enabled = true;
                    importToolStripMenuItem.Enabled = false;
                }
            }

        }

        private void boxItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = boxItemType.SelectedItem.ToString();

            var st = Assembly.GetExecutingAssembly().GetManifestResourceStream("ItemEditor.Icon." + type + ".png");
            if (st == null)
            {
                picItemIcon.BackgroundImage = picItemIcon.ErrorImage;
            }
            else
            {
                picItemIcon.BackgroundImage = new Bitmap(st);
                st.Dispose();
                st = null;
            }

        }

        private void cmdSaveItem_Click(object sender, EventArgs e)
        {
            if (Doc.Lib.Contains((int)numItemID.Value))
            {
                SaveItem();
            } else
            {
                AddItem();
            }
        }

        private void cmdReqAdd_Click(object sender, EventArgs e)
        {
            Requirement[] r = Requirement.FromString(boxReqSkill.SelectedItem.ToString() + boxReqOperator.SelectedItem.ToString() + numReqValue.Value + ";");

            txtItemRequire.Text += Requirement.ToString(r);
        }

        private void cmdResetItem_Click(object sender, EventArgs e)
        {
            if (Doc.Lib.Contains((int)numItemID.Value))
            {
                SaveItem();
            }
            else
            {
                AddItem();
            }

            IT_Item def = new IT_Item()
            {
                ID = 0,
                Name = "",
                Type = IT_Types.Miscellaneous,
                Value = 0,
                Mass = 0,
                IsDamaged = false,
                IsSellable = true,
                IsDestroyable = true,
                Requirements = new Requirement[0],
                NumberOfInstances = 0
            };
            SetActiveItem(def);
        }

        private void viewItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (viewItems.SelectedItems.Count == 1)
            {
                int id = int.Parse(viewItems.SelectedItems[0].SubItems[1].Text);
                IT_Item item = Doc.Lib[id];
                SetActiveItem(item);
                
            }
            else if (viewItems.SelectedItems.Count > 1)
            {

            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileAs();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFile();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quit();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportSet();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void changeIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeID();
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportSet();
        }

        private void exportToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CopyItem();
        }

        private void removeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RemoveItem();
        }

        private void changeIDToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ChangeID();
        }

        private void importToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ImportSet();
        }

        #region Autosave events

        private void viewItems_Enter(object sender, EventArgs e)
        {
            AutoSaveItem();
        }

        private void toolStrip1_Enter(object sender, EventArgs e)
        {
            AutoSaveItem();
        }

        private void mainForm_Leave(object sender, EventArgs e)
        {
            AutoSaveItem();
        }

        #endregion
        
        #endregion

        private void SaveItem()
        {
            int id = (int)numItemID.Value;
            if (!Doc.Lib.Contains(id))
            {
                return;
            }

            IT_Types type = (IT_Types)Enum.Parse(typeof(IT_Types), boxItemType.SelectedItem.ToString());
            string name = txtItemName.Text;
            int mass = (int)numItemMass.Value;
            int value = (int)numItemValue.Value;
            bool sellable = boxItemSellable.Checked;
            bool destroyable = boxItemDestroyable.Checked;
            bool damaged = boxItemDamaged.Checked;
            Requirement[] requs = Requirement.FromString(txtItemRequire.Text);

            Doc[id].IsDamaged = damaged;
            Doc[id].IsDestroyable = destroyable;
            Doc[id].IsSellable = sellable;
            Doc[id].Name = name;
            Doc[id].Type = type;
            Doc[id].Mass = mass;
            Doc[id].Value = value;
            Doc[id].Requirements = requs;

            Doc.Saved = false;

            ReloadItemView();
        }

        private void AddItem(bool force = false)
        {
            IT_Types type = (IT_Types)Enum.Parse(typeof(IT_Types), boxItemType.SelectedItem.ToString());
            int id = (int)numItemID.Value;
            id += 11000000 + ((int)type * 10000);

            if (Doc.Lib.Contains(id))
            {
                if (force)
                {
                    Doc.Remove(id);
                }
                else if (MessageBox.Show("Overwrite existing item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Doc.Remove(id);
                }
                else { return; }
            }

            string name = txtItemName.Text;
            int mass = (int)numItemMass.Value;
            int value = (int)numItemValue.Value;
            bool sellable = boxItemSellable.Checked;
            bool destroyable = boxItemDestroyable.Checked;
            bool damaged = boxItemDamaged.Checked;
            bool stackable = boxItemStackable.Checked;
            Requirement[] requs = Requirement.FromString(txtItemRequire.Text);

            IT_Item item = new IT_Item(id, type, name, value, mass, sellable, destroyable, damaged, stackable ,requs);

            Doc.Add(item);

            ReloadItemView();

        }

        private void LoadFile()
        {
            lblStatus.Text = "Loading Document from file...";
            
            var ofd = new OpenFileDialog()
            {
                Filter = "ItemSet file (*" + Document.EXTENSION + "|*" + Document.EXTENSION,
                FilterIndex = 0,
                AddExtension = true,
                ValidateNames = true,
                CheckPathExists = true,
                Multiselect = false,
                Title = "Select the File you want to load...",
                RestoreDirectory = true
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Doc.Dispose();
                Doc = new Document(ofd.FileName);
                Doc.OnEdit += Doc_OnEdit;
                Doc.OnSave += Doc_OnSave;
                lblStatus.Text = "Loaded Document from file";
                ReloadItemView();
            }
            else
            {
                lblStatus.Text = "Aborted";
            }
        }

        private void SaveFile()
        {
            lblStatus.Text = "Saving...";
            if (!Doc.FileIsBacked)
            {
                if (!ChangeFile()) { lblStatus.Text = "Aborted"; return; }
            }

            Doc.Save();
            lblStatus.Text = "Saved";
        }

        private void SaveFileAs()
        {
            lblStatus.Text = "Saving...";

            var sfd = new SaveFileDialog()
            {
                Filter = "ItemSet file (*" + Document.EXTENSION + "|*" + Document.EXTENSION,
                FilterIndex = 0,
                AddExtension = true,
                CreatePrompt = true,
                ValidateNames = true,
                CheckPathExists = true,
                Title = "Select the new path of the Document...",
                RestoreDirectory = true
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Doc.ChangeFile(sfd.FileName);
                Doc.Save();
                lblStatus.Text = "Saved";
            }
            else
            {
                lblStatus.Text = "Aborted";
            }

        }

        private bool ChangeFile()
        {
            lblStatus.Text = "Changing the document file...";

            var sfd = new SaveFileDialog()
            {
                Filter = "ItemSet file (*" + Document.EXTENSION + "|*" + Document.EXTENSION,
                FilterIndex = 0,
                AddExtension = true,
                CreatePrompt = true,
                ValidateNames = true,
                CheckPathExists = true,
                Title = "Select the path of the new Document...",
                RestoreDirectory = true
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                lblStatus.Text = "Changed the document file";
                return Doc.ChangeFile(sfd.FileName);
            }
            else
            {
                lblStatus.Text = "Aborted";
                return false;
            }
        }

        private void NewFile()
        {
            lblStatus.Text = "Creating new Document...";

            DialogForm_New dfn = new ItemEditor.DialogForm_New();

            var res = dfn.ShowDialog();
            if (res == DialogResult.OK)
            {
                Doc.Dispose();
                Doc = new Document(dfn.FilePath, dfn.SetName);
                Doc.OnEdit += Doc_OnEdit;
                Doc.OnSave += Doc_OnSave;
                lblStatus.Text = "Created new Document";
            }
            else { lblStatus.Text = "Aborted"; }
        }

        private void ExportSet()
        {
            lblStatus.Text = "Exporting item set...";

            var sfd = new SaveFileDialog()
            {
                Filter = "ItemSet file (*" + Document.EXTENSION + "|*" + Document.EXTENSION,
                FilterIndex = 0,
                AddExtension = true,
                CreatePrompt = true,
                ValidateNames = true,
                CheckPathExists = true,
                Title = "Select the path of the item set...",
                RestoreDirectory = true
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                throw new NotImplementedException();
                lblStatus.Text = "Exported item set";
            }
            else
            {
                lblStatus.Text = "Aborted";
            }

            lblStatus.Text = "Exported item set...";
        }

        private void CopyItem()
        {
            int id;

            if (!int.TryParse(viewItems.SelectedItems[0].SubItems[1].Text, out id) | !Doc.Lib.Contains(id)) return;
            int newID = id;

            while (Doc.Lib.Contains(newID))
            {
                newID = DialogForm_ChangeID.ShowDialog(Doc[id]);
            }

            var item = Doc[id].Copy(newID);
            Doc.Add(item);
            
            ReloadItemView();
        }

        private void AutoSaveItem()
        {
            int id = (int)numItemID.Value;

            if (boxAutoSave.Checked && Doc.Lib.Contains(id))
            {
                SaveItem();
            } else if (!Doc.Lib.Contains(id) && id != 0)
            {
                if (MessageBox.Show("Do you want to add the item to the collection?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    AddItem();
                }
            }

        }

        private void ChangeID()
        {
            int id = int.Parse(viewItems.SelectedItems[0].SubItems[1].Text);
            var item = Doc[id];

            int n = id;
            while (Doc.Lib.Contains(n)) { n = DialogForm_ChangeID.ShowDialog(Doc[id]); }

            item.ID = n;

            Doc.Remove(id);
            Doc.Add(item);

            ReloadItemView();
        }

        private void Quit()
        {
            lblStatus.Text = "Quitting...";

            Doc.Dispose();
            Doc = null;

            Application.Exit();

        }

        private void ImportSet()
        {
            lblStatus.Text = "Importing items from file...";
            
            var ofd = new OpenFileDialog()
            {
                Filter = "ItemSet file (*" + Document.EXTENSION + "|*" + Document.EXTENSION,
                FilterIndex = 0,
                AddExtension = true,
                ValidateNames = true,
                CheckPathExists = true,
                Multiselect = false,
                Title = "Select the File you want to import...",
                RestoreDirectory = true
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Doc.ImportSet(ofd.FileName);

                lblStatus.Text = "Imported items from file";
                ReloadItemView();
            }
            else
            {
                lblStatus.Text = "Aborted";
            }
        }
    }
}
