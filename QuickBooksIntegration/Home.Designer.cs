namespace QuickBooksIntegration
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.btnClose = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblKeyCaption = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPaste = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.txtApiKey = new System.Windows.Forms.TextBox();
            this.quickBooksIntegrationLabel1 = new QuickBooksIntegration.QuickBooksIntegrationLabel();
            this.qbLabel1 = new QuickBooksIntegration.QuickBooksIntegrationLabel();
            this.lblApiKeyInvalid = new System.Windows.Forms.Label();
            this.lblApiKeyValid = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(493, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(34, 30);
            this.btnClose.TabIndex = 88;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(25, -164);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 21, 0, 0);
            this.label7.Size = new System.Drawing.Size(479, 67);
            this.label7.TabIndex = 86;
            this.label7.Text = "      QUICKBOOKS CONNECTOR";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnCancel.Location = new System.Drawing.Point(298, 265);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 32);
            this.btnCancel.TabIndex = 95;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblKeyCaption
            // 
            this.lblKeyCaption.AutoSize = true;
            this.lblKeyCaption.BackColor = System.Drawing.Color.White;
            this.lblKeyCaption.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeyCaption.Location = new System.Drawing.Point(61, 99);
            this.lblKeyCaption.Name = "lblKeyCaption";
            this.lblKeyCaption.Size = new System.Drawing.Size(177, 19);
            this.lblKeyCaption.TabIndex = 122;
            this.lblKeyCaption.Text = "First Connect with PIYP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(61, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 17);
            this.label1.TabIndex = 122;
            this.label1.Text = "Paste the API Key given during setup";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(44, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 16);
            this.label2.TabIndex = 122;
            this.label2.Text = "QUICKBOOKS CONNECTOR";
            // 
            // btnPaste
            // 
            this.btnPaste.BackColor = System.Drawing.Color.White;
            this.btnPaste.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnPaste.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaste.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaste.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnPaste.Location = new System.Drawing.Point(343, 190);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(84, 42);
            this.btnPaste.TabIndex = 95;
            this.btnPaste.Text = "PASTE";
            this.btnPaste.UseVisualStyleBackColor = false;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.BackColor = System.Drawing.Color.White;
            this.btnContinue.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinue.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinue.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnContinue.Location = new System.Drawing.Point(408, 265);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(104, 32);
            this.btnContinue.TabIndex = 95;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = false;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // txtApiKey
            // 
            this.txtApiKey.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtApiKey.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApiKey.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txtApiKey.Location = new System.Drawing.Point(65, 199);
            this.txtApiKey.Multiline = true;
            this.txtApiKey.Name = "txtApiKey";
            this.txtApiKey.Size = new System.Drawing.Size(280, 35);
            this.txtApiKey.TabIndex = 123;
            this.txtApiKey.WordWrap = false;
            this.txtApiKey.TextChanged += new System.EventHandler(this.txtApiKey_TextChanged);
            // 
            // quickBooksIntegrationLabel1
            // 
            this.quickBooksIntegrationLabel1.BackColor = System.Drawing.Color.White;
            this.quickBooksIntegrationLabel1.Location = new System.Drawing.Point(57, 183);
            this.quickBooksIntegrationLabel1.Name = "quickBooksIntegrationLabel1";
            this.quickBooksIntegrationLabel1.Size = new System.Drawing.Size(377, 55);
            this.quickBooksIntegrationLabel1.TabIndex = 124;
            // 
            // qbLabel1
            // 
            this.qbLabel1.BackColor = System.Drawing.Color.White;
            this.qbLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qbLabel1.Location = new System.Drawing.Point(0, 0);
            this.qbLabel1.Name = "qbLabel1";
            this.qbLabel1.Size = new System.Drawing.Size(528, 320);
            this.qbLabel1.TabIndex = 96;
            // 
            // lblApiKeyInvalid
            // 
            this.lblApiKeyInvalid.AutoSize = true;
            this.lblApiKeyInvalid.BackColor = System.Drawing.Color.OrangeRed;
            this.lblApiKeyInvalid.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApiKeyInvalid.ForeColor = System.Drawing.Color.White;
            this.lblApiKeyInvalid.Location = new System.Drawing.Point(108, 157);
            this.lblApiKeyInvalid.MaximumSize = new System.Drawing.Size(420, 0);
            this.lblApiKeyInvalid.Name = "lblApiKeyInvalid";
            this.lblApiKeyInvalid.Size = new System.Drawing.Size(267, 20);
            this.lblApiKeyInvalid.TabIndex = 125;
            this.lblApiKeyInvalid.Text = "Key is InValid. Enter a Valid Api Key.";
            this.lblApiKeyInvalid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblApiKeyValid
            // 
            this.lblApiKeyValid.AutoSize = true;
            this.lblApiKeyValid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblApiKeyValid.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApiKeyValid.ForeColor = System.Drawing.Color.White;
            this.lblApiKeyValid.Location = new System.Drawing.Point(196, 157);
            this.lblApiKeyValid.MaximumSize = new System.Drawing.Size(420, 0);
            this.lblApiKeyValid.Name = "lblApiKeyValid";
            this.lblApiKeyValid.Size = new System.Drawing.Size(90, 20);
            this.lblApiKeyValid.TabIndex = 126;
            this.lblApiKeyValid.Text = "Key is Valid";
            this.lblApiKeyValid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuickBooksIntegration.Properties.Resources.form_title;
            this.pictureBox1.Location = new System.Drawing.Point(8, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 34);
            this.pictureBox1.TabIndex = 127;
            this.pictureBox1.TabStop = false;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(528, 320);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblApiKeyValid);
            this.Controls.Add(this.lblApiKeyInvalid);
            this.Controls.Add(this.btnPaste);
            this.Controls.Add(this.txtApiKey);
            this.Controls.Add(this.quickBooksIntegrationLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblKeyCaption);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.qbLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QuickBooks Integration";
            this.Load += new System.EventHandler(this.Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label7;
        private QuickBooksIntegrationLabel qbLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblKeyCaption;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.TextBox txtApiKey;
        private QuickBooksIntegrationLabel quickBooksIntegrationLabel1;
        private System.Windows.Forms.Label lblApiKeyInvalid;
        private System.Windows.Forms.Label lblApiKeyValid;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

