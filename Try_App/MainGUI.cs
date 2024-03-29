﻿using System;
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
        private Via_TH newTH;
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
            OpenFileDialog dlg =new OpenFileDialog();
            dlg.Filter = "DXF files (*.dxf)|*.dxf";
            if (dlg.ShowDialog(this) == DialogResult.OK) ;
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

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

        private void Menu_TH_Click(object sender, EventArgs e)
        {
            newTH = new Via_TH();
            newTH.MdiParent = this;
            openChildForm(newTH);
            newTH.Activate();
            newTH.Focus();
        }
    }
}
