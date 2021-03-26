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
            cmd.Parameters.AddWithValue("@Id", txtUpId.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                txtUpName.Text = dr.GetValue(1).ToString();
                txtUpPhone.Text = dr.GetValue(2).ToString();
                txtUpEmail.Text = dr.GetValue(3).ToString();
                txtUpMalayalam.Text = dr.GetValue(4).ToString();
                txtUpEnglish.Text = dr.GetValue(5).ToString();
                txtUpHindi.Text = dr.GetValue(6).ToString();
                txtUpStatus.Text = dr.GetValue(7).ToString();

            }
            else
            {
                MessageBox.Show("Record not found!!!");
            }
            cmd.ExecuteNonQuery();
            conn.Close();

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
    }
}
