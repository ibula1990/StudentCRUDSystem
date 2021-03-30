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
    public partial class frmAdminMenu : Form
    {
        SqlConnection conn = new SqlConnection(@"Server=DESKTOP-BLIQA1L\SQLEXPRESS01; Database = StudentCRUDSystem; Trusted_Connection = True;");
        
        public frmAdminMenu()
        {
            InitializeComponent();
        }

        private void btnStudReg_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAdminStudReg f = new frmAdminStudReg();
            f.ShowDialog();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAdminUpdate f = new frmAdminUpdate();
            f.ShowDialog();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAdminViewList f = new frmAdminViewList();
            f.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);

        }
    }
}
