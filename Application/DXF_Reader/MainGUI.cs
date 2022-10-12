using System;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Collections.Generic;
using netDxf;
using netDxf.Blocks;
using netDxf.Collections;
using netDxf.Entities;
using GTE = netDxf.GTE;
using netDxf.Header;
using netDxf.Objects;
using netDxf.Tables;
using netDxf.Units;
using Attribute = netDxf.Entities.Attribute;
using FontStyle = netDxf.Tables.FontStyle;
using Image = netDxf.Entities.Image;
using Point = netDxf.Entities.Point;
using Trace = netDxf.Entities.Trace;
using Vector2 = netDxf.Vector2;
using Vector3 = netDxf.Vector3;

namespace DXF_Reader
{
    public partial class MainGUI : Form
    {

        public string inputFileTxt;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Canvas newCanvas;
        private Via_TH newTH;
        public List<string> layerNames;
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
        
        private void boxLayers_Click(object sender, EventArgs e)
        {

        }

        private void button_TH_Click(object sender, EventArgs e)
        {
            newTH = new Via_TH(FCADImage);
            newTH.MdiParent = this;
            newTH.inputFileName = inputFileTxt;
            openChildForm(newTH);                        //the canvas is displayed...
            newTH.Activate();
            newTH.Focus();
        }
    }
}
