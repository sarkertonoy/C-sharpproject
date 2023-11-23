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
    public partial class complainbox : Form
    {
        public complainbox()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=SKD;Initial Catalog=Hostel;User ID=sa;Password=sujoy24");

        private void button2_Click(object sender, EventArgs e)
        {
            Student st = new Student();
            this.Hide();
            st.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Sorry!!Provide all information");
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("insert into cmplaintb (Student_ID, CompainBox) values (@SI,@CB)", Con);
                    Con.Open();
                    cmd.Parameters.AddWithValue("@CB", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@SI", textBox1.Text);                    

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Compaint Added Successfully.","Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    Con.Close();
                    
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
