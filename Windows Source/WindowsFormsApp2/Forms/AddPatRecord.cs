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
using System.Text.RegularExpressions;
using System.Globalization;

namespace WindowsFormsApp2.Forms
{
    public partial class AddPatDetail : Form
    {
        public AddPatDetail()
        {
            InitializeComponent();
        }
        private void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }
        private void ClearControls()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is RadioButton)
                        (control as RadioButton).Checked = false;
                    else
                        func(control.Controls);
            };

            func(Controls);
        }
        string code = string.Empty;
        private void buttonaddIn_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text) || String.IsNullOrEmpty(textBox5.Text) || String.IsNullOrEmpty(textBox6.Text) || String.IsNullOrEmpty(textBox7.Text) || String.IsNullOrEmpty(code))
            {
                MessageBox.Show("Pleaes fill all required fields.");
            }
            else
            {
                string constring = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;

                //string Query = "insert into patient(code,number,name,password,address,phone_number,email) values('" + this.textBox1.Text + "', '" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + this.textBox6.Text + "','" + this.textBox7.Text + "') ;";
                string Query = "insert into patient(code,number,name,password,address,phone_number,email) values(@code,@number,@name,@password,@address,@phone_number,@email) ;";
                MySqlConnection conDatabase = new MySqlConnection(constring);
                conDatabase.Open();
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDatabase);
                cmdDataBase.Parameters.AddWithValue("@code", code);
                cmdDataBase.Parameters.AddWithValue("@number", textBox2.Text);
                cmdDataBase.Parameters.AddWithValue("@name", textBox3.Text);
                cmdDataBase.Parameters.AddWithValue("@password", textBox4.Text);
                cmdDataBase.Parameters.AddWithValue("@address", textBox5.Text);
                cmdDataBase.Parameters.AddWithValue("@phone_number", textBox6.Text);
                cmdDataBase.Parameters.AddWithValue("@email", textBox7.Text);
                //MySqlDataReader myreader;


                try
                {
                    int flag = 0;
                    string email = textBox7.Text;
                    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    Match match = regex.Match(email);
                    if (System.Text.RegularExpressions.Regex.IsMatch(textBox6.Text, "[^0-9]"))
                    {
                        MessageBox.Show("Please enter valid phone number.");
                        return;
                    }
                    if (match.Success)
                    {
                        flag++;
                    }
                    else
                    {
                        MessageBox.Show("Please Enter a valid email");
                        return;
                    }

                    if (flag == 1)
                    {
                        cmdDataBase.ExecuteNonQuery();
                        MessageBox.Show("Patient Details for " + code + textBox2.Text + " has been added to the database");
                        ClearTextBoxes();
                        ClearControls();
                    }


                    /*while (myreader.Read())
                    {

                    }*/
                }
                catch (MySqlException exe)
                {
                    // MessageBox.Show(exe.Number.ToString());    //debug statement for sql error code
                    switch (exe.Number)
                    {
                        case 1452:
                            MessageBox.Show("Record for Patient does not exist, please generate Patient ID first.");
                            break;
                        case 1062:
                            MessageBox.Show("Entry for Patient already exists.");
                            break;
                        default:
                            MessageBox.Show(exe.Message);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                conDatabase.Close();
            }
            
        }

        private void AddPatDetail_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            code = "";
            ClearTextBoxes();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                code = "INP";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                code = "OUP";
        }
    }
}
