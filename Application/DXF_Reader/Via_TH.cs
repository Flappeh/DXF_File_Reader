using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace DXF_Reader
{
    public partial class Via_TH : Form
    {

        public string inputFileName;
        string outputFileName;
        private System.Windows.Forms.OpenFileDialog openFileName;
        public CADImage getCAD;
        public Via_TH(CADImage i)
        {
            getCAD = i;
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Via_TH_Load(object sender, EventArgs e)
        {
            if(inputFileName != null)
            label_Open_File.Text = inputFileName;
        }

        private List<string> layernames = new List<string>();
        private void button_inputFile_Click(object sender, EventArgs e)
        {
            inputFileName = "";
            openFileName.Filter = "dxf files (*.dxf)|*.dxf|All files (*.*)|*.*";
            openFileName.FilterIndex = 1;
            if (openFileName.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                inputFileName = openFileName.FileName;
                int fileindex = inputFileName.LastIndexOf("\\");
                label_Open_File.Text = inputFileName.Substring(fileindex+1);
                if(inputFileName.Length > 0)
                {
                    getCAD = new CADImage();
                    getCAD.LoadFromFile(inputFileName);

                }
                foreach (string l in layernames)
                {
                    list_layers.Items.Add(l);
                }

            }
            openFileName.Dispose();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
