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
    public partial class frmAdminUpdate : Form
    {
        SqlConnection conn = new SqlConnection(@"Server=DESKTOP-BLIQA1L\SQLEXPRESS01; Database = StudentCRUDSystem; Trusted_Connection = True;");

        public frmAdminUpdate()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdateStudent";
            cmd.Parameters.AddWithValue("@ID", txtUpId.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            
            if (dr.Read())
            {
                txtUpName.Text = dr["Name"].ToString();
                txtUpPhone.Text = dr["Phone"].ToString();
                txtUpEmail.Text = dr["Email"].ToString();
                txtUpMalayalam.Text = dr["Malayalam"].ToString();
                txtUpEnglish.Text = dr["English"].ToString();
                txtUpHindi.Text = dr["Hindi"].ToString();
                txtUpStatus.Text = dr["Status"].ToString();

               
                conn.Close();
                dr.Close();
            }
            else
            {
                MessageBox.Show("Record not found!!!");
            }
           

        }

        private void txtUpHindi_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAdminMenu f = new frmAdminMenu();
            f.ShowDialog();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdateStudent";
            cmd.Parameters.AddWithValue("@Name", txtUpName.Text);
            cmd.Parameters.AddWithValue("@Phone", txtUpPhone.Text);
            cmd.Parameters.AddWithValue("@Email", txtUpEmail.Text);
            cmd.Parameters.AddWithValue("@Malayalam", txtUpMalayalam.Text);
            cmd.Parameters.AddWithValue("@English", txtUpEnglish.Text);
            cmd.Parameters.AddWithValue("@Hindi", txtUpHindi.Text);
            cmd.Parameters.AddWithValue("@Status", txtUpStatus.Text);
            cmd.ExecuteNonQuery();
            conn.Close();


        }
    }
}
