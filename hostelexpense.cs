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
    public partial class hostelexpense : Form
    {
        public hostelexpense()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=SKD;Initial Catalog=Hostel;User ID=sa;Password=sujoy24");

        private void DisplayUpdate()
        {
            Con.Open();
            String Query = "select * from ht_ExpTb";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var rt = new DataSet();
            sda.Fill(rt);
            expDGV.DataSource = rt.Tables[0];
            Con.Close();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "" || textBox2.Text == "" || dateTimePicker1.Text == "")
            {
                MessageBox.Show("Sorry!!Provide all information");
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("insert into ht_ExpTb(Statement, Date, Amount) values (@St,@date,@Amo)", Con);
                    Con.Open();
                    cmd.Parameters.AddWithValue("@St", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@Amo", textBox2.Text);
                    cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data Added SuccessFully");
                    Con.Close();
                    DisplayUpdate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            Manager m = new Manager();
            this.Hide();
            m.Show();
        }
    }
}
