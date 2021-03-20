using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsUI.Design;

namespace WindowsUI
{
    public class WinForm : Form
    {
        public WinForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(33, 33, 33);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += new EventHandler(WinForm_Load);
        }

        Panel pnlTop = new Panel();
        Label lblProgram = new Label();
        Button btnMinimaze = new Button();
        Button btnMaximize = new Button();
        public Button btnClose = new Button();
        PictureBox pbProgram = new PictureBox();

        [Category("Windows UI - Control Bar")]
        [DisplayName("Title")]
        public string Title
        {
            get
            {
                return lblProgram.Text;
            }
            set
            {
                lblProgram.Text = value;
            }
        }

        [Category("Windows UI - Control Bar")]
        [DisplayName("Close Button")]
        public bool CloseButton
        {
            get
            {
                return btnClose.Visible;
            }
            set
            {
                btnClose.Visible = value;
            }
        }

        [Category("Windows UI - Control Bar")]
        [DisplayName("Minimaze Button")]
        public bool MinimazeButton
        {
            get
            {
                return btnMinimaze.Visible;
            }
            set
            {
                btnMinimaze.Visible = value;
            }
        }

        [Category("Windows UI - Control Bar")]
        [DisplayName("Maximize Button")]
        public bool MaximizeButton
        {
            get
            {
                return btnMaximize.Visible;
            }
            set
            {
                btnMaximize.Visible = value;
            }
        }

        [Category("Windows UI - Control Bar")]
        [DisplayName("Show Title")]
        public bool ShowTitle
        {
            get
            {
                return lblProgram.Visible;
            }
            set
            {
                lblProgram.Visible = value;
            }
        }

        [Category("Windows UI")]
        [DisplayName("Drag")]
        [Description("If Drag with Visual Type, Maybe exception or bug")]
        public bool Drag { get; set; } = true;

        [Category("Windows UI")]
        [DisplayName("Extra Shadow")]
        [Description("GS_DropShadow")]
        public bool ExtraDropShadow { get; set; } = false;

        [Category("Windows UI - Control Bar")]
        [DisplayName("Show Control Bar Icon")]
        public bool ShowControlBarIcon
        {
            get
            {
                return pbProgram.Visible;
            }
            set
            {
                pbProgram.Visible = value;
                if(pbProgram.Visible)
                {
                    lblProgram.Location = new Point(33, 8);
                }
                else
                {
                    lblProgram.Location = new Point(5, 8);
                }
            }
        }

        public Enums.AccentState FormAccentState = Enums.AccentState.ACCENT_ENABLE_HOSTBACKDROP;

        public void SetFormAccentState(Enums.AccentState value)
        {
            Aero.ChangeAccent(Handle, new Enums.AccentPolicy { GradientColor = 0xFD70000, AccentState = value });
        }

        private void WinForm_Load(object sender, EventArgs e)
        {
            this.Controls.Add(pnlTop);
            pnlTop.Size = new Size(560, 30);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.BackColor = Color.Black;
            pnlTop.MouseDown += new MouseEventHandler(DoDrag);

            btnMinimaze.ForeColor = Color.White;
            btnMinimaze.BackColor = pnlTop.BackColor;
            btnMinimaze.FlatStyle = FlatStyle.Flat;
            btnMinimaze.FlatAppearance.BorderSize = 0;
            btnMinimaze.FlatAppearance.MouseDownBackColor = Color.FromArgb(44, 44, 44);
            btnMinimaze.FlatAppearance.MouseOverBackColor = Color.FromArgb(66, 66, 66);
            btnMinimaze.Size = new Size(52, 30);
            btnMinimaze.Dock = DockStyle.Right;
            btnMinimaze.Cursor = Cursors.Hand;
            btnMinimaze.Font = new Font("Segoe UI Symbol", 9f);
            btnMinimaze.Text = "─";
            btnMinimaze.Click += new EventHandler(Minimaze);
            pnlTop.Controls.Add(btnMinimaze);

            btnMaximize.ForeColor = Color.White;
            btnMaximize.BackColor = pnlTop.BackColor;
            btnMaximize.FlatStyle = FlatStyle.Flat;
            btnMaximize.FlatAppearance.BorderSize = 0;
            btnMaximize.FlatAppearance.MouseDownBackColor = Color.FromArgb(44, 44, 44);
            btnMaximize.FlatAppearance.MouseOverBackColor = Color.FromArgb(66, 66, 66);
            btnMaximize.Size = new Size(52, 30);
            btnMaximize.Dock = DockStyle.Right;
            btnMaximize.Cursor = Cursors.Hand;
            btnMaximize.Font = new Font("Segoe UI Symbol", 9f);
            btnMaximize.Text = "◻";
            btnMaximize.Click += new EventHandler(Maximize);
            btnMaximize.Visible = MaximizeButton;
            pnlTop.Controls.Add(btnMaximize);

            btnClose.ForeColor = Color.White;
            btnClose.BackColor = pnlTop.BackColor;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseDownBackColor = Color.DarkRed;
            btnClose.FlatAppearance.MouseOverBackColor = Color.Red;
            btnClose.Size = new Size(52, 30);
            btnClose.Dock = DockStyle.Right;
            btnClose.Cursor = Cursors.Hand;
            btnClose.Font = new Font("Segoe UI Symbol", 9f);
            btnClose.Text = "✕";
            btnClose.Click += new EventHandler(Close);
            pnlTop.Controls.Add(btnClose);

            pbProgram.SizeMode = PictureBoxSizeMode.Zoom;
            pbProgram.Location = new Point(4, 2);
            pbProgram.Size = new Size(24, 24);
            pbProgram.Image = this.Icon.ToBitmap();
            pbProgram.MouseDown += new MouseEventHandler(DoDrag);
            pnlTop.Controls.Add(pbProgram);

            if (this.Icon != null && ShowControlBarIcon)
            {
                lblProgram.Location = new Point(33, 8);
            }
            else
            {
                lblProgram.Location = new Point(5, 8);
            }
            lblProgram.ForeColor = Color.White;
            lblProgram.MouseDown += new MouseEventHandler(DoDrag);
            pnlTop.Controls.Add(lblProgram);

            Aero.ChangeAccent(Handle, new Enums.AccentPolicy { GradientColor = 0xFD70000, AccentState = FormAccentState });
            if (ExtraDropShadow)
                Shadow.AddShadow(Handle);
        }

        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Maximize(object sender, EventArgs e)
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized:
                    this.WindowState = FormWindowState.Normal;
                    break;

                case FormWindowState.Normal:
                    this.WindowState = FormWindowState.Maximized;
                    break;
            }
        }

        private void Minimaze(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void DoDrag(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Control cntrl = (Control)sender;
            if (Drag)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Aero.ChangeAccent(Handle, new Enums.AccentPolicy { GradientColor = 0xFD70000, AccentState = Enums.AccentState.ACCENT_DISABLED });
                    this.Opacity = 0.85;
                    cntrl.Cursor = Cursors.Hand;
                    WinAPI.ReleaseCapture();
                    WinAPI.SendMessage(Handle, Constants.WM_NCLBUTTONDOWN, Constants.HT_CAPTION, 0);
                    Aero.ChangeAccent(Handle, new Enums.AccentPolicy { GradientColor = 0xFD70000, AccentState = FormAccentState });
                    this.Opacity = 1;
                    cntrl.Cursor = Cursors.Default;
                }
            }
        }
    }
}
