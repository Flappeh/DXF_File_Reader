namespace Try_App
{
    partial class MainGUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGUI));
            this.MainMenuStrip = new System.Windows.Forms.ToolStrip();
            this.menuStrip_File = new System.Windows.Forms.ToolStripDropDownButton();
            this.MenuStrip_New = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.Menu_TH = new System.Windows.Forms.ToolStripButton();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.MainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStrip_File,
            this.toolStripComboBox1,
            this.Menu_TH});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(1008, 25);
            this.MainMenuStrip.TabIndex = 0;
            this.MainMenuStrip.Text = "toolStrip1";
            // 
            // menuStrip_File
            // 
            this.menuStrip_File.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuStrip_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStrip_New,
            this.MenuStrip_Open,
            this.MenuStrip_Save});
            this.menuStrip_File.Image = ((System.Drawing.Image)(resources.GetObject("menuStrip_File.Image")));
            this.menuStrip_File.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuStrip_File.Name = "menuStrip_File";
            this.menuStrip_File.Size = new System.Drawing.Size(38, 22);
            this.menuStrip_File.Text = "File";
            // 
            // MenuStrip_New
            // 
            this.MenuStrip_New.Name = "MenuStrip_New";
            this.MenuStrip_New.Size = new System.Drawing.Size(180, 22);
            this.MenuStrip_New.Text = "New";
            // 
            // MenuStrip_Open
            // 
            this.MenuStrip_Open.Name = "MenuStrip_Open";
            this.MenuStrip_Open.Size = new System.Drawing.Size(180, 22);
            this.MenuStrip_Open.Text = "Open";
            this.MenuStrip_Open.Click += new System.EventHandler(this.MenuStrip_Open_Click);
            // 
            // MenuStrip_Save
            // 
            this.MenuStrip_Save.Name = "MenuStrip_Save";
            this.MenuStrip_Save.Size = new System.Drawing.Size(180, 22);
            this.MenuStrip_Save.Text = "Save";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBox1.Click += new System.EventHandler(this.toolStripComboBox1_Click);
            // 
            // Menu_TH
            // 
            this.Menu_TH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Menu_TH.Image = ((System.Drawing.Image)(resources.GetObject("Menu_TH.Image")));
            this.Menu_TH.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Menu_TH.Name = "Menu_TH";
            this.Menu_TH.Size = new System.Drawing.Size(45, 22);
            this.Menu_TH.Text = "Via TH";
            this.Menu_TH.Click += new System.EventHandler(this.Menu_TH_Click);
            // 
            // panelChildForm
            // 
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.Location = new System.Drawing.Point(0, 25);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(1008, 536);
            this.panelChildForm.TabIndex = 2;
            this.panelChildForm.Paint += new System.Windows.Forms.PaintEventHandler(this.panelChildForm_Paint);
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.MainMenuStrip);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1024, 600);
            this.Name = "MainGUI";
            this.Text = "Form1";
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripDropDownButton menuStrip_File;
        private System.Windows.Forms.ToolStripMenuItem MenuStrip_New;
        private System.Windows.Forms.ToolStripMenuItem MenuStrip_Open;
        private System.Windows.Forms.ToolStripMenuItem MenuStrip_Save;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripButton Menu_TH;
        private System.Windows.Forms.Panel panelChildForm;
    }
}
