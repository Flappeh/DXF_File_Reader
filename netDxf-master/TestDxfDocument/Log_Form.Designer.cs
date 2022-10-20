namespace TestDxfDocument
{
    partial class Log_Form
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
            this.label5 = new System.Windows.Forms.Label();
            this.label_Open_File = new System.Windows.Forms.Label();
            this.Group_Input = new System.Windows.Forms.GroupBox();
            this.button_inputFile = new System.Windows.Forms.Button();
            this.list_layers = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button_Generate = new System.Windows.Forms.Button();
            this.button_Clear = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.text_Output_Name = new System.Windows.Forms.TextBox();
            this.text_Gap_TopBot = new System.Windows.Forms.TextBox();
            this.text_Hole_Size = new System.Windows.Forms.TextBox();
            this.text_Gap_Hole = new System.Windows.Forms.TextBox();
            this.box_debug = new System.Windows.Forms.RichTextBox();
            this.Group_Input.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(384, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 25);
            this.label5.TabIndex = 16;
            this.label5.Text = "Source File :";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label_Open_File
            // 
            this.label_Open_File.AutoSize = true;
            this.label_Open_File.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_Open_File.Location = new System.Drawing.Point(507, 24);
            this.label_Open_File.Name = "label_Open_File";
            this.label_Open_File.Size = new System.Drawing.Size(96, 25);
            this.label_Open_File.TabIndex = 15;
            this.label_Open_File.Text = "File Name";
            // 
            // Group_Input
            // 
            this.Group_Input.Controls.Add(this.button_inputFile);
            this.Group_Input.Controls.Add(this.list_layers);
            this.Group_Input.Controls.Add(this.label6);
            this.Group_Input.Controls.Add(this.label8);
            this.Group_Input.Location = new System.Drawing.Point(12, 24);
            this.Group_Input.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Group_Input.Name = "Group_Input";
            this.Group_Input.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Group_Input.Size = new System.Drawing.Size(333, 103);
            this.Group_Input.TabIndex = 14;
            this.Group_Input.TabStop = false;
            this.Group_Input.Text = "Input Details :";
            // 
            // button_inputFile
            // 
            this.button_inputFile.Location = new System.Drawing.Point(178, 33);
            this.button_inputFile.Name = "button_inputFile";
            this.button_inputFile.Size = new System.Drawing.Size(134, 23);
            this.button_inputFile.TabIndex = 9;
            this.button_inputFile.Text = "Select File";
            this.button_inputFile.UseVisualStyleBackColor = true;
            this.button_inputFile.Click += new System.EventHandler(this.button_inputFile_Click);
            // 
            // list_layers
            // 
            this.list_layers.FormattingEnabled = true;
            this.list_layers.Location = new System.Drawing.Point(178, 62);
            this.list_layers.Name = "list_layers";
            this.list_layers.Size = new System.Drawing.Size(134, 23);
            this.list_layers.TabIndex = 8;
            this.list_layers.SelectedIndexChanged += new System.EventHandler(this.list_layers_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(16, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 21);
            this.label6.TabIndex = 6;
            this.label6.Text = "Source File             :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(14, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 21);
            this.label8.TabIndex = 1;
            this.label8.Text = "Outer Layer            :";
            // 
            // button_Generate
            // 
            this.button_Generate.BackColor = System.Drawing.Color.PaleGreen;
            this.button_Generate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Generate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Generate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_Generate.Location = new System.Drawing.Point(100, 385);
            this.button_Generate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Generate.Name = "button_Generate";
            this.button_Generate.Size = new System.Drawing.Size(144, 36);
            this.button_Generate.TabIndex = 13;
            this.button_Generate.Text = "Generate Output";
            this.button_Generate.UseVisualStyleBackColor = false;
            this.button_Generate.Click += new System.EventHandler(this.button_Generate_Click);
            // 
            // button_Clear
            // 
            this.button_Clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button_Clear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Clear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_Clear.Location = new System.Drawing.Point(100, 345);
            this.button_Clear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(144, 35);
            this.button_Clear.TabIndex = 12;
            this.button_Clear.Text = "Clear Input";
            this.button_Clear.UseVisualStyleBackColor = false;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.text_Output_Name);
            this.groupBox1.Controls.Add(this.text_Gap_TopBot);
            this.groupBox1.Controls.Add(this.text_Hole_Size);
            this.groupBox1.Controls.Add(this.text_Gap_Hole);
            this.groupBox1.Location = new System.Drawing.Point(12, 145);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(333, 150);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output Details :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(14, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "DXF Output Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(15, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "TOP.BOT Gap          :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(15, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Gap Between Hole : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(14, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hole Size                 :";
            // 
            // text_Output_Name
            // 
            this.text_Output_Name.Location = new System.Drawing.Point(178, 104);
            this.text_Output_Name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.text_Output_Name.Name = "text_Output_Name";
            this.text_Output_Name.Size = new System.Drawing.Size(134, 23);
            this.text_Output_Name.TabIndex = 4;
            // 
            // text_Gap_TopBot
            // 
            this.text_Gap_TopBot.Location = new System.Drawing.Point(178, 77);
            this.text_Gap_TopBot.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.text_Gap_TopBot.Name = "text_Gap_TopBot";
            this.text_Gap_TopBot.Size = new System.Drawing.Size(134, 23);
            this.text_Gap_TopBot.TabIndex = 2;
            this.text_Gap_TopBot.TextChanged += new System.EventHandler(this.text_Gap_TopBot_TextChanged);
            // 
            // text_Hole_Size
            // 
            this.text_Hole_Size.Location = new System.Drawing.Point(178, 23);
            this.text_Hole_Size.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.text_Hole_Size.Name = "text_Hole_Size";
            this.text_Hole_Size.Size = new System.Drawing.Size(134, 23);
            this.text_Hole_Size.TabIndex = 3;
            // 
            // text_Gap_Hole
            // 
            this.text_Gap_Hole.Location = new System.Drawing.Point(178, 50);
            this.text_Gap_Hole.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.text_Gap_Hole.Name = "text_Gap_Hole";
            this.text_Gap_Hole.Size = new System.Drawing.Size(134, 23);
            this.text_Gap_Hole.TabIndex = 1;
            // 
            // box_debug
            // 
            this.box_debug.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.box_debug.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.box_debug.HideSelection = false;
            this.box_debug.Location = new System.Drawing.Point(387, 57);
            this.box_debug.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.box_debug.Name = "box_debug";
            this.box_debug.ReadOnly = true;
            this.box_debug.Size = new System.Drawing.Size(521, 435);
            this.box_debug.TabIndex = 17;
            this.box_debug.Text = "";
            this.box_debug.WordWrap = false;
            this.box_debug.TextChanged += new System.EventHandler(this.box_debug_TextChanged);
            // 
            // Log_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 503);
            this.Controls.Add(this.box_debug);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label_Open_File);
            this.Controls.Add(this.Group_Input);
            this.Controls.Add(this.button_Generate);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(936, 542);
            this.Name = "Log_Form";
            this.Text = "Log_Form";
            this.Load += new System.EventHandler(this.Log_Form_Load);
            this.Group_Input.ResumeLayout(false);
            this.Group_Input.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_Open_File;
        private System.Windows.Forms.GroupBox Group_Input;
        private System.Windows.Forms.Button button_inputFile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_Generate;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_Output_Name;
        private System.Windows.Forms.TextBox text_Gap_TopBot;
        private System.Windows.Forms.TextBox text_Hole_Size;
        private System.Windows.Forms.TextBox text_Gap_Hole;
        private System.Windows.Forms.RichTextBox box_debug;
        public System.Windows.Forms.ComboBox list_layers;
    }
}