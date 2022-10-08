﻿namespace DXF_Reader
{
    partial class MainGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGUI));
            this.Menu_Strip = new System.Windows.Forms.ToolStrip();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.Menu_New = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boxLayers = new System.Windows.Forms.ToolStripComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.button_TH = new System.Windows.Forms.ToolStripButton();
            this.Menu_Strip.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu_Strip
            // 
            this.Menu_Strip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Menu_Strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1,
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.button_TH,
            this.boxLayers});
            this.Menu_Strip.Location = new System.Drawing.Point(0, 0);
            this.Menu_Strip.Name = "Menu_Strip";
            this.Menu_Strip.Size = new System.Drawing.Size(914, 28);
            this.Menu_Strip.TabIndex = 0;
            this.Menu_Strip.Text = "toolStrip1";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_New,
            this.Menu_Open,
            this.Menu_Save});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(46, 25);
            this.toolStripComboBox1.Text = "File";
            // 
            // Menu_New
            // 
            this.Menu_New.Name = "Menu_New";
            this.Menu_New.Size = new System.Drawing.Size(224, 26);
            this.Menu_New.Text = "New";
            // 
            // Menu_Open
            // 
            this.Menu_Open.Name = "Menu_Open";
            this.Menu_Open.Size = new System.Drawing.Size(224, 26);
            this.Menu_Open.Text = "Open";
            this.Menu_Open.Click += new System.EventHandler(this.Menu_Open_Click);
            // 
            // Menu_Save
            // 
            this.Menu_Save.Name = "Menu_Save";
            this.Menu_Save.Size = new System.Drawing.Size(224, 26);
            this.Menu_Save.Text = "Save";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomInToolStripMenuItem,
            this.zoomOutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(49, 25);
            this.toolStripDropDownButton1.Text = "Edit";
            // 
            // zoomInToolStripMenuItem
            // 
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            this.zoomInToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.zoomInToolStripMenuItem.Text = "Zoom In +";
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            this.zoomOutToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.zoomOutToolStripMenuItem.Text = "Zoom Out -";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.cutToolStripMenuItem.Text = "Cut";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(55, 25);
            this.toolStripDropDownButton2.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // boxLayers
            // 
            this.boxLayers.Name = "boxLayers";
            this.boxLayers.Size = new System.Drawing.Size(138, 28);
            this.boxLayers.Click += new System.EventHandler(this.boxLayers_Click);
            // 
            // panelChildForm
            // 
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.Location = new System.Drawing.Point(0, 28);
            this.panelChildForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(914, 572);
            this.panelChildForm.TabIndex = 2;
            this.panelChildForm.Paint += new System.Windows.Forms.PaintEventHandler(this.panelChildForm_Paint);
            // 
            // button_TH
            // 
            this.button_TH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.button_TH.Image = ((System.Drawing.Image)(resources.GetObject("button_TH.Image")));
            this.button_TH.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button_TH.Name = "button_TH";
            this.button_TH.Size = new System.Drawing.Size(104, 25);
            this.button_TH.Text = "Through Hole";
            this.button_TH.Click += new System.EventHandler(this.button_TH_Click);
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.Menu_Strip);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainGUI";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Menu_Strip.ResumeLayout(false);
            this.Menu_Strip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip Menu_Strip;
        private System.Windows.Forms.ToolStripDropDownButton toolStripComboBox1;
        private System.Windows.Forms.ToolStripMenuItem Menu_New;
        private System.Windows.Forms.ToolStripMenuItem Menu_Open;
        private System.Windows.Forms.ToolStripMenuItem Menu_Save;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem zoomInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Panel panelChildForm;
        public System.Windows.Forms.ToolStripComboBox boxLayers;
        private System.Windows.Forms.ToolStripButton button_TH;
    }
}