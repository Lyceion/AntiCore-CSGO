namespace AntiCoreCheat.Launcher.Pages
{
    partial class MainPage
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
            this.labelUserInfo = new System.Windows.Forms.Label();
            this.panelUser = new System.Windows.Forms.Panel();
            this.panelCheats = new System.Windows.Forms.Panel();
            this.labelVACBypass = new System.Windows.Forms.Label();
            this.checkboxVACBypass = new AntiCoreCheat.Design.ToggleSwitch();
            this.pictureBoxUserInfo = new AntiCoreCheat.Design.OvalPictureBox();
            this.buttonUser = new AntiCoreCheat.Design.RoundedButton();
            this.buttonLoad = new AntiCoreCheat.Design.RoundedButton();
            this.panelUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // labelUserInfo
            // 
            this.labelUserInfo.AutoSize = true;
            this.labelUserInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.labelUserInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelUserInfo.Location = new System.Drawing.Point(36, 12);
            this.labelUserInfo.Name = "labelUserInfo";
            this.labelUserInfo.Size = new System.Drawing.Size(101, 15);
            this.labelUserInfo.TabIndex = 9;
            this.labelUserInfo.Text = "Welcome, XXXXX!";
            // 
            // panelUser
            // 
            this.panelUser.Controls.Add(this.pictureBoxUserInfo);
            this.panelUser.Controls.Add(this.labelUserInfo);
            this.panelUser.Controls.Add(this.buttonUser);
            this.panelUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelUser.Location = new System.Drawing.Point(12, 6);
            this.panelUser.Name = "panelUser";
            this.panelUser.Size = new System.Drawing.Size(156, 38);
            this.panelUser.TabIndex = 17;
            // 
            // panelCheats
            // 
            this.panelCheats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.panelCheats.Location = new System.Drawing.Point(12, 58);
            this.panelCheats.Name = "panelCheats";
            this.panelCheats.Size = new System.Drawing.Size(500, 230);
            this.panelCheats.TabIndex = 20;
            // 
            // labelVACBypass
            // 
            this.labelVACBypass.AutoSize = true;
            this.labelVACBypass.Location = new System.Drawing.Point(519, 228);
            this.labelVACBypass.Name = "labelVACBypass";
            this.labelVACBypass.Size = new System.Drawing.Size(68, 13);
            this.labelVACBypass.TabIndex = 22;
            this.labelVACBypass.Text = "VAC Bypass:";
            // 
            // checkboxVACBypass
            // 
            this.checkboxVACBypass.Enabled = false;
            this.checkboxVACBypass.Location = new System.Drawing.Point(591, 224);
            this.checkboxVACBypass.Name = "checkboxVACBypass";
            this.checkboxVACBypass.OffFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkboxVACBypass.OffForeColor = System.Drawing.Color.WhiteSmoke;
            this.checkboxVACBypass.OffText = "OFF";
            this.checkboxVACBypass.OnFont = new System.Drawing.Font("Segoe UI", 8.25F);
            this.checkboxVACBypass.OnForeColor = System.Drawing.Color.WhiteSmoke;
            this.checkboxVACBypass.OnText = "ON";
            this.checkboxVACBypass.Size = new System.Drawing.Size(61, 20);
            this.checkboxVACBypass.Style = AntiCoreCheat.Design.ToggleSwitch.ToggleSwitchStyle.Android;
            this.checkboxVACBypass.TabIndex = 21;
            // 
            // pictureBoxUserInfo
            // 
            this.pictureBoxUserInfo.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBoxUserInfo.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxUserInfo.Name = "pictureBoxUserInfo";
            this.pictureBoxUserInfo.Size = new System.Drawing.Size(38, 38);
            this.pictureBoxUserInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxUserInfo.TabIndex = 10;
            this.pictureBoxUserInfo.TabStop = false;
            // 
            // buttonUser
            // 
            this.buttonUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.buttonUser.BorderRadius = 10;
            this.buttonUser.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.buttonUser.FlatAppearance.BorderSize = 0;
            this.buttonUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.buttonUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.buttonUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUser.Location = new System.Drawing.Point(0, 0);
            this.buttonUser.Name = "buttonUser";
            this.buttonUser.Size = new System.Drawing.Size(156, 38);
            this.buttonUser.TabIndex = 11;
            this.buttonUser.UseVisualStyleBackColor = false;
            // 
            // buttonLoad
            // 
            this.buttonLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.buttonLoad.BorderRadius = 10;
            this.buttonLoad.FlatAppearance.BorderSize = 0;
            this.buttonLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoad.Location = new System.Drawing.Point(522, 252);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(132, 36);
            this.buttonLoad.TabIndex = 16;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = false;
            this.buttonLoad.Click += new System.EventHandler(this.ButtonLoad_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Controls.Add(this.labelVACBypass);
            this.Controls.Add(this.checkboxVACBypass);
            this.Controls.Add(this.panelCheats);
            this.Controls.Add(this.panelUser);
            this.Controls.Add(this.buttonLoad);
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Name = "MainPage";
            this.Size = new System.Drawing.Size(666, 300);
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.panelUser.ResumeLayout(false);
            this.panelUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Design.RoundedButton buttonLoad;
        private Design.RoundedButton buttonUser;
        private Design.OvalPictureBox pictureBoxUserInfo;
        private System.Windows.Forms.Label labelUserInfo;
        private System.Windows.Forms.Panel panelUser;
        private System.Windows.Forms.Panel panelCheats;
        private System.Windows.Forms.Label labelVACBypass;
        private Design.ToggleSwitch checkboxVACBypass;
    }
}
