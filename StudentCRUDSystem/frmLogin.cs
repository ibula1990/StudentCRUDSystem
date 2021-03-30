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
    public partial class frmLogin : Form
    {
        
        SqlConnection conn = new SqlConnection(@"Server=DESKTOP-BLIQA1L\SQLEXPRESS01; Database = StudentCRUDSystem; Trusted_Connection = True;");
        
        public frmLogin()
        {
            

            InitializeComponent();
           
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "admin" && txtPassword.Text == "1111")
            {
                this.Hide();
                frmAdminMenu f = new frmAdminMenu();
                f.ShowDialog();
            }
            else
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "StudentLogin";
                cmd.Parameters.AddWithValue("@Email", txtUserName.Text);
                //cmd.Parameters.AddWithValue("rannum",txtPassword.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                this.Hide();
                frmStudUpdate_View f = new frmStudUpdate_View();
                f.ShowDialog();
            }
        }
    }
}
