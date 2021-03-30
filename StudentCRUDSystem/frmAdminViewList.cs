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
    public partial class frmAdminViewList : Form
    {
        SqlConnection conn = new SqlConnection(@"Server=DESKTOP-BLIQA1L\SQLEXPRESS01; Database = StudentCRUDSystem; Trusted_Connection = True;");

        public frmAdminViewList()
        {
            InitializeComponent();
        }

        private void frmAdminViewList_Load(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ListStudent";
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAdminMenu f = new frmAdminMenu();
            f.ShowDialog();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
