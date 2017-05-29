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
    public partial class DialogForm_Startup : Form
    {
        public DialogForm_Startup()
        {
            InitializeComponent();

            StartupResult = StartupResults.Default;
            DialogResult = DialogResult.None;
        }

        public StartupResults StartupResult { get; private set; }
        
        private void cmdNew_Click(object sender, EventArgs e)
        {
            StartupResult = StartupResults.New;
            this.Close();
        }

        private void cmdLoad_Click(object sender, EventArgs e)
        {

            StartupResult = StartupResults.Load;
            this.Close();
        }

        private void cmdQuit_Click(object sender, EventArgs e)
        {

            StartupResult = StartupResults.Quit;
            this.Close();
        }

        public new StartupResults ShowDialog()
        {
            base.ShowDialog();

            return this.StartupResult;
        }

        private void DialogForm_Startup_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }

    public enum StartupResults
    {
        Default,
        New,
        Load,
        Quit
    }
}
