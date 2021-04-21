namespace WindowsFormsApp2.Forms
{
    partial class AddInvForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddInvForm));
            this.connametextbox = new System.Windows.Forms.TextBox();
            this.conquantextBox = new System.Windows.Forms.TextBox();
            this.Name_label = new System.Windows.Forms.Label();
            this.Quan_label = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.IDlabel = new System.Windows.Forms.Label();
            this.conIDtextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.eqremtextBox = new System.Windows.Forms.TextBox();
            this.equsedtextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.eqquantextBox = new System.Windows.Forms.TextBox();
            this.eqnametextBox = new System.Windows.Forms.TextBox();
            this.eqidtextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.conremaintextBox = new System.Windows.Forms.TextBox();
            this.conusedtextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // connametextbox
            // 
            this.connametextbox.Location = new System.Drawing.Point(137, 149);
            this.connametextbox.Name = "connametextbox";
            this.connametextbox.Size = new System.Drawing.Size(120, 20);
            this.connametextbox.TabIndex = 0;
            // 
            // conquantextBox
            // 
            this.conquantextBox.Location = new System.Drawing.Point(137, 181);
            this.conquantextBox.Name = "conquantextBox";
            this.conquantextBox.Size = new System.Drawing.Size(120, 20);
            this.conquantextBox.TabIndex = 1;
            // 
            // Name_label
            // 
            this.Name_label.AutoSize = true;
            this.Name_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name_label.ForeColor = System.Drawing.Color.Gainsboro;
            this.Name_label.Location = new System.Drawing.Point(25, 151);
            this.Name_label.Name = "Name_label";
            this.Name_label.Size = new System.Drawing.Size(45, 17);
            this.Name_label.TabIndex = 2;
            this.Name_label.Text = "Name";
            // 
            // Quan_label
            // 
            this.Quan_label.AutoSize = true;
            this.Quan_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quan_label.ForeColor = System.Drawing.Color.Gainsboro;
            this.Quan_label.Location = new System.Drawing.Point(25, 184);
            this.Quan_label.Name = "Quan_label";
            this.Quan_label.Size = new System.Drawing.Size(61, 17);
            this.Quan_label.TabIndex = 3;
            this.Quan_label.Text = "Quantity";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(61)))), ((int)(((byte)(85)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Gainsboro;
            this.button1.Location = new System.Drawing.Point(64, 317);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 47);
            this.button1.TabIndex = 4;
            this.button1.Text = "Enter to Consumable";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // IDlabel
            // 
            this.IDlabel.AutoSize = true;
            this.IDlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDlabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.IDlabel.Location = new System.Drawing.Point(28, 118);
            this.IDlabel.Name = "IDlabel";
            this.IDlabel.Size = new System.Drawing.Size(21, 17);
            this.IDlabel.TabIndex = 6;
            this.IDlabel.Text = "ID";
            // 
            // conIDtextBox
            // 
            this.conIDtextBox.Location = new System.Drawing.Point(137, 115);
            this.conIDtextBox.Name = "conIDtextBox";
            this.conIDtextBox.Size = new System.Drawing.Size(120, 20);
            this.conIDtextBox.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panel1.Controls.Add(this.eqremtextBox);
            this.panel1.Controls.Add(this.equsedtextBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.eqquantextBox);
            this.panel1.Controls.Add(this.eqnametextBox);
            this.panel1.Controls.Add(this.eqidtextBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(728, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 582);
            this.panel1.TabIndex = 32;
            // 
            // eqremtextBox
            // 
            this.eqremtextBox.Location = new System.Drawing.Point(147, 253);
            this.eqremtextBox.Name = "eqremtextBox";
            this.eqremtextBox.Size = new System.Drawing.Size(120, 20);
            this.eqremtextBox.TabIndex = 22;
            // 
            // equsedtextBox
            // 
            this.equsedtextBox.Location = new System.Drawing.Point(147, 218);
            this.equsedtextBox.Name = "equsedtextBox";
            this.equsedtextBox.Size = new System.Drawing.Size(120, 20);
            this.equsedtextBox.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(35, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 20;
            this.label3.Text = "Remaining";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(35, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "Used";
            // 
            // eqquantextBox
            // 
            this.eqquantextBox.Location = new System.Drawing.Point(147, 181);
            this.eqquantextBox.Name = "eqquantextBox";
            this.eqquantextBox.Size = new System.Drawing.Size(120, 20);
            this.eqquantextBox.TabIndex = 13;
            // 
            // eqnametextBox
            // 
            this.eqnametextBox.Location = new System.Drawing.Point(147, 149);
            this.eqnametextBox.Name = "eqnametextBox";
            this.eqnametextBox.Size = new System.Drawing.Size(120, 20);
            this.eqnametextBox.TabIndex = 12;
            // 
            // eqidtextBox
            // 
            this.eqidtextBox.Location = new System.Drawing.Point(147, 115);
            this.eqidtextBox.Name = "eqidtextBox";
            this.eqidtextBox.Size = new System.Drawing.Size(120, 20);
            this.eqidtextBox.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gainsboro;
            this.label5.Location = new System.Drawing.Point(35, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gainsboro;
            this.label6.Location = new System.Drawing.Point(38, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "ID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gainsboro;
            this.label7.Location = new System.Drawing.Point(35, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Quantity";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(61)))), ((int)(((byte)(85)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Gainsboro;
            this.button2.Location = new System.Drawing.Point(74, 317);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(157, 47);
            this.button2.TabIndex = 16;
            this.button2.Text = "Enter to Equipment";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panel2.Controls.Add(this.conremaintextBox);
            this.panel2.Controls.Add(this.conusedtextBox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.conquantextBox);
            this.panel2.Controls.Add(this.connametextbox);
            this.panel2.Controls.Add(this.conIDtextBox);
            this.panel2.Controls.Add(this.Name_label);
            this.panel2.Controls.Add(this.IDlabel);
            this.panel2.Controls.Add(this.Quan_label);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 582);
            this.panel2.TabIndex = 33;
            // 
            // conremaintextBox
            // 
            this.conremaintextBox.Location = new System.Drawing.Point(137, 253);
            this.conremaintextBox.Name = "conremaintextBox";
            this.conremaintextBox.Size = new System.Drawing.Size(120, 20);
            this.conremaintextBox.TabIndex = 11;
            // 
            // conusedtextBox
            // 
            this.conusedtextBox.Location = new System.Drawing.Point(137, 218);
            this.conusedtextBox.Name = "conusedtextBox";
            this.conusedtextBox.Size = new System.Drawing.Size(120, 20);
            this.conusedtextBox.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(25, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Remaining";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(25, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Used";
            // 
            // AddInvForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(1028, 582);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddInvForm";
            this.Text = "Add Inventory";
            this.Load += new System.EventHandler(this.AddInvForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox connametextbox;
        private System.Windows.Forms.TextBox conquantextBox;
        private System.Windows.Forms.Label Name_label;
        private System.Windows.Forms.Label Quan_label;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label IDlabel;
        private System.Windows.Forms.TextBox conIDtextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox eqremtextBox;
        private System.Windows.Forms.TextBox equsedtextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox eqquantextBox;
        private System.Windows.Forms.TextBox eqnametextBox;
        private System.Windows.Forms.TextBox eqidtextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox conremaintextBox;
        private System.Windows.Forms.TextBox conusedtextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}