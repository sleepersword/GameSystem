using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameSystem.Items;
using System.IO;
using ProtoBuf;
using System.Windows.Forms;

namespace ItemEditor
{
    public class Document : IDisposable
    {
        public IT_Manager Lib;
        public string Name;

        private bool _saved = true;
        public bool Saved
        {
            get { return _saved; }
            set
            {
                _saved = value;
                if (_saved)
                {
                    OnSave?.Invoke(this, new EventArgs());
                } else { OnEdit?.Invoke(this, new EventArgs()); }
            }
        }

        public bool FileIsBacked
        {
            get { return (_file != null && _fs != null); }
        }

        private FileInfo _file;
        private FileStream _fs;

        public const string EXTENSION = ".isf";

        public IT_Item this[int id]
        {
            get { return Lib[id]; }
        }

        /// <summary>
        /// Only use to load valid files!
        /// </summary>
        /// <param name="filePath"></param>
        public Document(string filePath)
        {
            IT_Set set;

            _file = new FileInfo(filePath);
            _fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            
            set = Serializer.Deserialize<IT_Set>(_fs);

            Lib = new IT_Manager();
            Name = set.Name;

            _fs.Position = 0;
        }

        public Document(string filePath, string name)
        {
            Lib = new IT_Manager();
            Name = name;

            ChangeFile(filePath);
        }

        /// <summary>
        /// Returns a initialized Document object, which isn't attached to a real file (dummy doc)
        /// </summary>
        public Document()
        {
            Lib = new IT_Manager();
            Name = "";
            _file = null;
            _fs = null;
        }

        public void Save()
        {
            if (!FileIsBacked)
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
                    ChangeFile(sfd.FileName);
                }
            }

            IT_Set set = Lib.ToSet(Name);

            Serializer.Serialize<IT_Set>(_fs, set);

            _fs.Flush();
            _fs.Position = 0;

            Saved = true;
        }

        public void Add(IT_Item item)
        {
            Lib.AddItem(item);
            Saved = false;
        }

        public void Remove(IT_Item item)
        {
            Lib.RemoveItem(item.ID);
            Saved = false;
        }

        public void Remove(int id)
        {
            Lib.RemoveItem(id);
            Saved = false;
        }

        public void ExportSet(string filePath, params int[] ids)
        {
            IT_Item[] res = new IT_Item[ids.Length];
            for (int i = 0; i < ids.Length; i++)
            {
                res[i] = this[ids[i]];
            }

            FileInfo file = new FileInfo(filePath);

            using (FileStream fs = file.Open(FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
            {
                Serializer.Serialize<IT_Set>(fs, new IT_Set(file.Name, res));
            }
        }

        public void ImportSet(string filePath)
        {
            FileInfo file = new FileInfo(filePath);
            IT_Set set;

            using (FileStream fs = file.Open(FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite))
            {
                set = Serializer.Deserialize<IT_Set>(fs);
            }

            Lib.AddSet(set);
            Saved = false;
        }

        public bool ChangeFile(string newFile)
        {
            if (_fs != null)
            {
                _fs.Dispose();
            }

            _file = new FileInfo(newFile);

            if (_file.Exists)
            {
                _fs = _file.Open(FileMode.Truncate, FileAccess.ReadWrite, FileShare.ReadWrite);
            }
            else
            {
                _fs = _file.Open(FileMode.CreateNew, FileAccess.ReadWrite, FileShare.ReadWrite);
            }

            return true;
        }
        
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    if (_fs != null)
                    {
                        _fs.Dispose();
                    }
                }

                // TODO: set large fields to null.
                _fs = null;
                _file = null;

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            if (!Saved)
            {
                if (MessageBox.Show("Save unsaved changes?", "Save", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Save();
                }
            }

            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion

        public event EventHandler OnEdit;
        public event EventHandler OnSave;
    }
}
