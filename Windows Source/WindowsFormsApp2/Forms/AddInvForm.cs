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

namespace WindowsFormsApp2.Forms
{
    public partial class AddInvForm : Form
    {
        public AddInvForm()
        {
            InitializeComponent();
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
       

        private void AddInvForm_Load(object sender, EventArgs e)
        {
            LoadTheme();
            refresh_DataGridView();
        }

       public void UpdateDatabase(System.Data.DataSet DS)
        {

        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
        public void refresh_DataGridView()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetItem", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                
                con.Open();

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("             <<<INVALID SQL OPERATION>>>: \n" + ex);
                }
                con.Close();

                //dataGridView1.DataSource = DS.Tables[0];
            
            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("InvProc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", conIDtextBox.Text);
            cmd.Parameters.AddWithValue("@Item_Name", connametextbox.Text);
            cmd.Parameters.AddWithValue("@Item_Received", conquantextBox.Text); 
            cmd.Parameters.AddWithValue("@Item_Used", conusedtextBox.Text);
            cmd.Parameters.AddWithValue("@Item_Remaining", conremaintextBox.Text);

            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("             <<<INVALID SQL OPERATION>>>: \n" + ex);
            }
            con.Close();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("EquipProc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", eqidtextBox.Text);
            cmd.Parameters.AddWithValue("@Item_Name", eqnametextBox.Text);
            cmd.Parameters.AddWithValue("@Item_Received", eqquantextBox.Text);
            cmd.Parameters.AddWithValue("@Item_Used", equsedtextBox.Text);
            cmd.Parameters.AddWithValue("@Item_Remaining", eqremtextBox.Text);

            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("             <<<INVALID SQL OPERATION>>>: \n" + ex);
            }
            con.Close();

            refresh_DataGridView();
        }
    }
 }