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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=SKD;Initial Catalog=Hostel;User ID=sa;Password=sujoy24");

            string query = "Select * from login_tab where Username='" + textBox1.Text.Trim() + "' and Password = '" + textBox2.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlCon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            

            if (dtbl.Rows.Count>0)
            {
                
                if(comboBox1.SelectedItem == "Manager")
                {
                    Manager m = new Manager();
                    this.Hide();
                    m.Show();
                }
                else if(comboBox1.SelectedItem == "Employee")
                {
                    Employee emp = new Employee();
                    this.Hide();
                    emp.Show();
                }
                else
                {
                    Student st = new Student();
                    this.Hide();
                    st.Show();
                }
                    
                
            }
            else
            {
                MessageBox.Show ("Error!!");
            }

        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
