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
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=tempdb;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        public Form1()
        {
            InitializeComponent();
            
            try
            {
                con.Open();
                cmd = new SqlCommand("CREATE TABLE student(roll INT  primary key, name VARCHAR(20),marks int,grade varchar(20))", con);
                cmd.ExecuteScalar();
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
            finally
            {
                con.Close();
            }
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=tempdb;Integrated Security=True");
            //SqlCommand cmd;
            //SqlDataReader dr;
            try
            {
                
                cmd = new SqlCommand("insert into student values(@ro,@na,@ma,@gr)",con);
                cmd.Parameters.Add("@ro", SqlDbType.Int);
                cmd.Parameters.Add("@na", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@ma", SqlDbType.Int);
                cmd.Parameters.Add("@gr", SqlDbType.VarChar, 20);
                cmd.Parameters["@ro"].Value = int.Parse(textBox1.Text);
                cmd.Parameters["@na"].Value = textBox2.Text;
                cmd.Parameters["@ma"].Value = int.Parse(textBox3.Text);
                cmd.Parameters["@gr"].Value = textBox4.Text;
                
                con.Open();
                int nor = cmd.ExecuteNonQuery(); // DML
                if (nor > 0)
                    MessageBox.Show("inserted");
                else
                    MessageBox.Show("Not inserted");
               
                con.Close();

            }
            catch (Exception ex)
            {
               MessageBox.Show("something went wrong.\n" + ex);
                
            }
            finally
            {
                con.Close();
            }
        }
        
    }

}
