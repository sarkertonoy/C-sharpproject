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
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
            DisplayStUpdate();
            DisplayfoodUpdate();
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

        private void DisplayfoodUpdate()
        {
            Con.Open();
            String Query = "select * from foodtb";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var rt = new DataSet();
            sda.Fill(rt);
            dataGridView2.DataSource = rt.Tables[0];
            Con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            login login = new login();
            this.Hide();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            complainbox cmpl = new complainbox();
            this.Hide();
            cmpl.Show();
        }

        private void Student_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            this.Hide();
            emp.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            complainbox cmp = new complainbox();
            this.Hide();
            cmp.Show();
        }
    }
}
