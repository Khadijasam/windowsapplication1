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
    public partial class Form3 : Form
    {
      
        
        public Form3()
        {
            InitializeComponent();

        }


        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }
        

        
          

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=tempdb;Integrated Security=True");
            SqlCommand cmd;
            SqlDataReader dr;
            cn.Open();
            cmd = new SqlCommand("update  student set roll='" + comboBox1.Text + " ',name='" + textBox1.Text + " ',marks='" + textBox2.Text + " ',grade='" + textBox3.Text + "' where roll='" + comboBox1.Text + "' ", cn);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("updated...");

            }
            catch (Exception)
            {
                MessageBox.Show("Not updated");
            }
            cn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=tempdb;Integrated Security=True");
            SqlCommand cmd;
            SqlDataReader dr;
            cn.Open();
            cmd = new SqlCommand("Delete from student where roll='" + comboBox1.Text + "' ", cn);

            try
            {
                cmd.ExecuteNonQuery();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                MessageBox.Show("Deleted...");

            }
            catch (Exception)
            {
                MessageBox.Show("Not deleted");
            }
            cn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=tempdb;Integrated Security=True");
            SqlCommand cmd;
            SqlDataReader dr;
            try
            {
                cn.Open();
                cmd = new SqlCommand("Select * from student WHERE roll =  '" + comboBox1.Text + "'", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox1.Text = dr["name"].ToString();
                    textBox2.Text = dr["marks"].ToString();
                    textBox3.Text = dr["grade"].ToString();


                }

                cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("something went wrong" + ex);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=tempdb;Integrated Security=True");
            SqlCommand cmd;
            SqlDataReader dr;
            cmd = new SqlCommand("select roll from student", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            comboBox1.Text = "select";
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["roll"]);
            }
            cn.Close();
        }
    }
}
