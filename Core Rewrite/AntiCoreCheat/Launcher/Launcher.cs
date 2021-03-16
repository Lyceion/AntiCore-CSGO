using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntiCoreCheat.Launcher
{
    // THEME COLOR: #359CE6
    public partial class Launcher : Form
    {
        public static System.Drawing.Drawing2D.GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            // top left arc  
            path.AddArc(arc, 180, 90);

            // top right arc  
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc  
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc 
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn (int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        [DllImport("user32")]
        private static extern IntPtr GetWindowDC(IntPtr hwnd);

        // you also need ReleaseDC
        [DllImport("user32")]
        private static extern IntPtr ReleaseDC(IntPtr hwnd, IntPtr hdc);

        static IntPtr _handle;
        static int _width, _height;
        private bool mouseDown;
        private Point lastLocation;
        private void Drag_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }
        private void Drag_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point(
                    (Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y);

                Update();
            }
        }
        private void Drag_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        Pages.MainPage main = new Pages.MainPage();

        public Launcher()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            _handle = Handle;
            _width = Width;
            _height = Height;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(69);
        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            WindowState = FormWindowState.Minimized;
            FormBorderStyle = FormBorderStyle.None;
        }

        private void Launcher_Activated(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
        }

        public static void DrawOutline()
        {
            IntPtr hdc = GetWindowDC(_handle);
            Graphics g = Graphics.FromHdc(hdc);
            Pen pen = new Pen(Color.FromArgb(53, 156, 230), 1);
            using (System.Drawing.Drawing2D.GraphicsPath path = RoundedRect(new Rectangle(0, 0, _width - 2, _height - 2), 10))
            {
                g.DrawPath(pen, path);
            }
            g.Dispose();
            ReleaseDC(_handle, hdc);
        }

        private void Launcher_Paint(object sender, PaintEventArgs e)
        {
            DrawOutline();
        }

        private void Launcher_Load(object sender, EventArgs e)
        {

        }

        private void Launcher_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Launcher_Shown(object sender, EventArgs e)
        {
#if DEBUG
            Logger.Log.Debug();
            Logger.Log.Icon = this.Icon;
#endif
            Logger.Log.PrintLine(Logger.GetCurrentMethodName() + ", Hello from beginning!", LSDebug.TextType.Info);
            panelMain.Controls.Add(main);
            this.BringToFront();
        }
    }
}
