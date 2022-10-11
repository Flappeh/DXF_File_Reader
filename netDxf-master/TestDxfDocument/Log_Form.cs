using netDxf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestDxfDocument
{
    public partial class Log_Form : Form
    {
        public Log_Form()
        {
            InitializeComponent();
        }

        DxfDocument doc = Program.Test(@"sample.dxf");
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
