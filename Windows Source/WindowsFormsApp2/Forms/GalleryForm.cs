using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace WindowsFormsApp2.Forms
{
    public partial class GalleryForm : Form
    {
        public GalleryForm()
        {
            InitializeComponent();
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btns.BackColor = ThemeColor.PrimaryColor;
                    btns.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
                //label1.ForeColor = ThemeColor.SecondaryColor;
                //label2.ForeColor = ThemeColor.PrimaryColor;
            }
        }
        private void GalleryForm_Load(object sender, EventArgs e)
        {
            LoadTheme();
            dataGridView1.DataSource = GetSQLPat();
        }
        private DataTable GetSQLPat()
        {
            DataTable dtPat = new DataTable();
            string connString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;

            using (MySqlConnection con = new MySqlConnection(connString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * from patient;", con))
                {
                    con.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtPat.Load(reader);
                }
            }
            return dtPat;
        }

        private DataTable GetSQLRec()
        {
            DataTable dtPat = new DataTable();
            string connString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;

            using (MySqlConnection con = new MySqlConnection(connString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * from patient_record;", con))
                {
                    con.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtPat.Load(reader);
                }
            }
            return dtPat;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constring = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            string Query = "insert into patient(code,number,name,password,address,phone_number,email) values('"+this.textBox1.Text+"', '"+this.textBox2.Text+"','"+this.textBox3.Text+"','"+this.textBox4.Text+"','"+this.textBox5.Text+"','"+this.textBox6.Text+"','"+this.textBox7.Text+"') ;";
            MySqlConnection conDatabase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDatabase);
            MySqlDataReader myreader;
            try
            {
                conDatabase.Open();
                myreader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Saved");
                while(myreader.Read())
                {

                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetSQLPat();
        }

        private void email_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string constring = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            string Query = "insert into patient_record(code,number,blood_group,DOB,sex,height,weight,allergies,existing_conditions) values('"+this.textBox8.Text+"', '"+this.textBox9.Text+"','"+this.textBox10.Text+"','"+this.textBox11.Text+"','"+this.textBox12.Text+"','"+this.textBox13.Text+"','"+this.textBox14.Text+"','"+this.textBox15.Text+"','"+this.textBox16.Text+"') ;";
            MySqlConnection conDatabase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDatabase);
            MySqlDataReader myreader;
            try
            {
                conDatabase.Open();
                myreader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Saved");
                while (myreader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetSQLRec();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
