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
    public partial class bills : Form
    {
        public bills()
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
            status = "";
            code = "";
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
        string status = string.Empty;
        private void buttonaddIn_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text) || String.IsNullOrEmpty(code) || String.IsNullOrEmpty(status) || status == "clear" || code == "clear" )
            {
                MessageBox.Show("Pleaes fill all required fields.");
            }
            else
            {
                string constring = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
                //string Query = "insert into bill_details(code,number,details,cost,status) values('" + this.textBox1.Text + "', '" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "') ;";
                string Query = "insert into bill_details(code,number,details,cost,status) values(@code,@number,@details,@cost,@status) ;";

                MySqlConnection conDatabase = new MySqlConnection(constring);
                conDatabase.Open();
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDatabase);
                cmdDataBase.Parameters.AddWithValue("@code", code);
                cmdDataBase.Parameters.AddWithValue("@number", textBox2.Text);
                cmdDataBase.Parameters.AddWithValue("@details", textBox3.Text);
                cmdDataBase.Parameters.AddWithValue("@cost", textBox4.Text);
                cmdDataBase.Parameters.AddWithValue("@status", status);
                //MySqlDataReader myreader;
                try
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "[^0-9]"))
                    {
                        MessageBox.Show("Please enter correct value for cost.");
                        return;
                    }
                    cmdDataBase.ExecuteNonQuery();
                    //  myreader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("Saved");
                    ClearTextBoxes();
                    ClearControls();
                    //while (myreader.Read())
                    //{
                    //
                    //}
                }
                catch (MySqlException exe)
                {
                    //MessageBox.Show(exe.Number.ToString());    //debug statement for sql error code
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

        private void button3_Click(object sender, EventArgs e)
        {
            code = "";
            status = "";
            ClearTextBoxes();
            ClearControls();
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

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
                status = "Paid";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
                status = "Unpaid";
        }
    }
}
