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
    public partial class Prescription : Form
    {
        public Prescription()
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
            if(String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(code))
            {
                MessageBox.Show("Please fill all required fields.");

            }
            else
            {
                string constring = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
                //string Query = "insert into prescription(code,number,details) values('" + this.textBox1.Text + "', '" + this.textBox2.Text + "','" + this.textBox3.Text + "') ;";
                string Query = "insert into prescription(code,number,details) values(@code,@number,@details);";
                MySqlConnection conDatabase = new MySqlConnection(constring);
                conDatabase.Open();
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDatabase);
                cmdDataBase.Parameters.AddWithValue("@code", code);
                cmdDataBase.Parameters.AddWithValue("@number", textBox2.Text);
                cmdDataBase.Parameters.AddWithValue("@details", textBox3.Text);
                //MySqlDataReader myreader;
                try
                {

                    //myreader = cmdDataBase.ExecuteReader();
                    cmdDataBase.ExecuteNonQuery();
                    MessageBox.Show("Saved");
                    ClearTextBoxes();
                    ClearControls();
                    /*while (myreader.Read())
                    {

                    }*/
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
            ClearTextBoxes();
            ClearControls();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(code))
            {
                MessageBox.Show("Please fill all required fields.");

            }
            else
            {
                string constring = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
                //string Query = "update prescription set details = concat(details,\", \" ,@details  )  where code =@code and number = @number;";
                string Query = "update prescription set details = @details where code =@code and number = @number;";
                MySqlConnection conDatabase = new MySqlConnection(constring);
                conDatabase.Open();

                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDatabase);
                cmdDataBase.Parameters.AddWithValue("@code", code);
                cmdDataBase.Parameters.AddWithValue("@number", textBox2.Text);
                cmdDataBase.Parameters.AddWithValue("@details", textBox3.Text);

                string query2 = "select * from prescription where code = @code2 and number = @number2;";
                MySqlConnection conDatabase2 = new MySqlConnection(constring);
                conDatabase2.Open();
                MySqlCommand q2 = new MySqlCommand(query2, conDatabase2);
                q2.Parameters.AddWithValue("@code2", code);
                q2.Parameters.AddWithValue("@number2", textBox2.Text);
                MySqlDataReader readPres = q2.ExecuteReader();

                if (readPres.HasRows)
                {
                    //MySqlDataReader myreader;
                    try
                    {
                        // myreader = cmdDataBase.ExecuteReader();
                        cmdDataBase.ExecuteNonQuery();
                        MessageBox.Show("Saved");
                        ClearTextBoxes();
                        ClearControls();
                        conDatabase.Close();
                        conDatabase2.Close();
                        //while (myreader.Read())
                        //{

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
                else
                {
                    MessageBox.Show("Prescription Not found.");
                }
                conDatabase.Close();
                conDatabase2.Close();
                    
            }
            

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

        private void button2_Click(object sender, EventArgs e)
        {
            string constring = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            MySqlConnection conDatabase = new MySqlConnection(constring);
            conDatabase.Open();

            string getPres = "select details from prescription where code = @code and number = @number;";
            MySqlCommand getPrescmd = new MySqlCommand(getPres, conDatabase);
            getPrescmd.Parameters.AddWithValue("@code", code);
            getPrescmd.Parameters.AddWithValue("@number", textBox2.Text);
            getPrescmd.Parameters.AddWithValue("@details", textBox3.Text);
            try
            {
                MySqlDataReader readPres = getPrescmd.ExecuteReader();
                if (readPres.Read())
                {
                    textBox3.Text = readPres.GetValue(0).ToString();
                    MessageBox.Show("Patient Prescription Found");
                }
                else
                {
                    MessageBox.Show("Patient Prescription Not Found");
                    
                    ClearTextBoxes();
                    ClearControls();
                    return;
                }
                
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
}
