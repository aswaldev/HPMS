namespace WindowsFormsApp2
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.panelLogin = new System.Windows.Forms.Panel();
            this.labelError = new System.Windows.Forms.Label();
            this.passLabel = new System.Windows.Forms.Label();
            this.userLabel = new System.Windows.Forms.Label();
            this.passTextBox = new System.Windows.Forms.TextBox();
            this.userTextBox = new System.Windows.Forms.TextBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.Titlepanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.TitlepictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelLogin.SuspendLayout();
            this.Titlepanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TitlepictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLogin
            // 
            this.panelLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelLogin.Controls.Add(this.labelError);
            this.panelLogin.Controls.Add(this.pictureBox1);
            this.panelLogin.Controls.Add(this.passLabel);
            this.panelLogin.Controls.Add(this.userLabel);
            this.panelLogin.Controls.Add(this.passTextBox);
            this.panelLogin.Controls.Add(this.userTextBox);
            this.panelLogin.Controls.Add(this.buttonLogin);
            this.panelLogin.Controls.Add(this.panelLogo);
            this.panelLogin.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLogin.Location = new System.Drawing.Point(0, 0);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(234, 670);
            this.panelLogin.TabIndex = 0;
            // 
            // labelError
            // 
            this.labelError.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(10, 364);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(203, 16);
            this.labelError.TabIndex = 2;
            this.labelError.Text = "Incorrect Username or Password";
            // 
            // passLabel
            // 
            this.passLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.passLabel.AutoSize = true;
            this.passLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.passLabel.Location = new System.Drawing.Point(14, 323);
            this.passLabel.Name = "passLabel";
            this.passLabel.Size = new System.Drawing.Size(68, 16);
            this.passLabel.TabIndex = 5;
            this.passLabel.Text = "Password";
            // 
            // userLabel
            // 
            this.userLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.userLabel.AutoSize = true;
            this.userLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.userLabel.Location = new System.Drawing.Point(14, 272);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(71, 16);
            this.userLabel.TabIndex = 4;
            this.userLabel.Text = "Username";
            // 
            // passTextBox
            // 
            this.passTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.passTextBox.Location = new System.Drawing.Point(13, 342);
            this.passTextBox.Name = "passTextBox";
            this.passTextBox.PasswordChar = '*';
            this.passTextBox.Size = new System.Drawing.Size(205, 20);
            this.passTextBox.TabIndex = 3;
            // 
            // userTextBox
            // 
            this.userTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.userTextBox.Location = new System.Drawing.Point(13, 290);
            this.userTextBox.Name = "userTextBox";
            this.userTextBox.Size = new System.Drawing.Size(205, 20);
            this.userTextBox.TabIndex = 2;
            // 
            // buttonLogin
            // 
            this.buttonLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(61)))), ((int)(((byte)(85)))));
            this.buttonLogin.FlatAppearance.BorderSize = 0;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonLogin.Location = new System.Drawing.Point(50, 400);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(128, 50);
            this.buttonLogin.TabIndex = 1;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(234, 78);
            this.panelLogo.TabIndex = 0;
            // 
            // Titlepanel
            // 
            this.Titlepanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.Titlepanel.Controls.Add(this.label1);
            this.Titlepanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Titlepanel.Location = new System.Drawing.Point(234, 0);
            this.Titlepanel.Name = "Titlepanel";
            this.Titlepanel.Size = new System.Drawing.Size(1114, 78);
            this.Titlepanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(134, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(739, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hospital Patient Management System CS331";
            // 
            // TitlepictureBox
            // 
            this.TitlepictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.TitlepictureBox.BackgroundImage = global::WindowsFormsApp2.Properties.Resources.Lion;
            this.TitlepictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.TitlepictureBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.TitlepictureBox.Location = new System.Drawing.Point(234, 78);
            this.TitlepictureBox.Name = "TitlepictureBox";
            this.TitlepictureBox.Size = new System.Drawing.Size(1114, 592);
            this.TitlepictureBox.TabIndex = 3;
            this.TitlepictureBox.TabStop = false;
           // this.TitlepictureBox.Click += new System.EventHandler(this.TitlepictureBox_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::WindowsFormsApp2.Properties.Resources.WhatsApp_Image_2020_05_28_at_10_40_54_AM;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 78);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(234, 190);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1348, 670);
            this.Controls.Add(this.TitlepictureBox);
            this.Controls.Add(this.Titlepanel);
            this.Controls.Add(this.panelLogin);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(2046, 1062);
            this.MinimumSize = new System.Drawing.Size(1364, 708);
            this.Name = "Login";
            this.Text = "Hospital Patient Management System CS331";
            this.Load += new System.EventHandler(this.Login_Load);
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.Titlepanel.ResumeLayout(false);
            this.Titlepanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TitlepictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Label passLabel;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.TextBox passTextBox;
        private System.Windows.Forms.TextBox userTextBox;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel Titlepanel;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox TitlepictureBox;
    }
}

