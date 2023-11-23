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
    public partial class stpayment : Form
    {
        public stpayment()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=SKD;Initial Catalog=Hostel;User ID=sa;Password=sujoy24");

        private void DisplayUpdate()
        {
            Con.Open();
            String Query = "select * from st_pay_info";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var rt = new DataSet();
            sda.Fill(rt);
            payDGV.DataSource = rt.Tables[0];
            Con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" )
            {
                MessageBox.Show("Sorry!!Provide all information");
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("insert into st_pay_info(Student_ID,Amount,Payment,PaymentType) values (@SI,@Amo,@Pay,@Payt)", Con);
                    Con.Open();
                    cmd.Parameters.AddWithValue("@SI", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Amo", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Pay", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@Payt", comboBox2.Text);
                    
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

        private void button1_Click(object sender, EventArgs e)
        {
            Manager m = new Manager();
            this.Hide();
            m.Show();
        }
    }
}
