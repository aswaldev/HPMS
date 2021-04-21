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
using System.Configuration;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp2.Forms
{
    public partial class ViewPatForm : Form
    {
        public ViewPatForm()
        {
            InitializeComponent();
            Application.EnableVisualStyles();
        }


        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");



        string code = string.Empty;

        private void ViewADbutton_Click(object sender, EventArgs e)
        {
            DataTable dtPat = new DataTable();
            string connString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            MySqlConnection con = new MySqlConnection(connString);
            MySqlCommand cmd = new MySqlCommand("SELECT CONCAT(code,number) as 'Patient ID',name as 'Patient Name',address as Address ,phone_number as 'Phone Number',email as 'e-mail' from patient where code=@code and number=@number;", con);
            //MySqlCommand cmd = new MySqlCommand("SELECT * from patient where code = @code and number = @number ;",con);
            cmd.Parameters.AddWithValue("@code", code);
            cmd.Parameters.AddWithValue("@number", searchNumberbox.Text);
            //MessageBox.Show(code + searchNumberbox.Text);
            con.Open();
            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    dtPat.Load(reader);
                }
                else
                {
                    MessageBox.Show("Entry for patient does not exist.");
                }
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

            con.Close();

            dataGridView1.DataSource = dtPat;
            dataGridView1.ClearSelection();
            

        }

        private void ViewVisbutton_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetSQLRec();
            dataGridView1.ClearSelection();
            


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

        private void button4SearchVisbutton_Click(object sender, EventArgs e)
        {
            code = "";
            ClearControls();
            ClearTextBoxes();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

   



        private void ViewPatForm_Load_2(object sender, EventArgs e)
        {

        }
        
       /* private DataTable GetSQLPat()
        {
            
            
           
        }*/

        private DataTable GetSQLRec()
        {
            DataTable dtPat = new DataTable();
            string connString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;

            using (MySqlConnection con = new MySqlConnection(connString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT CONCAT(code,number) as 'Patient ID',blood_group as 'Blood Group',DOB as 'Date of Birth',sex as 'Sex', height as Height, weight as Weight, allergies as Allergies,existing_conditions as 'Existing Conditions' from patient_record where code=@code and number=@number;", con))
                {
                    cmd.Parameters.AddWithValue("@code", code);
                    cmd.Parameters.AddWithValue("@number", searchNumberbox.Text);
                    con.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dtPat.Load(reader);
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Entry for patient does not exist.");
                        
                    }
                }
            }
            
            return dtPat;
        }
        
        private DataTable GetAppointment()
        {
            DataTable dtPat = new DataTable();
            string connString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;

            using (MySqlConnection con = new MySqlConnection(connString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT ID as 'Appointment ID', CONCAT(code,number) as 'Patient ID', doctor_id as 'Doctor ID',reason as 'Reason',datetime as 'Date and Time' from appointment  where code= @code and number= @number;", con))
                {
                    cmd.Parameters.AddWithValue("@code", code);
                    cmd.Parameters.AddWithValue("@number", searchNumberbox.Text);
                    con.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        
                            dtPat.Load(reader);
                        
                    }
                    else
                    {
                        MessageBox.Show("Entry for patient does not exist.");
                    }
                }
            }
            return dtPat;
        }
        private DataTable GetBill()
        {
            DataTable dtPat = new DataTable();
            string connString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;

            using (MySqlConnection con = new MySqlConnection(connString))
            {
                /// using (MySqlCommand cmd = new MySqlCommand("SELECT CONCAT(code,number) as 'Patient ID',details as Details,cost as Cost, status as Status from bill_details  where code=@code and number=@number;", con))
                using (MySqlCommand cmd = new MySqlCommand("SELECT * from bill_details  where code=@code and number=@number;", con))
                { 
                    cmd.Parameters.AddWithValue("@code", code);
                    cmd.Parameters.AddWithValue("@number", searchNumberbox.Text);
                    con.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dtPat.Load(reader);
                    }
                    else
                    {
                        MessageBox.Show("Entry for patient does not exist.");
                    }
                }
            }
            return dtPat;
        }
        private DataTable GetPres()
        {
            DataTable dtPat = new DataTable();
            string connString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;

            using (MySqlConnection con = new MySqlConnection(connString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT CONCAT(code,number) as 'Patient ID', details as Details  from prescription  where code=@code and number=@number;", con))
                {
                    cmd.Parameters.AddWithValue("@code", code);
                    cmd.Parameters.AddWithValue("@number", searchNumberbox.Text);
                    con.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dtPat.Load(reader);
                    }
                    else
                    {
                        MessageBox.Show("Entry for patient does not exist.");
                    }
                }
            }
            return dtPat;
        }
        private DataTable Gettest()
        {
            DataTable dtPat = new DataTable();
            string connString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;

            using (MySqlConnection con = new MySqlConnection(connString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT ID as 'Test ID', CONCAT(code,number) as 'Patient ID',test_name as 'Test Name',status as Status, report as 'Report Link'  from tests  where code=@code and number=@number;", con))
                {
                    cmd.Parameters.AddWithValue("@code", code);
                    cmd.Parameters.AddWithValue("@number", searchNumberbox.Text);
                    con.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dtPat.Load(reader);
                    }
                    else
                    {
                        MessageBox.Show("Entry for patient does not exist.");
                    }
                }
            }
            return dtPat;
        }
        private DataTable GetSQLTest()
        {
            DataTable dtPat = new DataTable();
            string connString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;

            using (MySqlConnection con = new MySqlConnection(connString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * from bill_details;", con))
                {
                    con.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtPat.Load(reader);
                }
            }
            return dtPat;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetAppointment();
            dataGridView1.ClearSelection();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetBill();
            dataGridView1.ClearSelection();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetPres();
            dataGridView1.ClearSelection();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Gettest();
            dataGridView1.ClearSelection();
            
        }

        private void dataGridView1_MouseLeave(object sender, EventArgs e)
        {
           // dataGridView1.ClearSelection();
           
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
