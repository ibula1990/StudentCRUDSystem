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
    public partial class frmStudUpdate_View : Form
    {
        SqlConnection conn = new SqlConnection(@"Server=DESKTOP-BLIQA1L\SQLEXPRESS01; Database = StudentCRUDSystem; Trusted_Connection = True;");
        
        public frmStudUpdate_View()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            panelUpdate.Show();
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdateStudent";
            cmd.Parameters.AddWithValue("@ID", txtStudUPId);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                txtStudUpName.Text = dr["Name"].ToString();
                txtStudUpPhone.Text = dr["Phone"].ToString();
                txtStudUpEmail.Text = dr["Email"].ToString();
                //cmd.ExecuteNonQuery();

               
                dr.Close();

                conn.Close();

            }



        }

        private void frmStudUpdate_View_Load(object sender, EventArgs e)
        {
            dataGridViewStudView.Hide();
            panelUpdate.Hide();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            dataGridViewStudView.Show();
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ViewStudent";
            cmd.Parameters.AddWithValue("@ID", txtStudUPId.Text);

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            adapter.Fill(dt);
            dataGridViewStudView.DataSource = dt;
            

        }
    }
}
