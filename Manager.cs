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
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=SKD;Initial Catalog=Hostel;User ID=sa;Password=sujoy24");

        private void DisplayStUpdate()
        {
            Con.Open();
            String Query = "select * from student_info";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var rt = new DataSet();
            sda.Fill(rt);
            //StDGV.DataSource = rt.Tables[0];
            Con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            empupdate empup = new empupdate();
            this.Hide();
            empup.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showstinfocs stinfo = new showstinfocs();
            this.Hide();
            stinfo.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            stpayment stpay = new stpayment();
            this.Hide();
            stpay.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            showcomplain showcomplain = new showcomplain();
            this.Hide();
            showcomplain.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            hostelexpense htlexp = new hostelexpense();
            this.Hide();
            htlexp.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            login login = new login();
            this.Hide();
            login.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("Sorry!!Provide all information");
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("insert into noticetb(notice) values (@not)", Con);
                    Con.Open();
                    cmd.Parameters.AddWithValue("@not", richTextBox1.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Student Added SuccessFUlly");
                    Con.Close();
                    DisplayStUpdate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
