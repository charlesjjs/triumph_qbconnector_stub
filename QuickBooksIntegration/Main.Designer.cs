namespace QuickBooksIntegration
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblQBConnected = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPiYPConnected = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblExitConfirmation = new System.Windows.Forms.Label();
            this.lblDivider = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.crProgress = new CircularProgressBar.CircularProgressBar();
            this.lblSync = new System.Windows.Forms.Label();
            this.notifyQB = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.verticalline = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtAPIKey = new System.Windows.Forms.TextBox();
            this.qbLabel1 = new QuickBooksIntegration.QuickBooksIntegrationLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.White;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.Location = new System.Drawing.Point(488, 4);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(34, 30);
            this.btnMinimize.TabIndex = 97;
            this.btnMinimize.Text = "--";
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.White;
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnEdit.Location = new System.Drawing.Point(404, 290);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(104, 32);
            this.btnEdit.TabIndex = 116;
            this.btnEdit.Text = "EDIT";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(52, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 18);
            this.label1.TabIndex = 123;
            this.label1.Text = "QUICKBOOKS";
            // 
            // lblQBConnected
            // 
            this.lblQBConnected.AutoSize = true;
            this.lblQBConnected.BackColor = System.Drawing.Color.White;
            this.lblQBConnected.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblQBConnected.ForeColor = System.Drawing.Color.Green;
            this.lblQBConnected.Location = new System.Drawing.Point(55, 103);
            this.lblQBConnected.Name = "lblQBConnected";
            this.lblQBConnected.Size = new System.Drawing.Size(92, 18);
            this.lblQBConnected.TabIndex = 123;
            this.lblQBConnected.Text = "Connected";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label6.Location = new System.Drawing.Point(400, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 18);
            this.label6.TabIndex = 123;
            this.label6.Text = "PIYP";
            // 
            // lblPiYPConnected
            // 
            this.lblPiYPConnected.AutoSize = true;
            this.lblPiYPConnected.BackColor = System.Drawing.Color.White;
            this.lblPiYPConnected.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPiYPConnected.ForeColor = System.Drawing.Color.Green;
            this.lblPiYPConnected.Location = new System.Drawing.Point(376, 103);
            this.lblPiYPConnected.Name = "lblPiYPConnected";
            this.lblPiYPConnected.Size = new System.Drawing.Size(92, 18);
            this.lblPiYPConnected.TabIndex = 123;
            this.lblPiYPConnected.Text = "Connected";
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlMain.Location = new System.Drawing.Point(0, 161);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(527, 20);
            this.pnlMain.TabIndex = 124;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(22, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 18);
            this.label3.TabIndex = 125;
            this.label3.Text = "PIYP Authentication";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label4.Location = new System.Drawing.Point(22, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(438, 30);
            this.label4.TabIndex = 126;
            this.label4.Text = "The API Key ties this computer to your PIYP account. The Key can be found in the " +
    "\r\nsettings section of the PIYP web portal.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(22, 295);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 18);
            this.label5.TabIndex = 123;
            this.label5.Text = "Connection Key:";
            // 
            // lblExitConfirmation
            // 
            this.lblExitConfirmation.AutoSize = true;
            this.lblExitConfirmation.BackColor = System.Drawing.Color.White;
            this.lblExitConfirmation.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExitConfirmation.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblExitConfirmation.Location = new System.Drawing.Point(153, 370);
            this.lblExitConfirmation.Name = "lblExitConfirmation";
            this.lblExitConfirmation.Size = new System.Drawing.Size(211, 16);
            this.lblExitConfirmation.TabIndex = 126;
            this.lblExitConfirmation.Text = "EXIT QUICKBOOKS CONNECTOR";
            this.lblExitConfirmation.Click += new System.EventHandler(this.lblExitConfirmation_Click);
            // 
            // lblDivider
            // 
            this.lblDivider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDivider.Location = new System.Drawing.Point(0, 354);
            this.lblDivider.Name = "lblDivider";
            this.lblDivider.Size = new System.Drawing.Size(528, 2);
            this.lblDivider.TabIndex = 129;
            this.lblDivider.Text = "label8";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 8.75F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label7.Location = new System.Drawing.Point(44, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(164, 16);
            this.label7.TabIndex = 126;
            this.label7.Text = "QUICKBOOKS CONNECTOR";
            // 
            // crProgress
            // 
            this.crProgress.AnimationFunction = ((WinFormAnimation.AnimationFunctions.Function)(resources.GetObject("crProgress.AnimationFunction")));
            this.crProgress.AnimationSpeed = 500;
            this.crProgress.BackColor = System.Drawing.Color.White;
            this.crProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold);
            this.crProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.crProgress.InnerColor = System.Drawing.Color.White;
            this.crProgress.InnerMargin = 2;
            this.crProgress.InnerWidth = -1;
            this.crProgress.Location = new System.Drawing.Point(210, 24);
            this.crProgress.Margin = new System.Windows.Forms.Padding(0);
            this.crProgress.MarqueeAnimationSpeed = 2000;
            this.crProgress.Name = "crProgress";
            this.crProgress.OuterColor = System.Drawing.Color.Gray;
            this.crProgress.OuterMargin = -25;
            this.crProgress.OuterWidth = 26;
            this.crProgress.ProgressColor = System.Drawing.Color.DeepSkyBlue;
            this.crProgress.ProgressWidth = 4;
            this.crProgress.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.crProgress.Size = new System.Drawing.Size(113, 110);
            this.crProgress.StartAngle = 270;
            this.crProgress.Step = 1;
            this.crProgress.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.crProgress.SubscriptMargin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.crProgress.SubscriptText = "";
            this.crProgress.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.crProgress.SuperscriptMargin = new System.Windows.Forms.Padding(2, 20, 0, 0);
            this.crProgress.SuperscriptText = "%";
            this.crProgress.TabIndex = 131;
            this.crProgress.Text = "0";
            this.crProgress.TextMargin = new System.Windows.Forms.Padding(4, -4, 0, 0);
            this.crProgress.Value = 68;
            // 
            // lblSync
            // 
            this.lblSync.AutoSize = true;
            this.lblSync.BackColor = System.Drawing.Color.White;
            this.lblSync.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblSync.Location = new System.Drawing.Point(246, 94);
            this.lblSync.Name = "lblSync";
            this.lblSync.Size = new System.Drawing.Size(51, 19);
            this.lblSync.TabIndex = 132;
            this.lblSync.Text = "SYNC";
            // 
            // notifyQB
            // 
            this.notifyQB.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyQB.Icon")));
            this.notifyQB.Text = "notifyIcon1";
            this.notifyQB.Visible = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Location = new System.Drawing.Point(312, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 2);
            this.groupBox1.TabIndex = 133;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox2.Location = new System.Drawing.Point(-4, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(225, 2);
            this.groupBox2.TabIndex = 134;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // verticalline
            // 
            this.verticalline.BackColor = System.Drawing.SystemColors.ControlLight;
            this.verticalline.Location = new System.Drawing.Point(262, 132);
            this.verticalline.Name = "verticalline";
            this.verticalline.Size = new System.Drawing.Size(2, 28);
            this.verticalline.TabIndex = 0;
            this.verticalline.TabStop = false;
            this.verticalline.Text = "groupBox3";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuickBooksIntegration.Properties.Resources.form_title;
            this.pictureBox1.Location = new System.Drawing.Point(8, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 34);
            this.pictureBox1.TabIndex = 135;
            this.pictureBox1.TabStop = false;
            // 
            // txtAPIKey
            // 
            this.txtAPIKey.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAPIKey.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtAPIKey.Location = new System.Drawing.Point(156, 286);
            this.txtAPIKey.Multiline = true;
            this.txtAPIKey.Name = "txtAPIKey";
            this.txtAPIKey.Size = new System.Drawing.Size(242, 40);
            this.txtAPIKey.TabIndex = 136;
            // 
            // qbLabel1
            // 
            this.qbLabel1.BackColor = System.Drawing.Color.White;
            this.qbLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qbLabel1.Location = new System.Drawing.Point(0, 0);
            this.qbLabel1.Name = "qbLabel1";
            this.qbLabel1.Size = new System.Drawing.Size(527, 403);
            this.qbLabel1.TabIndex = 96;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(527, 403);
            this.Controls.Add(this.txtAPIKey);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.verticalline);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblSync);
            this.Controls.Add(this.crProgress);
            this.Controls.Add(this.lblDivider);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblExitConfirmation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.lblPiYPConnected);
            this.Controls.Add(this.lblQBConnected);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.qbLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QuickBooks Integration";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private QuickBooksIntegrationLabel qbLabel1;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblQBConnected;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPiYPConnected;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblExitConfirmation;
        private System.Windows.Forms.Label lblDivider;
        private System.Windows.Forms.Label label7;
        private CircularProgressBar.CircularProgressBar crProgress;
        private System.Windows.Forms.Label lblSync;
        private System.Windows.Forms.NotifyIcon notifyQB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox verticalline;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtAPIKey;
    }
}

