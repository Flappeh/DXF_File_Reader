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
            PolygonMesh();
        }
        public static void PolygonMesh()
        {
            short u = 4;
            short v = 4;

            //Vector3[] controls =
            //{
            //    new Vector3(0, 0, 0),
            //    new Vector3(10, 0, 10),
            //    new Vector3(20, 0, 10),
            //    new Vector3(30, 0, 0),

            //    new Vector3(0, 10, 0),
            //    new Vector3(10, 10, 10),
            //    new Vector3(20, 10, 10),
            //    new Vector3(30, 10, 0),

            //    new Vector3(0, 20, 0),
            //    new Vector3(10, 20, 10),
            //    new Vector3(20, 20, 10),
            //    new Vector3(30, 20, 0),

            //    new Vector3(0, 30, 0),
            //    new Vector3(10, 30, 10),
            //    new Vector3(20, 30, 10),
            //    new Vector3(30, 30, 0),
            //};

            //Vector3[] controls =
            //{
            //    new Vector3(0, 0, 0),
            //    new Vector3(10, 0, 0),
            //    new Vector3(20, 0, 0),
            //    new Vector3(30, 0, 0),

            //    new Vector3(0, 10, 10),
            //    new Vector3(10, 10, 10),
            //    new Vector3(20, 10, 10),
            //    new Vector3(30, 10, 10),

            //    new Vector3(0, 20, 10),
            //    new Vector3(10, 20, 10),
            //    new Vector3(20, 20, 10),
            //    new Vector3(30, 20, 10),

            //    new Vector3(0, 30, 0),
            //    new Vector3(10, 30, 0),
            //    new Vector3(20, 30, 0),
            //    new Vector3(30, 30, 0),
            //};

            Vector3[] controls =
            {
                new Vector3(0, 0, 0),
                new Vector3(10, 0, 10),
                new Vector3(20, 0, 10),
                new Vector3(30, 0, 0),

                new Vector3(0, 10, 10),
                new Vector3(10, 10, 10),
                new Vector3(20, 10, 10),
                new Vector3(30, 10, 10),

                new Vector3(0, 20, 10),
                new Vector3(10, 20, 10),
                new Vector3(20, 20, 10),
                new Vector3(30, 20, 10),

                new Vector3(0, 30, 0),
                new Vector3(10, 30, 10),
                new Vector3(20, 30, 10),
                new Vector3(30, 30, 0),
            };

            //// number of vertexes along the mesh local X axis
            //short u = 6;
            //// number of vertexes along the mesh local Y axis
            //short v = 4;

            //// array of vertexes
            //Vector3[] vertexes = new Vector3[u * v];
            //// first row (local X axis)
            //vertexes[0] = new Vector3(0,0,0);
            //vertexes[1] = new Vector3(10,0,10);
            //vertexes[2] = new Vector3(20,0,0);
            //vertexes[3] = new Vector3(30,0,10);
            //vertexes[4] = new Vector3(40,0,0);
            //vertexes[5] = new Vector3(50,0,10);

            //// second row (local X axis)
            //vertexes[6] = new Vector3(0,10,10);
            //vertexes[7] = new Vector3(10,10,0);
            //vertexes[8] = new Vector3(20,10,10);
            //vertexes[9] = new Vector3(30,10,0);
            //vertexes[10] = new Vector3(40,10,10);
            //vertexes[11] = new Vector3(50,10,0);

            //// third row (local X axis)
            //vertexes[12] = new Vector3(0,20,0);
            //vertexes[13] = new Vector3(10,20,10);
            //vertexes[14] = new Vector3(20,20,0);
            //vertexes[15] = new Vector3(30,20,10);
            //vertexes[16] = new Vector3(40,20,0);
            //vertexes[17] = new Vector3(50,20,10);

            //// fourth row (local X axis)
            //vertexes[18] = new Vector3(0,30,10);
            //vertexes[19] = new Vector3(10,30,0);
            //vertexes[20] = new Vector3(20,30,10);
            //vertexes[21] = new Vector3(30,30,0);
            //vertexes[22] = new Vector3(40,30,10);
            //vertexes[23] = new Vector3(50,30,0);

            PolygonMesh pMesh = new PolygonMesh(u, v, controls)
            {
                Color = AciColor.Blue,
                DensityU = (short)(5 * u),
                DensityV = (short)(5 * v),
                IsClosedInU = true,
                IsClosedInV = true,
                SmoothType = PolylineSmoothType.Quadratic
            };

            // the Mesh entity doesn't have the restrictions the PolygonMesh has
            // you can create smoothed polygon meshes with higher densities that the ones allowed by the polygon mesh
            Mesh mesh = pMesh.ToMesh(60 * u, 60 * v);
            mesh.Color = AciColor.Red;

            DxfDocument doc = new DxfDocument();
            doc.Entities.Add(pMesh);
            doc.Entities.Add(mesh);
            doc.Save("test.dxf");
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
