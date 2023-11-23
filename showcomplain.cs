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
    public partial class showcomplain : Form
    {
        public showcomplain()
        {
            InitializeComponent();
            DisplayUpdate();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=SKD;Initial Catalog=Hostel;User ID=sa;Password=sujoy24");

        private void DisplayUpdate()
        {
            Con.Open();
            String Query = "select * from cmplaintb";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var rt = new DataSet();
            sda.Fill(rt);
            dataGridView1.DataSource = rt.Tables[0];
            Con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Manager m = new Manager();
            this.Hide();
            m.Show();
        }
    }
}
