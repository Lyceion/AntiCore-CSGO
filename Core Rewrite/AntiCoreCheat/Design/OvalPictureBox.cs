using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace AntiCoreCheat.Design
{
    class OvalPictureBox : PictureBox
    {
        public OvalPictureBox()
        {
            BackColor = Color.DarkGray;
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            using (var gp = new GraphicsPath())
            {
                gp.AddEllipse(new Rectangle(0, 0, this.Width - 1, this.Height - 1));
                Region = new Region(gp);
            }
        }
    }
}
