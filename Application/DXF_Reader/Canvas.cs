using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace DXF_Reader
{
    public partial class Canvas : Form
    {
        private int cX, cY;
        private bool det1 = false;

        public CADImage NCAD_IMG;
        private void Canvas_Load(object sender, EventArgs e)
        {
            NCAD_IMG.FScale = NCAD_IMG.FScale / 1;
            NCAD_IMG.Base.Y = this.Height/2;
            NCAD_IMG.Base.X = this.Width/4;
            Invalidate();
        }
        public Canvas()
        {

            InitializeComponent();

            //.Net Style Double Buffering/////////////////
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private void Canvas_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (NCAD_IMG == null)
                return;
            NCAD_IMG.Draw(e.Graphics);
        }

        #region Mouse Movement
        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                Canvas.ActiveForm.Cursor = Cursors.Hand; 
                cX = e.X;
                cY = e.Y;
                det1 = true;

            }
        }
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (det1)
            {
                while_move(sender,e);
            }
        }
        private void while_move(object sender, MouseEventArgs e)
        {
            if ((det1) && (NCAD_IMG != null))
            {
                NCAD_IMG.Base.X -= (cX - e.X) / 10;
                NCAD_IMG.Base.Y -= (cY - e.Y) / 10;
            }
        }
        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            det1 = false;
            Canvas.ActiveForm.Cursor = Cursors.Default;
            Invalidate();
        }

        #endregion

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }


    }
}
