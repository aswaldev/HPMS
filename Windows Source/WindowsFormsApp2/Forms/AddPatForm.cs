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
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
namespace WindowsFormsApp2.Forms
{
   
    public partial class AddPatForm : Form
    {
        public AddPatForm()
        {
            InitializeComponent();
            //refresh_DataGridView();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker3.Value = DateTime.Now;
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
                
            }
        }
        private void AddPatForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseDataSet.Employee' table. You can move, or remove it, as needed.
           // this.employeeTableAdapter.Fill(this.databaseDataSet.Employee);
            LoadTheme();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker3.Value = DateTime.Now;
            dateTimePicker1.MaxDate = DateTime.Today;
            dateTimePicker1.MinDate = new DateTime(1900, 1, 1);
            this.textBox2.Enter += new EventHandler(textBox2_Enter);
            this.textBox2.Leave += new EventHandler(textBox2_Leave);
            textBox2_SetText();
        }
        protected void textBox2_SetText()
        {
            this.textBox2.Text = "Patient Number for Outdate";
            textBox2.ForeColor = Color.Gray;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.ForeColor == Color.Black)
                return;
            textBox2.Text = "";
            textBox2.ForeColor = Color.Black;
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "")
                textBox2_SetText();
        }

        private void labelHeight_feet_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            LoadTheme();
        }
        

       


       

       
        private void labelResgister_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

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
            if (code == "INP")
            {
                if (String.IsNullOrWhiteSpace(textBox3.Text) || String.IsNullOrWhiteSpace(textBox5.Text) || String.IsNullOrWhiteSpace(textBox6.Text) || String.IsNullOrWhiteSpace(textBox7.Text) || String.IsNullOrWhiteSpace(textBox8.Text) || String.IsNullOrWhiteSpace(textBox9.Text) || String.IsNullOrWhiteSpace(code) || String.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Pleaes fill all required fields.");
                }
                else
                {
                    string constring = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
                    // string Query = "insert into patient_record(code,number,blood_group,DOB,sex,height,weight,allergies,existing_conditions) values('" + this.textBox1.Text + "', '" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + this.textBox6.Text + "','" + this.textBox7.Text + "','" + this.textBox8.Text + "','" + this.textBox9.Text + "') ;";
                    string Query = "insert into patient_record(code,number,in_date,out_date,room_no,blood_group,DOB,sex,height,weight,allergies,existing_conditions) values(@code,@number,@in,@out,@room,@blood_group,@DOB,@sex,@height,@weight,@allergies,@existing_conditions);";

                    MySqlConnection conDatabase = new MySqlConnection(constring);
                    conDatabase.Open();
                    MySqlCommand cmdDataBase = new MySqlCommand(Query, conDatabase);
                    string maxnum = "select Max(number) as m from patient_record where code= @code2;";

                    MySqlCommand maxnumber = new MySqlCommand(maxnum, conDatabase);
                    maxnumber.Parameters.AddWithValue("@code2", code);
                    SqlDataReader usernameRdr = null;
                    int maxID = (Int32)maxnumber.ExecuteScalar();
                    int maxreal = ++maxID;
                    string maxidpad;
                    maxidpad = String.Format("{0:D5}", maxreal);

                    cmdDataBase.Parameters.AddWithValue("@code", code);
                    cmdDataBase.Parameters.AddWithValue("@number", maxidpad);
                    cmdDataBase.Parameters.AddWithValue("@in", dateTimePicker2.Value.Date);
                    cmdDataBase.Parameters.AddWithValue("@out", dateTimePicker3.Value.Date);
                    cmdDataBase.Parameters.AddWithValue("@room", textBox1.Text);
                    cmdDataBase.Parameters.AddWithValue("@blood_group", textBox3.Text);
                    cmdDataBase.Parameters.AddWithValue("@DOB", dateTimePicker1.Value.Date);
                    cmdDataBase.Parameters.AddWithValue("@sex", textBox5.Text);
                    cmdDataBase.Parameters.AddWithValue("@height", textBox6.Text);
                    cmdDataBase.Parameters.AddWithValue("@weight", textBox7.Text);
                    cmdDataBase.Parameters.AddWithValue("@allergies", textBox8.Text);
                    cmdDataBase.Parameters.AddWithValue("@existing_conditions", textBox9.Text);


                    //MySqlDataReader myreader;
                    try
                    {
                        if (!System.Text.RegularExpressions.Regex.IsMatch(textBox6.Text, "^[+-]?([0-9]*[.])?[0-9]+$"))
                        {
                            MessageBox.Show("Please enter valid value for height.");
                            return;
                        }
                        if (!System.Text.RegularExpressions.Regex.IsMatch(textBox7.Text, "^[+-]?([0-9]*[.])?[0-9]+$"))
                        {
                            MessageBox.Show("Please enter valid value for weight.");
                            return;
                        }
                        //myreader = cmdDataBase.ExecuteReader();
                        cmdDataBase.ExecuteNonQuery();
                        string patient = code + maxID.ToString();
                        MessageBox.Show("Patient " + maxidpad + " has been added.");
                        ClearTextBoxes();
                        ClearControls();
                        /*while (myreader.Read())
                        {

                        }*/
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    conDatabase.Close();
                }
            }
            else if(code == "OUP")
            {
                if (String.IsNullOrWhiteSpace(textBox3.Text) || String.IsNullOrWhiteSpace(textBox5.Text) || String.IsNullOrWhiteSpace(textBox6.Text) || String.IsNullOrWhiteSpace(textBox7.Text) || String.IsNullOrWhiteSpace(textBox8.Text) || String.IsNullOrWhiteSpace(textBox9.Text) || String.IsNullOrWhiteSpace(code) )
                {
                    MessageBox.Show("Pleaes fill all required fields.");
                }
                else
                {
                    string constring = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
                    // string Query = "insert into patient_record(code,number,blood_group,DOB,sex,height,weight,allergies,existing_conditions) values('" + this.textBox1.Text + "', '" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + this.textBox6.Text + "','" + this.textBox7.Text + "','" + this.textBox8.Text + "','" + this.textBox9.Text + "') ;";
                    string Query = "insert into patient_record(code,number,blood_group,DOB,sex,height,weight,allergies,existing_conditions) values(@code,@number,@blood_group,@DOB,@sex,@height,@weight,@allergies,@existing_conditions);";

                    MySqlConnection conDatabase = new MySqlConnection(constring);
                    conDatabase.Open();
                    MySqlCommand cmdDataBase = new MySqlCommand(Query, conDatabase);
                    string maxnum = "select Max(number) as m from patient_record where code= @code2;";

                    MySqlCommand maxnumber = new MySqlCommand(maxnum, conDatabase);
                    maxnumber.Parameters.AddWithValue("@code2", code);
                    SqlDataReader usernameRdr = null;
                    int maxID = (Int32)maxnumber.ExecuteScalar();
                    int maxreal = ++maxID;
                    string maxidpad;
                    maxidpad = String.Format("{0:D5}", maxreal);

                    cmdDataBase.Parameters.AddWithValue("@code", code);
                    cmdDataBase.Parameters.AddWithValue("@number", maxidpad);
                    //cmdDataBase.Parameters.AddWithValue("@in", dateTimePicker2.Value.Date);
                    //cmdDataBase.Parameters.AddWithValue("@out", dateTimePicker3.Value.Date);
                    //cmdDataBase.Parameters.AddWithValue("@room", textBox1.Text);
                    cmdDataBase.Parameters.AddWithValue("@blood_group", textBox3.Text);
                    cmdDataBase.Parameters.AddWithValue("@DOB", dateTimePicker1.Value.Date);
                    cmdDataBase.Parameters.AddWithValue("@sex", textBox5.Text);
                    cmdDataBase.Parameters.AddWithValue("@height", textBox6.Text);
                    cmdDataBase.Parameters.AddWithValue("@weight", textBox7.Text);
                    cmdDataBase.Parameters.AddWithValue("@allergies", textBox8.Text);
                    cmdDataBase.Parameters.AddWithValue("@existing_conditions", textBox9.Text);


                    //MySqlDataReader myreader;
                    try
                    {
                        if (!System.Text.RegularExpressions.Regex.IsMatch(textBox6.Text, "^[+-]?([0-9]*[.])?[0-9]+$"))
                        {
                            MessageBox.Show("Please enter valid value for height.");
                            return;
                        }
                        if (!System.Text.RegularExpressions.Regex.IsMatch(textBox7.Text, "^[+-]?([0-9]*[.])?[0-9]+$"))
                        {
                            MessageBox.Show("Please enter valid value for weight.");
                            return;
                        }
                        //myreader = cmdDataBase.ExecuteReader();
                        cmdDataBase.ExecuteNonQuery();
                        string patient = code + maxID.ToString();
                        MessageBox.Show("Patient " + patient + " has been added.");
                        ClearTextBoxes();
                        ClearControls();
                        conDatabase.Close();
                        /*while (myreader.Read())
                        {

                        }*/
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
                MessageBox.Show("Pleaes fill all required fields.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            code = "";
            ClearTextBoxes();
            code = string.Empty;
            
            ClearControls();
            
        }
     

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                code = "INP";
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                code = "OUP";
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            
           
            string constring = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            string Query = "update patient_record set out_date = @out where number = @num and code = @code;";
            string readerquery = "select * from patient_record where number=@num2 and code = @code2;";
            string code = textBox2.Text.Substring(0, Math.Min(textBox2.Text.Length, 3));
            string number = textBox2.Text.Substring(Math.Min(textBox2.Text.Length,3), Math.Min(Math.Max(textBox2.Text.Length - 3, 0),5));
            //MessageBox.Show("Code=" + code + " and Number=" + number);
            MySqlConnection conDatabase = new MySqlConnection(constring);
            conDatabase.Open();
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDatabase);
            
            cmdDataBase.Parameters.AddWithValue("@code", code);
            cmdDataBase.Parameters.AddWithValue("@num", number);
            cmdDataBase.Parameters.AddWithValue("@out", dateTimePicker3.Value.Date);

            MySqlConnection conDatabase2 = new MySqlConnection(constring);
            conDatabase2.Open();
            MySqlCommand readquery = new MySqlCommand(readerquery, conDatabase2);
            readquery.Parameters.AddWithValue("@code2", code);
            readquery.Parameters.AddWithValue("@num2", number);
            if (number.Length != 5 || !System.Text.RegularExpressions.Regex.IsMatch(number, "[0-9]") || code != "INP")
            {
                MessageBox.Show("Please enter a valid Patient ID for update.");
                ClearTextBoxes();
                conDatabase.Close();
                return;
            }
            else
            {
                try
                {
                    //if (!System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "^INP\d{5}$"))
                    //MessageBox.Show("CODE=" + code + " Number=" + number);
                    MySqlDataReader reader = readquery.ExecuteReader();
                    if (reader.HasRows)
                    {
                        cmdDataBase.ExecuteNonQuery();
                        MessageBox.Show("Outdate for Patient " + code + number + " has been updated.");
                        ClearTextBoxes();
                        conDatabase.Close();
                        conDatabase2.Close();
                    }
                    else
                    {
                        MessageBox.Show("Entry for patient does not exist.");
                        ClearTextBoxes();
                        conDatabase.Close();
                        conDatabase2.Close();
                    }
                    
                }
                catch (MySqlException exe)
                {
                    // MessageBox.Show(exe.Number.ToString());    //debug statement for sql error code
                    switch (exe.Number)
                    {
                        case 1452:
                            MessageBox.Show("Record for Patient does not exist, please generate Patient ID first.");
                            conDatabase.Close();
                            break;
                        case 1062:
                            MessageBox.Show("Entry for Patient already exists.");
                            conDatabase.Close();
                            break;
                        default:
                            MessageBox.Show(exe.Message);
                            conDatabase.Close();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conDatabase.Close();
                }
                conDatabase.Close();
                conDatabase2.Close();
            }
            
        }
    }
}
