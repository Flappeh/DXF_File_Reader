using netDxf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
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
using System.Windows.Forms;
using System.Runtime.Versioning;
using System.Windows.Forms.Design;
using System.Drawing.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Reflection.Emit;

namespace TestDxfDocument
{
    public partial class Log_Form : Form
    {
        Vector2 cMin, cMax;
        double cCenter, cSize, cHoleGap, cTopBotGap;
        List<string> layerNames = new List<string>();
        public DxfDocument dxf;
        public Log_Form()
        {
            InitializeComponent();
        }
        string fName,selectedItem = "";
        OpenFileDialog ofName = new OpenFileDialog();

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Log_Form_Load(object sender, EventArgs e)
        {
           
        }

        private void button_inputFile_Click(object sender, EventArgs e)
        {
            ofName.Filter = "dxf files (*.dxf)|*.dxf|All files (*.*)|*.*";
            ofName.FilterIndex = 1;
            if (ofName.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fName = ofName.FileName;
                label_Open_File.Text = fName;
            }
            dxf = DxfDocument.Load(fName, new List<string> { @".\Support" });
            box_debug.Text += "Loaded " + fName;
            int lNums = 0;
            foreach (var o in dxf.Layers)
            {
                box_debug.Text += lNums + ". "+ o.Name+ " References count: "+ dxf.Layers.GetReferences(o).Count;
                Debug.Assert(ReferenceEquals(o.Linetype, dxf.Linetypes[o.Linetype.Name]), "Object reference not equal.");
                layerNames.Add(o.Name);
                list_layers.Items.Add(o.Name);
                lNums++;
            }
            box_debug.Text += ("Select Which Layer to save! \n");
        }

