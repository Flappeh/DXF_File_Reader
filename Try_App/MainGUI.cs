using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Try_App
{
    public partial class MainGUI : Form
    {
        public string inputFileTxt;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        //private Canvas newCanvas;
        public MainGUI()
        {
            InitializeComponent();
        }
        private void onFileOpen(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "DXF files (*.dxf)|*.dxf";
        }

        private void MenuStrip_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "DXF files (*.dxf)|*.dxf";
            if (dlg.ShowDialog(this) == DialogResult.OK) ;
        }
    }
}
