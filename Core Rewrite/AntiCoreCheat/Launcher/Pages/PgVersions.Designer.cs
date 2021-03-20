
namespace AntiCoreCheat.Launcher.Pages
{
    partial class PgVersions
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.winPanel1 = new WindowsUI.WinPanel();
            this.winPanel2 = new WindowsUI.WinPanel();
            this.lblVACBypass = new System.Windows.Forms.Label();
            this.cbVACBypass = new AntiCoreCheat.Design.ToggleSwitch();
            this.btnLoadCheat = new WindowsUI.WinButton();
            this.pbUserInfo = new AntiCoreCheat.Design.OvalPictureBox();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lstCheats = new System.Windows.Forms.FlowLayoutPanel();
            this.winPanel1.SuspendLayout();
            this.winPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // winPanel1
            // 
            this.winPanel1.BackColor = System.Drawing.Color.Transparent;
            this.winPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.winPanel1.BorderRadius = 40;
            this.winPanel1.BorderSize = 2;
            this.winPanel1.Controls.Add(this.lblWelcome);
            this.winPanel1.Controls.Add(this.pbUserInfo);
            this.winPanel1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.winPanel1.ForeColor = System.Drawing.Color.White;
            this.winPanel1.Location = new System.Drawing.Point(15, 16);
            this.winPanel1.Name = "winPanel1";
            this.winPanel1.Normal = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.winPanel1.Opacity = 128;
            this.winPanel1.SeperatorWidth = 0;
            this.winPanel1.ShowBorder = false;
            this.winPanel1.Size = new System.Drawing.Size(537, 48);
            this.winPanel1.TabIndex = 0;
            this.winPanel1.Title = "";
            // 
            // winPanel2
            // 
            this.winPanel2.BackColor = System.Drawing.Color.Transparent;
            this.winPanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.winPanel2.BorderRadius = 20;
            this.winPanel2.BorderSize = 2;
            this.winPanel2.Controls.Add(this.lstCheats);
            this.winPanel2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.winPanel2.ForeColor = System.Drawing.Color.White;
            this.winPanel2.Location = new System.Drawing.Point(15, 70);
            this.winPanel2.Name = "winPanel2";
            this.winPanel2.Normal = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.winPanel2.Opacity = 128;
            this.winPanel2.SeperatorWidth = 0;
            this.winPanel2.ShowBorder = false;
            this.winPanel2.Size = new System.Drawing.Size(537, 262);
            this.winPanel2.TabIndex = 1;
            this.winPanel2.Title = "";
            // 
            // lblVACBypass
            // 
            this.lblVACBypass.AutoSize = true;
            this.lblVACBypass.Font = new System.Drawing.Font("Segoe UI Semibold", 9.25F);
            this.lblVACBypass.ForeColor = System.Drawing.Color.White;
            this.lblVACBypass.Location = new System.Drawing.Point(18, 356);
            this.lblVACBypass.Name = "lblVACBypass";
            this.lblVACBypass.Size = new System.Drawing.Size(152, 17);
            this.lblVACBypass.TabIndex = 24;
            this.lblVACBypass.Text = "Start with VAC Bypass : ";
            // 
            // cbVACBypass
            // 
            this.cbVACBypass.Location = new System.Drawing.Point(169, 356);
            this.cbVACBypass.Name = "cbVACBypass";
            this.cbVACBypass.OffFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbVACBypass.OffForeColor = System.Drawing.Color.WhiteSmoke;
            this.cbVACBypass.OffText = "OFF";
            this.cbVACBypass.OnFont = new System.Drawing.Font("Segoe UI", 8.25F);
            this.cbVACBypass.OnForeColor = System.Drawing.Color.WhiteSmoke;
            this.cbVACBypass.OnText = "ON";
            this.cbVACBypass.Size = new System.Drawing.Size(61, 20);
            this.cbVACBypass.Style = AntiCoreCheat.Design.ToggleSwitch.ToggleSwitchStyle.Android;
            this.cbVACBypass.TabIndex = 23;
            // 
            // btnLoadCheat
            // 
            this.btnLoadCheat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnLoadCheat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadCheat.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnLoadCheat.ForeColor = System.Drawing.Color.White;
            this.btnLoadCheat.Location = new System.Drawing.Point(411, 338);
            this.btnLoadCheat.Name = "btnLoadCheat";
            this.btnLoadCheat.Normal = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnLoadCheat.Press = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.btnLoadCheat.Size = new System.Drawing.Size(141, 48);
            this.btnLoadCheat.TabIndex = 25;
            this.btnLoadCheat.Text = "Load Cheat";
            this.btnLoadCheat.UseVisualStyleBackColor = false;
            this.btnLoadCheat.Click += new System.EventHandler(this.btnLoadCheat_Click);
            // 
            // pbUserInfo
            // 
            this.pbUserInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pbUserInfo.Location = new System.Drawing.Point(6, 5);
            this.pbUserInfo.Name = "pbUserInfo";
            this.pbUserInfo.Size = new System.Drawing.Size(38, 38);
            this.pbUserInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbUserInfo.TabIndex = 11;
            this.pbUserInfo.TabStop = false;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI Semibold", 9.25F);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(50, 16);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(297, 17);
            this.lblWelcome.TabIndex = 25;
            this.lblWelcome.Text = "Welcome, CRACKED BY OWNER OF THE CHEAT!";
            // 
            // lstCheats
            // 
            this.lstCheats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCheats.Location = new System.Drawing.Point(0, 0);
            this.lstCheats.Name = "lstCheats";
            this.lstCheats.Size = new System.Drawing.Size(537, 262);
            this.lstCheats.TabIndex = 0;
            // 
            // PgVersions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Controls.Add(this.cbVACBypass);
            this.Controls.Add(this.btnLoadCheat);
            this.Controls.Add(this.lblVACBypass);
            this.Controls.Add(this.winPanel2);
            this.Controls.Add(this.winPanel1);
            this.Name = "PgVersions";
            this.Size = new System.Drawing.Size(567, 400);
            this.Load += new System.EventHandler(this.PgVersions_Load);
            this.winPanel1.ResumeLayout(false);
            this.winPanel1.PerformLayout();
            this.winPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbUserInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WindowsUI.WinPanel winPanel1;
        private WindowsUI.WinPanel winPanel2;
        private System.Windows.Forms.Label lblVACBypass;
        private Design.ToggleSwitch cbVACBypass;
        private WindowsUI.WinButton btnLoadCheat;
        private Design.OvalPictureBox pbUserInfo;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.FlowLayoutPanel lstCheats;
    }
}
