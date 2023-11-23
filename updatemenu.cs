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
    public partial class updatemenu : Form
    {
        public updatemenu()
        {
            InitializeComponent();
            DisplayStUpdate();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=SKD;Initial Catalog=Hostel;User ID=sa;Password=sujoy24");

        private void DisplayStUpdate()
        {
            Con.Open();
            String Query = "select * from foodtb";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var rt = new DataSet();
            sda.Fill(rt);
            foodDGV.DataSource = rt.Tables[0];
            Con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Text == "" || textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Sorry!!Provide all information");
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("insert into foodtb(Date,Morning,Noon,Night) values (@date,@M,@Noon,@n)", Con);
                    Con.Open();
                    cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@M", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Noon", textBox2.Text);
                    cmd.Parameters.AddWithValue("@n", textBox3.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Food Added SuccessFUlly");
                    Con.Close();
                    DisplayStUpdate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            this.Hide();
            emp.Show();
        }
    }
}
