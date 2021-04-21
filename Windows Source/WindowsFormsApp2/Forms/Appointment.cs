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
    public partial class Appointment : Form
    {
        public Appointment()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now;
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
            if(String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text) || String.IsNullOrEmpty(code))
            {
                MessageBox.Show("Pleaes fill all required fields.");
            }
            else
            {
                string constring = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;

                //string Query = "insert into appointment(code,number,doctor_id,reason,datetime) values('" + this.textBox1.Text + "', '" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "') ;";
                string Query = "insert into appointment(code,number,doctor_id,reason,datetime) values(@code,@number,@doctor_id,@reason,@datetime);";

                MySqlConnection conDatabase = new MySqlConnection(constring);
                conDatabase.Open();
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDatabase);
                cmdDataBase.Parameters.AddWithValue("@code", code);
                cmdDataBase.Parameters.AddWithValue("@number", textBox2.Text);
                cmdDataBase.Parameters.AddWithValue("@doctor_id", textBox3.Text);
                cmdDataBase.Parameters.AddWithValue("@reason", textBox4.Text);
                cmdDataBase.Parameters.AddWithValue("@datetime", dateTimePicker1.Value);
                string Query2 = "select * from doctor where doctor_id = @doc;";
                MySqlConnection conDatabase2 = new MySqlConnection(constring);
                conDatabase2.Open();
                MySqlCommand doctor = new MySqlCommand(Query2, conDatabase2);
                doctor.Parameters.AddWithValue("@doc", textBox3.Text);
                MySqlDataReader reader = doctor.ExecuteReader();
                if (reader.HasRows)
                {
                    try
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "[^0-9]"))
                        {
                            MessageBox.Show("Please enter valid Doctor ID.");
                            return;
                        }
                        cmdDataBase.ExecuteNonQuery();
                        //myreader = cmdDataBase.ExecuteReader();
                        MessageBox.Show("Saved");
                        ClearTextBoxes();
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
                else
                {
                    MessageBox.Show("Please enter existing Doctor ID");
                    conDatabase.Close();
                    conDatabase2.Close();
                }
            }
                    //MySqlDataReader myreader;
                   
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            code = "";
            
            ClearTextBoxes();
            ClearControls();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox6.Text) )
            {
                MessageBox.Show("Please enter Appointment ID and new date to update.");
            }
            else
            {
                string constring = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
                //string Query = "UPDATE appointment set datetime = '" + this.textBox5.Text + "' where id = '" + this.textBox6.Text +"';";
                string Query = "UPDATE appointment set datetime = @date where ID = @id;";
                MySqlConnection conDatabase = new MySqlConnection(constring);
                conDatabase.Open();
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDatabase);
                cmdDataBase.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                cmdDataBase.Parameters.AddWithValue("@id", textBox6.Text);

                string query2 = "select * from appointment where ID = @id2;";

                MySqlConnection conDatabase2 = new MySqlConnection(constring);
                conDatabase2.Open();
                MySqlCommand q2 = new MySqlCommand(query2, conDatabase2);
                q2.Parameters.AddWithValue("@id2", textBox6.Text);
                MySqlDataReader reader = q2.ExecuteReader();
                if (reader.HasRows)
                {
                    try
                    {
                        cmdDataBase.ExecuteNonQuery();
                        // myreader = cmdDataBase.ExecuteReader();
                        MessageBox.Show("Saved");
                        ClearTextBoxes();
                        conDatabase.Close();
                        conDatabase2.Close();
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
                    conDatabase2.Close();
                }
                //MySqlDataReader myreader;
                else
                {
                    MessageBox.Show("Appointment does not exist.");
                    return;
                }   
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

            string Query = "delete from appointment where ID=@id;";

            MySqlConnection conDatabase = new MySqlConnection(constring);
            conDatabase.Open();
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDatabase);
            cmdDataBase.Parameters.AddWithValue("@id",textBox6.Text);
            try
            {
                cmdDataBase.ExecuteNonQuery();
                
                MessageBox.Show("Succesfully Deleted");
                ClearTextBoxes();
               
            }
            catch (MySqlException exe)
            {
               
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

        private void Appointment_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }
    }
}
