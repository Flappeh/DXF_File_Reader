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
            this.MainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStrip_File});
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
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 711);
            this.Controls.Add(this.MainMenuStrip);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1024, 750);
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
    }
}
