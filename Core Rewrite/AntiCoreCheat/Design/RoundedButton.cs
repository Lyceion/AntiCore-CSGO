using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AntiCoreCheat.Design
{
    public class RoundedButton : Button
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        int m_borderRadius = 0;
        public int BorderRadius
        {
            get { return m_borderRadius; }
            set { m_borderRadius = value; Invalidate(); }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, BorderRadius, BorderRadius));
            base.OnPaint(e);
        }
    }

}