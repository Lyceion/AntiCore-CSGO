
namespace AntiCoreCheat.Launcher
{
    partial class LauncherForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LauncherForm));
            this.plMenu = new WindowsUI.WinPanel();
            this.winButton1 = new WindowsUI.WinButton();
            this.winButton2 = new WindowsUI.WinButton();
            this.plMain = new System.Windows.Forms.Panel();
            this.plMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // plMenu
            // 
            this.plMenu.BackColor = System.Drawing.Color.Transparent;
            this.plMenu.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.plMenu.BorderRadius = 1;
            this.plMenu.BorderSize = 2;
            this.plMenu.Controls.Add(this.winButton2);
            this.plMenu.Controls.Add(this.winButton1);
            this.plMenu.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.plMenu.ForeColor = System.Drawing.Color.White;
            this.plMenu.Location = new System.Drawing.Point(12, 38);
            this.plMenu.Name = "plMenu";
            this.plMenu.Normal = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.plMenu.Opacity = 128;
            this.plMenu.SeperatorWidth = 1;
            this.plMenu.ShowBorder = false;
            this.plMenu.Size = new System.Drawing.Size(203, 400);
            this.plMenu.TabIndex = 2;
            this.plMenu.Title = "Menu";
            // 
            // winButton1
            // 
            this.winButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.winButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.winButton1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.winButton1.ForeColor = System.Drawing.Color.White;
            this.winButton1.Location = new System.Drawing.Point(5, 30);
            this.winButton1.Name = "winButton1";
            this.winButton1.Normal = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.winButton1.Press = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.winButton1.Size = new System.Drawing.Size(192, 29);
            this.winButton1.TabIndex = 0;
            this.winButton1.Text = "Home";
            this.winButton1.UseVisualStyleBackColor = false;
            // 
            // winButton2
            // 
            this.winButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.winButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.winButton2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.winButton2.ForeColor = System.Drawing.Color.White;
            this.winButton2.Location = new System.Drawing.Point(5, 65);
            this.winButton2.Name = "winButton2";
            this.winButton2.Normal = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.winButton2.Press = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.winButton2.Size = new System.Drawing.Size(192, 29);
            this.winButton2.TabIndex = 1;
            this.winButton2.Text = "Versions";
            this.winButton2.UseVisualStyleBackColor = false;
            // 
            // plMain
            // 
            this.plMain.Location = new System.Drawing.Point(221, 38);
            this.plMain.Name = "plMain";
            this.plMain.Size = new System.Drawing.Size(567, 400);
            this.plMain.TabIndex = 3;
            // 
            // LauncherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.plMain);
            this.Controls.Add(this.plMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeButton = false;
            this.Name = "LauncherForm";
            this.Text = "Launcher";
            this.Title = "AntiCore - Loader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LauncherForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LauncherForm_FormClosed);
            this.Load += new System.EventHandler(this.LauncherForm_Load);
            this.Shown += new System.EventHandler(this.LauncherForm_Shown);
            this.plMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private WindowsUI.WinPanel plMenu;
        private WindowsUI.WinButton winButton1;
        private WindowsUI.WinButton winButton2;
        private System.Windows.Forms.Panel plMain;
    }
}