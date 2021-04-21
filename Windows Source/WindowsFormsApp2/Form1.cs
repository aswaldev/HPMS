using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace WindowsFormsApp2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            Application.EnableVisualStyles();
            this.WindowState = FormWindowState.Maximized;
            TitlepictureBox.Dock = DockStyle.Fill;
            labelError.Hide();
        }

        ///string constring = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
        ///MySqlConnection con = new MySqlConnection(constring);
        ///MySqlDataReader dr;
        /*private String getUsername()
        {
            //fetch database data
            con.Open();
            String syntax = "SELECT Value FROM SystemCred where Property='Username'";
            MySqlCommand cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            String temp = dr[0].ToString();
            con.Close();
            return temp;
        }
        private String getPassword()
        {
            //fetch database data
            con.Open();
            String syntax = "SELECT Value FROM SystemCred where Property='Password'";
            MySqlCommand cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            String temp = dr[0].ToString();
            con.Close();
            return temp;

        }*/

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            /*String Uname = getUsername(), Upass = getPassword(), name, pass;
            name = userTextBox.Text;
            pass = passTextBox.Text;

            if (name.Equals(Uname) && pass.Equals(Upass))
            {
                labelError.Hide();

                Dash obj = new Dash();
               
                obj.Closed += (s, args) => this.Close();
                obj.Show();
                this.Hide();
                
            }
            else
            {
                labelError.Show();
            }*/



            string constring = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;

            string Query = "select * from staff where staff_id = @staff and password=@pass;";
            MySqlConnection conDatabase = new MySqlConnection(constring);
            conDatabase.Open();
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDatabase);
            cmdDataBase.Parameters.AddWithValue("@staff", userTextBox.Text);
            cmdDataBase.Parameters.AddWithValue("@pass", passTextBox.Text);
            try
            {
                MySqlDataReader reader = cmdDataBase.ExecuteReader();
                if (reader.Read())
                {
                    labelError.Hide();

                    Dash obj = new Dash();

                    obj.Closed += (s, args) => this.Close();
                    obj.Show();
                    this.Hide();
                    conDatabase.Close();
                }
                else
                {
                    labelError.Show();
                    conDatabase.Close();
                    return;
                    
                }
            }
            catch (Exception ex)
            {
                labelError.Show();
            }
            conDatabase.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Application.EnableVisualStyles();
        }
    }
}