        private void button_Generate_Click(object sender, EventArgs e)
        {
            if (text_Output_Name.Text.Length < 3)
                MessageBox.Show("Output Name must have more than 3 characters!");
            else if (dxf == null)
                MessageBox.Show("No present dxf file");
            else
            {
                ParseLayer(dxf);
                GenerateCircles(dxf, text_Output_Name.Text);
            }
        }
        private void GenerateCircles(DxfDocument doc, string outName)
        {
            List<Vector2> outerCoords = new List<Vector2>();
            List<Vector2> cirCoords = new List<Vector2>();
            List<double> xCoords = new List<double>();
            List<double> yCoords = new List<double>();
            List<double> xCircles = new List<double>();
            List<double> yCircles = new List<double>();
            List<DxfObject> entities = doc.Layers.GetReferences(selectedItem);
            Layer layer = doc.Layers[selectedItem];
            cSize = Convert.ToDouble(text_Hole_Size.Text);
            cHoleGap = Convert.ToDouble(text_Gap_Hole.Text);
            foreach (Polyline2D poly in entities)
            {
                foreach (var i in poly.Vertexes)
                {
                    box_debug.Text += ("x" + i.Position.X.ToString(), "y" + i.Position.Y.ToString());
                    outerCoords.Add(i.Position);
                    xCoords.Add(i.Position.X);
                    yCoords.Add(i.Position.Y);
                }
            }
            for (double i = xCoords.Min() + cHoleGap; i < xCoords.Max() - cHoleGap; i += cHoleGap)
            {
                xCircles.Add(i);
            }
            for (double i = yCoords.Min() + cHoleGap; i < yCoords.Max() - cHoleGap; i += cHoleGap)
            {
                yCircles.Add(i);
            }
            for(int i=0; i<xCircles.Count; i++)
            {
                for (int j = 0; j < yCircles.Count; j++)
                {

                    cirCoords.Add(new Vector2(xCircles[i], yCircles[j]));
                }
            }
            foreach(List<Vector2> list in Split(cirCoords, 8))
            {
                foreach (Vector2 cPoint in list)
                {
                    for (int u = 0; u < outerCoords.Count(); u++)
                    {
                        double distLine = Vector2.Distance(outerCoords[u], new Vector2(0, 0));
                        double distCir = Vector2.Distance(cPoint, new Vector2(0, 0));
                        if (distCir + cHoleGap < distLine)
                        {
                            if (outerCoords[u].X < 0 && outerCoords[u].Y < 0 && (cPoint.X <= 0 && cPoint.Y <= 0))
                            {
                                //q3
                                Circle circle = new Circle(cPoint, cSize);
                                circle.Layer = layer;
                                doc.Entities.Add(circle);
                            }
                            if ((cPoint.X <= 0 && cPoint.Y >= 0) && (outerCoords[u].X < 0 && outerCoords[u].Y > 0))
                            {
                                //q2
                                Circle circle = new Circle(cPoint, cSize);
                                circle.Layer = layer;
                                doc.Entities.Add(circle);
                            }
                            if ((cPoint.X >= 0 && cPoint.Y >= 0) && outerCoords[u].X > 0 && outerCoords[u].Y > 0)
                            {
                                //q1
                                Circle circle = new Circle(cPoint, cSize);
                                circle.Layer = layer;
                                doc.Entities.Add(circle);

                            }
                            if ((cPoint.X >= 0 && cPoint.Y <= 0) && outerCoords[u].X > 0 && outerCoords[u].Y < 0)
                            {

                                Circle circle = new Circle(cPoint, cSize);
                                circle.Layer = layer;
                                doc.Entities.Add(circle);

                            }
                        }

                    }
                }

                
            }
                
            //List<Circle> cir = new List<Circle>(doc.Entities.Circles);
            //doc.Save(outName + ".dxf");
            //DxfDocument docs = DxfDocument.Load(outName + ".dxf", new List<string> { @".\Support" });
            //foreach (Polyline2D poly in entities)
            //{
            //    for (int i = 0; i < cir.Count(); i++)
            //    { 
            //        if (!checkOverlap(cSize, cir[i].Center, poly.Vertexes[0].Position, poly.Vertexes[1].Position))
            //        {
            //            docs.Entities.Remove(cir);
            //        }
            //    }
            //}
            doc.Save(outName + ".dxf");
            box_debug.Text += "Done creating DXF!";
        }
        public static List<List<T>> Split<T>(IList<T> source,int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
        private void CreateCircles()
        {

        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        public static bool checkOverlap(double rad, Vector3 circle, Vector2 poly1, Vector2 poly2)
        {
            double m = (poly2.Y - poly1.Y) / (poly2.X - poly1.X);
            double dist = (Math.Abs((poly1.Y - poly2.Y) * circle.X + (poly2.X - poly1.X) * circle.Y + m) / Math.Sqrt((poly1.Y - poly2.Y) * (poly1.Y - poly2.Y) + (poly2.X - poly1.X) * (poly2.X - poly1.X)));
            //Vector2 nearest = new Vector2((Math.Max(poly1.X, Math.Min(rad, poly2.X))), (Math.Max(poly1.Y, Math.Min(rad, poly2.Y))));
            //double Dx = nearest.X - circle.X;
            //double Dy = nearest.Y - circle.Y;
            //return (Dx * Dx + Dy * Dy) * 2 <= rad * rad;
            return dist >= rad;
        }
        public void ParseLayer(DxfDocument dxf)
        {
            layerNames.Remove(selectedItem);
            layerNames.Remove("0");
            bool ok;
            foreach (var o in dxf.Blocks)
            {
                if (layerNames.Contains(o.Layer.Name))
                {
                    List<DxfObject> dxfObjects;
                    dxfObjects = dxf.Blocks.GetReferences(o.Name);
                    box_debug.Text += ("Deleting Blocks : {0}", o.Name);
                    int xitems = 0;
                    foreach (DxfObject obj in dxfObjects)
                    {
                        dxf.Entities.Remove(obj as EntityObject);
                        box_debug.Text += ("{0} Files deleted", xitems);
                        xitems++;
                    }
                    ok = dxf.Blocks.Remove(o.Name);
                }
            }
            foreach (var o in dxf.Layers)
            {
                if (layerNames.Contains(o.Name))
                {
                    ok = dxf.Layers.Remove(o.Name);
                    box_debug.Text += ("Deleting Layer : {0}", o.Name);
                    List<DxfObject> entities = dxf.Layers.GetReferences(o.Name);
                    int xitems = 0;
                    foreach(DxfObject obj in entities)
                    {
                        dxf.Entities.Remove(obj as EntityObject);
                        box_debug.Text += xitems + " Files deleted";
                        xitems++;
                    }                    
                    ok = dxf.Layers.Remove(o.Name);
                }
            }
            dxf.Layers.Clear();
            dxf.Linetypes.Clear();
        }
        private void list_layers_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedItem= list_layers.SelectedItem.ToString();
            box_debug.Text += "Layer : "+ selectedItem+ " is saved!";
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            dxf = new DxfDocument();
            list_layers.Items.Clear();
            list_layers.Text = "";
            text_Gap_Hole.Clear();
            text_Gap_TopBot.Clear();
            text_Hole_Size.Clear();
            text_Output_Name.Clear();
        }

        private void box_debug_TextChanged(object sender, EventArgs e)
        {
            box_debug.Text += '\n';
            box_debug.SelectionStart = box_debug.Text.Length;
            box_debug.ScrollToCaret();
        }
    }
}
