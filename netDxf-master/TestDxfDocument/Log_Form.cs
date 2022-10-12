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

namespace TestDxfDocument
{
    public partial class Log_Form : Form
    {
        List<string> layerNames = new List<string>();
        DxfDocument dxf;
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
            if(text_Output_Name.Text.Length >3)
                ParseLayer(dxf, text_Output_Name.Text);
            else
            {
                MessageBox.Show( "Output Name must have more than 3 characters!");
            }
        }

        public void ParseLayer(DxfDocument dxf, string outName)
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
                    foreach (DxfObject obj in entities)
                    {
                        dxf.Entities.Remove(obj as EntityObject);
                        box_debug.Text += ("{0} Files deleted", xitems);
                        xitems++;
                    }
                    ok = dxf.Layers.Remove(o.Name);
                }
            }
            dxf.Layers.Clear();
            dxf.Linetypes.Clear();
            dxf.Save(outName + ".dxf");
        }

        private void list_layers_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedItem= list_layers .SelectedItem.ToString();
            box_debug.Text += "Layer : "+ selectedItem+ " is saved!";
        }

        private void box_debug_TextChanged(object sender, EventArgs e)
        {
            box_debug.Text = box_debug.Text + "\n";
        }
    }
}
