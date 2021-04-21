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
    public partial class Tests : Form
    {
        public Tests()
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
        string status = null;
        private void buttonaddIn_Click(object sender, EventArgs e)
        {
            if(status == "Pending")
            {
                if (String.IsNullOrWhiteSpace(textBox2.Text) || String.IsNullOrWhiteSpace(textBox3.Text))
                {
                    MessageBox.Show("Please fill all required fields.");
                }
                else
                {
                    string constring = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
                    //string Query = "insert into tests(code,number,test_name,status,report) values('" + this.textBox1.Text + "', '" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "') ;";
                    string Query = "insert into tests(code,number,test_name,status,report) values(@code,@number,@test_name,@status,@report) ;";

                    MySqlConnection conDatabase = new MySqlConnection(constring);
                    conDatabase.Open();
                    MySqlCommand cmdDataBase = new MySqlCommand(Query, conDatabase);
                    cmdDataBase.Parameters.AddWithValue("@code", code);
                    cmdDataBase.Parameters.AddWithValue("@number", textBox2.Text);
                    cmdDataBase.Parameters.AddWithValue("@test_name", textBox3.Text);
                    cmdDataBase.Parameters.AddWithValue("@status", status);
                    cmdDataBase.Parameters.AddWithValue("@report", textBox5.Text);
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
            else if(status == "Available")
            {
                if (String.IsNullOrWhiteSpace(textBox2.Text) || String.IsNullOrWhiteSpace(textBox3.Text) || String.IsNullOrWhiteSpace(textBox5.Text))
                {
                    MessageBox.Show("Please fill all required fields.");
                }
                else
                {
                    string constring = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
                    //string Query = "insert into tests(code,number,test_name,status,report) values('" + this.textBox1.Text + "', '" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "') ;";
                    string Query = "insert into tests(code,number,test_name,status,report) values(@code,@number,@test_name,@status,@report) ;";

                    MySqlConnection conDatabase = new MySqlConnection(constring);
                    conDatabase.Open();
                    MySqlCommand cmdDataBase = new MySqlCommand(Query, conDatabase);
                    cmdDataBase.Parameters.AddWithValue("@code", code);
                    cmdDataBase.Parameters.AddWithValue("@number", textBox2.Text);
                    cmdDataBase.Parameters.AddWithValue("@test_name", textBox3.Text);
                    cmdDataBase.Parameters.AddWithValue("@status", status);
                    cmdDataBase.Parameters.AddWithValue("@report", textBox5.Text);
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
            else
            {
                MessageBox.Show("Please fill all required fields.");
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            status = "";
            code = "";
            ClearTextBoxes();
            ClearControls();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                
                    string constring = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
                    string Query = "";
            string Query2 = "select * from tests where id=@id2";
                    //string Query2 = "";
            MySqlConnection conDatabase = new MySqlConnection(constring);
            MySqlConnection conDatabase2 = new MySqlConnection(constring);
            MySqlCommand q2 = new MySqlCommand(Query2, conDatabase);
            q2.Parameters.AddWithValue("@id2", idbox.Text);
            //MySqlConnection conDatabase2 = new MySqlConnection(constring);
            conDatabase.Open();
            conDatabase2.Open();
            if (!String.IsNullOrWhiteSpace(textBox5.Text) && !String.IsNullOrWhiteSpace(status))
            {
                if (String.IsNullOrWhiteSpace(idbox.Text))
                {
                    MessageBox.Show("Please Enter ID for update.");

                }
                else
                {
                    Query = "update tests set report = @report,status = @status where id=@id;";
                    
                    MySqlCommand cmdDataBase = new MySqlCommand(Query, conDatabase);
                    cmdDataBase.Parameters.AddWithValue("@report", textBox5.Text);
                    cmdDataBase.Parameters.AddWithValue("@status", status);
                    cmdDataBase.Parameters.AddWithValue("@id", idbox.Text);
                    MySqlDataReader reader = q2.ExecuteReader();
                    if (reader.HasRows)
                    {
                        try
                        {

                            cmdDataBase.ExecuteNonQuery();
                            MessageBox.Show("Report and Status Updated");
                            ClearTextBoxes();
                            ClearControls();
                            conDatabase.Close();
                            conDatabase2.Close();

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
                    }
                    else
                    {
                        MessageBox.Show("Test not found.");
                        conDatabase.Close();
                        conDatabase2.Close();
                        return;
                    }


                }


            }
            else if (!String.IsNullOrWhiteSpace(textBox5.Text))
            {
                if (String.IsNullOrWhiteSpace(idbox.Text))
                {
                    MessageBox.Show("Please Enter ID for update.");

                }
                else
                {
                    Query = "update tests set report = @report where id=@id;";

                    MySqlCommand cmdDataBase = new MySqlCommand(Query, conDatabase);
                    cmdDataBase.Parameters.AddWithValue("@report", textBox5.Text);
                    cmdDataBase.Parameters.AddWithValue("@id", idbox.Text);
                    MySqlDataReader reader = q2.ExecuteReader();
                    if (reader.HasRows)
                    {
                        try
                        {

                            //myreader = cmdDataBase.ExecuteReader();
                            cmdDataBase.ExecuteNonQuery();
                            MessageBox.Show("Report Updated");
                            ClearTextBoxes();
                            ClearControls();
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
                            conDatabase.Close();
                            conDatabase2.Close();
                        }
                    }
                    //MySqlDataReader myreader;
                    else
                    {
                        MessageBox.Show("Test not found.");
                        conDatabase.Close();
                        conDatabase2.Close();
                        return;
                    }


                }

            }
            else if (!String.IsNullOrWhiteSpace(status))
            {
                if (String.IsNullOrWhiteSpace(idbox.Text))
                {
                    MessageBox.Show("Please Enter ID for update.");

                }
                else
                {
                    Query = "update tests set status = @status where id=@id;";


                    MySqlCommand cmdDataBase = new MySqlCommand(Query, conDatabase);
                    cmdDataBase.Parameters.AddWithValue("@status", status);
                    cmdDataBase.Parameters.AddWithValue("@id", idbox.Text);

                    //MySqlDataReader myreader;
                    MySqlDataReader reader = q2.ExecuteReader();
                    if (reader.HasRows)
                    {
                        try
                        {

                            //myreader = cmdDataBase.ExecuteReader();
                            cmdDataBase.ExecuteNonQuery();
                            MessageBox.Show("Status Saved");
                            ClearTextBoxes();
                            ClearControls();
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
                            conDatabase.Close();
                            conDatabase2.Close();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Test not found.");
                        conDatabase.Close();
                        conDatabase2.Close();
                        return;
                    }

                }

            }
         conDatabase.Close();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
                status = "Pending";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
                status = "Available";
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

            string Query = "delete from tests where ID=@id;";

            MySqlConnection conDatabase = new MySqlConnection(constring);
            conDatabase.Open();
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDatabase);
            cmdDataBase.Parameters.AddWithValue("@id", idbox.Text);
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
    }
}
