using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentCRUDSystem
{
    public partial class frmAdminStudReg : Form
    {
        SqlConnection conn = new SqlConnection(@"Server=DESKTOP-BLIQA1L\SQLEXPRESS01; Database = StudentCRUDSystem; Trusted_Connection = True;");

        public frmAdminStudReg()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AddStudent";

            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@Malayalam", txtMalayalam.Text);
            cmd.Parameters.AddWithValue("@English", txtEnglish.Text);
            cmd.Parameters.AddWithValue("@Hindi", txtHindi.Text);
            cmd.Parameters.AddWithValue("@Status", comboStatus.SelectedItem);
           
            cmd.ExecuteNonQuery();
            conn.Close();


            Random ran = new Random();
            int rannum = ran.Next(1000, 10000);
            

            DialogResult dialogResult = MessageBox.Show("Do you want to save  ?", ProjectTitle.ProjectName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Successfully Saved.", ProjectTitle.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("your Password is:",rannum.ToString());
               
            }

            else
            {
                MessageBox.Show("Invalid Student Information", ProjectTitle.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

           
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void frmAdminStudReg_Load(object sender, EventArgs e)
        {
          //  conn.Open();
            //SqlCommand  cmd= conn.CreateCommand();
            //cmd.CommandType = CommandType.StoredProcedure;
           // cmd.CommandText = "AddStudent";
           // DataTable dt = new DataTable();
            //SqlDataAdapter ad = new SqlDataAdapter(cmd);
            //ad.Fill(dt);
            //dt.Load(cmd.ExecuteReader());
            //foreach (DataRow dr in dt.Rows)
           // {
           //     listBox1.Items.Add(dr["Name"].ToString());
            //     listBox1.Items.Add(dr["Id"].ToString());
            //}
           // cmd.ExecuteNonQuery();
           // conn.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (Control c in panel2.Controls)
            {

                if (c.GetType() == typeof(System.Windows.Forms.TextBox))
                {
                    TextBox temp = (TextBox)c;
                    temp.Text = "";

                }
            }

            foreach (Control c in panel2.Controls)
            {

                if (c.GetType() == typeof(System.Windows.Forms.ComboBox))
                {
                    ComboBox temp = (ComboBox)c;
                    temp.Text = "";

                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex!=-1)
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to Delete this Student  ?", ProjectTitle.ProjectName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dialogResult==DialogResult.Yes)
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "DeleteStudent";
                   
                    SqlDataReader reader = cmd.ExecuteReader();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Student Deleted", ProjectTitle.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    
                }
                else
                {
                    MessageBox.Show("Please Select Student", ProjectTitle.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAdminMenu f = new frmAdminMenu();
            f.ShowDialog();

        }
    }
}

