namespace AntiCoreCheat.Launcher
{
    partial class Launcher
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

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launcher));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelTiteBar = new System.Windows.Forms.Panel();
            this.panelControlBox = new System.Windows.Forms.Panel();
            this.panelHeaderText = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.labelHeaderText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.seperatorHeader = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.buttonMinimize = new AntiCoreCheat.Design.RoundedButton();
            this.buttonExit = new AntiCoreCheat.Design.RoundedButton();
            this.panelHeader.SuspendLayout();
            this.panelTiteBar.SuspendLayout();
            this.panelControlBox.SuspendLayout();
            this.panelHeaderText.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.panelTiteBar);
            this.panelHeader.Controls.Add(this.panelHeaderText);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(666, 55);
            this.panelHeader.TabIndex = 0;
            this.panelHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseDown);
            this.panelHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseMove);
            this.panelHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseUp);
            // 
            // panelTiteBar
            // 
            this.panelTiteBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.panelTiteBar.Controls.Add(this.panelControlBox);
            this.panelTiteBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTiteBar.Location = new System.Drawing.Point(0, 0);
            this.panelTiteBar.Name = "panelTiteBar";
            this.panelTiteBar.Size = new System.Drawing.Size(510, 27);
            this.panelTiteBar.TabIndex = 0;
            this.panelTiteBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseDown);
            this.panelTiteBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseMove);
            this.panelTiteBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseUp);
            // 
            // panelControlBox
            // 
            this.panelControlBox.Controls.Add(this.buttonMinimize);
            this.panelControlBox.Controls.Add(this.buttonExit);
            this.panelControlBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControlBox.Location = new System.Drawing.Point(0, 0);
            this.panelControlBox.Name = "panelControlBox";
            this.panelControlBox.Size = new System.Drawing.Size(60, 27);
            this.panelControlBox.TabIndex = 0;
            this.panelControlBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseDown);
            this.panelControlBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseMove);
            this.panelControlBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseUp);
            // 
            // panelHeaderText
            // 
            this.panelHeaderText.Controls.Add(this.label2);
            this.panelHeaderText.Controls.Add(this.labelHeaderText);
            this.panelHeaderText.Controls.Add(this.label1);
            this.panelHeaderText.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelHeaderText.Location = new System.Drawing.Point(510, 0);
            this.panelHeaderText.Name = "panelHeaderText";
            this.panelHeaderText.Size = new System.Drawing.Size(156, 55);
            this.panelHeaderText.TabIndex = 1;
            this.panelHeaderText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseDown);
            this.panelHeaderText.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseMove);
            this.panelHeaderText.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(156)))), ((int)(((byte)(230)))));
            this.label2.Location = new System.Drawing.Point(84, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "EXTERNAL";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseDown);
            this.label2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseMove);
            this.label2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseUp);
            // 
            // labelHeaderText
            // 
            this.labelHeaderText.AutoSize = true;
            this.labelHeaderText.Font = new System.Drawing.Font("Segoe UI Light", 18F);
            this.labelHeaderText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(66)))), ((int)(((byte)(245)))));
            this.labelHeaderText.Location = new System.Drawing.Point(77, 10);
            this.labelHeaderText.Name = "labelHeaderText";
            this.labelHeaderText.Size = new System.Drawing.Size(61, 32);
            this.labelHeaderText.TabIndex = 0;
            this.labelHeaderText.Text = "ɘɿoƆ";
            this.labelHeaderText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseDown);
            this.labelHeaderText.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseMove);
            this.labelHeaderText.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 18F);
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 32);
            this.label1.TabIndex = 7;
            this.label1.Text = "Anti - ";
            // 
            // seperatorHeader
            // 
            this.seperatorHeader.BackColor = System.Drawing.Color.White;
            this.seperatorHeader.Location = new System.Drawing.Point(12, 55);
            this.seperatorHeader.Name = "seperatorHeader";
            this.seperatorHeader.Size = new System.Drawing.Size(642, 3);
            this.seperatorHeader.TabIndex = 2;
            this.seperatorHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseDown);
            this.seperatorHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseMove);
            this.seperatorHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseUp);
            // 
            // panelMain
            // 
            this.panelMain.Location = new System.Drawing.Point(0, 64);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(666, 310);
            this.panelMain.TabIndex = 10;
            this.panelMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseDown);
            this.panelMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseMove);
            this.panelMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseUp);
            // 
            // buttonMinimize
            // 
            this.buttonMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(0)))));
            this.buttonMinimize.BorderRadius = 10;
            this.buttonMinimize.FlatAppearance.BorderSize = 0;
            this.buttonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinimize.Location = new System.Drawing.Point(34, 11);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.Size = new System.Drawing.Size(13, 13);
            this.buttonMinimize.TabIndex = 2;
            this.buttonMinimize.UseVisualStyleBackColor = false;
            this.buttonMinimize.Click += new System.EventHandler(this.buttonMinimize_Click);
            this.buttonMinimize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseDown);
            this.buttonMinimize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseMove);
            this.buttonMinimize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseUp);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(74)))), ((int)(((byte)(73)))));
            this.buttonExit.BorderRadius = 10;
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Location = new System.Drawing.Point(15, 11);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(13, 13);
            this.buttonExit.TabIndex = 1;
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            this.buttonExit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseDown);
            this.buttonExit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseMove);
            this.buttonExit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseUp);
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(666, 377);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.seperatorHeader);
            this.Controls.Add(this.panelHeader);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Launcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.Launcher_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Launcher_FormClosed);
            this.Load += new System.EventHandler(this.Launcher_Load);
            this.Shown += new System.EventHandler(this.Launcher_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Launcher_Paint);
            this.panelHeader.ResumeLayout(false);
            this.panelTiteBar.ResumeLayout(false);
            this.panelControlBox.ResumeLayout(false);
            this.panelHeaderText.ResumeLayout(false);
            this.panelHeaderText.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelTiteBar;
        private System.Windows.Forms.Panel panelControlBox;
        private Design.RoundedButton buttonExit;
        private Design.RoundedButton buttonMinimize;
        private System.Windows.Forms.Panel panelHeaderText;
        private System.Windows.Forms.Label labelHeaderText;
        private System.Windows.Forms.Panel seperatorHeader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label label1;
    }
}

