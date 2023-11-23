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
    public partial class stupdate : Form
    {
        public stupdate()
        {
            InitializeComponent();
            DisplayStUpdate();
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
            StDGV.DataSource = rt.Tables[0];
            Con.Close();
        }

        private void InsertBtn_Click(object sender, EventArgs e)
        {
            if (Nametb.Text == "" || AddressTb.Text == "" || DobDTP.Text == "" || NidTb.Text == "" || MobileTb.Text == "" || RmTb.Text == "")
            {
                MessageBox.Show("Sorry!!Provide all information");
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("insert into student_info(Student_ID,Name,DOB,NID,Address,ContactNo,RoomNo) values (@SI,@SN,@Dob,@Nid,@Add,@Cno,@Rmn)", Con);
                    Con.Open();
                    cmd.Parameters.AddWithValue("@SI", IdTb.Text);
                    cmd.Parameters.AddWithValue("@SN", Nametb.Text);
                    cmd.Parameters.AddWithValue("@Dob", DobDTP.Value.Date);
                    cmd.Parameters.AddWithValue("@Nid", NidTb.Text);
                    cmd.Parameters.AddWithValue("@Add", AddressTb.Text);
                    cmd.Parameters.AddWithValue("@Cno", MobileTb.Text);
                    cmd.Parameters.AddWithValue("@Rmn", RmTb.Text);

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

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" || Nametb.Text == "" || AddressTb.Text == "" || DobDTP.Text == "" || NidTb.Text == "" || MobileTb.Text == "" || RmTb.Text == "")
            {
                MessageBox.Show("Sorry!!Provide all information");
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update student_info set Name = @SN,DOB = @Dob, NID = @Nid, Address = @Add, ContactNo = @Cno, RoomNo = @Rmn where Student_ID=@SI", Con);
                    Con.Open();
                    cmd.Parameters.AddWithValue("@SI", IdTb.Text);
                    cmd.Parameters.AddWithValue("@SN", Nametb.Text);
                    cmd.Parameters.AddWithValue("@Dob", DobDTP.Value.Date);
                    cmd.Parameters.AddWithValue("@Nid", NidTb.Text);
                    cmd.Parameters.AddWithValue("@Add", AddressTb.Text);
                    cmd.Parameters.AddWithValue("@Cno", MobileTb.Text);
                    cmd.Parameters.AddWithValue("@Rmn", RmTb.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Employee Update SuccessFUlly");
                    Con.Close();
                    DisplayStUpdate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "")
            {
                MessageBox.Show("Sorry!!Provide all information");
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("delete student_info where Student_ID=@SI", Con);
                    Con.Open();
                    cmd.Parameters.AddWithValue("@SI", IdTb.Text);
                    cmd.Parameters.AddWithValue("@SN", Nametb.Text);
                    cmd.Parameters.AddWithValue("@Dob", DobDTP.Value.Date);
                    cmd.Parameters.AddWithValue("@Nid", NidTb.Text);
                    cmd.Parameters.AddWithValue("@Add", AddressTb.Text);
                    cmd.Parameters.AddWithValue("@Cno", MobileTb.Text);
                    cmd.Parameters.AddWithValue("@Rmn", RmTb.Text);

                    cmd.ExecuteNonQuery();

                    Con.Close();
                    DisplayStUpdate();
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
                MessageBox.Show("Probide ID");
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from student_info where Student_ID=@SI", Con);
                    Con.Open();
                    cmd.Parameters.AddWithValue("@SI", IdTb.Text);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    StDGV.DataSource = dt;
                    Con.Close();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            this.Hide();
            emp.Show();
        }
    }
}
