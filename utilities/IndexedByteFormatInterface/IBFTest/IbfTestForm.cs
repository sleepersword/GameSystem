using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IndexedByteFormatInterface;

namespace IBFTest
{
    public partial class IbfTestForm : Form
    {
        public IbfTestForm()
        {
            InitializeComponent();
        }

        #region tabCreate
        private void tabCreate_Enter(object sender, EventArgs e)
        {
            if (_analDoc != null)
            {
                _analDoc.Dispose();
            }
            foreach (TextBoxBase ctrl in tabAnalize.Controls.OfType<TextBoxBase>())
            {
                ctrl.Text = "";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FileIndex[] fi = new FileIndex[txtSelectedFiles.Lines.Length];

            for (int i = 0; i < txtSelectedFiles.Lines.Length; i++)
            {
                fi[i] = new FileIndex(txtSelectedFiles.Lines[i], (byte)i);
            }
		
            Document _document = Document.Factory.FromFiles(txtDocName.Text, fi);
            txtDocPath.Text = _document.FilePath;
            MessageBox.Show(string.Format("Succeeded to create IBF document \"{0}\" in file \"{1}\"", _document.Name, _document.FilePath));
            _document.Dispose();
        }
        private void cmdSelectFiles_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog(){Multiselect = true})
            {
                ofd.ShowDialog();

                if (ofd.FileNames != null || ofd.FileNames.Length != 0)
                {
                    txtSelectedFiles.Lines = ofd.FileNames;
                }
            }
        }

        #endregion 
        
        
        #region tabAnalize

        private Document _analDoc;

        private void cmdAnalize_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDocPath.Text)) return;
            
            _analDoc = Document.ReadDocument(txtDocPath.Text);

            txtHeadMembers.Text = ListMembersOfDocument();

            lbElementIndices.Items.Clear();
            foreach (UInt16 id in _analDoc)
            {
                lbElementIndices.Items.Add(id + @"    " + _analDoc.GetExtension(id));
            }
        }

        private string ListMembersOfDocument()
        {
            StringBuilder sb = new StringBuilder();

            FieldInfo[] headFieldInfos = _analDoc.GetType().GetFields();
            foreach (FieldInfo field in headFieldInfos)
            {
                sb.AppendLine(field.Name + " = " + field.GetValue(_analDoc));
            }
            PropertyInfo[] headPropertyInfos = _analDoc.GetType().GetProperties().Where((p) =>
            {
                if (p.GetIndexParameters().Length > 0) return false;
                return true;
            }).ToArray();
            foreach (PropertyInfo prop in headPropertyInfos)
            {
                if (prop.PropertyType.GetInterface("IEnumerable") != null && prop.PropertyType != typeof(string))
                {
                    var items = (IEnumerable)prop.GetValue(_analDoc,null);
                    StringBuilder enumBuilder = new StringBuilder("{");
                    foreach (object obj in items)
                    {
                        enumBuilder.Append(obj.ToString() + ";");
                    }
                    enumBuilder.Append("}");
                    sb.AppendLine(prop.Name + "=" + enumBuilder.ToString());
                }
                else
                {
                    sb.AppendLine(prop.Name + " = " + prop.GetValue(_analDoc,null));
                }
            }
            sb.AppendLine("MD5 Check: " + _analDoc.CheckMD5Hash());

            return sb.ToString();
        }

        private void lbElementIndices_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter || lbElementIndices.SelectedItem == null) return;
            ShowSelectedElement();
            tabAnalize.Focus();
        }

        private void lbElementIndices_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lbElementIndices.SelectedItem == null) return;
            ShowSelectedElement();
        }

        private void ShowSelectedElement()
        {
            var siString = lbElementIndices.SelectedItem.ToString();
            siString = siString.Remove(siString.IndexOf(' '));
            var id = UInt16.Parse(siString);
            string ext = _analDoc.GetExtension(id);

            if (ext == ".jpg" || ext == ".png" || ext == ".bmp" || ext == ".gif")
            {
                ShowAsImage(id);
            }
            else
            {
                if (
                    MessageBox.Show("Do you want to write this element to \"" + id + ext + "\"?", "Check",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    File.WriteAllBytes(id + ext, _analDoc.GetElementByID_RawBytes(id));
                    MessageBox.Show("Success", "Info", MessageBoxButtons.OK);
                }
            }
        }

        private void ShowAsImage(UInt16 id)
        {
            Image img = null;

            using (var ms = _analDoc.GetElementByID(id))
            {
                img = Image.FromStream(ms);
            }

            using (PictureForm pictureForm = new PictureForm(img))
            {
                pictureForm.ShowDialog();
            }
        }
        #endregion

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_analDoc != null)
            {
                _analDoc.Dispose();
            }
        }
        
        private void tabAnalize_Enter(object sender, EventArgs e)
        {
            foreach (TextBoxBase ctrl in tabCreate.Controls.OfType<TextBoxBase>())
            {
                ctrl.Text = "";
            }
        }

        private void cmdSelectAnal_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Multiselect = false, Filter="IBF File|*.ibf" })
            {
                ofd.ShowDialog();

                if (!string.IsNullOrEmpty(ofd.FileName))
                {
                    txtDocPath.Text = ofd.FileName;
                }
            }
        }

        private void lbElementIndices_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmdOFD_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Multiselect = false })
            {
                ofd.ShowDialog();

                if (!string.IsNullOrEmpty(ofd.FileName))
                {
                    txtAddPath.Text = ofd.FileName;
                }
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txtAddPath.Text) || _analDoc.Contains((ushort) numID.Value)) return;

            //using (DocumentWriter dw = new DocumentWriter(_analDoc))
            //{
            //    dw.AddElements(new FileIndex(txtAddPath.Text, (ushort)numID.Value));
            //}

            //MessageBox.Show("Successfull added element.");
        }
    }
}
