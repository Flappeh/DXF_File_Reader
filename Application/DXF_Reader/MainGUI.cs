using System;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Collections.Generic;

namespace DXF_Reader
{
    public partial class MainGUI : Form
    {

        public string inputFileTxt;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Canvas newCanvas;
        public List<string> layerNames;
        public delegate void LayerUpdateEventHandler(object source, EventArgs e);
        public event LayerUpdateEventHandler LayerUpdate;
        protected virtual void OnLayerUpdate()
        {
            if(LayerUpdate != null)
            {
                LayerUpdate(this, EventArgs.Empty);
            }
        }
        public MainGUI()
        {
            InitializeComponent();
        }
        private void Main_Load(object sender, EventArgs e)
        {

        }

        protected CADImage FCADImage;// = new CADImage();
        private void Menu_Open_Click(object sender, EventArgs e) //Open a file
        {
            inputFileTxt = "";

            openFileDialog1.Filter = "dxf files (*.dxf)|*.dxf|All files (*.*)|*.*"; //filters the visible files...

            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)       //open file dialog is shown here...if "cancel" button is clicked then nothing will be done...
            {
                inputFileTxt = openFileDialog1.FileName;    //filename is taken (file path is also included to this name example: c:\windows\system\blabla.dxf

                int ino = inputFileTxt.LastIndexOf("\\");   //index no of the last "\" (that is before the filename) is found here


                newCanvas = new Canvas();           //a new canvas is created...

                newCanvas.MdiParent = this;         //...its mdiparent is set...

                newCanvas.Text = inputFileTxt.Substring(ino + 1, inputFileTxt.Length - ino - 1);  //...filename is extracted from the text...(blabla.dxf)...
                newCanvas.MinimumSize = new Size(500, 400);     //...canvas minimum size is set...

                if (inputFileTxt.Length > 0)
                {
                    FCADImage = new CADImage();
                    FCADImage.Base.X = Bottom - 100;
                    FCADImage.Base.Y = 100;
                    FCADImage.LoadFromFile(inputFileTxt);
                    newCanvas.NCAD_IMG = FCADImage;
                }



                openChildForm(newCanvas);                        //the canvas is displayed...
                newCanvas.Activate();
                newCanvas.Focus();

            }

            openFileDialog1.Dispose();
        }
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void panelChildForm_Paint(object sender, PaintEventArgs e)
        {

        }
        public void writeNames(string i)
        {
            boxLayers.Items.Add(i);
        }
        private void boxLayers_Click(object sender, EventArgs e)
        {

        }
    }
}
