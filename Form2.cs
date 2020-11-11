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


namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=tempdb;Integrated Security=True");
        SqlCommand cmd;
        SqlCommand cmod;
        SqlDataReader dr;
        DataTable dt = new DataTable();
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM student", con);
                Int32 count = (Int32)cmd.ExecuteScalar();
                
                //MessageBox.Show(count.ToString());
                cmd = new SqlCommand("insert into student values(@ro,'@na',@ma,'@gr')", con);
                cmd.Parameters.Add("@ro", SqlDbType.Int);
                if (count==0)
                {
                    int i= 1000;
                    
                    textBox1.Text = i.ToString();
                    cmd.Parameters["@ro"].Value = int.Parse(textBox1.Text);
                }
                else
                {

                    cmd = new SqlCommand("Select Max(roll)+1 from student", con);
                    Int32 roll = (Int32)cmd.ExecuteScalar();
                    textBox1.Text = roll.ToString();
                    cmd.Parameters["@ro"].Value = int.Parse(textBox1.Text);
                }
                cmd.Parameters.Add("@na", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@ma", SqlDbType.Int);
                cmd.Parameters.Add("@gr", SqlDbType.VarChar, 20);
                cmd.Parameters["@na"].Value = textBox2.Text;
                cmd.Parameters["@ma"].Value = int.Parse(textBox3.Text);
                cmd.Parameters["@gr"].Value = textBox4.Text;

                //{
                //    textBox1.Text = "1000";
                //    cmd.Parameters.Add("@ro", SqlDbType.Int).Value=int.Parse(textBox1.Text);
                //}
                //else
                //{
                //    textBox1.Text = "max(@ro)+1";
                //    cmd.Parameters.Add("@ro", SqlDbType.Int).Value = int.Parse(textBox1.Text);
                //}
                ////cmd.Parameters.AddWithValue("@ro", textBox1.Text);
                //cmd.Parameters.AddWithValue("@na", textBox2.Text);
                //cmd.Parameters.AddWithValue("@ma", int.Parse(textBox3.Text));
                //cmd.Parameters.AddWithValue("@gr", textBox4.Text);
                int nor = cmd.ExecuteNonQuery(); // DML
                if (nor > 0)
                    MessageBox.Show("inserted");
                else
                    MessageBox.Show("Not inserted");

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("something went wrong" + ex);
            }
        }
    }
}
