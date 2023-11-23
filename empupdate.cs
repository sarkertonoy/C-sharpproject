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
    public partial class empupdate : Form
    {
        public empupdate()
        {
            InitializeComponent();
            DisplayEmpUpdate();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=SKD;Initial Catalog=Hostel;User ID=sa;Password=sujoy24");

        private void DisplayEmpUpdate()
        {
            Con.Open();
            String Query = "select * from emp_info";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var rt = new DataSet();
            sda.Fill(rt);
            EmpDGV.DataSource = rt.Tables[0];
            Con.Close();
        }


        private void InsertBtn_Click(object sender, EventArgs e)
        {
            if(Nametb.Text == "" || AddressTb.Text == "" || DobDTP.Text == "" || NidTb.Text == "" || MobileTb.Text == "" || SalaryTb.Text == "")
            {
                MessageBox.Show("Sorry!!Provide all information");
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("insert into emp_info(EMP_ID,Name,DOB,NID,Adress,ContactNo,Salary) values (@DI,@DN,@Dob,@Nid,@Add,@Cno,@sal)", Con);
                    Con.Open();
                    cmd.Parameters.AddWithValue("@DI", IdTb.Text);
                    cmd.Parameters.AddWithValue("@DN", Nametb.Text);
                    cmd.Parameters.AddWithValue("@Dob", DobDTP.Value.Date);
                    cmd.Parameters.AddWithValue("@Nid", NidTb.Text);
                    cmd.Parameters.AddWithValue("@Add", AddressTb.Text);
                    cmd.Parameters.AddWithValue("@Cno", MobileTb.Text);
                    cmd.Parameters.AddWithValue("@sal", SalaryTb.Text);
                    
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Doctor Added SuccessFUlly");
                    Con.Close();
                    DisplayEmpUpdate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" || Nametb.Text == "" || AddressTb.Text == "" || DobDTP.Text == "" || NidTb.Text == "" || MobileTb.Text == "" || SalaryTb.Text == "")
            {
                MessageBox.Show("Sorry!!Provide all information");
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update emp_info set Name = @DN,DOB = @Dob, NID = @Nid, Adress = @Add, ContactNo = @Cno, Salary = @sal where EMP_ID=@DI", Con);
                    Con.Open();
                    cmd.Parameters.AddWithValue("@DI", IdTb.Text);
                    cmd.Parameters.AddWithValue("@DN", Nametb.Text);
                    cmd.Parameters.AddWithValue("@Dob", DobDTP.Value.Date);
                    cmd.Parameters.AddWithValue("@Nid", NidTb.Text);
                    cmd.Parameters.AddWithValue("@Add", AddressTb.Text);
                    cmd.Parameters.AddWithValue("@Cno", MobileTb.Text);
                    cmd.Parameters.AddWithValue("@sal", SalaryTb.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Employee Update SuccessFUlly");
                    Con.Close();
                    DisplayEmpUpdate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" )
            {
                MessageBox.Show("Sorry!!Provide all information");
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("delete emp_info where EMP_ID=@DI", Con);
                    Con.Open();
                    cmd.Parameters.AddWithValue("@DI", IdTb.Text);
                    cmd.Parameters.AddWithValue("@DN", Nametb.Text);
                    cmd.Parameters.AddWithValue("@Dob", DobDTP.Value.Date);
                    cmd.Parameters.AddWithValue("@Nid", NidTb.Text);
                    cmd.Parameters.AddWithValue("@Add", AddressTb.Text);
                    cmd.Parameters.AddWithValue("@Cno", MobileTb.Text);
                    cmd.Parameters.AddWithValue("@sal", SalaryTb.Text);

                    cmd.ExecuteNonQuery();

                    Con.Close();
                    DisplayEmpUpdate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "")
            {
                MessageBox.Show("Probide id");
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from emp_info where EMP_ID=@DI", Con);
                    Con.Open();
                    cmd.Parameters.AddWithValue("@DI", IdTb.Text);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    EmpDGV.DataSource = dt;
                    Con.Close();
                   
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void MobileTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void AddressTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void NidTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Nametb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SalaryTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void EmpDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void IdTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void DobDTP_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manager m = new Manager();
            this.Hide();
            m.Show();
        }
    }
}
