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

namespace Hostel
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
            DisplayStUpdate();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=SKD;Initial Catalog=Hostel;User ID=sa;Password=sujoy24");

        private void DisplayStUpdate()
        {
            Con.Open();
            String Query = "select * from noticetb";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var rt = new DataSet();
            sda.Fill(rt);
            dataGridView1.DataSource = rt.Tables[0];
            Con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stupdate stupdate = new stupdate();
            this.Hide();
            stupdate.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            login login = new login();
            this.Hide();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updatemenu upmenu = new updatemenu();
            this.Hide();
            upmenu.Show();
        }
    }
}
