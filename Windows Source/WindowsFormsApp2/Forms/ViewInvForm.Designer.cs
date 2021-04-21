namespace WindowsFormsApp2.Forms
{
    partial class ViewInvForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewInvForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Invbutton = new System.Windows.Forms.Button();
            this.ConsumeInvbutton = new System.Windows.Forms.Button();
            this.IDSearchlabel = new System.Windows.Forms.Label();
            this.SearchIDtextBox = new System.Windows.Forms.TextBox();
            this.Deqbutton = new System.Windows.Forms.Button();
            this.dconbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 101);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1066, 580);
            this.dataGridView1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panel1.Controls.Add(this.dconbutton);
            this.panel1.Controls.Add(this.Deqbutton);
            this.panel1.Controls.Add(this.Invbutton);
            this.panel1.Controls.Add(this.ConsumeInvbutton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1064, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 681);
            this.panel1.TabIndex = 31;
            // 
            // Invbutton
            // 
            this.Invbutton.Dock = System.Windows.Forms.DockStyle.Top;
            this.Invbutton.FlatAppearance.BorderSize = 0;
            this.Invbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Invbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Invbutton.ForeColor = System.Drawing.Color.Gainsboro;
            this.Invbutton.Location = new System.Drawing.Point(0, 52);
            this.Invbutton.Name = "Invbutton";
            this.Invbutton.Size = new System.Drawing.Size(200, 52);
            this.Invbutton.TabIndex = 30;
            this.Invbutton.Text = "Equipment";
            this.Invbutton.UseVisualStyleBackColor = true;
            this.Invbutton.Click += new System.EventHandler(this.Invbutton_Click_1);
            // 
            // ConsumeInvbutton
            // 
            this.ConsumeInvbutton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ConsumeInvbutton.FlatAppearance.BorderSize = 0;
            this.ConsumeInvbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConsumeInvbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsumeInvbutton.ForeColor = System.Drawing.Color.Gainsboro;
            this.ConsumeInvbutton.Location = new System.Drawing.Point(0, 0);
            this.ConsumeInvbutton.Name = "ConsumeInvbutton";
            this.ConsumeInvbutton.Size = new System.Drawing.Size(200, 52);
            this.ConsumeInvbutton.TabIndex = 29;
            this.ConsumeInvbutton.Text = "Consumable Items";
            this.ConsumeInvbutton.UseVisualStyleBackColor = true;
            this.ConsumeInvbutton.Click += new System.EventHandler(this.Invbutton_Click);
            // 
            // IDSearchlabel
            // 
            this.IDSearchlabel.AutoSize = true;
            this.IDSearchlabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IDSearchlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDSearchlabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.IDSearchlabel.Location = new System.Drawing.Point(22, 32);
            this.IDSearchlabel.Name = "IDSearchlabel";
            this.IDSearchlabel.Size = new System.Drawing.Size(57, 17);
            this.IDSearchlabel.TabIndex = 35;
            this.IDSearchlabel.Text = "ITEM ID";
            // 
            // SearchIDtextBox
            // 
            this.SearchIDtextBox.Location = new System.Drawing.Point(22, 52);
            this.SearchIDtextBox.Name = "SearchIDtextBox";
            this.SearchIDtextBox.Size = new System.Drawing.Size(468, 20);
            this.SearchIDtextBox.TabIndex = 34;
            // 
            // Deqbutton
            // 
            this.Deqbutton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Deqbutton.FlatAppearance.BorderSize = 0;
            this.Deqbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Deqbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Deqbutton.ForeColor = System.Drawing.Color.Gainsboro;
            this.Deqbutton.Location = new System.Drawing.Point(0, 629);
            this.Deqbutton.Name = "Deqbutton";
            this.Deqbutton.Size = new System.Drawing.Size(200, 52);
            this.Deqbutton.TabIndex = 31;
            this.Deqbutton.Text = "Delete Equipment";
            this.Deqbutton.UseVisualStyleBackColor = true;
            this.Deqbutton.Click += new System.EventHandler(this.Deqbutton_Click);
            // 
            // dconbutton
            // 
            this.dconbutton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dconbutton.FlatAppearance.BorderSize = 0;
            this.dconbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dconbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dconbutton.ForeColor = System.Drawing.Color.Gainsboro;
            this.dconbutton.Location = new System.Drawing.Point(0, 577);
            this.dconbutton.Name = "dconbutton";
            this.dconbutton.Size = new System.Drawing.Size(200, 52);
            this.dconbutton.TabIndex = 32;
            this.dconbutton.Text = "Delete Item";
            this.dconbutton.UseVisualStyleBackColor = true;
            this.dconbutton.Click += new System.EventHandler(this.dconbutton_Click);
            // 
            // ViewInvForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.IDSearchlabel);
            this.Controls.Add(this.SearchIDtextBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewInvForm";
            this.Text = "View Inventory";
            this.Load += new System.EventHandler(this.ViewInvForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Invbutton;
        private System.Windows.Forms.Button ConsumeInvbutton;
        private System.Windows.Forms.Label IDSearchlabel;
        private System.Windows.Forms.TextBox SearchIDtextBox;
        private System.Windows.Forms.Button dconbutton;
        private System.Windows.Forms.Button Deqbutton;
    }
}