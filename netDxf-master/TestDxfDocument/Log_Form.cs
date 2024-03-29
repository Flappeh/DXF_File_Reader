﻿using netDxf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
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
using System.Text.RegularExpressions;
using System.Net.Security;
using System.Numerics;
using System.Configuration;

namespace TestDxfDocument
{
    public partial class Log_Form : Form
    {
        double cSize, cHoleGap, cTopBotGap;
        List<string> layerNames = new List<string>();
        List<Polyline2D> tbPols = new List<Polyline2D> ();
        //List<DxfObject> TOP_Entities = new List<DxfObject>();
        //List<DxfObject> BOT_Entities = new List<DxfObject>();
        List<Circle> tbCircs = new List<Circle>();
        List<Vector2> cirCoords = new List<Vector2>();
        List<Circle> topCircle = new List<Circle>();
        List<Circle> botCircle = new List<Circle>();
        List<Vector2> tb_Vectors = new List<Vector2>();
        List<Vector2> top_Vectors = new List<Vector2>();
        List<Vector2> bot_Vectors = new List<Vector2>();
        List<double> xCoordsTH = new List<double>();
        List<double> yCoordsTH = new List<double>();
        public DxfDocument dxf;
        Stopwatch watch = new Stopwatch();
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
                watch.Start();
                ParseLayer(dxf);
                parseTOPBOT(dxf);
                GenerateCircles(dxf, text_Output_Name.Text);
                watch.Stop();
                box_debug.Text += "\tloading time: " + (watch.ElapsedMilliseconds / 1000.0)+" seconds" ;
            }
        }
        public void parseTOPBOT(DxfDocument doc)
        {

            tbPols = new List<Polyline2D>(doc.Entities.Polylines2D);
            tbCircs = new List<Circle>(doc.Entities.Circles);
            foreach (List<Polyline2D> list in Split(tbPols, 6))
            {
                foreach (Polyline2D i in list)
                {
                    tb_Vectors.Add(i.Vertexes[0].Position);
                    tb_Vectors.Add(i.Vertexes[1].Position);
                    tbPols.Add(i);
                    //top_Vectors.Add(i.Vertexes[0].Position);
                    //top_Vectors.Add(i.Vertexes[1].Position);
                    //bot_Vectors.Add(i.Vertexes[0].Position);
                    //bot_Vectors.Add(i.Vertexes[1].Position);
                }
            }
            tbPols = new List<Polyline2D>(tbPols.Distinct());
            foreach (List<Circle> list in Split(tbCircs, 6))
            {
                foreach (Circle i in list)
                {
                    tbCircs.Add(i);
                    tb_Vectors.Add(new Vector2(i.Center.X, i.Center.Y));
                }
            }
            List<Circle> a = new List<Circle>();
            List<Vector2> b = new List<Vector2>();
            a = tbCircs.Distinct().ToList();
            b = tb_Vectors.Distinct().ToList();
            tbCircs.Clear();
            tb_Vectors.Clear();
            tbCircs = a;
            tb_Vectors = b;
            //TOP_Entities = doc.Layers.GetReferences("PIN_TOP");
            //BOT_Entities = doc.Layers.GetReferences("PIN_BOTTOM");

            //foreach (DxfObject i in TOP_Entities)
            //{
            //    if (i.GetType() == typeof(Polyline2D))
            //    {
            //        Polyline2D polyline = (Polyline2D)i;
            //        top_Vectors.Add(polyline.Vertexes[0].Position);
            //        top_Vectors.Add(polyline.Vertexes[1].Position);
            //    }
            //    else if (i.GetType() == typeof(Circle))
            //    {
            //        Circle circle = (Circle)i;
            //        topCircle.Add(circle);
            //        top_Vectors.Add(new Vector2(circle.Center.X, circle.Center.Y));
            //    }
            //}
            //foreach (DxfObject i in BOT_Entities)
            //{
            //    if (i.GetType() == typeof(Polyline2D))
            //    {
            //        Polyline2D polyline = (Polyline2D)i;
            //        bot_Vectors.Add(polyline.Vertexes[0].Position);
            //        bot_Vectors.Add(polyline.Vertexes[1].Position);
            //    }
            //    else if (i.GetType() == typeof(Circle))
            //    {
            //        Circle circle = (Circle)i;
            //        botCircle.Add(circle);
            //        bot_Vectors.Add(new Vector2(circle.Center.X, circle.Center.Y));
            //    }
            //}
            //TOP_Entities.Clear();
            //BOT_Entities.Clear();
        }
        private void GenerateCircles(DxfDocument doc, string outName)
        {

            List<Vector2> outerCoords = new List<Vector2>();
            List<double> xCircles = new List<double>();
            List<double> yCircles = new List<double>();
            List<DxfObject> bg_outline_Entities = doc.Layers.GetReferences(selectedItem);

            Layer thLayer = doc.Layers.Add(new Layer("TH"));

            cSize = Convert.ToDouble(text_Hole_Size.Text);
            cHoleGap = Convert.ToDouble(text_Gap_Hole.Text);
            cTopBotGap = Convert.ToDouble(text_Gap_TopBot.Text);

            foreach (Polyline2D poly in bg_outline_Entities)
            {
                foreach (var i in poly.Vertexes)
                {
                    outerCoords.Add(i.Position);
                    xCoordsTH.Add(i.Position.X);
                    yCoordsTH.Add(i.Position.Y);
                }
            }
            bg_outline_Entities.Clear();
            for (double i = xCoordsTH.Min() + cHoleGap; i < xCoordsTH.Max() - cHoleGap; i += cHoleGap)
            {
                xCircles.Add(i);
            }
            for (double i = yCoordsTH.Min() + cHoleGap; i < yCoordsTH.Max() - cHoleGap; i += cHoleGap)
            {
                yCircles.Add(i);
            }
            foreach (List<double> list in Split(xCircles, 6))
            {
                foreach(double i in list)
                {
                    foreach(double j in yCircles)
                    {
                        Vector2 cVec = new Vector2(i, j);
                        if (!cirCoords.Contains(cVec))
                        {
                            cirCoords.Add(cVec);
                        }
                    }

                }
            }
            xCircles.Clear();
            yCircles.Clear();
            List<Vector2> a = new List<Vector2>();
            a = cirCoords.Distinct().ToList();
            cirCoords.Clear();
            cirCoords = a;
            //Thread c = new Thread(() => remWithCircs(topCircle));
            //a.Start(); 
            List<Thread> tVecs = new List<Thread>();
            int splits = 6;
            int vecsSize = tb_Vectors.Count();
            while (splits <= 14)
            {
                if (vecsSize % splits == 0)
                {
                    break;
                }
                else
                {
                    splits++;
                }
                if(splits == 14)
                {
                    splits = 6;
                    tb_Vectors.RemoveAt(tb_Vectors.Count()-1);
                    vecsSize = tb_Vectors.Count();
                }
            }
            List<List<Vector2>> lvecs = new List<List<Vector2>>();
            foreach(List<Vector2> vecs in Split(tb_Vectors, vecsSize/splits))
            {
                lvecs.Add(vecs);
            }
            int k = 0;
            while (k < lvecs.Count()-1)
            {
                if (k == lvecs.Count)
                {
                    k =- 1;
                }
                tVecs.Add(new Thread(() => remWithVecs(lvecs[k])));
                tVecs[k].Start();
                k++;

            }


            for(int i = 0; i < tVecs.Count(); i++)
            {
                tVecs[i].Join();
            }
            tVecs.Clear();
            List<List<Circle>> listCircs = Split(tbCircs, 4);
            for (int i = 0; i < listCircs.Count()-1; i++)
            {
                tVecs.Add(new Thread(() => remWithCircs(listCircs[i])));
                tVecs[i].Start();
            }
            for (int i = 0; i < tVecs.Count(); i++)
            {
                tVecs[i].Join();
            }
            foreach (Circle j in listCircs[listCircs.Count() - 1])
            {
                for (int i = 0; i < cirCoords.Count(); i++)
                {
                    if (checkCircle(new Vector2(j.Center.X, j.Center.Y), cirCoords[i], j.Radius, cSize))
                    {
                        cirCoords.Remove(cirCoords[i]);
                    }

                }
            }
            //c.Join();
            topCircle.Clear();
            botCircle.Clear();
            foreach (List<Vector2> list in Split(cirCoords, 8))
            {
                foreach (Vector2 cPoint in list)
                {
                    for (int u = 0; u < outerCoords.Count(); u++)
                    {
                        double distLine = Math.Abs(Vector2.Distance(outerCoords[u], new Vector2(0, 0)));
                        double distCir = Math.Abs(Vector2.Distance(cPoint, new Vector2(0, 0)));
                        if (distCir + cHoleGap < distLine)
                        {
                            if (outerCoords[u].X < 0 && outerCoords[u].Y < 0 && (cPoint.X <= 0 && cPoint.Y <= 0))
                            {
                                //q3
                                Circle circle = new Circle(cPoint, cSize);
                                circle.Layer = thLayer;
                                doc.Entities.Add(circle);
                            }
                            if ((cPoint.X <= 0 && cPoint.Y >= 0) && (outerCoords[u].X < 0 && outerCoords[u].Y > 0))
                            {
                                //q2
                                Circle circle = new Circle(cPoint, cSize);
                                circle.Layer = thLayer;
                                doc.Entities.Add(circle);
                            }
                            if ((cPoint.X >= 0 && cPoint.Y >= 0) && outerCoords[u].X > 0 && outerCoords[u].Y > 0)
                            {
                                //q1
                                Circle circle = new Circle(cPoint, cSize);
                                circle.Layer = thLayer;
                                doc.Entities.Add(circle);

                            }
                            if ((cPoint.X >= 0 && cPoint.Y <= 0) && outerCoords[u].X > 0 && outerCoords[u].Y < 0)
                            {

                                Circle circle = new Circle(cPoint, cSize);
                                circle.Layer = thLayer;
                                doc.Entities.Add(circle);

                            }
                        }

                    }
                }
            }
            doc.Save(outName + ".dxf");
            box_debug.Text += "Done creating DXF!";

            //foreach (List<Circle> list in Split(topCircle, 6))
            //{
            //    foreach (Circle i in list)
            //    {
            //        for (int u = 0; u < cirCoords.Count(); u++)
            //        {
            //            if (checkCircle(new Vector2(i.Center.X, i.Center.Y), cirCoords[u], cSize, i.Radius))
            //            {
            //                cirCoords.Remove(cirCoords[u]);
            //            }
            //        }
            //    }
            //}
            //foreach (List<Circle> list in Split(botCircle, 6))
            //{
            //    foreach (Circle i in list)
            //    {
            //        for (int u = 0; u < cirCoords.Count(); u++)
            //        {
            //            if (checkCircle(new Vector2(i.Center.X, i.Center.Y), cirCoords[u], cSize, i.Radius))
            //            {
            //                cirCoords.Remove(cirCoords[u]);
            //            }
            //        }
            //    }
            //}

        }
        public void addCircs(List<double> a, List<double> b)
        {
            for(int i = 0; i < a.Count(); i++)
            {
                for(int j = 0; j < b.Count(); j++)
                {
                    Vector2 x = new Vector2(i, j);
                    if(!cirCoords.Contains(x))
                    {
                        cirCoords.Add(x);
                    }
                }
            }
        }
        public void remWithCircs(List<Circle> circs)
        {
            foreach(List<Circle> list in Split(circs, 9))
            {
                foreach(Circle j in list)
                {
                    int jml = cirCoords.Count();
                    int i = 0;
                    while (i < cirCoords.Count())
                    {
                        if (i > cirCoords.Count())
                        {
                            i = cirCoords.Count()-15;
                        }
                        if (checkCircle(new Vector2(j.Center.X, j.Center.Y), cirCoords[i], j.Radius, cSize))
                        {
                            cirCoords.Remove(cirCoords[i]);
                        }
                        i++;
                    }
                }
            }
        }
        public void remWithVecs(List<Vector2> vec)
        {
            foreach (List<Vector2> list in Split(vec, 9))
            {
                foreach (Vector2 tops in list)
                {
                    int jml = cirCoords.Count();
                    int u = 0;
                    while (u < cirCoords.Count())
                    {
                        if (u >cirCoords.Count())
                        {
                            u = cirCoords.Count() - 15;
                        }
                        double TDistance = Vector2.Distance(tops, cirCoords[u]);
                        if (TDistance <= cTopBotGap + cSize)
                        {
                            cirCoords.Remove(cirCoords[u]);
                        }
                        u++;
                    }
                }
            }
        }
        public static List<List<T>> Split<T>(IList<T> source,int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void text_Gap_TopBot_TextChanged(object sender, EventArgs e)
        {

        }
        public bool checkCircle(Vector2 c1, Vector2 c2, double r1, double r2)
        {
            int distSq = (int)Math.Sqrt(((c1.X - c2.X)
                            * (c1.X - c2.X))
                            + ((c1.Y - c2.Y)
                                * (c1.Y - c2.Y)));

        return ((distSq + r2 == r1) || (distSq + r2 < r1));

        }
        public static bool checkOverlap(double rad, Vector3 circle, Vector2 poly1, Vector2 poly2)
        {
            double m = (poly2.Y - poly1.Y) / (poly2.X - poly1.X);
            double dist = (Math.Abs((poly1.Y - poly2.Y) * circle.X + (poly2.X - poly1.X) * circle.Y + m) / Math.Sqrt((poly1.Y - poly2.Y) * (poly1.Y - poly2.Y) + (poly2.X - poly1.X) * (poly2.X - poly1.X)));

            return dist <= rad;
        }
        public void ParseLayer(DxfDocument dxf)
        {
            layerNames.Remove(selectedItem);
            layerNames.Remove("0");
            layerNames.Remove("PIN_TOP");
            layerNames.Remove("PIN_BOTTOM");
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
            if(selectedItem != null)
            {
                selectedItem = String.Empty;
            }
            selectedItem = list_layers.SelectedItem.ToString();
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
