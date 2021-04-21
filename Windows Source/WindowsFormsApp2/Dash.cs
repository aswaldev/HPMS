using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Dash : Form
    {
        //Fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;

        public Dash()
        {
            InitializeComponent();
            Application.EnableVisualStyles();
            this.WindowState = FormWindowState.Maximized;
            random = new Random();
            resetbutton.Visible = false;
            
        }

   

  


        private void DisableButton()
        {
            foreach (Control previousBtn in DashPanel.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {

                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }


        private void OpenAboutMenu(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButtonAbout(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.ContentPanel.Controls.Add(childForm);
            this.ContentPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            Titlelabel.Text = childForm.Text;
        }




        private void OpenAddInv(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButtonAddInv(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.ContentPanel.Controls.Add(childForm);
            this.ContentPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            Titlelabel.Text = childForm.Text;

        }
        private void OpenViewInv(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButtonViewInv(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.ContentPanel.Controls.Add(childForm);
            this.ContentPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            Titlelabel.Text = childForm.Text;

        }
        private void OpenGallery(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButtonGallery(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.ContentPanel.Controls.Add(childForm);
            this.ContentPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            Titlelabel.Text = childForm.Text;

        }
        private void OpenPatDetails(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButtonPatDetails(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.ContentPanel.Controls.Add(childForm);
            this.ContentPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            Titlelabel.Text = childForm.Text;

        }



        private void ActivateButtonPatDetails(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = ColorTranslator.FromHtml("#4caf50");
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    //TitlePanel.BackColor = ColorTranslator.FromHtml("#334C4A");

                    //LogoPanel.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    //ThemeColor.PrimaryColor = color;
                    //ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    resetbutton.Visible = true;
                }
            }
        }

        private void ActivateButtonAbout(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = ColorTranslator.FromHtml("#4caf50");
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    TitlePanel.BackColor = color;

                    LogoPanel.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    resetbutton.Visible = true;
                }
            }
        }
        
        private void ActivateButtonAddInv(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = ColorTranslator.FromHtml("#4caf50");
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    TitlePanel.BackColor = color;

                    LogoPanel.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    resetbutton.Visible = true;
                }
            }
        }
        private void ActivateButtonViewInv(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = ColorTranslator.FromHtml("#4caf50");
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    TitlePanel.BackColor = color;

                    LogoPanel.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    resetbutton.Visible = true;
                }
            }
        }
        private void ActivateButtonGallery(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = ColorTranslator.FromHtml("#4caf50");
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    TitlePanel.BackColor = color;

                    LogoPanel.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    resetbutton.Visible = true;
                }
            }
        }

        private void AddPat_button_Click(object sender, EventArgs e)
        {
            OpenPatDetails(new Forms.AddPatForm(), sender);
            
        }

        private void ViewPat_button_Click(object sender, EventArgs e)
        {
            OpenPatDetails(new Forms.ViewPatForm(), sender);
        }

        private void AddInv_button_Click(object sender, EventArgs e)
        {
            OpenAddInv(new Forms.AddInvForm(), sender);
        }

        private void ViewInv_button_Click(object sender, EventArgs e)
        {
            OpenViewInv(new Forms.ViewInvForm(), sender);
        }

        private void GalleryButton_Click(object sender, EventArgs e)
        {
            OpenGallery(new Forms.GalleryForm(), sender);
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            
            OpenAboutMenu(new Forms.AboutForm(), sender);
        }

        private void ContentPanel_Paint(object sender, PaintEventArgs e)
        {
            

        }

        private void Titlelabel_Click(object sender, EventArgs e)
        {

        }

        private void Dash_Load_1(object sender, EventArgs e)
        {
        }

        private void resetbutton_Click(object sender, EventArgs e)
        {
            if(activeForm!=null)
            {
                activeForm.Close();
                Reset();
            }
        }
        private void Reset()
        {
            DisableButton();
            Titlelabel.Text = "HOME";
            TitlePanel.BackColor = Color.FromArgb(51, 51, 76);
            LogoPanel.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            resetbutton.Visible = false;
        }

        private void GalleryButton_Click_1(object sender, EventArgs e)
        {
            OpenPatDetails(new Forms.Appointment(), sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenPatDetails(new Forms.AddPatDetail(), sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenPatDetails(new Forms.bills(), sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenPatDetails(new Forms.Prescription(), sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenPatDetails(new Forms.Tests(), sender);
        }

    }
}
